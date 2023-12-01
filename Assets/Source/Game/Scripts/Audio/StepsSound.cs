using UnityEngine;

namespace Audio
{
    internal class StepsSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private float _minPitch = 0.7f;
        private float _maxPitch = 1.1f;

        public void Play()
        {
            _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
            _audioSource.Play();
        }
    }
}
