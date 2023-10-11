using UnityEngine;

namespace Wanderer
{
    abstract class PlayerComponent : MonoBehaviour
    {
        [SerializeField] protected AudioSource AudioSource;

        public abstract void Init();

        protected abstract void Interact(Collider other);

        private void OnTriggerEnter(Collider other)
        {
            Interact(other);
        }
    }
}
