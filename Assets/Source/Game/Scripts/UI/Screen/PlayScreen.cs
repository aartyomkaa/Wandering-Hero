using System;
using Agava.WebUtility;
using Background;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using Agava.WebUtility;
using Background;
=======
>>>>>>> NewPatch

namespace UI
{
    internal class PlayScreen : Screen
    {
        [SerializeField] private BackgroundSwitcher _background;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _muteButton;
        [SerializeField] private MobileInput _mobileInput;
        [SerializeField] private MobileOrientation _orientation;

        public event Action RestartButtonPressed;

        public event Action MenuButtonPressed;

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

#if UNITY_WEBGL && !UNITY_EDITOR
            if (Device.IsMobile)
            {
                _orientation.gameObject.SetActive(true);
                _mobileInput.gameObject.SetActive(true);
            }
#endif
        }

        private void OnRestartButtonClick()
        {
            ButtonAudio.Play();
            RestartButtonPressed?.Invoke();
        }

        private void OnMenuButtonClick()
        {
            ButtonAudio.Play();
            MenuButtonPressed?.Invoke();
        }
    }
}