using Agava.YandexGames;
using Lean.Localization;
using UnityEngine.UI;

namespace UI
{
    internal class LeaderboardEntry
    {
        private const string AnonymousEn = "Anonymous";
        private const string AnonymousRu = "Аноним";
        private const string AnonymousTr = "İsimsiz";

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
            string anon = AnonymousEn;

            Name = name;

            if (YandexGamesSdk.Environment.i18n.lang == "ru")
            {
                anon = AnonymousRu;
            }
            else if (YandexGamesSdk.Environment.i18n.lang == "tr")
            {
                anon = AnonymousTr;
            }

            if (string.IsNullOrEmpty(Name))
                Name = anon;
        }
    }
}