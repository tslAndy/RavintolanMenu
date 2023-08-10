using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShopScripts;
using FoodListScripts;

public class Test : MonoBehaviour
{
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private FoodList foodList;

    private void Start()
    {
        shopUI.LoadMenu(foodList);
    }
}
