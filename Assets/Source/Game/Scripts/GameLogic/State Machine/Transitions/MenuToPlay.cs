using UnityEngine;
using UI;

namespace GameLogic
{
    internal class MenuToPlay : Transition
    {
        [SerializeField] private MenuScreen _menuScreen;

        private void OnEnable()
        {
            NeedTransit = false;

            _menuScreen.Play += OnPlay;
        }

        private void OnDisable()
        {
            _menuScreen.Play -= OnPlay;
        }

        private void OnPlay()
        {
            NeedTransit = true;
        }
    }
}