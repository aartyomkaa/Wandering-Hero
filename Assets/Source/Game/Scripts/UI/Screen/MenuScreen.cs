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

        public event Action PlayButtonPressed;

        public event Action SettingsButtonPressed;

        public event Action LeaderboardButtonPressed;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _leaderboardButton.onClick.AddListener(OnLeaderboardButtonClick);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
            _leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonClick);
        }

        private void OnPlayButtonClick()
        {
            ButtonAudio.Play();
            PlayButtonPressed?.Invoke();
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
    }
}