using System;
using UnityEngine;
using UnityEngine.UI;
using GameLogic;

namespace UI
{
    internal class SettingsScreen : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _tutorialButton;
        [SerializeField] private Slider _levelSlider;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Tutorial _tutorialManager;
        [SerializeField] private SettingsPanel _settingsPanel;

        public event Action Closed;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
            _tutorialButton.onClick.AddListener(OnTutorialButtonClick);

            _tutorialManager.Finished += OnTutorialFinish;
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
            _tutorialButton.onClick.RemoveListener(OnTutorialButtonClick);

            _tutorialManager.Finished -= OnTutorialFinish;
        }

        public override void Open()
        {
            base.Open();
            _settingsPanel.Open();
        }

        private void OnClose()
        {
            ButtonAudio.Play();

            Closed?.Invoke();
        }

        private void OnTutorialButtonClick()
        {
            ButtonAudio.Play();

            _settingsPanel.Close();
            _tutorialManager.gameObject.SetActive(true);
            _tutorialManager.OnOpenNextScreen();
        }

        private void OnTutorialFinish()
        {
            _settingsPanel.Open();
        }
    }
}
