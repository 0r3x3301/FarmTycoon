using UnityEngine;
[CreateAssetMenu(fileName = "New Seed", menuName = "Item/Seed")]
public class Seed : Item
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GrowingItem _growingItem;
    [SerializeField] private int _id;

    public override string Name => _name;
    public override string Description => _description;
    public override Sprite Icon => _icon;
    public GrowingItem GrowingItem => _growingItem;
    public override int Id => _id;
}
