using UnityEngine;
using UI;

namespace GameLogic
{
    internal class PlayState : State
    {
        [SerializeField] private PlayScreen _playScreen;
        [SerializeField] private Map _map;

        private void OnEnable()
        {
            Init();

            _playScreen.Mute += OnMute;
            _playScreen.Restart += OnRestart;
        }

        private void OnDisable()
        {
            _playScreen.Mute -= OnMute;
            _playScreen.Restart -= OnRestart;

            _playScreen.Close();
        }

        private void Init()
        {
            Time.timeScale = 1.0f;

            _playScreen.Open();
        }

        private void OnMute()
        {
            if (AudioController.Instance.IsMuted)
                AudioController.Instance.Unmute();
            else
                AudioController.Instance.Mute();

            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
        }

        private void OnRestart()
        {
            _map.Restart();
            AudioController.Instance.Play(StaticVariables.ButtonClickSound);
        }
    }
}