using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class FinishedScreen : Screen
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _menuButton;

        public event Action RestartButtonPressed;
        
        public event Action NewGameButtonPressed;
        
        public event Action MenuButtonPressed;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _newGameButton.onClick.AddListener(OnNewGameButtonClick);
            _menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _newGameButton.onClick.RemoveListener(OnNewGameButtonClick);
            _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        }

        private void OnRestartButtonClick()
        {
            ButtonAudio.Play();
            RestartButtonPressed?.Invoke();
        }

        private void OnNewGameButtonClick()
        {
            ButtonAudio.Play();
            NewGameButtonPressed?.Invoke();
        }

        private void OnMenuButtonClick()
        {
            ButtonAudio.Play();
            MenuButtonPressed?.Invoke();
        }
    }
}