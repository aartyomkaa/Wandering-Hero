using UnityEngine;
using GameLogic;
using Player;
using Constants;
using Agava.YandexGames;

namespace UI
{
    internal class Score : MonoBehaviour
    {
        private const string LeaderboardName = "leader";

        [SerializeField] private Map _map;
        [SerializeField] private Wanderer _wanderer;
        [SerializeField] private Indicator[] _indicators;

        private static int _value;

        public int Value => _value;

        private void OnEnable()
        {
            HideResult();
        }

        public void ShowResult()
        {
            _value = 1;

            if (_map.BattleAmount == _wanderer.EnemiesDefeated)
                _value++;

            if (_wanderer.HasStar)
                _value++;

            if (_wanderer.Health == 0)
                _value = 0;

            for (int i = 0; i < _value; i++)
            {
                _indicators[i].gameObject.SetActive(true);
            }

            SaveScore(_value);
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
            Leaderboard.GetPlayerEntry(LeaderboardName, response =>
            {
                if (response != null)
                {
                    Leaderboard.SetScore(LeaderboardName, response.score += value);

                    PlayerPrefs.SetInt(PlayerPrefsConstants.Record, response.score);
                    PlayerPrefs.Save();
                }
            });
        }
    }
}