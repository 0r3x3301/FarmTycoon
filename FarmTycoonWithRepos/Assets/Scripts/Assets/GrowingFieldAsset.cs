using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class GrowingFieldAsset
{
    private string _name;
    private string _description;
    private int _maxItemsCount;
    private GameObject _prefab;
    private Sprite _sprite;

    private List<GrowingItem> _acceptableItems;


    private FieldInventory _fieldInventory;
    private InFieldItemsHandler _inFieldItemsHandler;
    private TimerForItems _timerForItems;

    public string Name => _name;
    public string Description => _description;
    public Sprite Sprite => _sprite;
    public int MaxItemsCount => _maxItemsCount;


    public GrowingFieldAsset(GrowingField field, Vector3 position)
    {
        _name = field.Name;
        _description = field.Description;
        _acceptableItems = field.AcceptableItems;
        _prefab = GameObject.Instantiate(field.Prefab, position, Quaternion.identity); ;
        _prefab.transform.position = position;
        
        var spawnPoints = new List<Vector3>();
        for (int i = 0; i < _prefab.transform.childCount; i++)
        {
            var child = _prefab.transform.GetChild(i);
            if (child.name == "SpawnPoint") spawnPoints.Add(child.transform.position);
        }
        if (spawnPoints.Count != field.MaxItemsCount) Debug.LogError($"Количество спавнпоинтов не равно максимально возможному!!!, {spawnPoints.Count}, {field.MaxItemsCount}");
        
        _maxItemsCount = spawnPoints.Count;
        _fieldInventory = new FieldInventory(_maxItemsCount);
        _inFieldItemsHandler = new InFieldItemsHandler(spawnPoints);
        _timerForItems = _prefab.AddComponent<TimerForItems>();
        _timerForItems.OnUpdateItems += UpdateItemsTime;
    }

    public void Add(GrowingItem item)
    {
        if (_fieldInventory.IsFreePlaceExist && _inFieldItemsHandler.IsFreePlaceExist && _acceptableItems.Contains(item))
        {
            var newItem = new GrowingItemAsset(item, _inFieldItemsHandler.FreePlace);
            _fieldInventory.AddItem(newItem);
            _inFieldItemsHandler.Add(newItem);
        }
    }

    private void UpdateItemsTime(float seconds)
    {
        if (_fieldInventory.Items != null)
        {
            for(int i = 0; i < _fieldInventory.Items.Count(); i++)
            {
                _fieldInventory.Items.ElementAt(i).UpdateLifeTime(seconds);
            }
        }
    }

    public void DeleteField()
    {
        _timerForItems.OnUpdateItems -= UpdateItemsTime;
        GameObject.Destroy(_prefab);
    }

}
