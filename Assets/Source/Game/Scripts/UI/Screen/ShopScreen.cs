using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class ShopScreen : Screen
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private StorePanel _storePanel;

        public Action CloseButtonPressed;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnClose);
        }

        public override void Open()
        {
            base.Open();

            _storePanel.Open();
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnClose);
        }

        private void OnClose()
        {
            ButtonAudio?.Play();
            CloseButtonPressed?.Invoke();
            Close();
            _storePanel.Close();
        }
    }
}
