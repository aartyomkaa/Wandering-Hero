using Agava.YandexGames;
using UnityEngine;
using Constants;

namespace UI
{
    internal class LeaderboardView : MonoBehaviour
    {
        private const int MaxPlayers = 5;

        [SerializeField] private LeaderboardPanel _leaderboardPanel;

        public void Init()
        {
            ClearViews();

            LoadData();
        }

        private void LoadData()
        {
            _leaderboardPanel.Open();

            LoadEntries();
            LoadPlayerEntry();
        }

        private void LoadPlayerEntry()
        {
            Leaderboard.GetEntries(StaticVariables.LeaderboardName, (result) =>
            {
                foreach (var entry in result.entries)
                {
                    _leaderboardPanel.Create(entry);
                }
            }, null, MaxPlayers);
        }

        private void LoadEntries()
        {
            Leaderboard.GetEntries(StaticVariables.LeaderboardName, (result) =>
            {
                foreach (var entry in result.entries)
                {
                    _leaderboardPanel.Create(entry);
                }
            }, null, MaxPlayers);
        }

        private void ClearViews()
        {
            _leaderboardPanel.Clear();
        }
    }
}