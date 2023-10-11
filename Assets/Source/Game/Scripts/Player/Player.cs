using GameLogic;
using UnityEngine;

namespace Wanderer
{
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerMover))]
    internal class Player : Moveable
    {
        private PlayerMover _mover;
        private PlayerAnimator _animator;

        private void Start()
        {
            _animator = GetComponent<PlayerAnimator>();
            _mover = GetComponent<PlayerMover>();
        }

        public void Die()
        {
            _animator.Death();
            _mover.StopMove();
        }
    }
}