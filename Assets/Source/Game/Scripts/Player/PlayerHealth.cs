using System;
<<<<<<< HEAD
=======
using GameLogic;
using NPC;
>>>>>>> NewPatch
using UnityEngine;
using GameLogic;
using NPC;

namespace Wanderer
{
    [RequireComponent(typeof(Player))]
    internal class PlayerHealth : PlayerComponent
    {
        [SerializeField] private int _maxHealth;

        private Player _player;

        private int _currentHealth;

        public event Action Died;

        public event Action<int> HealthChanged;

        public int Health => _currentHealth;

        public int MaxHealth => _maxHealth;

        private void Start()
        {
            _player = GetComponent<Player>();

            _currentHealth = _maxHealth;
        }

        public override void Init()
        {
            _currentHealth = _maxHealth;
            HealthChanged?.Invoke(_currentHealth);
        }

        protected override void Interact(Collider other)
        {
            if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                TakeDamage();
            }
            else if (other.gameObject.TryGetComponent<InterestTile>(out InterestTile tile))
            {
                if (tile is Heal)
                {
                    AudioSource.Play();
                    RestoreHealth();
                }
            }
        }

        private void TakeDamage()
        {
            _currentHealth--;
            HealthChanged?.Invoke(_currentHealth);

            if (_currentHealth == 0)
            {
                _player.Die();
                Died?.Invoke();
            }
        }

        private void RestoreHealth()
        {
            _currentHealth++;

            if (_currentHealth > MaxHealth)
                _currentHealth = MaxHealth;
            else
                HealthChanged?.Invoke(_currentHealth);
        }
    }
}
