using Constants;
using UnityEngine;

namespace UI
{
    internal class MobileController : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void OnEnable()
        {
            _rectTransform = GetComponent<RectTransform>();

            if (UnityEngine.Device.Screen.height < UnityEngine.Device.Screen.width)
                _rectTransform.anchoredPosition = StaticVariables.ControllerPosition;
            else
                _rectTransform.anchoredPosition = StaticVariables.ControllerPositionVertical;
        }
    }
}
