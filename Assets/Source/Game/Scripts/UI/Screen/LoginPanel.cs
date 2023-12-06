using System;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

namespace UI
{
    internal class LoginPanel : Screen
    {
        [SerializeField] private Button _accept;
        [SerializeField] private Button _decline;
        [SerializeField] private ScorePanel _scorePanel;

        public event Action DeclineButtonPressed;

        public event Action AcceptButtonPressed;

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

            _scorePanel.SetScore();

            AcceptButtonPressed?.Invoke();
            Close();
        }

        private void OnDecline()
        {
            ButtonAudio.Play();

            DeclineButtonPressed?.Invoke();
            Close();
        }
    }
}