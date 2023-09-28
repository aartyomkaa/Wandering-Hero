using UI;
using UnityEngine;

namespace GameLogic
{
    internal class PlayToMenu : Transition
    {
        [SerializeField] private PlayScreen _playScreen;

        private void OnEnable()
        {
            NeedTransit = false;

            _playScreen.Menu += OnMenu;
        }

        private void OnDisable()
        {
            _playScreen.Menu -= OnMenu;
        }

        private void OnMenu()
        {
            NeedTransit = true;
        }
    }
}
