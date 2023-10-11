using UnityEngine;

namespace Audio
{
    internal class FinishedAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _victory;
        [SerializeField] private AudioSource _defeat;

        public void Play(bool victory)
        {
            if (victory)
                _victory.Play();
            else
                _defeat.Play();
        }
    }
}
