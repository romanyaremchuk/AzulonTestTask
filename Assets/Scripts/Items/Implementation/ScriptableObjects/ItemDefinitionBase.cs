using Currency;
using UnityEngine;

namespace Items.Implementation.ScriptableObjects
{
    public enum ItemType
    {
        Item,
        Case
    }

    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    
    public class ItemDefinitionBase : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private string _displayName;
    
        [TextArea]
        [SerializeField] private string _description;

        [Header("Visual")]
        [SerializeField] private Sprite _icon;

        [Header("Classification")]
        [SerializeField] private ItemType _itemType;
        
        [SerializeField] private CurrencyEntry _costToBuy;
        [SerializeField] private CurrencyEntry _costToSell;
        
        public string DisplayName => _displayName;

        public string Description => _description;

        public ItemType Type => _itemType;

        public CurrencyEntry CostToBuy => _costToBuy;

        public CurrencyEntry CostToSell => _costToSell;

        public Sprite Icon => _icon;
    }
}
