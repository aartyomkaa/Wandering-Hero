using UnityEngine;
using UI;

namespace GameLogic
{
    internal class MenuState : State
    {
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private LeaderboardScreen _leaderboardScreen;
        [SerializeField] private LeaderboardPanel _leaderboardPanel;
        [SerializeField] private LoginPanel _loginPanel;
        [SerializeField] private Map _map;

        private void OnEnable()
        {
            Init();

            _menuScreen.Play += OnPlay;
            _menuScreen.Settings += OnSettingsOpen;
            _menuScreen.Leaderboard += OnLeaderboardOpen;

            _settingsScreen.CloseScreen += OnSettingsClose;
            _settingsScreen.OnLevelChange += OnLevelChange;

            _leaderboardPanel.Closed += OnLeaderboardClose;
            _loginPanel.Decline += OnLeaderboardClose;
        }

        private void OnDisable()
        {
            _menuScreen.Play -= OnPlay;
            _menuScreen.Settings -= OnSettingsOpen;
            _menuScreen.Leaderboard -= OnLeaderboardOpen;

            _settingsScreen.CloseScreen -= OnSettingsClose;
            _settingsScreen.OnLevelChange -= OnLevelChange;

            _leaderboardPanel.Closed -= OnLeaderboardClose;
            _loginPanel.Decline -= OnLeaderboardClose;
        }

        private void OnSettingsOpen()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _menuScreen.Close();
            _settingsScreen.Open();
        }

        private void OnPlay()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _menuScreen.Close();
            _map.Reset();
        }

        private void OnSettingsClose()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _settingsScreen.Close();
            _menuScreen.Open();
        }

        private void OnLevelChange(int level)
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _map.SetLevel(level);
        }

        private void OnLeaderboardOpen()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _menuScreen.Close();
            _leaderboardScreen.Open();
        }

        private void OnLeaderboardClose()
        {
            _menuScreen.Open();
            _leaderboardScreen.Close();
        }

        private void Init()
        {
            Time.timeScale = 0f;
            _menuScreen.Open();
        }
    }
}