using GameLogic;
using Player;

namespace NPC
{
    internal abstract class Enemy : Moveable
    {
        public abstract void Restart();

        protected abstract void Interact(Wanderer wanderer);
    }
}