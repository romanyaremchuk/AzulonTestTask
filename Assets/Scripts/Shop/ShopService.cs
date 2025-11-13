using System.Collections.Generic;
using Currency;
using Player;
using UnityEngine;

namespace Shop
{
    public class ShopService : MonoBehaviour, IShop
    {
        public List<ShopEntry> ShopEntries { get; }
        
        public PurchaseResult TryBuy(ShopEntry entry)
        {
            Wallet wallet = Global.RD<PlayerData>().Wallet;
            PurchaseResult result = Purchase(entry, wallet);
            return result;
        }

        public void Sell(ShopEntry entry)
        {
            Wallet wallet = Global.RD<PlayerData>().Wallet;
            PurchaseResult result = Sell(entry, wallet);
        }
        
        public PurchaseResult Purchase(ShopEntry entry, Wallet wallet)
        {
            bool success = wallet.IsEnoughMoney(entry.Price.Definition.currencyName, entry.Price.Amount);
            if (success)
            {
                CurrencyEntry moneyEntry = wallet.GetCurrency(entry.Price.Definition.currencyName);
                moneyEntry.Amount -= entry.Price.Amount;
                Global.RE<InventoryEvents>().ItemEquipped(entry.ItemDefinition);

                return new PurchaseResult(true, entry, entry.Price.Amount, PurchaseFailReason.None);
            }
            
            return new PurchaseResult(false, entry, entry.Price.Amount, PurchaseFailReason.NotEnoughCurrency);
        }
        
        public PurchaseResult Sell(ShopEntry entry, Wallet wallet)
        {
            CurrencyEntry moneyEntry = wallet.GetCurrency(entry.Price.Definition.currencyName);
            moneyEntry.Amount += entry.Price.Amount;
            Global.RE<InventoryEvents>().ItemUnequipped(entry.ItemDefinition);
            return new PurchaseResult(true, entry, entry.Price.Amount, PurchaseFailReason.None);
        }
    }
}