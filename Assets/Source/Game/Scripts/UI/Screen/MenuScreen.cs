using System;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using Audio;

namespace UI
{
    internal class MenuScreen : Screen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _leaderboardButton;

        public event Action Play;
        public event Action Settings;
        public event Action Leaderboard;

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
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Play?.Invoke();
        }

        private void OnSettingsButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Settings?.Invoke();
        }

        private void OnLeaderboardButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Leaderboard?.Invoke();
        }
    }
}