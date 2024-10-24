using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InFieldItemsHandler
{
    private HashSet<Transform> _itemsTransforms;
    HashSet<Vector3> _freePositions;
    HashSet<Vector3> _takedPositions;

    public bool IsFreePlaceExist { get { return _freePositions.Count != 0; } }
    public Vector3 FreePlace => _freePositions.First();

    public InFieldItemsHandler(List<Vector3> spawnPositions)
    {
        _itemsTransforms = new HashSet<Transform>();
        _freePositions = spawnPositions.ToHashSet();
        _takedPositions = new HashSet<Vector3>();
    }

    public void Add(Transform transform)
    {
        _itemsTransforms.Add(transform);
        transform.position = _freePositions.ElementAt(0);
        _takedPositions.Add(transform.position);
        _freePositions.Remove(transform.position);
    }

    public void Remove(Transform transform)
    {
        _takedPositions.Remove(transform.position);
        _freePositions.Add(transform.position);
        _itemsTransforms.Remove(transform);
    }
}
