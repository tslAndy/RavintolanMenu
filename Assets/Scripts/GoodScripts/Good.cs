using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoodScripts
{
    [CreateAssetMenu(menuName = "Goods")]
    public class Good : ScriptableObject
    {
        [SerializeField] private string goodName, goodComposition, dietMarks;
        [SerializeField] private int goodPrice;

        public string GoodName => goodName;
        public string GoodComposition => goodComposition;
        public string DietMarks => dietMarks;
        public int GoodPrice => goodPrice;
    }
}
