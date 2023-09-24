using UnityEngine;
using UI;
using YandexSDK;

namespace GameLogic
{
    internal class FinishedState : State
    {
        [SerializeField] private FinishedScreen _finishedScreen;
        [SerializeField] private Score _score;
        [SerializeField] private Map _map;
        [SerializeField] private AdShower _adShower;

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
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _map.Reset();
            _finishedScreen.Close();
            _score.HideResult();

            _adShower.Show();
        }

        private void OnRestart()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _map.Restart();
            _finishedScreen.Close();
            _score.HideResult();

            _adShower.Show();
        }

        private void OnMenu()
        {
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);

            _finishedScreen.Close();
            _score.HideResult();

            _adShower.Show();
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