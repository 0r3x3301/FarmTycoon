using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldsHandler : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private GrowingField[] _dataVariants;
    private List<Vector2> _takedPositions;

    private void Awake()
    {
        _takedPositions = new List<Vector2>();
    }

    //private void Start()
    //{
    //    foreach (var prefab in _prefabs)
    //    {
    //        var freePositions = _transforms.Select(x => x.position).Where(x => !_takedPositions.Contains(x)).ToList();
    //        var randomNum = Random.Range(0, freePositions.Count);
    //        var newField = Instantiate(prefab, freePositions[randomNum], Quaternion.identity).GetComponent<GrowingFieldAsset>();
    //        newField.Init(_dataVariants[Random.Range(0, _dataVariants.Length)]);
    //        for (int i = 0; i < 3; i++)
    //        {
    //            newField.Add();
    //        }
    //    }
    //}
}
