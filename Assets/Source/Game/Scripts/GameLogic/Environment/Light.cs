using UnityEngine;

namespace GameLogic
{
    internal class Light : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistanceX;
        [SerializeField] private Vector3 _startPoint;

        private void Update()
        {
            if (transform.position.x > _maxDistanceX)
                transform.position = _startPoint;

            transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }
}