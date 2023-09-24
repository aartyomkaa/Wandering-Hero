using Player;
using System;

namespace GameLogic
{
    internal class Finish : InterestTile
    {
        public event Action Finished;

        protected override void Interact(Wanderer wanderer)
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = false;

                Finished?.Invoke();
            }
        }

        public override void Restart()
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = true;
            }
        }
    }
}