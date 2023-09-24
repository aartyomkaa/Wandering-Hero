using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

namespace YandexSDK
{
    public sealed class Localization : MonoBehaviour
    {
        private void Awake()
        {
            switch (YandexGamesSdk.Environment.i18n.lang)
            {
                case "en":
                    LeanLocalization.SetCurrentLanguageAll("English");
                    break;

                case "ru":
                    LeanLocalization.SetCurrentLanguageAll("Russian");
                    break;

                case "tr":
                    LeanLocalization.SetCurrentLanguageAll("Turkish");
                    break;

                default:
                    LeanLocalization.SetCurrentLanguageAll("English");
                    break;
            }

            LeanLocalization.UpdateTranslations();
        }
    }
}