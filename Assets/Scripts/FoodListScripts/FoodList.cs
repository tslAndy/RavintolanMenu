using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoodScripts;

namespace FoodListScripts
{
    [CreateAssetMenu(menuName = "Food List")]
    public class FoodList : ScriptableObject
    {
        [SerializeField] private List<Good> foods;
        public List<Good> Foods => foods;
    }
}
