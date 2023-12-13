<<<<<<< HEAD
using UnityEngine;
using UI;
using Wanderer;
=======
using UI;
using UnityEngine;
>>>>>>> NewPatch

namespace GameLogic
{
    internal class Upgrade : InterestTile
    {
<<<<<<< HEAD
        private static Vector3 IndicatorOffset = new Vector3(0, 2, 0);

        [SerializeField] private Indicator _swordTemplate;
=======
        [SerializeField] private Indicator _starTemplate;
>>>>>>> NewPatch

        private Camera _camera;
        private Indicator _star;

        private void Start()
        {
            _camera = Camera.main;

<<<<<<< HEAD
            _sword = Instantiate(_swordTemplate, transform.position + IndicatorOffset, Quaternion.identity, transform);
            Vector3 direction = _camera.transform.position - _sword.transform.position;
            _sword.transform.rotation = Quaternion.LookRotation(direction);
=======
            _star = Instantiate(_starTemplate, transform.position + Constants.StaticVariables.IndicatorOffset, Quaternion.identity, transform);
            Vector3 direction = _camera.transform.position - _star.transform.position;
            _star.transform.rotation = Quaternion.LookRotation(direction);
>>>>>>> NewPatch
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