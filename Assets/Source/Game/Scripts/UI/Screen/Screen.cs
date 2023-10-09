using UnityEngine;

namespace UI
{
    internal abstract class Screen : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup CanvasGroup;

        private void Start()
        {
            Close();
        }

        public void Close()
        {
            CanvasGroup.alpha = 0f;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }

        public virtual void Open()
        {
            CanvasGroup.alpha = 1f;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        }
    }
}