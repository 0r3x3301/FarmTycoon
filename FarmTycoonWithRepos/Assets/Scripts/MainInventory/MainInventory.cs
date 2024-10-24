using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : MonoBehaviour 
{
    private static InventoryLoader _inventoryLoader;
    private static InventorySaver _inventorySaver;
    private static Dictionary<int, int> _items;
    public static IReadOnlyDictionary<int, int> Items => _items;


    private void Awake()
    {
        _inventoryLoader = new InventoryLoader();
        _inventorySaver = new InventorySaver();
        _items = new Dictionary<int, int>();
    }

    public static void Add(int id, int count = 1)
    {
        if (_items.ContainsKey(id))
        {
            _items[id] += count;
        }
        else
        {
            _items.Add(id, count);
        }
        _inventorySaver.Save();
        Debug.Log($"Added {id}, all count: {_items[id]}");
    }

    public static void Remove(int id, int count = 1)
    {
        if (_items.ContainsKey(id))
        {
            _items[id] -= count;
            if (_items[id] <= 0) _items.Remove(id);
        }
    }

    private class InventoryLoader
    {
        public void Load()
        {
            Debug.Log("Inventory Loaded");
        }
    }

    private class InventorySaver
    {
        public void Save()
        {
            Debug.Log("Inventory Saved");
        }
    }
}
