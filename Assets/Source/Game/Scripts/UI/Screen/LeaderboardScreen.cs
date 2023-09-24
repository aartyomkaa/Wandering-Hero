using Agava.YandexGames;
using UnityEngine;

namespace UI
{
    public class LeaderboardScreen : Screen
    {
        [SerializeField] private LoginPanel _logInPanel;
        [SerializeField] private LeaderboardView _leaderboardView;

        public override void Open()
        {
            base.Open();

            if (PlayerAccount.IsAuthorized)
            {
                PlayerAccount.RequestPersonalProfileDataPermission();

                _leaderboardView.Init();
            }
            else
            {
                _logInPanel.Open();
            }
        }
    }
}