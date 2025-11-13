using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using Items.Implementation;
using Items.Implementation.ScriptableObjects;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //public InventorySlot itemDebug;

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         AddItem(itemDebug);
    //     }
    //     
    //     if (Input.GetKeyDown(KeyCode.G))
    //     {
    //         RemoveItem(itemDebug);
    //     }
    // }
    
    private void OnEnable()
    {
        Global.RE<InventoryEvents>().OnItemEquipped += AddItem;
        Global.RE<InventoryEvents>().OnItemUnequipped += RemoveItem;
    }

    private void OnDisable()
    {
        Global.RE<InventoryEvents>().OnItemEquipped -= AddItem;
        Global.RE<InventoryEvents>().OnItemUnequipped -= RemoveItem;
    }

    public void AddItem(ItemDefinitionBase itemDefinition)
    {
        Debug.Log($"Adding item: {itemDefinition}");
        InventorySlot inventorySlot = new InventorySlot(itemDefinition);
        
        Global.RD<InventoryData>().InventoryItems.Add(inventorySlot);
        Global.RE<InventoryEvents>().InventoryChanged();
    }

    public void RemoveItem(ItemDefinitionBase itemDefinition)
    {
        Debug.Log($"Removing item: {itemDefinition}");

        List<InventorySlot> items = Global.RD<InventoryData>().InventoryItems;
        items.RemoveAll(slot => slot.Definition == itemDefinition);

        Global.RE<InventoryEvents>().InventoryChanged();
    }
}
