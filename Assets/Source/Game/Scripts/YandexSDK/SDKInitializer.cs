using System.Collections;
using Agava.YandexGames;
using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YandexSDK
{
    internal class SDKInitializer : MonoBehaviour
    {
        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene(ScenesNames.MainScene);
        }
    }
}