using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GoodScripts;
using FoodListScripts;


namespace ShopScripts
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private string currency;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text totalPriceText;
        [SerializeField] private Transform menuSectionTransform;
        [SerializeField] private GameObject foodMenuPrefab;
        [SerializeField] private GoodUI goodPrefab;
        [SerializeField] private float yDistanceBetweenGoods;

        private readonly Dictionary<FoodList, GameObject> _foodListMenu = new();
        private FoodList _currentFoodList = null;

        public void LoadMenu(FoodList foodList)
        {
            // if try to load same menu
            if (foodList == _currentFoodList)
                return;

            // if we already have spawned menu
            if (_foodListMenu.ContainsKey(foodList))
            {
                _foodListMenu[_currentFoodList].SetActive(false);

                // new food list
                _currentFoodList = foodList;
                _foodListMenu[_currentFoodList].SetActive(true);
                return;
            }

            // if should spawn menu
            if (_currentFoodList != null)
                _foodListMenu[_currentFoodList].SetActive(false);


            GameObject newMenu = Instantiate(foodMenuPrefab, menuSectionTransform);
            Transform spawnStartTransform = newMenu.transform.GetChild(0);
            for (int i = 0; i < foodList.Foods.Count; i++)
            {
                GoodUI good = Instantiate(goodPrefab, newMenu.transform);
                good.InitGood(foodList.Foods[i]);
                good.transform.position = spawnStartTransform.position + i * yDistanceBetweenGoods * Vector3.down;
            }
            _foodListMenu.Add(foodList, newMenu);
            _currentFoodList = foodList;

        }

        public void UpdateTotalPrice(float price)
        {
            totalPriceText.SetText($"Total: {String.Format("{0:0.00}", price)} {currency}");
        }

        public void Order()
        {
            Shop.Instance.MakeOrder(nameText.text);
        }
    }
}