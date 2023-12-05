using UnityEngine;
using UI;
using Wanderer;

namespace GameLogic
{
    internal class Heal : InterestTile
    {
        [SerializeField] private Indicator _heartTemplate;

        private Camera _camera;
        private Indicator _heart;

        private void Start()
        {
            _camera = Camera.main;

            _heart = Instantiate(_heartTemplate, transform.position + Constants.StaticVariables.IndicatorOffset, Quaternion.identity, transform);
            Vector3 direction = _camera.transform.position - _heart.transform.position;
            _heart.transform.rotation = Quaternion.LookRotation(-direction);
        }

        public override void Restart()
        {
            _heart.gameObject.SetActive(true);

            foreach (var collider in _colliders)
            {
                collider.enabled = true;
            }
        }

        protected override void Interact(Wanderer.Player wanderer)
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = false;

                _heart.Disappear();
            }
        }
    }
}