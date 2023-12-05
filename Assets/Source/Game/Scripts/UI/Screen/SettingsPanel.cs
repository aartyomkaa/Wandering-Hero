using System;
using UnityEngine;
using UnityEngine.UI;
using GameLogic;

namespace UI
{
    internal class SettingsPanel : Screen
    {
        [SerializeField] private StarsLevelUnlock[] _levelUnlocks;
        [SerializeField] private Slider _slider;
        [SerializeField] private ScorePanel _scorePanel;
        [SerializeField] private Map _map;

        private int _sliderMaxLevel = 0;

        private void OnEnable()
        {
            _scorePanel.ScoreChanged += OnScoreChange;
            _slider.onValueChanged.AddListener(OnSliderLevelChange);
        }

        private void OnDisable()
        {
            _scorePanel.ScoreChanged -= OnScoreChange;
            _slider.onValueChanged.RemoveListener(OnSliderLevelChange);
        }

        private void OnSliderLevelChange(float level)
        {
            if (level > _sliderMaxLevel)
            {
                _slider.value = _sliderMaxLevel;
            }
            else
            {
                ButtonAudio.Play();
                _map.SetLevel((int)Math.Round(level, 0));
            }
        }

        private void OnScoreChange(int value)
        {
            for (int i = _sliderMaxLevel;  i < _levelUnlocks.Length; i++)
            {
                if (_levelUnlocks[i].Value <= value)
                {
                    _levelUnlocks[i].gameObject.SetActive(false);
                    _sliderMaxLevel++;
                }
            }
        }
    }
}