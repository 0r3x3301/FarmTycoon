using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrowingItemsAdder : MonoBehaviour
{
    [SerializeField] private Seed _seed;
    public GrowingFieldAsset GrowingFieldAsset;

    public void AddItem()
    {
        if (_seed != null)
        {
            var seedAsset = new SeedAsset(_seed);
            GrowingFieldAsset.Add(seedAsset.Use());
        }
    }
}
