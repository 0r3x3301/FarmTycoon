using System.Collections.Generic;
using UnityEngine;

public abstract class Field : ScriptableObject
{
    abstract public string Name { get; }
    abstract public string Description { get; }
    abstract public Sprite Sprite { get; }
    abstract public int MaxItemsCount { get; }
}
