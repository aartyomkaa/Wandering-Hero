using System;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using Audio;
using Background;

namespace UI
{
    internal class PlayScreen : Screen
    {
        [SerializeField] private BackgroundSwitcher _background;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _muteButton;
        [SerializeField] private Button _menuButton;

        public event Action Restart;
        public event Action Mute;
        public event Action Menu;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _muteButton.onClick.AddListener(OnMuteButtonClick);
            _menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _muteButton.onClick.RemoveListener(OnMuteButtonClick);
            _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        }

        public override void Open()
        {
            base.Open();

            _background.Switch();
        }

        private void OnRestartButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Restart?.Invoke();
        }

        private void OnMuteButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Mute?.Invoke();
        }

        private void OnMenuButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Menu?.Invoke();
        }
    }
}