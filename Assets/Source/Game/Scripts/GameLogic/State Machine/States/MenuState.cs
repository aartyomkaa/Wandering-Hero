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
            _loginPanel.Accept += OnLeaderboardClose;
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
            _loginPanel.Accept -= OnLeaderboardClose;
        }

        private void OnSettingsOpen()
        {
            _menuScreen.Close();
            _settingsScreen.Open();
        }

        private void OnPlay()
        {
            _menuScreen.Close();
            _map.Reset();
        }

        private void OnSettingsClose()
        {
            _settingsScreen.Close();
            _menuScreen.Open();
        }

        private void OnLevelChange(int level)
        {
            _map.SetLevel(level);
        }

        private void OnLeaderboardOpen()
        {
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