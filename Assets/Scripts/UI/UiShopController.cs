using System;
using System.Collections;
using System.Collections.Generic;
using Items.Implementation.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiShopController : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceText;
    [SerializeField] private List<GameObject> _toBuy;
    [SerializeField] private List<GameObject> _toSell;
    [SerializeField] private Transform _shopGroupLayout;
    [SerializeField] private Transform _inventoryGroupLayout;

    public void InstantiateButtonToBuy(ShopEntry entry, IShop shop)
    {
        GameObject btn = Instantiate(Resources.Load<GameObject>("Button"), _shopGroupLayout);
        btn.transform.Find("Root/Image").GetComponent<Image>().sprite = entry.ItemDefinition.Icon;
        Button button = btn.GetComponentInChildren<Button>();
        button.onClick.AddListener(() => shop.TryBuy(entry));
        btn.GetComponentInChildren<TMP_Text>().text = entry.ItemDefinition.DisplayName + " Price: " + entry.Price.Amount + " " + entry.Price.DisplayName;
        _toBuy.Add(btn);
        _balanceText.text = entry.Price.Amount.ToString();
    }
    
    public void InstantiateButtonToInventory(ShopEntry entry, IShop shop)
    {
        GameObject btn = Instantiate(Resources.Load<GameObject>("Button"), _inventoryGroupLayout);

        switch (entry.ItemDefinition.Type)
        {
            case ItemType.Case:
                CaseDefinition actualItem = entry.ItemDefinition as CaseDefinition;
                int randomIndex = UnityEngine.Random.Range(0, actualItem.WeaponDefinitions.Count);
                WeaponDefinition item = actualItem.WeaponDefinitions[randomIndex];
                btn.transform.Find("Root/Image").GetComponent<Image>().sprite = item.Icon;
                Button button = btn.GetComponentInChildren<Button>();
                ShopEntry shopEntryItemToSell = new ShopEntry(item, item.CostToBuy, Int32.MaxValue);
                button.onClick.AddListener(() => shop.Sell(shopEntryItemToSell));
                button.onClick.AddListener(() => RemoveFromInventory(btn));
                btn.GetComponentInChildren<TMP_Text>().text = item.DisplayName + " Price: " + item.CostToBuy.Amount + " " + item.CostToBuy.DisplayName;
                break;
            case ItemType.Item:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        
        _toSell.Add(btn);
    }

    public void UpdateBalance(int newBalance, string currencyName)
    {
        _balanceText.text = newBalance.ToString() + " " + currencyName;
    }

    private void RemoveFromInventory(GameObject itemToRemove)
    {
        Destroy(itemToRemove);
        _toSell.Remove(itemToRemove);
    }
}
