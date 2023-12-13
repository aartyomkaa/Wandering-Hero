using System;
using UnityEngine;

namespace Shop
{
    internal class Hero : MonoBehaviour,IItem
    {
        [SerializeField] private Sprite _image;
        [SerializeField] private int _price;

        private bool _isUnlocked;

        public bool IsUnlocked => _isUnlocked;

        public int Price => _price;

        public Sprite Image => _image;

        public void Unlock()
        {
            throw new NotImplementedException();
        }
    }
}
