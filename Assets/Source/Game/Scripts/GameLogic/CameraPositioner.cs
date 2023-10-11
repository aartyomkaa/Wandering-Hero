using Agava.WebUtility;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(Camera))]
    internal class CameraPositioner : MonoBehaviour
    {
        [SerializeField] private MapGenerator _generator;

        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
            _generator.LevelChanged += OnLevelChanged;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
            _generator.LevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(Level level)
        {
            if (UnityEngine.Device.Screen.height > UnityEngine.Device.Screen.width)
            {
                _camera.transform.position = level.MobilePortretCameraPosition;
                _camera.transform.rotation = Quaternion.Euler(level.MobilePortretCameraRotation.x, 0, 0);
            }
            else
            {
                _camera.transform.position = level.CameraPosition;
                _camera.transform.rotation = level.CameraRotation;
            }
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : 1f;
        }
    }
}