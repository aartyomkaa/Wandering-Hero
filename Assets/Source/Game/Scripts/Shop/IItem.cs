using UnityEngine;

namespace Shop
{
    internal interface  IItem
    {
        public Sprite Image { get; }

        public bool IsUnlocked { get; }

        public int Price { get; }

        public void Unlock();
    }
}
