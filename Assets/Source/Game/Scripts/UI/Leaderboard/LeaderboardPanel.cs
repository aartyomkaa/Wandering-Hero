using Agava.YandexGames;
using Constants;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class LeaderboardPanel : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private LeaderboardView _leaderboardView;

        private int _topPlayers = 5;

        public Action Closed;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
        }

        public void Init()
        {
            Open();

            ClearViews();

            LoadEntries();
        }

        private void LoadEntries()
        {
            Leaderboard.GetEntries(StaticVariables.LeaderboardName, (result) =>
            {
                for (int i = 0; i < _topPlayers; i++)
                {
                    _leaderboardView.Create(result.entries[i]);
                }
            });
        }

        private void ClearViews()
        {
            _leaderboardView.Clear();
        }

        private void OnClose()
        {
            ButtonAudio.Play();
            Closed?.Invoke();
        }
    }
}