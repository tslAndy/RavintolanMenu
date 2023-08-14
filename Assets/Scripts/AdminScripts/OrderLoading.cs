using System.Collections;
using System.Collections.Generic;
using AdminScripts;
using UnityEngine;

public class OrderLoading : MonoBehaviour
{
    [SerializeField] private OrderUI orderUIPrefab;
    [SerializeField] private Transform ordersTransform, startSpawnTransform;
    [SerializeField] private float yDistanceBetweenOrders;

    private void Start()
    {
        Order[] orders = SaveSystem.LoadAllOrders();
        for (int i = 0; i < orders.Length; i++)
        {
            OrderUI orderUI = Instantiate(orderUIPrefab, ordersTransform);
            orderUI.transform.position += Vector3.down * yDistanceBetweenOrders * i;
            orderUI.InitOrderUI(orders[i]);
        }
    }
}
