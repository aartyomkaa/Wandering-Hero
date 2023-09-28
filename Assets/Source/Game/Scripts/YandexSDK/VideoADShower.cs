using Agava.YandexGames;

namespace YandexSDK
{
    internal class VideoAdShower : AdShower
    {
        public override void Show()
        {
            VideoAd.Show(OnOpenCallBack, onCloseCallback: OnCloseCallBack);
        }
    }
}