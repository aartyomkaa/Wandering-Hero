using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : Screen
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Slider _levelSlider;
    [SerializeField] private Slider _volumeSlider;

    public event Action<int> OnLevelChange;
    public event Action CloseScreen;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnClose);
        _levelSlider.onValueChanged.AddListener(OnSliderValueChange);
        _volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChange);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnClose);
        _levelSlider.onValueChanged.RemoveListener(OnSliderValueChange);
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderValueChange);
    }

    private void OnSliderValueChange(float value)
    {
        OnLevelChange?.Invoke((int)Math.Round(value, 0));
    }

    private void OnVolumeSliderValueChange(float value)
    {
        AudioController.Instance.ChangeVolume(value);
    }

    private void OnClose()
    {
        CloseScreen?.Invoke();
    }
}
