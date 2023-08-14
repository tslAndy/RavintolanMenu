using System.Collections.Generic;
using System;
using GoodScripts;

[Serializable]
public class Order
{
    public List<GoodData> GoodDatas { get; private set; }
    public string CustomerName { get; private set; }
    public float TotalPrice { get; private set; }

    public Order(List<Good> goods, string customerName, float totalPrice)
    {
        GoodDatas = new();
        foreach (var good in goods)
            GoodDatas.Add(new GoodData(good));

        CustomerName = customerName;
        TotalPrice = totalPrice;
    }
}
