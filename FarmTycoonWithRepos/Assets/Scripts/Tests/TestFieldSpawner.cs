using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFieldSpawner : MonoBehaviour
{
    [SerializeField] private GrowingField _growingField;
    [SerializeField] private Transform _spawnPointTransform;
    [SerializeField] private TestGrowingItemsAdder _testItemsAdder;
    public void SpawnField()
    {
        var field = new GrowingFieldAsset(_growingField, _spawnPointTransform.position);
        _testItemsAdder.GrowingFieldAsset = field;
        Debug.Log($"Added {field.Name}");
    }
}
