using System;
using UnityEngine;
using UnityEngine.UI;
using Constants;
using GameLogic;

public class SettingsScreen : Screen
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Slider _levelSlider;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private TutorialManager _tutorialManager;

    public event Action<int> OnLevelChange;
    public event Action CloseScreen;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnClose);
        _levelSlider.onValueChanged.AddListener(OnSliderValueChange);
        _volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChange);
        _tutorialButton.onClick.AddListener(OnTutorialButtonClick);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnClose);
        _levelSlider.onValueChanged.RemoveListener(OnSliderValueChange);
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderValueChange);
        _tutorialButton.onClick.RemoveListener(OnTutorialButtonClick);
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
        _tutorialManager.gameObject.SetActive(true);
        _tutorialManager.OpenNextScreen();
    }
}
