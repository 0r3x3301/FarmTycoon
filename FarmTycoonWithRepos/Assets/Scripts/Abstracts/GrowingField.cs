using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Growing Field", menuName = "Field/GrowingField")]
public class GrowingField : Field
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _maxItemsCount;
    [SerializeField] private Item[] _acceptableItems;

    public override string Name => _name;
    public override string Description => _description;
    public override Sprite Sprite => _sprite;
    public override int MaxItemsCount => 0;
    public override List<Item> AcceptableItems => _acceptableItems.ToList();
}
