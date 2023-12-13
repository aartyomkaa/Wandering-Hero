using UI;
using UnityEngine;

namespace GameLogic
{
    internal class MenuToPlay : Transition
    {
        [SerializeField] private MenuScreen _menuScreen;

        private void OnEnable()
        {
            NeedTransit = false;

            _menuScreen.PlayButtonPressed += OnPlay;
        }

        private void OnDisable()
        {
            _menuScreen.PlayButtonPressed -= OnPlay;
        }

        private void OnPlay()
        {
            NeedTransit = true;
        }
    }
}