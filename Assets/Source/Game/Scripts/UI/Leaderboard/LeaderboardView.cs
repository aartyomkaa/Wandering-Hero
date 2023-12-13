using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine;
using Agava.YandexGames;
=======
using Agava.YandexGames;
using UnityEngine;
>>>>>>> NewPatch

namespace UI
{
    internal class LeaderboardView : MonoBehaviour
    {
        private readonly List<LeaderboardEntryView> _leaderboardEntryViews = new ();
<<<<<<< HEAD

        [SerializeField] private LeaderboardEntryView _playerViewTemplate;

=======
        
        [SerializeField] private LeaderboardEntryView _playerViewTemplate;

>>>>>>> NewPatch
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