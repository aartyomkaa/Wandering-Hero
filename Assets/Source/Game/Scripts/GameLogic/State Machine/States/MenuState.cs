<<<<<<< HEAD
using UnityEngine;
using Agava.YandexGames;
using UI;
=======
using Agava.YandexGames;
using UI;
using UnityEngine;
>>>>>>> NewPatch

namespace GameLogic
{
    internal class MenuState : State
    {
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private LeaderboardScreen _leaderboardScreen;
        [SerializeField] private LeaderboardPanel _leaderboardPanel;
        [SerializeField] private LoginPanel _loginPanel;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private Map _map;

        private void OnEnable()
        {
            Init();

<<<<<<< HEAD
            _menuScreen.PlayButtonPressed += OnPlay;
            _menuScreen.SettingsButtonPressed += OnSettingsOpen;
            _menuScreen.LeaderboardButtonPressed += OnLeaderboardOpen;
=======
            _shopScreen.CloseButtonPressed += OnShopClose;

            _menuScreen.Play += OnPlay;
            _menuScreen.Settings += OnSettingsOpen;
            _menuScreen.Leaderboard += OnLeaderboardOpen;
            _menuScreen.Shop += OnShopOpen;
>>>>>>> NewPatch

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
<<<<<<< HEAD
            _menuScreen.PlayButtonPressed -= OnPlay;
            _menuScreen.SettingsButtonPressed -= OnSettingsOpen;
            _menuScreen.LeaderboardButtonPressed -= OnLeaderboardOpen;
=======
            _shopScreen.CloseButtonPressed -= OnShopClose;

            _menuScreen.Play -= OnPlay;
            _menuScreen.Settings -= OnSettingsOpen;
            _menuScreen.Leaderboard -= OnLeaderboardOpen;
            _menuScreen.Shop -= OnShopOpen;
>>>>>>> NewPatch

            _settingsScreen.Closed -= OnSettingsClose;

            _leaderboardPanel.Closed -= OnLeaderboardClose;
            _loginPanel.DeclineButtonPressed -= OnLeaderboardClose;
            _loginPanel.AcceptButtonPressed -= OnLeaderboardClose;
        }

        private void OnSettingsOpen()
        {
            _settingsScreen.Open();
        }

        private void OnPlay()
        {
            _map.Reset();
        }

        private void OnSettingsClose()
        {
            _settingsScreen.Close();
        }

        private void OnLeaderboardOpen()
        {
            _leaderboardScreen.Open();
        }

        private void OnLeaderboardClose()
        {
            _leaderboardScreen.Close();
        }

        private void OnShopOpen()
        {
            _shopScreen.Open();
        }

        private void OnShopClose()
        {
            _shopScreen.Close();
        }

        private void Init()
        {
            Time.timeScale = 0f;
            _menuScreen.Open();
        }
    }
}