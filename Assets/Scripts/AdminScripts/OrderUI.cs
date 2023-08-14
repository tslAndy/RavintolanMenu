using System;
using System.Linq;
using UnityEngine;
using TMPro;

namespace AdminScripts
{
    public class OrderUI : MonoBehaviour
    {
        [SerializeField] private string currency;
        [SerializeField] private TMP_Text orderGoods, customerName, totalPrice;

        public void InitOrderUI(Order order)
        {
            string goods = String.Join(", ", order.GoodDatas.Select(x => x.GoodName));
            orderGoods.SetText(goods);
            customerName.SetText(order.CustomerName);
            totalPrice.SetText($"{order.TotalPrice} {currency}");
        }
    }
}
