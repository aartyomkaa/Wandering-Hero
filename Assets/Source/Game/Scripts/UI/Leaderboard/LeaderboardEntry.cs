using Agava.YandexGames;
using UnityEngine.UI;

namespace UI
{
    internal class LeaderboardEntry
    {
        private const string Anonymous = "Anonymous";

        public string Name { get; private set; }
        public string Score { get; private set; }
        public string Rank { get; private set; }
        public string Picture { get; private set; }

        public LeaderboardEntry(LeaderboardEntryResponse entry)
        {
            if (entry == null)
                return;

            SetName(entry.player.publicName);
            Score = entry.score.ToString();
            Rank = entry.rank.ToString();
            Picture = entry.player.profilePicture;
        }

        private void SetName(string name)
        {
            Name = name;

            if (string.IsNullOrEmpty(Name))
                Name = Anonymous;
        }
    }
}