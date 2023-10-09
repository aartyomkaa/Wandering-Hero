using System;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using GameLogic;
using Audio;

namespace UI
{
    internal class SettingsScreen : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _levelSlider;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Button _tutorialButton;
        [SerializeField] private TutorialManager _tutorialManager;
        [SerializeField] private SettingsPanel _settingsPanel;

        public event Action<int> OnLevelChange;
        public event Action CloseScreen;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
            _levelSlider.onValueChanged.AddListener(OnSliderValueChange);
            _volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChange);
            _tutorialButton.onClick.AddListener(OnTutorialButtonClick);

            _tutorialManager.Finished += OnTutorialFinish;
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
            _levelSlider.onValueChanged.RemoveListener(OnSliderValueChange);
            _volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderValueChange);
            _tutorialButton.onClick.RemoveListener(OnTutorialButtonClick);

            _tutorialManager.Finished -= OnTutorialFinish;
        }

        public override void Open()
        {
            base.Open();
            _settingsPanel.Open();
        }

        private void OnSliderValueChange(float value)
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            OnLevelChange?.Invoke((int)Math.Round(value, 0));
        }

        private void OnVolumeSliderValueChange(float value)
        {
            AudioController.Instance.ChangeVolume(value);
        }

        private void OnClose()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
            CloseScreen?.Invoke();
        }

        private void OnTutorialButtonClick()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

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
