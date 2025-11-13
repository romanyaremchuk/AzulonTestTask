using UnityEngine;

namespace Currency.Implementation
{
    [CreateAssetMenu(fileName = "CurrencyDefinition", menuName = "Game/Currency")]
    public class CurrencyDefinition : ScriptableObject
    {
        public string currencyName;
        public Sprite icon;
    }
}