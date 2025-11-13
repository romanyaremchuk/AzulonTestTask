using System;
using System.Collections.Generic;
using Items.Implementation;
using Items.Implementation.ScriptableObjects;
using UnityEngine;

namespace Inventory
{
    public class InventoryData : BaseGlobalRuntimeData
    {
        private List<InventorySlot> _inventoryInventoryItems = new List<InventorySlot>();

        public List<InventorySlot> InventoryItems => _inventoryInventoryItems;
    }
}