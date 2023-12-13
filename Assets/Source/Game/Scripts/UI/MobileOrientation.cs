<<<<<<< HEAD
using System;
using UnityEngine;
using Agava.WebUtility;
=======
using Agava.WebUtility;
using System;
using UnityEngine;
>>>>>>> NewPatch

namespace UI
{
    internal class MobileOrientation : MonoBehaviour
    {
        private ScreenOrientation _currentOrientation;

        public event Action<ScreenOrientation> OrientationChanged;

        private void OnEnable()
        {
            _currentOrientation = UnityEngine.Device.Screen.orientation;
        }

        private void Start()
        {
            OrientationChanged?.Invoke(_currentOrientation);
        }

        private void Update()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (Device.IsMobile == false)
                return;
#endif
            ScreenOrientation orientation = UnityEngine.Device.Screen.orientation;

            if (orientation == _currentOrientation)
                return;

            _currentOrientation = orientation;

            if (UnityEngine.Device.Screen.orientation == ScreenOrientation.Portrait)
                OrientationChanged?.Invoke(ScreenOrientation.Portrait);
            else if (UnityEngine.Device.Screen.orientation == ScreenOrientation.LandscapeLeft ||
                     UnityEngine.Device.Screen.orientation == ScreenOrientation.LandscapeRight)
                OrientationChanged?.Invoke(ScreenOrientation.LandscapeLeft);
        }
    }
}