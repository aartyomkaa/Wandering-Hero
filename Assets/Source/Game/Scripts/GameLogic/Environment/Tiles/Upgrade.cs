using UnityEngine;
using Player;
using UI;

namespace GameLogic
{
    internal class Upgrade : InterestTile
    {
        [SerializeField] private Indicator _swordTemplate;

        private Indicator _sword;

        private void Start()
        {
            _sword = Instantiate(_swordTemplate, transform.position + StaticVariables.IndicatorOffset, Quaternion.identity, transform);
        }

        public override void Restart()
        {
            _sword.gameObject.SetActive(true);

            foreach (var collider in _colliders)
            {
                collider.enabled = true;
            }
        }

        protected override void Interact(Wanderer wanderer)
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = false;

                _sword.Disappear();
            }
        }
    }
}