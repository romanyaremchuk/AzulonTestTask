using System;
using Currency;
using Items.Implementation.ScriptableObjects;
using UnityEngine;

[Serializable]
public class ShopEntry
{
    [SerializeField] private ItemDefinitionBase _itemDefinition;
    [SerializeField] private CurrencyEntry _price;
    
    public int RemainingStock { get; }

    public bool HasInfiniteStock => RemainingStock < 0;

    public ItemDefinitionBase ItemDefinition => _itemDefinition;

    public CurrencyEntry Price
    {
        get => _price;
        set => _price = value;
    }

    public ShopEntry(ItemDefinitionBase item, CurrencyEntry price, int remainingStock = -1)
    {
        _itemDefinition = item;
        _price = price;
        RemainingStock = remainingStock;
    }
    
    public ShopEntry DecreaseStock(int amount = 1)
    {
        if (HasInfiniteStock) 
            return this;

        int newStock = Mathf.Max(0, RemainingStock - amount);
        return new ShopEntry(_itemDefinition, _price, newStock);
    }
}
