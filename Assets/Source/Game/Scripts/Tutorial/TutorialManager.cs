using UI;
using UnityEngine;
using System;
using Agava.WebUtility;

namespace GameLogic
{
    internal class TutorialManager : MonoBehaviour
    {
        [SerializeField] private TutorialScreen[] _tutorialScreens;
        [SerializeField] private TutorialScreen _mobileTutorial;

        private bool _hasPassedTutorial;
        private int _screenIndex = 0;

        public Action Finished;

        private void OnEnable()
        {
            foreach (TutorialScreen screen in _tutorialScreens)
            {
                screen.Closed += OpenNextScreen;
            }

#if UNITY_WEBGL && !UNITY_EDITOR
            if (Device.IsMobile)
            {
                _mobileTutorial.Closed += OpenNextScreen;
                _tutorialScreens[0] = _mobileTutorial;
            }
#endif
        }

        private void OnDisable()
        {
            foreach (TutorialScreen screen in _tutorialScreens)
            {
                screen.Closed -= OpenNextScreen;
            }

            if (Device.IsMobile)
                _mobileTutorial.Closed -= OpenNextScreen;
        }

        public void OpenNextScreen()
        {
            if (_screenIndex == _tutorialScreens.Length)
            {
                FinishTutorial();
            }
            else
            {
                _tutorialScreens[_screenIndex].Open();
                _screenIndex++;
            }     
        }

        private void FinishTutorial()
        {
            _screenIndex = 0;
            _hasPassedTutorial = true;

            PlayerPrefs.SetInt(Constants.PlayerPrefs.HasPassedTutorial, _hasPassedTutorial ? 1 : 0);
            PlayerPrefs.Save();

            Finished?.Invoke();
            Time.timeScale = 1f;

            gameObject.SetActive(false);
        }
    }
}