using UI;
using UnityEngine;

namespace GameLogic
{
    internal class FinishedToMenu : Transition
    {
        [SerializeField] private FinishedScreen _finishedScreen;

        private void OnEnable()
        {
            NeedTransit = false;

            _finishedScreen.Menu += OnMenu;
        }

        private void OnDisable()
        {
            _finishedScreen.Menu -= OnMenu;
        }

        private void OnMenu()
        {
            NeedTransit = true;
        }
    }
}