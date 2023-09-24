using Agava.YandexGames;

namespace YandexSDK
{
    internal sealed class VideoAdShower : AdShower
    {
        public override void Show()
        {
            VideoAd.Show(OnOpenCallBack, onCloseCallback: OnCloseCallBack);
        }
    }
}