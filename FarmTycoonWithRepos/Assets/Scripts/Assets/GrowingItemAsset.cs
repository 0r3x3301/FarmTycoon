using System;
using UnityEngine;

public class GrowingItemAsset
{
    private string _name;
    private string _description;
    private float _growingTime;
    private Sprite _icon;
    private GameObject _prefab;
    private float _currentLifeTime;
    private int _id;
    
    private HandlerOfTaking _handlerOfTaking;

    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    public float GrowingTime => _growingTime;
    public Transform Transform => _prefab.transform;
    public event Action<GrowingItemAsset> OnGrown;

    public GrowingItemAsset(GrowingItem item, Vector3 position, float currentLifeTime = 0)
    {
        _name = item.Name;
        _prefab = GameObject.Instantiate(item.Prefab, position, Quaternion.identity);
        _description = item.Description;
        _growingTime = item.GrowingTime;
        _currentLifeTime = currentLifeTime;
        _icon = item.Icon;
        _id = item.Id;
        _handlerOfTaking = _prefab.AddComponent<HandlerOfTaking>();
        _handlerOfTaking.OnTaked += CollectItem;
        _prefab.transform.position = position;
    }

    public void UpdateLifeTime(float time)
    {
        _currentLifeTime += time;
        if (_currentLifeTime >= _growingTime)
        {
            OnGrown?.Invoke(this);
            _handlerOfTaking.CanBeTaked = true;
        }
    }

    public void CollectItem()
    {
        _handlerOfTaking.OnTaked -= CollectItem;
        GameObject.Destroy(_prefab);
        MainInventory.Add(_id);
    }
}
