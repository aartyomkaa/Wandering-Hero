using System.Collections;
using UnityEngine;
using Constants;
using GameLogic;
using NPC;

namespace Wanderer
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Player))]
    internal class PlayerAnimator : PlayerComponent
    {
        [SerializeField] private float _animationTime;

        private Animator _animator;
        private Coroutine _animation;
        private float _animationDuration;
        private bool _isPlaying;

        public bool IsPlaying => _isPlaying;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public override void Init()
        {
            _animator.SetBool(StaticVariables.Death, false);
        }

        public void Walk(bool isWalking)
        {
            _animator.SetBool(StaticVariables.Walking, isWalking);
        }

        public void Death()
        {
            _animator.SetBool(StaticVariables.Death, true);

            StartCoroutine();
        }

        protected override void Interact(Collider other)
        {
            if (other.gameObject.TryGetComponent<InterestTile>(out InterestTile tile))
            {
                if (tile is not Finish)
                    Interact();
            }
            else if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Attack();
            }
        }

        private void Attack()
        {
            _animator.SetTrigger(StaticVariables.Attack);

            StartCoroutine();
        }

        private void Interact()
        {
            _animator.SetTrigger(StaticVariables.Intercat);

            StartCoroutine();
        }

        private void StartCoroutine()
        {
            if (_animation != null)
                StopCoroutine(_animation);

            _animationDuration = 0f;
            _animation = StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            _isPlaying = true;

            while (_animationDuration <= _animationTime)
            {
                _animationDuration += Time.deltaTime;

                yield return Time.deltaTime;
            }

            _isPlaying = false;
        }
    }
}