using System;
using Random = UnityEngine.Random;


//Domanda: ma ha senso fare il check sul tipo quando vado a fare add e remove?
//          chiedo perchè credo che non si dovrebbe poter aggiungere secondo me un'armatura fra i figli della classe gemma ad esempio
[Serializable]
public class Gem : Component
{
    public string Name { get; }
    public StatType GemType { get; }
    
    public Gem()
    {
        GemType = (StatType)Random.Range(0, 3);
        Name = GemType.ToString() + " gem";
    }

    public Gem(StatType gemType)
    {
        GemType = gemType;
    }
    
    public override string ShowDetails()
    {
        if (_components.Count < 1)
        {
            return $"This is a {GemType} gem with no enchants.\n";
        }
        string result = $"This is a {GemType} gem and contains the following enchants:\n";
        foreach (var component in _components)
        {
            result += component.ShowDetails();
        }
        return result;
    }

    public int GetBuff()
    {
        int buff = 0;
        foreach (Enchantment enchantment in _components)
        {
            buff += enchantment.BuffAmount;
        }
        return buff;
    }
}
