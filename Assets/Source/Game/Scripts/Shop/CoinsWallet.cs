using Constants;
using System;
using UnityEngine;

namespace Shop
{
    internal class CoinsWallet : MonoBehaviour
    {
        [SerializeField] private int _value;

        public int Value => _value;

        public Action<int> OnCoinsChanged;

        private void Start()
        {
            UpdateCoins();

            _value = PlayerPrefs.GetInt(StaticVariables.Coins);
        }

        public void Add(int amount)
        {
            _value += amount;

            UpdateCoins();
        }

        public void Spend(int amount)
        {
            if (amount <= _value)
            {
                _value -= amount;
            }

            UpdateCoins();
        }

        private void UpdateCoins()
        {
            OnCoinsChanged?.Invoke(_value);

            PlayerPrefs.SetInt(StaticVariables.Coins, _value);
        }
    }
}
