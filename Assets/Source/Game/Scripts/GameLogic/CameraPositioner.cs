using Agava.WebUtility;
using UI;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(Camera))]
    internal class CameraPositioner : MonoBehaviour
    {
        [SerializeField] private MapGenerator _generator;
        [SerializeField] private MobileOrientation _screenOrientation;

        private Level _currentLevel;
        private ScreenOrientation _currentOrientation = ScreenOrientation.LandscapeLeft;

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
            _generator.LevelChanged += OnLevelChanged;
            _screenOrientation.OrientationChanged += OnScreenOrientationChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
            _generator.LevelChanged -= OnLevelChanged;
            _screenOrientation.OrientationChanged -= OnScreenOrientationChange;
        }

        private void OnLevelChanged(Level level)
        {
           _currentLevel = level;
           ChangePosition(_currentOrientation);
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : 1f;
        }

        private void OnScreenOrientationChange(ScreenOrientation orientation)
        {
            if (orientation != ScreenOrientation.AutoRotation)
                _currentOrientation = orientation;
            else
                throw new System.Exception();

            ChangePosition(_currentOrientation);
        }

        private void ChangePosition(ScreenOrientation orientation)
        {
            if (orientation == ScreenOrientation.Portrait)
            {
                transform.position = _currentLevel.MobilePortretCameraPosition;
                transform.rotation = Quaternion.Euler(_currentLevel.MobilePortretCameraRotation.x, 0, 0);
            }
            else
            {
                transform.position = _currentLevel.CameraPosition;
                transform.rotation = _currentLevel.CameraRotation;
            }
        }
    }
}