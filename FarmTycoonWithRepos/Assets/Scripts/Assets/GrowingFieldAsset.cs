using System.Collections.Generic;
using UnityEngine;

public class GrowingFieldAsset : MonoBehaviour
{
    private string _name;
    private string _description;
    private int _maxItemsCount;
    private GameObject _prefab;

    private List<GrowingItem> _acceptableItems;

    private const float _itemsUpdateTimeSeconds = 60;
    private float _timeWithoutItemsUpdate;

    private FieldInventory _fieldInventory;
    private InFieldItemsHandler _inFieldItemsHandler;


    public GrowingFieldAsset(GrowingField field, Vector3 position)
    {
        _name = field.Name;
        _description = field.Description;
        _acceptableItems = field.AcceptableItems;
        _prefab = field.Prefab;
        GameObject.Instantiate(_prefab, position, Quaternion.identity);
        _prefab.transform.position = position;
        
        var spawnPoints = new List<Vector3>();
        for (int i = 0; i < _prefab.transform.childCount; i++)
        {
            var child = _prefab.transform.GetChild(i);
            if (child.name == "SpawnPoint") spawnPoints.Add(child.transform.position);
        }
        if (spawnPoints.Count != field.MaxItemsCount) Debug.LogError("Количество спавнпоинтов не равно максимально возможному!!!");
        
        _maxItemsCount = spawnPoints.Count;
        _fieldInventory = new FieldInventory(_maxItemsCount);
        _inFieldItemsHandler = new InFieldItemsHandler(spawnPoints);
        _timeWithoutItemsUpdate = 0;
    }

    public void Add(GrowingItem item)
    {
        if (_fieldInventory.IsFreePlaceExist && _inFieldItemsHandler.IsFreePlaceExist && _acceptableItems.Contains(item))
            _fieldInventory.AddItem(new GrowingItemAsset(item, _inFieldItemsHandler.FreePlace));
    }

    private void Update()
    {
        if (_timeWithoutItemsUpdate >= _itemsUpdateTimeSeconds)
        {
            _timeWithoutItemsUpdate = 0;
            UpdateItemsTime();
        }
        else
        {
            _timeWithoutItemsUpdate += Time.deltaTime;
        }
    }

    private void UpdateItemsTime()
    {
        foreach(var item in _fieldInventory.Items)
        {
            item.UpdateLifeTime(_itemsUpdateTimeSeconds);
        }
    }
}
