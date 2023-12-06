using UnityEngine;

namespace Audio
{
    internal class FinishedAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _victory;
        [SerializeField] private AudioSource _defeat;

        public void PlayVictory()
        {
            _victory.Play();
        }

        public void PlayDefeat()
        {
            _defeat.Play();
        }
    }
}
