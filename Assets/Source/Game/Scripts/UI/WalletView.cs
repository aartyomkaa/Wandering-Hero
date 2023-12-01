using Shop;
using TMPro;
using UnityEngine;

namespace UI
{
    internal class WalletView : MonoBehaviour
    {
        [SerializeField] private CoinsWallet _wallet;
        [SerializeField] private TMP_Text _coins;

        private void OnEnable()
        {
            _wallet.OnCoinsChanged += OnCoinsChange;
        }

        private void OnDisable()
        {
            _wallet.OnCoinsChanged -= OnCoinsChange;
        }

        private void OnCoinsChange(int amount)
        {
            _coins.text = amount.ToString();
        }
    }
}
