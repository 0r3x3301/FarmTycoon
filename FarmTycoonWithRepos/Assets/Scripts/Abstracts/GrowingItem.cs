using UnityEngine;
[CreateAssetMenu(fileName = "New Growing Item", menuName = "Item/GrowingItem")] 
public class GrowingItem : Item
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _growingTime;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _id;
    public override string Name => _name;
    public override string Description => _description;
    public override Sprite Icon => _icon;
    public override int Id => _id;
    public float GrowingTime => _growingTime;
    public GameObject Prefab => _prefab;
}
