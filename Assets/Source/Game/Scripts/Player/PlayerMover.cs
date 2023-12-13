using System.Collections.Generic;
<<<<<<< HEAD
=======
using Audio;
using GameLogic;
>>>>>>> NewPatch
using UnityEngine;
using GameLogic;

namespace Wanderer
{
    [RequireComponent(typeof(PlayerAnimator))]
    internal class PlayerMover : Moveable
    {
<<<<<<< HEAD
        private static Vector3 Offset = new Vector3(0, 1, 0);

        [SerializeField] private AudioSource _audioSource;
=======
        [SerializeField] private StepsSound _stepsSound;
>>>>>>> NewPatch

        private PlayerAnimator _animator;

        private bool _isDead = false;
        private Queue<Vector3> _path = new Queue<Vector3>();

        private void Start()
        {
            _animator = GetComponent<PlayerAnimator>();
        }

        private void Update()
        {
            if (_animator.IsPlaying || _isDead)
                return;

            if (CanMove == false)
                return;

            if (_path.Count > 0)
            {
                Move(CanMove, _path.Dequeue());
                _animator.Walk(CanMove);

<<<<<<< HEAD
                _audioSource.Play();
=======
                _stepsSound.Play();
>>>>>>> NewPatch
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

        public void AddRoad(Vector3 roadPosition)
        {
            if (roadPosition != null)
                _path.Enqueue(roadPosition);
        }

        public void Init(Vector3 startPosition)
        {
            CanMove = false;
            _isDead = false;
            _animator.Walk(CanMove);
            Move(CanMove, startPosition);
            _path.Clear();

            transform.position = startPosition + Offset;
            transform.rotation = Quaternion.identity;
        }

        public void OnDeath()
        {
            StopMove();
            _isDead = true;
        }

        private void Rotate(Vector3 target)
        {
            RotateTowards(target);
        }

        private void StopMove()
        {
            CanMove = false;
            Move(CanMove, transform.position);
            _animator.Walk(CanMove);
        }
    }
}
