using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InFieldItemsHandler
{
    private HashSet<Transform> _itemsTransforms;
    List<Vector3> _positions;
    List<Vector3> _takedPositions;

    public bool IsFreePlaceExist { get { return GetFreePlace() != Vector3.zero; } }
    public Vector3 FreePlace => GetFreePlace();

    public InFieldItemsHandler(List<Vector3> spawnPositions)
    {
        _itemsTransforms = new HashSet<Transform>();
        _positions = spawnPositions;
        _takedPositions = new List<Vector3>();
    }

    public void Add(GrowingItemAsset item)
    {
        _itemsTransforms.Add(item.Transform);
        item.Transform.position = _positions.First();
        _takedPositions.Add(item.Transform.position);
        _positions.RemoveAt(0);
        item.OnGrown += Remove;
    }

    private Vector3 GetFreePlace()
    {
        foreach(var place in _positions)
        {
            if (!_takedPositions.Contains(place))
            {
                return place;
            }
        }
        return Vector3.zero;
    }

    public void Remove(GrowingItemAsset item)
    {
        _takedPositions.Remove(item.Transform.position);
        _positions.Add(item.Transform.position);
        _itemsTransforms.Remove(item.Transform);
    }
}
