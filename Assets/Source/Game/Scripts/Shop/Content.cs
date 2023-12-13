using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    internal abstract class Content : MonoBehaviour
    {
        [SerializeField] protected Image _imagePrefab;

        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private float _scrollDuration;

        private Coroutine _scroll;
        private bool _canScroll = true;

        protected List<Image> _images = new List<Image>();

        protected int _scrollIndex;
        protected IItem _selectedItem;

        protected virtual void Start()
        {
            FillImages();
            _scrollIndex = 0;
            _scrollRect.horizontalNormalizedPosition = 0;
        }

        public virtual void ScrollLeft()
        {
            if (_scrollRect.horizontalNormalizedPosition >= 0 && _canScroll)
                StartCoroutine(-1); 
        }

        public virtual void ScrollRight()
        {
            if (_scrollRect.horizontalNormalizedPosition <= 1 && _canScroll)
                StartCoroutine(1);
        }

        public abstract IItem GetSelectedItem();

        protected abstract void FillImages();

        private void StartCoroutine(int direction)
        {
            if (_scroll != null)
                StopCoroutine(_scroll);

            _scroll = StartCoroutine(Scroll(direction));
        }

        private IEnumerator Scroll(int direction)
        {
            float contentLength = 1.0f / (_images.Count - 1);
            float targetPosition = _scrollRect.horizontalNormalizedPosition + contentLength * direction;
            float startPosition = _scrollRect.horizontalNormalizedPosition;

            _canScroll = false;

            float elapsedTime = 0f;
            float fixedTimeStep = 0.02f;

            while (elapsedTime < _scrollDuration)
            {
                _scrollRect.horizontalNormalizedPosition = Mathf.Lerp(startPosition, targetPosition, elapsedTime / _scrollDuration);
                elapsedTime += fixedTimeStep;

                yield return null; // or yield return new WaitForEndOfFrame();
            }

            _scrollRect.horizontalNormalizedPosition = targetPosition;
            _canScroll = true;
        }
    }
}