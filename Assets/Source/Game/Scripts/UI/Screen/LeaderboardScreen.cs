using Agava.YandexGames;
using UnityEngine;

namespace UI
{
    internal class LeaderboardScreen : Screen
    {
        [SerializeField] private LoginPanel _logInPanel;
        [SerializeField] private LeaderboardPanel _leaderboardPanel;

        public override void Open()
        {
            base.Open();

            if (PlayerAccount.IsAuthorized)
            {
                PlayerAccount.RequestPersonalProfileDataPermission();

                _leaderboardPanel.Init();
            }
            else
            {
                _logInPanel.Open();
            }
        }
    }
}