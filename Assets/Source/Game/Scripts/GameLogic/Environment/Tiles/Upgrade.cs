using UnityEngine;
using Wanderer;
using UI;

namespace GameLogic
{
    internal class Upgrade : InterestTile
    {
        [SerializeField] private Indicator _swordTemplate;

        private Camera _camera;
        private Indicator _sword;

        private void Start()
        {
            _camera = Camera.main;

            _sword = Instantiate(_swordTemplate, transform.position + Constants.StaticVariables.IndicatorOffset, Quaternion.identity, transform);
            Vector3 direction = _camera.transform.position - _sword.transform.position;
            _sword.transform.rotation = Quaternion.LookRotation(direction);
        }

        public override void Restart()
        {
            _sword.gameObject.SetActive(true);

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

                _sword.Disappear();
            }
        }
    }
}