using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoodScripts
{
    [Serializable]
    public class GoodData
    {
        public string GoodName { get; private set; }
        public string GoodComposition { get; private set; }
        public string DietMarks { get; private set; }
        public float GoodPrice { get; private set; }

        public GoodData(Good good)
        {
            GoodName = good.GoodName;
            GoodComposition = good.GoodComposition;
            DietMarks = good.DietMarks;
            GoodPrice = good.GoodPrice;
        }
    }
}
