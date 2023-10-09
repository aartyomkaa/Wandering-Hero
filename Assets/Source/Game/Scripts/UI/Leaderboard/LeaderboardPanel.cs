using Agava.YandexGames;
using Constants;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace UI
{
    internal class LeaderboardPanel : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private LeaderboardView _leaderboardView;

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
                foreach (var entry in result.entries)
                {
                    _leaderboardView.Create(entry);
                }
            });
        }

        private void ClearViews()
        {
            _leaderboardView.Clear();
        }

        private void OnClose()
        {
            Audio.AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            Closed?.Invoke();

            Close();
        }
    }
}