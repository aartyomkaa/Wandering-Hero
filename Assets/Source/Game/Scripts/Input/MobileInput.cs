using Agava.WebUtility;
using UnityEngine;

namespace UI
{
    internal class MobileInput : MonoBehaviour
    {
        [SerializeField] private MobileOrientation _screenOrientation;
        [SerializeField] private Vector2 _positionPortrait;
        [SerializeField] private Vector2 _positionLandscape;

        private RectTransform _rectTransform;

        private void OnEnable()
        {
            _rectTransform = GetComponent<RectTransform>();
            _screenOrientation.OrientationChanged += OnScreenOrientationChange;
        }

        private void OnDisable()
        {
            _screenOrientation.OrientationChanged -= OnScreenOrientationChange;
        }

        private void OnScreenOrientationChange(ScreenOrientation orientation)
        {
            if (orientation == ScreenOrientation.Portrait)
                _rectTransform.anchoredPosition = _positionPortrait;
            else
                _rectTransform.anchoredPosition = _positionLandscape;
        }
    }
}
