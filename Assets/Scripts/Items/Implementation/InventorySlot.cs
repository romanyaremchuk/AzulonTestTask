using Items.Implementation.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Items.Implementation
{
    [System.Serializable]
    public class InventorySlot
    {
        public ItemDefinitionBase Definition;

        public InventorySlot(ItemDefinitionBase definition)
        {
            Definition = definition;
        }
        
    }
}
