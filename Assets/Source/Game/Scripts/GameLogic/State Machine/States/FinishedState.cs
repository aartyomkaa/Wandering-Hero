using UnityEngine;
using Audio;
using UI;
using YandexSDK;

namespace GameLogic
{
    internal class FinishedState : State
    {
        [SerializeField] private FinishedScreen _finishedScreen;
        [SerializeField] private ScorePanel _score;
        [SerializeField] private Map _map;
        [SerializeField] private InterstitialAdShower _interstitialAdShower;
        [SerializeField] private VideoAdShower _videoAdShower;
        [SerializeField] private FinishedAudioPlayer _audioPlayer;

        private void OnEnable()
        {
            Init();

            _finishedScreen.RestartButtonPressed += OnRestart;
            _finishedScreen.NewGameButtonPressed += OnNewGame;
            _finishedScreen.MenuButtonPressed += OnMenu;
        }

        private void OnDisable()
        {
            _finishedScreen.RestartButtonPressed -= OnRestart;
            _finishedScreen.NewGameButtonPressed -= OnNewGame;
            _finishedScreen.MenuButtonPressed -= OnMenu;
        }

        private void OnNewGame()
        {
            _interstitialAdShower.Show();

            _map.Reset();
            Leave();
        }

        private void OnRestart()
        {
            _videoAdShower.Show();

            _map.Restart();
            Leave();
        }

        private void OnMenu()
        {
            _interstitialAdShower.Show();

            Leave();
        }

        private void Init()
        {
            _finishedScreen.Open();
            _score.ShowResult();

            if (_score.Value > 0)
                _audioPlayer.PlayVictory();
            else
                _audioPlayer.PlayDefeat();
        }

        private void Leave()
        {
            _finishedScreen.Close();
            _score.HideResult();
        }
    }
}