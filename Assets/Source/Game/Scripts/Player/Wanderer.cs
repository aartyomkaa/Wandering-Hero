using System;
using System.Collections.Generic;
using UnityEngine;
using Animation;
using Enemy;
using GameLogic;

namespace Player
{
    internal class Wanderer : Moveable
    {
        [SerializeField] private int _maxHealth;

        private Queue<Vector3> _path = new Queue<Vector3>();
        private int _currentHealth;

        private int _enemiesDefeated;
        private bool _hasStar;

        public int Health => _currentHealth;
        public int MaxHealth => _maxHealth;
        public int EnemiesDefeated => _enemiesDefeated;
        public bool HasStar => _hasStar;

        public event Action<int> HealthChanged;
        public event Action<bool> Moving;
        public event Action Finished;
        public event Action Interact;
        public event Action Restart;
        public event Action Attack;
        public event Action Death;

        private void Update()
        {
            if (WandererAnimator.IsPlaying == true)
                return;

            if (CanMove == false)
                return;

            if (_path.Count > 0)
            {
                Move(CanMove, _path.Dequeue());
                Moving?.Invoke(CanMove);
            }

            CanMove = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            CanMove = false;
            Move(CanMove, transform.position);
            Moving?.Invoke(CanMove);

            RotateTowards(other.transform.position);

            if (other.gameObject.TryGetComponent<Skeleton>(out Skeleton enemy))
            {
                Fight();
            }
            else if (other.gameObject.TryGetComponent<InterestTile>(out InterestTile tile))
            {
                if (tile is Finish)
                    Finished?.Invoke();

                if (tile is not Finish)
                    Interact?.Invoke();

                if (tile is Heal)
                    RestoreHealth();

                if (tile is Upgrade)
                    Upgrade();
            }

            CanMove = true;
        }

        public void AddRoad(Vector3 roadPosition)
        {
            if (roadPosition != null)
                _path.Enqueue(roadPosition);
        }

        public void StartMove(Vector3 endPosition)
        {
            _path.Dequeue();
            CanMove = true;
        }

        public void Init(Vector3 startPosition)
        {
            _enemiesDefeated = 0;
            _hasStar = false;

            CanMove = false;
            Moving?.Invoke(CanMove);
            Move(CanMove, startPosition);
            _path.Clear();

            transform.position = startPosition + Constants.StaticVariables.Offset;
            transform.rotation = Quaternion.identity;

            _currentHealth = _maxHealth;
            HealthChanged?.Invoke(_currentHealth);
            Restart?.Invoke();
        }

        private void Fight()
        {
            _currentHealth--;
            HealthChanged?.Invoke(_currentHealth);

            if (_currentHealth == 0)
            {
                Death?.Invoke();
                Move(false, transform.position);
                _path?.Clear();
            }
            else
            {
                Attack?.Invoke();
                _enemiesDefeated++;
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

        private void Upgrade()
        {
            _hasStar = true;
        }
    }
}