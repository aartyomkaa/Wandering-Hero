using System.Collections;
using UnityEngine;
using Player;
using Constants;

namespace Animation
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Wanderer))]
    internal class WandererAnimator : MonoBehaviour
    {
        [SerializeField] private float _animationTime;

        private Animator _animator;
        private Wanderer _wanderer;

        private Coroutine _animation;
        private float _animationDuration;
        private static bool _isPlaying;

        public static bool IsPlaying => _isPlaying;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _wanderer = GetComponent<Wanderer>();
        }

        private void OnEnable()
        {
            _wanderer.Moving += OnWalk;
            _wanderer.Attack += OnAttack;
            _wanderer.Interact += OnInteract;
            _wanderer.Death += OnDeath;
            _wanderer.Restart += OnRestart;
        }

        private void OnDisable()
        {
            _wanderer.Moving -= OnWalk;
            _wanderer.Attack -= OnAttack;
            _wanderer.Interact -= OnInteract;
            _wanderer.Death -= OnDeath;
            _wanderer.Restart -= OnRestart;
        }

        private void OnWalk(bool isWalking)
        {
            _animator.SetBool(StaticVariables.Walking, isWalking);

            if (isWalking)
                AudioController.Instance.Play(StaticVariables.WalkSound);
            else
                AudioController.Instance.Stop(StaticVariables.WalkSound);
        }

        private void OnAttack()
        {
            _animator.SetTrigger(StaticVariables.Attack);
            AudioController.Instance.Play(StaticVariables.AttackSound);

            StartCoroutine();
        }

        private void OnInteract()
        {
            _animator.SetTrigger(StaticVariables.Intercat);
            AudioController.Instance.Play(StaticVariables.InteractSound);

            StartCoroutine();
        }

        private void OnDeath()
        {
            _animator.SetBool(StaticVariables.Death, true);

            StartCoroutine();
        }

        private void OnRestart()
        {
            _animator.SetBool(StaticVariables.Death, false);
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