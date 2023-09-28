using UI;
using UnityEngine;

namespace GameLogic
{
    internal class TutorialManager : MonoBehaviour
    {
        [SerializeField] private TutorialScreen[] _tutorialScreens;

        private bool _hasPassedTutorial;
        private int _screenIndex = 0;

        private void OnEnable()
        {
            foreach (TutorialScreen screen in _tutorialScreens)
            {
                screen.Closed += OpenNextScreen;
            }
        }

        private void OnDisable()
        {
            foreach (TutorialScreen screen in _tutorialScreens)
            {
                screen.Closed -= OpenNextScreen;
            }
        }

        public void OpenNextScreen()
        {
            if (_screenIndex == _tutorialScreens.Length)
            {
                Time.timeScale = 1f;

                _screenIndex = 0;
                _hasPassedTutorial = true;

                PlayerPrefs.SetInt(Constants.PlayerPrefsConstants.HasPassedTutorial, _hasPassedTutorial ? 1 : 0);
                PlayerPrefs.Save();

                gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;

                _tutorialScreens[_screenIndex].Open();
                _screenIndex++;
            }     
        }
    }
}

