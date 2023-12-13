using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class MenuScreen : Screen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private Button _shopButton;

<<<<<<< HEAD
        public event Action PlayButtonPressed;

        public event Action SettingsButtonPressed;

        public event Action LeaderboardButtonPressed;
=======
        public event Action Play;
        public event Action Shop;
        public event Action Settings;
        public event Action Leaderboard;
>>>>>>> NewPatch

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _shopButton.onClick.AddListener(OnShopButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _leaderboardButton.onClick.AddListener(OnLeaderboardButtonClick);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _shopButton.onClick.RemoveListener(OnShopButtonClick);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
            _leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonClick);
        }

        private void OnPlayButtonClick()
        {
            ButtonAudio.Play();
<<<<<<< HEAD
            PlayButtonPressed?.Invoke();
=======
            Play?.Invoke();
            Close();
>>>>>>> NewPatch
        }

        private void OnSettingsButtonClick()
        {
            ButtonAudio.Play();
            SettingsButtonPressed?.Invoke();
        }

        private void OnLeaderboardButtonClick()
        {
            ButtonAudio.Play();
            LeaderboardButtonPressed?.Invoke();
        }

        private void OnShopButtonClick()
        {
            ButtonAudio.Play();
            Shop?.Invoke();
        }
    }
}