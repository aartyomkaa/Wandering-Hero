using UnityEngine;
using Wanderer;

namespace GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    internal abstract class InterestTile : Tile
    {
        protected BoxCollider[] _colliders;

        protected void Awake()
        {
            _colliders = GetComponents<BoxCollider>();
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player wanderer))
            {
                Interact(wanderer);
            }
        }

        protected virtual void Interact(Wanderer.Player wanderer)
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = false;
            }
        }
    }
}