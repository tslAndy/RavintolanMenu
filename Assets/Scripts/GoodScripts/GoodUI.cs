using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ShopScripts;

namespace GoodScripts
{
    public class GoodUI : MonoBehaviour
    {
        [SerializeField] private Good good;
        [SerializeField] private TMP_Text goodName, goodComposition, dietMarks, goodPrice;
        [SerializeField] private Toggle productChooseToggle;

        private void Start()
        {
            goodName.SetText(good.GoodName);
            goodComposition.SetText(good.GoodComposition);
            dietMarks.SetText(good.DietMarks);
            goodPrice.SetText(good.GoodPrice.ToString());
            productChooseToggle.onValueChanged.AddListener(
                delegate
                {
                    OnProductToggleValueChanged();
                });
        }

        private void OnProductToggleValueChanged()
        {
            if (productChooseToggle.isOn)
                Shop.Instance.PutToShoppingCart(good);
            else
                Shop.Instance.RemoveFromShoppingCart(good);
        }
    }
}