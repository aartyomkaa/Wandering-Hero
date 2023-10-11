using NPC;
using UnityEngine;

namespace Wanderer
{
    [RequireComponent(typeof(PlayerHealth))]
    internal class PlayerAttacker : PlayerComponent
    {
        private PlayerHealth _health;

        private int _enemiesDefeated;

        public int EnemiesDefeated => _enemiesDefeated;

        private void Start()
        {
            _health = GetComponent<PlayerHealth>();
        }

        public override void Init()
        {
            _enemiesDefeated = 0;
        }

        protected override void Interact(Collider other)
        {
            if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (_health.Health > 0)
                {
                    AudioSource.Play();
                    _enemiesDefeated++;
                }
            }
        }
    }
}