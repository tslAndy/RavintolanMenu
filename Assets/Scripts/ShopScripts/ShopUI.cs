using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace ShopScripts
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text totalPriceText;

        public void UpdateTotalPrice(int price)
        {
            totalPriceText.SetText(price.ToString());
        }
    }
}