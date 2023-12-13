using GameLogic;
using UnityEngine;

namespace Shop
{
    internal class Store : UI.Screen
    {
        [SerializeField] private CoinsWallet _wallet;
        [SerializeField] private Map _map;

        public void ProceedToBuy(IItem item)
        {
            if (_wallet.Value >= item.Price)
            {
                _wallet.Spend(item.Price);
                item.Unlock();
            }
        }

        public void ProceedToSelect<T>(T item) where T : IItem
        {
            if (item is MapStyle)
            {
                _map.ChangeStyle(item as MapStyle);
            }
            else if (item is Hero)
            {

            }
        }
    }
}
