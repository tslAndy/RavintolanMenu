using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ShopScripts;
using System;

namespace GoodScripts
{
    public class GoodUI : MonoBehaviour
    {
        [SerializeField] private Image panelBackground;
        [SerializeField] private Color idleColor, choosenColor;
        [SerializeField] private TMP_Text goodName, goodComposition, dietMarks, goodPrice;
        [SerializeField] private Toggle productChooseToggle;

        private void Start()
        {
            panelBackground.color = idleColor;
        }

        public void InitGood(Good good)
        {
            goodName.SetText(good.GoodName);
            goodComposition.SetText(good.GoodComposition);
            dietMarks.SetText(good.DietMarks);
            goodPrice.SetText(String.Format("{0:0.00}", good.GoodPrice));

            productChooseToggle.onValueChanged.AddListener(
                delegate
                {
                    OnProductToggleValueChanged(good);
                });
        }

        private void OnProductToggleValueChanged(Good good)
        {
            if (productChooseToggle.isOn)
            {
                panelBackground.color = choosenColor;
                Shop.Instance.PutToShoppingCart(good);
            }
            else
            {
                panelBackground.color = idleColor;
                Shop.Instance.RemoveFromShoppingCart(good);
            }

        }
    }
}