using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Currency
{
    [Serializable]
    public class Wallet
    {
        [SerializeField] private List<CurrencyEntry> _money = new List<CurrencyEntry>();
        public List<CurrencyEntry> Money { get { return _money; } }

        public bool IsEnoughMoney(string currencyName, float price) =>
            _money.Find(c => c.Definition.currencyName == currencyName).Amount >= price;

        public CurrencyEntry GetCurrency(string currencyName) =>
            _money.Find(c => c.Definition.currencyName == currencyName);
    }
}
