using Agava.YandexGames;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class LoginPanel : Screen
    {
        [SerializeField] private Button _accept;
        [SerializeField] private Button _decline;

        public Action Decline;
        public Action Accept;

        private void OnEnable()
        {
            _accept.onClick.AddListener(OnAccept);
            _decline.onClick.AddListener(OnDecline);
        }

        private void OnDisable()
        {
            _accept.onClick.RemoveListener(OnAccept);
            _decline.onClick.RemoveListener(OnDecline);
        }

        private void OnAccept()
        {
            ButtonAudio.Play();

            PlayerAccount.Authorize();

            Accept?.Invoke();
            Close();
        }
        
        private void OnDecline()
        {
            ButtonAudio.Play();

            Decline?.Invoke();
            Close();
        }
    }
}