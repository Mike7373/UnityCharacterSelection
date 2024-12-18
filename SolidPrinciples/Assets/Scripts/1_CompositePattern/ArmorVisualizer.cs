using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArmorVisualizer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _armorContent;
    [SerializeField] private Transform _itemContent;
    [SerializeField] private Transform _gemContent;
    [SerializeField] private Transform _enchantmentContent;
    
    [Header("Others")]
    [SerializeField] private GameObject _button;

    private ArmorLogic _armorLogic;

    private void Start()
    {
        _armorLogic = new ArmorLogic();
        SetupArmor();
    }

    public void SetupArmor()
    {
        ClearList(_armorContent);
        ClearList(_itemContent);
        ClearList(_gemContent);
        ClearList(_enchantmentContent);
        //Cose fatte male: armor logic potrebbe essere di tipo component per evitare sta roba
        GameObject button = Instantiate(_button, _armorContent);
        button.GetComponent<Button>().onClick.AddListener(SetupItems);
        button.GetComponentInChildren<TMP_Text>().text = _armorLogic.dragonArmor.Name;
    }

    public void SetupItems()
    {
        ClearList(_itemContent);
        ClearList(_gemContent);
        ClearList(_enchantmentContent);
        foreach (Item item in _armorLogic.dragonArmor.GetComponents())
        {
            GameObject button = Instantiate(_button, _itemContent);
            button.GetComponent<Button>().onClick.AddListener(delegate { SetupGems(item);});
            button.GetComponentInChildren<TMP_Text>().text = item.Name;
        }
    }

    public void SetupGems(Item item)
    {
        ClearList(_gemContent);
        ClearList(_enchantmentContent);
        foreach (Gem gem in item.GetComponents())
        {
            GameObject button = Instantiate(_button, _gemContent);
            button.GetComponent<Button>().onClick.AddListener(delegate { SetupEnchantments(gem); });
            button.GetComponentInChildren<TMP_Text>().text = gem.Name;
        }

        
    }

    public void SetupEnchantments(Gem gem)
    {
        ClearList(_enchantmentContent);
        foreach (Enchantment enchantment in gem.GetComponents())
        {
            GameObject button = Instantiate(_button, _enchantmentContent);
            button.GetComponentInChildren<TMP_Text>().text = enchantment.Name;
        }
    }

    private void ClearList(Transform parent)
    {
        for (int i = 1; i < parent.GetComponentsInChildren<Transform>().Length; i++)
        {
            Destroy(parent.GetComponentsInChildren<Transform>()[i].gameObject);
        }
    }
}
