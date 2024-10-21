using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingItemAsset : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private string _name;
    private string _description;
    private float _growingTime;

    public void Init(GrowingItem item)
    {
        _spriteRenderer.sprite = item.Icon;
        _name = item.Name;
        _description = item.Description;
        _growingTime = item.GrowingTime;
    }
}
