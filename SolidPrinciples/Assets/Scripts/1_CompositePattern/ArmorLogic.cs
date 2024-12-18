using UnityEngine;

public class ArmorLogic
{
    public Armor dragonArmor { get; private set; }

    public ArmorLogic()
    {
        SetupArmors();
        Debug.Log(dragonArmor.ShowDetails());
    }

    private void SetupArmors()
    {
        //Armor
        dragonArmor = new Armor("Dragon's Armor");
        SetupItems(dragonArmor);
    }
    
    private void SetupItems(Armor armor)
    {
        //Items
        Item helmet = new Item("Helmet");
        Item cloak = new Item("Cloak");
        Item shield = new Item("Shield");
        Item gloves = new Item("Gloves");
        Item kneepads = new Item("Kneepads");
        SetupGems(helmet);
        armor.Add(helmet);
        SetupGems(cloak);
        armor.Add(cloak);
        SetupGems(shield);
        armor.Add(shield);
        SetupGems(gloves);
        armor.Add(gloves);
        SetupGems(kneepads);
        armor.Add(kneepads);
    }
    
    private void SetupGems(Item item)
    {
        //Gems
        int rnd = Random.Range(0, 5);
        for (int i = 0; i < rnd; i++)
        {
            Gem gem = new Gem();
            SetupEnchantments(gem);
            item.Add(gem);
        }
    }

    private void SetupEnchantments(Gem gem)
    {
        int rnd = Random.Range(0, 5);
        for (int i = 0; i < rnd; i++)
        {
            Enchantment ench = new Enchantment();
            gem.Add(ench);
        }
    }
}
