using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class SpriteSetter : MonoBehaviour
    {
        [SerializeField] private Sprite _muteSprite;
        [SerializeField] private Sprite _unmuteSprite;
        [SerializeField] private Button _muteButton;
        [SerializeField] private AuidoMixer _mixer;

        private void OnEnable()
        {
            _mixer.Muted += OnMute;
        }

        private void OnDisable()
        {
            _mixer.Muted -= OnMute;
        }

        private void OnMute(bool mute)
        {
            if (mute)
                _muteButton.image.sprite = _muteSprite;
            else
                _muteButton.image.sprite = _unmuteSprite;
        }
    }
}
