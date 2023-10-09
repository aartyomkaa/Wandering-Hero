using Agava.YandexGames;
using UnityEngine;
using System.Collections.Generic;

namespace UI
{
    internal class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private LeaderboardEntryView _playerViewTemplate;

        private readonly List<LeaderboardEntryView> _leaderboardEntryViews = new();

        public void Create(LeaderboardEntryResponse entry)
        {
            LeaderboardEntryView view = Instantiate(_playerViewTemplate, transform);
            view.SetData(entry);
            _leaderboardEntryViews.Add(view);
        }

        public void Clear()
        {
            foreach (var entry in _leaderboardEntryViews)
                Destroy(entry.gameObject);

            _leaderboardEntryViews.Clear();
        }
    }
}