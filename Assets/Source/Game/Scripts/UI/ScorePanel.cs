using System;
using UnityEngine;
using Agava.YandexGames;
using Constants;
using GameLogic;
using Lean.Localization;
using Wanderer;

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

        private int _score;
        private int _value;

        public event Action<int> ScoreChanged;

        public int Value => _value;

        private void Start()
        {
            HideResult();

            LoadScore();
            ScoreChanged?.Invoke(_score);
        }

        public void ShowResult()
        {
            _value = GetScore();

            for (int i = 0; i < _value; i++)
            {
                _indicators[i].gameObject.SetActive(true);
            }

            IncreaseTotalScore(_value);

            SetScore();
        }

        public void SetScore()
        {
            SaveScore(_score);
            SaveLeaderboardScore(_score);
        }

        public void HideResult()
        {
            foreach (var indicator in _indicators)
            {
                if (indicator.gameObject.activeSelf)
                    indicator.Disappear();
            }
        }

        private void IncreaseTotalScore(int value)
        {
            _score += value;

            ScoreChanged?.Invoke(_score);
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

        private void LoadScore()
        {
            if (UnityEngine.PlayerPrefs.HasKey(PlayerSettings.Score))
            {
                _score = UnityEngine.PlayerPrefs.GetInt(PlayerSettings.Score);
            }
        }

        private void SaveScore(int value)
        {
            UnityEngine.PlayerPrefs.SetInt(PlayerSettings.Score, value);
            UnityEngine.PlayerPrefs.Save();
        }

        private void SaveLeaderboardScore(int value)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (PlayerAccount.IsAuthorized)
            {
                Leaderboard.GetPlayerEntry(StaticVariables.LeaderboardName, response =>
                {
                    Leaderboard.SetScore(StaticVariables.LeaderboardName, value);
                });
            }
#endif
        }
    }
}