using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveOrder(Order order)
    {

        BinaryFormatter formatter = new();
        string path = Path.Combine(Application.persistentDataPath, "Orders", $"{order}_{order.GetHashCode()}");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, order);
        stream.Close();
    }

    private static Order LoadOrder(string path)
    {
        if (!File.Exists(path))
            return null;

        BinaryFormatter binaryFormatter = new();
        FileStream stream = new FileStream(path, FileMode.Open);
        Order order = binaryFormatter.Deserialize(stream) as Order;
        return order;
    }

    public static Order[] LoadAllOrders()
    {
        string path = Path.Combine(Application.persistentDataPath, "Orders");
        string[] orderPaths = Directory.GetFiles(path);
        Order[] orders = new Order[orderPaths.Length];
        for (int i = 0; i < orders.Length; i++)
            orders[i] = LoadOrder(orderPaths[i]);
        return orders;
    }
}
