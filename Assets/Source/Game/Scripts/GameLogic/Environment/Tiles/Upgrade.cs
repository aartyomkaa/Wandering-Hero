using UI;
using UnityEngine;

namespace GameLogic
{
    internal class Upgrade : InterestTile
    {
        [SerializeField] private Indicator _starTemplate;

        private Camera _camera;
        private Indicator _star;

        private void Start()
        {
            _camera = Camera.main;

            _star = Instantiate(_starTemplate, transform.position + Constants.StaticVariables.IndicatorOffset, Quaternion.identity, transform);
            Vector3 direction = _camera.transform.position - _star.transform.position;
            _star.transform.rotation = Quaternion.LookRotation(direction);
        }

        public override void Restart()
        {
            _star.gameObject.SetActive(true);

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

                _star.Disappear();
            }
        }
    }
}