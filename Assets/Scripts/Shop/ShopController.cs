using System;
using System.Collections.Generic;
using Inventory;
using Items.Implementation;
using Player;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private List<ShopEntry> _shopEntries = new List<ShopEntry>();

    [SerializeField] private GameObject _shopInstance;
    private IShop _shop;

    [SerializeField] private UiShopController _uiController;

public List<ShopEntry> ShopEntries => _shopEntries;

    private void Awake()
    {
        Global.RE<InventoryEvents>().OnInventoryChanged += () => _uiController.UpdateBalance(Global.RD<PlayerData>().Wallet.Money[0].Amount, Global.RD<PlayerData>().Wallet.Money[0].DisplayName);
        Initialize();
    }

    private void Start()
    {
        _uiController.UpdateBalance(Global.RD<PlayerData>().Wallet.Money[0].Amount, Global.RD<PlayerData>().Wallet.Money[0].DisplayName);
    }

    private void OnEnable()
    {
        Global.RE<InventoryEvents>().OnItemEquipped += (item) =>  _uiController.InstantiateButtonToInventory(_shopEntries.Find(e => e.ItemDefinition.DisplayName == item.DisplayName), _shop);
    }

    private void OnDisable()
    {
        Global.RE<InventoryEvents>().OnItemEquipped -= (item) =>  _uiController.InstantiateButtonToInventory(_shopEntries.Find(e => e.ItemDefinition.DisplayName == item.DisplayName), _shop);
    }

    public void Initialize()
    {
        _shop = _shopInstance.GetComponent<IShop>();
        if (_shop == null)
            throw new MissingComponentException("The Shop Instance doesn't contain an IShop component!");

        foreach (ShopEntry shopEntry in _shopEntries)
        {
            _uiController.InstantiateButtonToBuy(shopEntry, _shop);
        }
    }

    public PurchaseResult TryBuy(ShopEntry entry)
    {
        PurchaseResult result = _shop.TryBuy(entry);
        _uiController.InstantiateButtonToInventory(entry, _shop);
        return result;
    }   

    public void Sell(ShopEntry entry)
    {
        _shop.Sell(entry);
    }
}
