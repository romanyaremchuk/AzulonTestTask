using System;
using Currency.Implementation;
using UnityEngine;

namespace Currency
{
    [Serializable]
    public class CurrencyEntry
    {
        public string DisplayName;

        [SerializeField] private CurrencyDefinition _currencyDefinition;
        [SerializeField] private int _amount;

        public CurrencyDefinition Definition => _currencyDefinition;

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }
    }
}