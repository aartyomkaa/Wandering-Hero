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
        [SerializeField] private Tutorial _tutorialManager;

        private void OnEnable()
        {
            Init();

            _playScreen.RestartButtonPressed += OnRestart;

            _tutorialManager.Finished += OnTutorialFinish;
        }

        private void OnDisable()
        {
            _playScreen.RestartButtonPressed -= OnRestart;

            _tutorialManager.Finished -= OnTutorialFinish;

            _playScreen.Close();
        }

        private void Init()
        {
            if (PlayerPrefs.GetInt(Constants.PlayerSettings.HasPassedTutorial) == 0)
            {
                _tutorialManager.OnOpenNextScreen();
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
        }
    }
}