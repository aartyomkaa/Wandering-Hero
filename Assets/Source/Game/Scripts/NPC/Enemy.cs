using GameLogic;
using UnityEngine;
using Wanderer;

namespace NPC
{
    internal abstract class Enemy : Moveable
    {
        [SerializeField] protected AudioSource AudioSource;

        public abstract void Restart();

        protected abstract void Interact(Player wanderer);
    }
}