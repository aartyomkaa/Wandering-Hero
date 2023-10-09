using UnityEngine;
using UI;
using YandexSDK;
using Audio;
using Agava.WebUtility;

namespace GameLogic
{
    internal class PlayState : State
    {
        [SerializeField] private PlayScreen _playScreen;
        [SerializeField] private Map _map;
        [SerializeField] private VideoAdShower _videoAdShower;
        [SerializeField] private TutorialManager _tutorialManager;
        [SerializeField] private MobileController _controller;

        private void OnEnable()
        {
            Init();

            _playScreen.Mute += OnMute;
            _playScreen.Restart += OnRestart;

            _tutorialManager.Finished += OnTutorialFinish;
        }

        private void OnDisable()
        {
            _playScreen.Mute -= OnMute;
            _playScreen.Restart -= OnRestart;

            _tutorialManager.Finished -= OnTutorialFinish;

            _playScreen.Close();
        }

        private void Init()
        {
            if (PlayerPrefs.GetInt(Constants.PlayerPrefs.HasPassedTutorial) == 0)
            {
                _tutorialManager.OpenNextScreen();
            }
            else
            {
                Time.timeScale = 1.0f;
                _playScreen.Open();
            }
        }

        private void OnMute()
        {
            if (AudioController.Instance.IsMuted)
                AudioController.Instance.Unmute(false);
            else
                AudioController.Instance.Mute(false);
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

            if (Device.IsMobile)
            {
                _controller.gameObject.SetActive(true);
            }
        }
    }
}