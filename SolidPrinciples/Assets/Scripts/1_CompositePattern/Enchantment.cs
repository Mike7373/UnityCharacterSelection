using System;
using UnityEngine;
using Random = UnityEngine.Random;


//LEAF:
//questa classe non può avere oggetti al proprio interno
[Serializable]
public class Enchantment : Component
{
    public int BuffAmount { get; }
    public string Name { get; }


    public Enchantment()
    {
        BuffAmount = Random.Range(1, 20);
        Name = $"+{BuffAmount}";
    }
    public Enchantment(int buffAmount)
    {
        BuffAmount = buffAmount;
    }
    
    public override string ShowDetails()
    {
        return ($"- Enchantment buff: amount: +{BuffAmount}\n");
    }

    public override void Add(Component component)
    {
        Debug.LogError($"[Enchantment] You cannot add a component here because this object is a leaf.");
    }
    
    public override void Remove(Component component)
    {
        Debug.LogError($"[Enchantment] You cannot remove a component here because this object is a leaf.");
    }
}
