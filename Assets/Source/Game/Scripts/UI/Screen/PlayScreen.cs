using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class PlayScreen : Screen
    {
        [SerializeField] private BackgroundSwitcher _background;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _muteButton;

        public event Action Restart;
        public event Action Mute;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _muteButton.onClick.AddListener(OnMuteButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _muteButton.onClick.RemoveListener(OnMuteButtonClick);
        }

        public override void Open()
        {
            base.Open();

            _background.Switch();
        }

        private void OnRestartButtonClick()
        {
            Restart?.Invoke();
        }

        private void OnMuteButtonClick()
        {
            Mute?.Invoke();
        }
    }
}