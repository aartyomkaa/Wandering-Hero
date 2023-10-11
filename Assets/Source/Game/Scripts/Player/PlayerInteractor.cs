using GameLogic;
using System;
using UnityEngine;

namespace Wanderer
{
    internal class PlayerInteractor : PlayerComponent
    {
        private bool _hasStar;

        public bool HasStar => _hasStar;

        public event Action Finished;

        public override void Init()
        {
            _hasStar = false;
        }

        protected override void Interact(Collider other)
        {
            if (other.gameObject.TryGetComponent<InterestTile>(out InterestTile tile))
            {
                if (tile is Finish)
                    Finished?.Invoke();

                if (tile is Upgrade)
                {
                    AudioSource.Play();
                    Upgrade();
                }     
            }
        }

        private void Upgrade()
        {
            _hasStar = true;
        }
    }
}