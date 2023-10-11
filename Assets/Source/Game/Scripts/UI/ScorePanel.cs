using UnityEngine;
using GameLogic;
using Wanderer;
using Constants;
using Agava.YandexGames;
using Lean.Localization;

namespace UI
{
    internal class ScorePanel : MonoBehaviour
    {
        [SerializeField] private Map _map;
        [SerializeField] private PlayerAttacker _playerAttacker;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerInteractor _playerInteractor;
        [SerializeField] private RoadBuilder _roadBuilder;
        [SerializeField] private LeanLocalizedText _localization;
        [SerializeField] private Indicator[] _indicators;

        private static int _value;

        public int Value => _value;

        private void OnEnable()
        {
            HideResult();
        }

        public void ShowResult()
        {
            _value = GetScore();

            for (int i = 0; i < _value; i++)
            {
                _indicators[i].gameObject.SetActive(true);
            }

#if UNITY_WEBGL && !UNITY_EDITOR
            SaveScore(_value);
#endif
        }

        public void HideResult()
        {
            foreach (var indicator in _indicators)
            {
                if (indicator.gameObject.activeSelf)
                    indicator.Disappear();
            }
        }

        private void SaveScore(int value)
        {
            Leaderboard.GetPlayerEntry(StaticVariables.LeaderboardName, response =>
            {
                if (response != null)
                {
                    Leaderboard.SetScore(StaticVariables.LeaderboardName, response.score += value);

                    PlayerPrefs.SetInt(PlayerSettings.Record, response.score);
                    PlayerPrefs.Save();
                }
            });
        }

        private int GetScore()
        {
            int value = 1;
            _localization.TranslationName = StaticVariables.VictoryText;

            if (_map.BattleAmount == _playerAttacker.EnemiesDefeated)
                value++;

            if (_playerInteractor.HasStar)
                value++;

            if (_playerHealth.Health == 0)
            {
                value = 0;
                _localization.TranslationName = StaticVariables.LoseText;
            }

            if (_roadBuilder.HasStuck)
            {
                value = 0;
                _localization.TranslationName = StaticVariables.LostText;
            }

            return value;
        }
    }
}