using Audio;
using UI;
using UnityEngine;
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

            _finishedScreen.Restart += OnRestart;
            _finishedScreen.NewGame += OnNewGame;
            _finishedScreen.Menu += OnMenu;
        }

        private void OnDisable()
        {
            _finishedScreen.Restart -= OnRestart;
            _finishedScreen.NewGame -= OnNewGame;
            _finishedScreen.Menu -= OnMenu;
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
#if UNITY_WEBGL && !UNITY_EDITOR
            _interstitialAdShower.Show();
#endif

            Leave();
        }

        private void Init()
        {
            _finishedScreen.Open();
            _score.ShowResult();

            _audioPlayer.Play(_score.Value > 0);
        }

        private void Leave()
        {
            _finishedScreen.Close();
            _score.HideResult();
        }
    }
}