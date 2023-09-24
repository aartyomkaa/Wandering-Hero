using System.Collections;
using UnityEngine;

namespace GameLogic
{
    internal class Moveable : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        protected bool CanMove = false;

        private Coroutine _move;
        private Coroutine _rotate;

        protected void RotateTowards(Vector3 target)
        {
            if (_rotate != null)
                StopCoroutine(_rotate);

            _rotate = StartCoroutine(Rotate(target));
        }

        protected void Move(bool canMove, Vector3 targetPosition)
        {
            if (canMove == false && _move != null)
                StopCoroutine(_move);
            else
                _move = StartCoroutine(MoveTo(targetPosition));
        }

        protected IEnumerator MoveTo(Vector3 targetPosition)
        {
            targetPosition += StaticVariables.Offset;

            if (CanMove != false)
                RotateTowards(targetPosition);

            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

                yield return Time.deltaTime;
            }

            CanMove = true;
        }

        private IEnumerator Rotate(Vector3 target)
        {
            Vector3 direction = target - transform.position;

            if (target.y == 0)
                direction += StaticVariables.Offset;

            Quaternion rotation = Quaternion.LookRotation(direction);

            while (transform.rotation != rotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);

                yield return Time.deltaTime;
            }
        }
    }
}