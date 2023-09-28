using System.Collections;
using UnityEngine;

namespace UI
{
    internal class Indicator : MonoBehaviour
    {
        [SerializeField] private Vector3 _maxSize;
        [SerializeField] private Vector3 _minSize;
        [SerializeField] private float _speed;
        [SerializeField] private float _fadeTime;

        private float _elapsedTime;

        private Coroutine _appear;
        private Coroutine _disappear;

        private void OnEnable()
        {
            gameObject.transform.localScale = Vector3.zero;

            Appear();
        }

        public void Disappear()
        {
            if (_disappear != null)
                StopCoroutine(_disappear);

            _disappear = StartCoroutine(ChangeSize(_minSize));
        }

        private void Appear()
        {
            if (_appear != null)
                StopCoroutine(_appear);

            _appear = StartCoroutine(ChangeSize(_maxSize));
        }

        private IEnumerator ChangeSize(Vector3 size)
        {
            _elapsedTime = 0;

            while (_elapsedTime <= _fadeTime)
            {
                gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, size, Time.deltaTime * _speed);

                _elapsedTime += Time.deltaTime;

                yield return Time.deltaTime;
            }

            if (size == _minSize)
                gameObject.SetActive(false);
        }
    }
}