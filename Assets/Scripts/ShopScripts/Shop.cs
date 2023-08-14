using System.Collections.Generic;
using UnityEngine;
using Utils;
using GoodScripts;
using System.Linq;
using System.Collections;

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

        public void MakeOrder(string customerName)
        {
            Order order = new Order(_goods, customerName, CountTotalPrice());
            SaveSystem.SaveOrder(order);
            StartCoroutine(ShopReloadCoroutine());
        }

        private IEnumerator ShopReloadCoroutine()
        {
            yield return new WaitForSeconds(1);
            SceneLoader.LoadScene("Shop");
        }
    }
}
