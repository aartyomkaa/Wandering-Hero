using Agava.YandexGames;

namespace YandexSDK
{
    internal class InterstitialAdShower : AdShower
    {
        public override void Show()
        {
            InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);
        }
    }
}