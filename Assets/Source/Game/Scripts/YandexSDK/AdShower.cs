using UnityEngine;
using Audio;
using System.Collections.Generic;
using UnityEngine.UI;

namespace YandexSDK
{
    internal abstract class AdShower : MonoBehaviour
    {
        [SerializeField] private List<Button> _adButtons;

        public abstract void Show();

        protected void OnOpenCallBack()
        {
            Time.timeScale = 0;

            foreach(Button button in _adButtons)
                button.interactable = false;

            AudioController.Instance.Mute(true);
        }

        protected void OnCloseCallBack()
        {
            Time.timeScale = 1;

            foreach (Button button in _adButtons)
                button.interactable = true;

            AudioController.Instance.Unmute(true);
        }

        protected void OnCloseCallBack(bool wasShown)
        {
            if (wasShown == false)
                return;

            Time.timeScale = 1;

            foreach (Button button in _adButtons)
                button.interactable = true;

            AudioController.Instance.Unmute(true);
        }
    }
}