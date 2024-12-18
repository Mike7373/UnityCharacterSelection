using System;
using Random = UnityEngine.Random;

[Serializable]
public class Item : Component
{
    public string Name { get; }
    public int BaseFireRes { get; }
    public int BaseIceRes { get; }
    public int BaseEarthRes { get; }
    public int BaseBoltRes { get; }

    public Item(string name)
    {
        Name = name;
        BaseFireRes = Random.Range(0, 999);
        BaseIceRes = Random.Range(0, 999);
        BaseEarthRes = Random.Range(0, 999);
        BaseBoltRes = Random.Range(0, 999);
    }

    public Item(string name, int baseFireRes, int baseIceRes, int baseEarthRes, int baseBoltRes)
    {
        Name = name;
        BaseFireRes = baseFireRes;
        BaseIceRes = baseIceRes;
        BaseEarthRes = baseEarthRes;
        BaseBoltRes = baseBoltRes;
    }

    public override string ShowDetails()
    {
        if (_components.Count < 1)
        {
            return $"{Name} is an item with no gems.\nBase stats:\nFireRes -> {BaseFireRes} | IceRes -> {BaseIceRes} | EarthRes -> {BaseEarthRes} | BoltRes -> {BaseBoltRes}\n";
        }

        int fireRes = BaseFireRes + GetBuff(StatType.FIRE);
        int iceRes = BaseIceRes + GetBuff(StatType.ICE);
        int earthRes = BaseEarthRes + GetBuff(StatType.EARTH);
        int boltRes = BaseBoltRes + GetBuff(StatType.BOLT);
        
        string result = $"{Name} stats:\n FireRes -> {fireRes} | IceRes -> {iceRes} | EarthRes -> {earthRes} | BoltRes -> {boltRes}\n";
        result += $"{Name} contains the following gems:\n";
        foreach (var component in _components)
        {
            result += component.ShowDetails();
        }
        return result;
    }

    public int GetBuff(StatType type)
    {
        int buff = 0;
        foreach (Gem gem in _components)
        {
            if (gem.GemType == type)
            {
                buff += gem.GetBuff();
            }
        }
        return buff;
    }
}
