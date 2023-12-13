using UnityEngine;

namespace Wanderer
{
    [RequireComponent(typeof(PlayerAttacker))]
    [RequireComponent(typeof(PlayerInteractor))]
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerAnimator))]
    internal class PlayerReseter : MonoBehaviour
    {
        private PlayerComponent[] _playerComponents;

        private void Awake()
        {
            _playerComponents = GetComponents<PlayerComponent>();

        }

        public void Reset()
        {
            foreach (var component in _playerComponents)
                component.Init();
        }
    }
}
