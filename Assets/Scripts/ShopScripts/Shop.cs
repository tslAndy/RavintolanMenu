using System.Collections.Generic;
using UnityEngine;
using Utils;
using GoodScripts;
using System.Linq;

namespace ShopScripts
{
    public class Shop : Singleton<Shop>
    {
        [SerializeField] private ShopUI shopUI;

        private readonly List<Good> _goods = new();

        public void PutToShoppingCart(Good good)
        {
            _goods.Add(good);
            shopUI.UpdateTotalPrice(CountTotalPrice());
        }

        public void RemoveFromShoppingCart(Good good)
        {
            _goods.Remove(good);
            shopUI.UpdateTotalPrice(CountTotalPrice());
        }

        private float CountTotalPrice() => _goods.Sum(good => good.GoodPrice);
    }
}
