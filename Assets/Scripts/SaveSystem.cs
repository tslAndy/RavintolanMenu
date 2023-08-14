using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static int orderNumber = 0;
    public static void SaveOrder(Order order)
    {
        BinaryFormatter formatter = new();
        string path = Path.Combine(Application.persistentDataPath, "Orders", $"{order}_{orderNumber}");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, order);
        stream.Close();
        orderNumber++;
    }

    public static Order LoadOrder(string orderName)
    {
        string path = Path.Combine(Application.persistentDataPath, "Orders", orderName);
        if (!File.Exists(path))
            return null;

        BinaryFormatter binaryFormatter = new();
        FileStream stream = new FileStream(path, FileMode.Open);
        Order order = binaryFormatter.Deserialize(stream) as Order;
        return order;
    }
}
