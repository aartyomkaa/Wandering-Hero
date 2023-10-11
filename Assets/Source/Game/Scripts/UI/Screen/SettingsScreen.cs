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

        public event Action<int> OnLevelChange;
        public event Action CloseScreen;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
            _tutorialButton.onClick.AddListener(OnTutorialButtonClick);
            _levelSlider.onValueChanged.AddListener(OnSliderValueChange);

            _tutorialManager.Finished += OnTutorialFinish;
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
            _tutorialButton.onClick.RemoveListener(OnTutorialButtonClick);
            _levelSlider.onValueChanged.RemoveListener(OnSliderValueChange);

            _tutorialManager.Finished -= OnTutorialFinish;
        }

        public override void Open()
        {
            base.Open();
            _settingsPanel.Open();
        }

        private void OnSliderValueChange(float value)
        {
            ButtonAudio.Play();

            OnLevelChange?.Invoke((int)Math.Round(value, 0));
        }

        private void OnClose()
        {
            ButtonAudio.Play();

            CloseScreen?.Invoke();
        }

        private void OnTutorialButtonClick()
        {
            ButtonAudio.Play();

            _settingsPanel.Close();
            _tutorialManager.gameObject.SetActive(true);
            _tutorialManager.OpenNextScreen();
        }

        private void OnTutorialFinish()
        {
            _settingsPanel.Open();
        }
    }
}
