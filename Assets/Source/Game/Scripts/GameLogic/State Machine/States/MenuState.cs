using UnityEngine;
using Agava.YandexGames;
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

            _menuScreen.PlayButtonPressed += OnPlay;
            _menuScreen.SettingsButtonPressed += OnSettingsOpen;
            _menuScreen.LeaderboardButtonPressed += OnLeaderboardOpen;

            _settingsScreen.Closed += OnSettingsClose;

            _leaderboardPanel.Closed += OnLeaderboardClose;
            _loginPanel.DeclineButtonPressed += OnLeaderboardClose;
            _loginPanel.AcceptButtonPressed += OnLeaderboardClose;
        }

        private void Awake()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            YandexGamesSdk.GameReady();
#endif
        }

        private void OnDisable()
        {
            _menuScreen.PlayButtonPressed -= OnPlay;
            _menuScreen.SettingsButtonPressed -= OnSettingsOpen;
            _menuScreen.LeaderboardButtonPressed -= OnLeaderboardOpen;

            _settingsScreen.Closed -= OnSettingsClose;

            _leaderboardPanel.Closed -= OnLeaderboardClose;
            _loginPanel.DeclineButtonPressed -= OnLeaderboardClose;
            _loginPanel.AcceptButtonPressed -= OnLeaderboardClose;
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