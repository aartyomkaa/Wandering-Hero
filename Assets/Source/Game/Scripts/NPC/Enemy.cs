<<<<<<< HEAD
﻿using UnityEngine;
using GameLogic;
=======
﻿using GameLogic;
using UnityEngine;
>>>>>>> NewPatch
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