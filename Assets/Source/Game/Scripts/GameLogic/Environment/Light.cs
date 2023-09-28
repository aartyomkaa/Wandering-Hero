using UnityEngine;

namespace GameLogic
{
    internal class Light : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _startPoint;
        [SerializeField] private Vector3 _endPoint;

        private float _startTime;
        private float _journeyLength;

        void Start()
        {
            _startTime = Time.time;

            _journeyLength = Vector3.Distance(_startPoint, _endPoint);
        }

        void FixedUpdate()
        {
            if (transform.position == _endPoint)
                transform.position = _startPoint;

            float distCovered = (Time.time - _startTime) * _speed;

            float fractionOfJourney = distCovered / _journeyLength;

            transform.position = Vector3.Lerp(_startPoint, _endPoint, fractionOfJourney);
        }
    }
}