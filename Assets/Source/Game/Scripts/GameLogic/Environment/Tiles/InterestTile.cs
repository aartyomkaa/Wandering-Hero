using UnityEngine;
using Player;

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
            if (other.gameObject.TryGetComponent<Wanderer>(out Wanderer wanderer))
            {
                Interact(wanderer);
            }
        }

        protected virtual void Interact(Wanderer wanderer)
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = false;
            }
        }
    }
}