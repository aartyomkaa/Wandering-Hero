using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine;
using UnityEngine.UI;
=======
>>>>>>> NewPatch
using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace YandexSDK
{
    internal abstract class AdShower : MonoBehaviour
    {
        [SerializeField] private List<Button> _adButtons;
        [SerializeField] private AuidoMixer _audioMixer;

        public abstract void Show();

        protected void OnOpenCallBack()
        {
            Time.timeScale = 0;

            foreach (Button button in _adButtons)
<<<<<<< HEAD
            {
=======
>>>>>>> NewPatch
                button.interactable = false;
            }

            _audioMixer.Mute();
        }

        protected void OnCloseCallBack()
        {
            Time.timeScale = 1;

            foreach (Button button in _adButtons)
                button.interactable = true;

            _audioMixer.Unmute();
        }

        protected void OnCloseCallBack(bool wasShown)
        {
            if (wasShown == false)
                return;

            Time.timeScale = 1;

            foreach (Button button in _adButtons)
                button.interactable = true;

            _audioMixer.Unmute();
        }
    }
}