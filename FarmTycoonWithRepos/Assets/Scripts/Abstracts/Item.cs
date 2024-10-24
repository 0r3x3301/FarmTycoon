using UnityEngine;

public abstract class Item : ScriptableObject
{
    abstract public string Name { get; }
    abstract public string Description { get; }
    abstract public Sprite Icon { get; }
    abstract public int Id { get; }
}
