using GameLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    [RequireComponent(typeof(PlayerAnimator))]
    internal class PlayerMover : Moveable
    {
        [SerializeField] private AudioSource _audioSource;

        private PlayerAnimator _animator;

        private float _minPitch = 0.7f;
        private float _maxPitch = 1.1f;

        private Queue<Vector3> _path = new Queue<Vector3>();

        private void Start()
        {
            _animator = GetComponent<PlayerAnimator>();
        }

        private void Update()
        {
            if (_animator.IsPlaying == true)
                return;

            if (CanMove == false)
                return;

            if (_path.Count > 0)
            {
                Move(CanMove, _path.Dequeue());
                _animator.Walk(CanMove);

                _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
                _audioSource.Play();
            }

            CanMove = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            StopMove();
            Rotate(other.transform.position);

            CanMove = true;
        }

        public void StartMove(Vector3 endPosition)
        {
            AddRoad(endPosition);

            _path.Dequeue();
            CanMove = true;
        }

        public void StopMove()
        {
            CanMove = false;
            Move(CanMove, transform.position);
            _animator.Walk(CanMove);
        }

        public void AddRoad(Vector3 roadPosition)
        {
            if (roadPosition != null)
                _path.Enqueue(roadPosition);
        }

        public void Init(Vector3 startPosition)
        {
            CanMove = false;
            _animator.Walk(CanMove);
            Move(CanMove, startPosition);
            _path.Clear();

            transform.position = startPosition + Constants.StaticVariables.Offset;
            transform.rotation = Quaternion.identity;
        }

        private void Rotate(Vector3 target)
        {
            RotateTowards(target);
        }
    }
}
