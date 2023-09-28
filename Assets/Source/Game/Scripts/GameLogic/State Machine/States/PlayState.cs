using UnityEngine;
using UI;
using YandexSDK;

namespace GameLogic
{
    internal class PlayState : State
    {
        [SerializeField] private PlayScreen _playScreen;
        [SerializeField] private Map _map;
        [SerializeField] private VideoAdShower _videoAdShower;
        [SerializeField] private TutorialManager _tutorialManager;

        private void OnEnable()
        {
            Init();

            _playScreen.Mute += OnMute;
            _playScreen.Restart += OnRestart;
        }

        private void OnDisable()
        {
            _playScreen.Mute -= OnMute;
            _playScreen.Restart -= OnRestart;

            _playScreen.Close();
        }

        private void Init()
        {
            if (PlayerPrefs.GetInt(Constants.PlayerPrefsConstants.HasPassedTutorial) == 0)
                _tutorialManager.OpenNextScreen();

            Time.timeScale = 1.0f;
            _playScreen.Open();
        }

        private void OnMute()
        {
            if (AudioController.Instance.IsMuted)
                AudioController.Instance.Unmute();
            else
                AudioController.Instance.Mute();
        }

        private void OnRestart()
        {
            _videoAdShower.Show();

            _map.Restart();
        }
    }
}