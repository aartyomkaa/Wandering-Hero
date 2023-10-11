using GameLogic;
using Wanderer;
using UnityEngine;

namespace NPC
{
    internal abstract class Enemy : Moveable
    {
        [SerializeField] protected AudioSource AudioSource;

        public abstract void Restart();

        protected abstract void Interact(Player wanderer);
    }
}