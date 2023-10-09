using System;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using Audio;

namespace UI
{
    internal class FinishedScreen : Screen
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _menuButton;

        public event Action Restart;
        public event Action NewGame;
        public event Action Menu;

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
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Restart?.Invoke();
        }

        private void OnNewGameButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            NewGame?.Invoke();
        }

        private void OnMenuButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            Menu?.Invoke();
        }
    }
}