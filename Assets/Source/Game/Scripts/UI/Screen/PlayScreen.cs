using System;
using UnityEngine;
using UnityEngine.UI;
using Background;

namespace UI
{
    internal class PlayScreen : Screen
    {
        [SerializeField] private BackgroundSwitcher _background;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _muteButton;

        public event Action Restart;
        public event Action Menu;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        }

        public override void Open()
        {
            base.Open();

            _background.Switch();
        }

        private void OnRestartButtonClick()
        {
            ButtonAudio.Play();
            Restart?.Invoke();
        }

        private void OnMenuButtonClick()
        {
            ButtonAudio.Play();
            Menu?.Invoke();
        }
    }
}