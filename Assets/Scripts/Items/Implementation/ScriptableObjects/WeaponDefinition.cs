using UnityEngine;

namespace Items.Implementation.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemDefinition", menuName = "Game/Items/Weapon Definition")]
    public class WeaponDefinition : ItemDefinitionBase
    {
        [SerializeField] private ItemRarity _itemRarity;

        public ItemRarity Rarity => _itemRarity;
    }
}
