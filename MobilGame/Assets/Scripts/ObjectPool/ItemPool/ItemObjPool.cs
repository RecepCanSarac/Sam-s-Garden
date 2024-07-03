using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjPool : MonoBehaviour
{
    private const int itemPool_SIZE = 80;
    public GameObject ItemPrefab;
    public Queue<GameObject> itemPool;
    void Start()
    {
        itemPool = new Queue<GameObject>();

        for (int i = 0; i < itemPool_SIZE; i++)
        {
            GameObject item = Instantiate(ItemPrefab, transform);
            item.SetActive(false);
            itemPool.Enqueue(item);
        }
    }

    public GameObject GetpoolFromItem()
    {
        if (itemPool.Count > 0)
        {
            GameObject item = itemPool.Dequeue();
            item.SetActive(true);
            return item;
        }
        return null;
    }

    public void ReturnItemPool(GameObject item)
    {
        item.SetActive(false);
        itemPool.Enqueue(item);
    }
}
