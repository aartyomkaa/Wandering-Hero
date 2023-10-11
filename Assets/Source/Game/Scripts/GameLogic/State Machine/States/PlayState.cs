using UnityEngine;
using UI;
using YandexSDK;
using Agava.WebUtility;

namespace GameLogic
{
    internal class PlayState : State
    {
        [SerializeField] private PlayScreen _playScreen;
        [SerializeField] private Map _map;
        [SerializeField] private VideoAdShower _videoAdShower;
        [SerializeField] private Tutorial _tutorialManager;
        [SerializeField] private MobileInput _controller;

        private void OnEnable()
        {
            Init();

            _playScreen.Restart += OnRestart;

            _tutorialManager.Finished += OnTutorialFinish;
        }

        private void OnDisable()
        {
            _playScreen.Restart -= OnRestart;

            _tutorialManager.Finished -= OnTutorialFinish;

            _playScreen.Close();
        }

        private void Init()
        {
            if (PlayerPrefs.GetInt(Constants.PlayerSettings.HasPassedTutorial) == 0)
            {
                _tutorialManager.OpenNextScreen();
            }
            else
            {
                Time.timeScale = 1.0f;
                _playScreen.Open();
            }
        }

        private void OnRestart()
        {
            _videoAdShower.Show();

            _map.Restart();
        }

        private void OnTutorialFinish()
        {
            if (IsActive)
                _playScreen.Open();

#if UNITY_WEBGL && !UNITY_EDITOR
            if (Device.IsMobile)
            {
                _controller.gameObject.SetActive(true);
            }
#endif
        }
    }
}