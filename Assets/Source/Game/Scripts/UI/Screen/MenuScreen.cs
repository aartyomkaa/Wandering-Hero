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

        public event Action Play;
        public event Action Shop;
        public event Action Settings;
        public event Action Leaderboard;

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
            Play?.Invoke();
            Close();
        }

        private void OnSettingsButtonClick()
        {
            ButtonAudio.Play();
            Settings?.Invoke();
        }

        private void OnLeaderboardButtonClick()
        {
            ButtonAudio.Play();
            Leaderboard?.Invoke();
        }

        private void OnShopButtonClick()
        {
            ButtonAudio.Play();
            Shop?.Invoke();
        }
    }
}