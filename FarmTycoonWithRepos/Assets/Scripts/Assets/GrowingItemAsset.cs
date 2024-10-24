using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingItemAsset
{
    private string _name;
    private string _description;
    private float _growingTime;
    private Sprite _icon;
    private GameObject _prefab;
    private float _currentLifeTime;

    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    public float GrowingTime => _growingTime;

    public event Action<GrowingItemAsset> OnGrown;

    public GrowingItemAsset(GrowingItem item, Vector3 position, float currentLifeTime = 0)
    {
        _name = item.Name;
        _prefab = item.Prefab;
        _description = item.Description;
        _growingTime = item.GrowingTime;
        _currentLifeTime = currentLifeTime;
        _icon = item.Icon;
        GameObject.Instantiate(_prefab, position, Quaternion.identity);
        _prefab.transform.position = position;
    }

    public void UpdateLifeTime(float time)
    {
        _currentLifeTime += time;
        if (_currentLifeTime >= _growingTime)
        {
            OnGrown?.Invoke(this);
        }
    }
}
