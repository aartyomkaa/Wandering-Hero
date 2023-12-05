using UnityEngine;
using UI;

namespace GameLogic
{
    internal class FinishedToPlay : Transition
    {
        [SerializeField] private FinishedScreen _finishedScreen;

        private void OnEnable()
        {
            NeedTransit = false;

            _finishedScreen.RestartButtonPressed += OnRestart;
            _finishedScreen.NewGameButtonPressed += OnRestart;
        }

        private void OnDisable()
        {
            _finishedScreen.RestartButtonPressed -= OnRestart;
            _finishedScreen.NewGameButtonPressed -= OnRestart;
        }

        private void OnRestart()
        {
            NeedTransit = true;
        }
    }
}