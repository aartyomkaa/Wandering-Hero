using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class TutorialScreen : Screen
    {
        [SerializeField] private Button _close;

        public Action Closed;

        private void OnEnable()
        {
            _close.onClick.AddListener(OnClose);
        }

        private void OnDisable()
        {
            _close.onClick.RemoveListener(OnClose);
        }

        private void OnClose()
        {
            Closed?.Invoke();
            Close();
        }
    }
}