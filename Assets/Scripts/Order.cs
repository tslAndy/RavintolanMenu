using System.Collections.Generic;
using System;
using GoodScripts;

[Serializable]
public class Order
{
    public List<Good> Goods { get; private set; }
    public string CustomerName { get; private set; }
    public float TotalPrice { get; private set; }
}
