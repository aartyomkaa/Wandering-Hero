using UnityEngine;

namespace Wanderer
{
    internal class PlayerReseter : MonoBehaviour
    {
        [SerializeField] private PlayerComponent[] _playerComponents;

        public void Reset()
        {
            foreach (var component in _playerComponents)
                component.Init();
        }
    }
}
