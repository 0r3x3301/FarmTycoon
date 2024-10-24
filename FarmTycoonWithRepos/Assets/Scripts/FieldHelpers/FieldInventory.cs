using System.Collections.Generic;
using UnityEngine;

public class FieldInventory
{
    private List<GrowingItemAsset> _items;
    private int _maxItemsCount;

    public bool IsFreePlaceExist { get { return _items.Count < _maxItemsCount; } }
    public IEnumerable<GrowingItemAsset> Items => _items;

    public FieldInventory(int maxItemsCount)
    {
        _maxItemsCount = maxItemsCount;
        _items = new List<GrowingItemAsset>(maxItemsCount);
    }

    public void AddItem(GrowingItemAsset item)
    {
        if (IsFreePlaceExist)
        {
            _items.Add(item);
            item.OnGrown += OnItemGrown;
        }
    }

    private void OnItemGrown(GrowingItemAsset item)
    {
        item.OnGrown -= OnItemGrown;
        Debug.Log($"Âûנמס ןנוהלוע {item.Name}");
        _items.Remove(item);
    }
}
