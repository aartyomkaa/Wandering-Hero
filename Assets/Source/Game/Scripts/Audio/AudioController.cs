using System;
using UnityEngine;
using Constants;
using UnityEngine.UI;

namespace Audio
{
    internal class AudioController : MonoBehaviour
    {
        [SerializeField] private Sound[] _sounds;
        [SerializeField] private Button _muteButton;
        [SerializeField] private Sprite _muteButtonSprite;
        [SerializeField] private Sprite _unmuteButtonSprite;

        private bool _isMuted = false;

        public static AudioController Instance;

        public bool IsMuted => _isMuted;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            foreach (var sound in _sounds)
            {
                sound.Source = gameObject.AddComponent<AudioSource>();

                sound.Source.clip = sound.Clip;
                sound.Source.volume = sound.Volume;
                sound.Source.loop = sound.Loop;
            }

            Play(StaticVariables.ThemeSound);

            UnityEngine.PlayerPrefs.SetFloat(Constants.PlayerPrefs.Volume, 1);
        }

        public void Play(string name)
        {
            Sound sound = Array.Find(_sounds, sound => sound.Name == name);

            if (sound != null)
                sound.Source.Play();
            else
                throw new Exception();
        }

        public void Stop(string name)
        {
            Sound sound = Array.Find(_sounds, sound => sound.Name == name);

            if (sound != null)
                sound.Source.Stop();
            else
                throw new Exception();
        }

        public void ChangeVolume(float value)
        {
            foreach (var sound in _sounds)
            {
                sound.Source.volume = value;
            }

            _muteButton.image.sprite = _unmuteButtonSprite;
            _isMuted = false;

            UnityEngine.PlayerPrefs.SetFloat(Constants.PlayerPrefs.Volume, value);
        }

        public void Mute(bool isAdvertisement)
        {
            foreach (var sound in _sounds)
            {
                sound.Source.volume = 0;
            }

            if (isAdvertisement == false)
                _isMuted = true;

            _muteButton.image.sprite = _muteButtonSprite;
        }

        public void Unmute(bool isAdvertisement)
        {
            if (isAdvertisement && _isMuted)
                return;

            float value = UnityEngine.PlayerPrefs.GetFloat(Constants.PlayerPrefs.Volume);

            foreach (var sound in _sounds)
            {
                sound.Source.volume = value;   
            }

            _isMuted = false;
            _muteButton.image.sprite = _unmuteButtonSprite;
        }
    }
}