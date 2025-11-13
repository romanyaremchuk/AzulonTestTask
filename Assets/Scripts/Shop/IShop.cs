using System.Collections.Generic;
using Items.Implementation;

public interface IShop
{
    List<ShopEntry> ShopEntries { get; }
    PurchaseResult TryBuy(ShopEntry entry);
    void Sell(ShopEntry entry);
}