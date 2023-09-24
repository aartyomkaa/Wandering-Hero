using Player;
using UnityEngine;
using UI;

namespace GameLogic
{
    internal class Heal : InterestTile
    {
        [SerializeField] private Indicator _heartTemplate;

        private Indicator _heart;

        private void Start()
        {
            _heart = Instantiate(_heartTemplate, transform.position + StaticVariables.IndicatorOffset, Quaternion.identity, transform);
        }

        public override void Restart()
        {
            _heart.gameObject.SetActive(true);

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

                _heart.Disappear();
            }
        }
    }
}