using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Growing Field", menuName = "Field/GrowingField")]
public class GrowingField : Field
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _maxItemsCount;
    [SerializeField] private GrowingItem[] _acceptableItems;
    [SerializeField] private GameObject _prefab;
    public override string Name => _name;
    public override string Description => _description;
    public override Sprite Sprite => _sprite;
    public override int MaxItemsCount => _maxItemsCount;
    public List<GrowingItem> AcceptableItems => _acceptableItems.ToList();
    public GameObject Prefab => _prefab;
}
