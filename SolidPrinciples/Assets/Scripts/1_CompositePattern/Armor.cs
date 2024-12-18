using System;
using UnityEngine;

[Serializable]
public class Armor : Component
{
    public string Name { get; }

    public Armor(string name)
    {
        Name = name;
    }
    
    public override string ShowDetails()
    {
        if (_components.Count < 1)
        {
            return $"{Name} has no items.";
        }

        string result = $"{Name} have the following items:\n";

        foreach (Item item in _components)
        {
            result += item.ShowDetails();
        }
        
        return result;
    }
}
