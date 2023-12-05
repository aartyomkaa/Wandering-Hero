using System.Collections;
using UnityEngine;
using Constants;
using Wanderer;

namespace NPC
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Animator))]
    internal class Skeleton : Enemy
    {
        [SerializeField] private float _animationTime;

        private BoxCollider[] _colliders;
        private Quaternion _rotation;

        private Animator _animator;
        private Coroutine _animation;
        private float _animationDuration;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _colliders = GetComponents<BoxCollider>();

            _rotation = transform.rotation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player player))
            {
                Interact(player);
            }
        }

        public override void Restart()
        {
            _animator.SetTrigger(StaticVariables.Restart);
            transform.rotation = _rotation;

            foreach (var collider in _colliders)
            {
                collider.enabled = true;
            }
        }

        protected override void Interact(Player wanderer)
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = false;
            }

            RotateTowards(wanderer.transform.position);

            if (wanderer.TryGetComponent<PlayerHealth>(out PlayerHealth player))
                Attack(player);
        }

        private void Attack(PlayerHealth wanderer)
        {
            _animator.SetTrigger(StaticVariables.Attack);
            AudioSource.Play();

            if (wanderer.Health > 0)
                Die();
            else
                _animator.SetTrigger(StaticVariables.Dance);
        }

        private void Die()
        {
            _animator.SetTrigger(StaticVariables.Death);
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
            while (_animationDuration <= _animationTime)
            {
                _animationDuration += Time.deltaTime;

                yield return Time.deltaTime;
            }

            gameObject.SetActive(false);
        }
    }
}