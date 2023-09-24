using UnityEngine;

namespace YandexSDK
{
    internal abstract class AdShower : MonoBehaviour
    {
        public abstract void Show();

        protected void OnOpenCallBack()
        {
            Time.timeScale = 0;

            AudioController.Instance.Mute();
        }

        protected void OnCloseCallBack()
        {
            Time.timeScale = 1;

            AudioController.Instance.Unmute();
        }

        protected void OnCloseCallBack(bool state)
        {
            Time.timeScale = 1;

            AudioController.Instance.Unmute();
        }
    }
}