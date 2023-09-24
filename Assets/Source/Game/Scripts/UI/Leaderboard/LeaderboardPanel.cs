using Agava.YandexGames;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class LeaderboardPanel : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private LeaderboardEntryView _playerViewTemplate;

        private readonly List<LeaderboardEntryView> _leaderboardEntryViews = new();

        public Action Closed;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
        }

        public void Create(LeaderboardEntryResponse entry)
        {
            LeaderboardEntryView view = Instantiate(_playerViewTemplate, transform);
            view.SetData(new LeaderboardEntry(entry));
            _leaderboardEntryViews.Add(view);
        }

        public void Clear()
        {
            foreach (var entry in _leaderboardEntryViews)
                Destroy(entry.gameObject);

            _leaderboardEntryViews.Clear();
        }

        private void OnClose()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            Closed?.Invoke();

            Close();
        }
    }
}