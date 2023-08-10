using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GoodScripts;
using FoodListScripts;


namespace ShopScripts
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text totalPriceText;
        [SerializeField] private Transform menuSectionTransform;
        [SerializeField] private GameObject foodMenuPrefab;
        [SerializeField] private GoodUI goodPrefab;

        private Dictionary<FoodList, GameObject> _foodListMenu = new();
        private FoodList currentFoodList = null;

        public void LoadMenu(FoodList foodList)
        {
            // if try to load same menu
            if (foodList == currentFoodList)
                return;

            // if we already have spawned menu
            if (_foodListMenu.ContainsKey(foodList))
            {
                // if another menu was loaded
                if (currentFoodList != null)
                    _foodListMenu[currentFoodList].SetActive(false);

                // new food list
                currentFoodList = foodList;
                _foodListMenu[currentFoodList].SetActive(true);
                return;
            }

            // if should spawn menu
            GameObject newMenu = Instantiate(foodMenuPrefab, menuSectionTransform);
        }

        public void UpdateTotalPrice(float price)
        {
            totalPriceText.SetText(price.ToString());
        }
    }
}