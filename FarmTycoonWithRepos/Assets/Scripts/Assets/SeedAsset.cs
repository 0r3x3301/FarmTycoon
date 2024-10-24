using UnityEngine;

public class SeedAsset
{
    private string _name;
    private string _description;
    private Sprite _icon;
    private string _growingItemName;
    private GrowingItem _growingItem;

    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    public string GrowingItemName => _growingItemName;

    public SeedAsset(Seed seed)
    {
        _name = seed.Name;
        _description = seed.Description;
        _icon = seed.Icon;
        _growingItem = seed.GrowingItem;
        _growingItemName = _growingItem.Name;
    }

    public GrowingItem Use()
    {
        return _growingItem;
    }
}   
