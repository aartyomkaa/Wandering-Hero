using UnityEngine;
using UI;
using YandexSDK;
using Constants;

namespace GameLogic
{
    internal class FinishedState : State
    {
        [SerializeField] private FinishedScreen _finishedScreen;
        [SerializeField] private Score _score;
        [SerializeField] private Map _map;
        [SerializeField] private InterstitialAdShower _interstitialAdShower;
        [SerializeField] private VideoAdShower _videoAdShower;

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
            _finishedScreen.Close();
            _score.HideResult();
        }

        private void OnRestart()
        {
            _videoAdShower.Show();

            _map.Restart();
            _finishedScreen.Close();
            _score.HideResult();
        }

        private void OnMenu()
        {
            _interstitialAdShower.Show();

            _finishedScreen.Close();
            _score.HideResult();
        }

        private void Init()
        {
            _finishedScreen.Open();
            _score.ShowResult();

            if (_score.Value > 0)
                AudioController.Instance.Play(StaticVariables.VictorySound);
            else
                AudioController.Instance.Play(StaticVariables.DefeatSound);
        }
    }
}