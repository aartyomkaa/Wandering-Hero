using Agava.YandexGames;

namespace YandexSDK
{
    internal sealed class InterstitialAdShower : AdShower
    {
        public override void Show()
        {
            InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);
        }
    }
}