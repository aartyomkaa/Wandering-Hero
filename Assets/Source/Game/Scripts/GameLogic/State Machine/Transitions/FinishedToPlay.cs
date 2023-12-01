using UI;
using UnityEngine;

namespace GameLogic
{
    internal class FinishedToPlay : Transition
    {
        [SerializeField] private FinishedScreen _finishedScreen;

        private void OnEnable()
        {
            NeedTransit = false;

            _finishedScreen.Restart += OnRestart;
            _finishedScreen.NewGame += OnRestart;
        }

        private void OnDisable()
        {
            _finishedScreen.Restart -= OnRestart;
            _finishedScreen.NewGame -= OnRestart;
        }

        private void OnRestart()
        {
            NeedTransit = true;
        }
    }
}