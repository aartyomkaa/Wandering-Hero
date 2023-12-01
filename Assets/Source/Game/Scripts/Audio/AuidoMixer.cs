using System;
using Constants;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    internal class AuidoMixer : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mixer;

        private float _minVolume = -80;
        private float _maxVolume = 0;

        private bool _isMuted = false;

        public bool IsMuted => _isMuted;

        public event Action<bool> Muted;

        public void ChangeVolume(float volume)
        {
            _mixer.audioMixer.SetFloat(StaticVariables.MusicVolume, volume);
            PlayerPrefs.SetFloat(StaticVariables.MusicVolume, volume);

            _isMuted = false;
            Muted?.Invoke(_isMuted);
        }

        public void ToggleMusic()
        {
            float value = PlayerPrefs.GetFloat(StaticVariables.MusicVolume);

            if (_isMuted)
            {
                if (value > _minVolume)
                    _mixer.audioMixer.SetFloat(StaticVariables.MusicVolume, value);
                else
                    _mixer.audioMixer.SetFloat(StaticVariables.MusicVolume, _maxVolume);

                _isMuted = false;
            }
            else
            {
                _mixer.audioMixer.SetFloat(StaticVariables.MusicVolume, _minVolume);
                _isMuted = true;
            }

            Muted?.Invoke(_isMuted);
        }

        public void Mute()
        {
            if (_isMuted == false)
                _mixer.audioMixer.SetFloat(StaticVariables.MusicVolume, _minVolume);
        }

        public void Unmute()
        {
            float value = PlayerPrefs.GetFloat(StaticVariables.MusicVolume);

            if (_isMuted == false)
            {
                if (value > _minVolume)
                    _mixer.audioMixer.SetFloat(StaticVariables.MusicVolume, value);
                else
                    _mixer.audioMixer.SetFloat(StaticVariables.MusicVolume, _maxVolume);
            }
        }
    }
}

