using System;
using Items.Implementation;
using Items.Implementation.ScriptableObjects;

public class InventoryEvents : BaseGlobalRuntimeEvents
{
    public Action OnInventoryChanged;
    public Action<ItemDefinitionBase> OnItemEquipped;
    public Action<ItemDefinitionBase> OnItemUnequipped;

    public void InventoryChanged()
    {
        OnInventoryChanged?.Invoke();
    }

    public void ItemEquipped(ItemDefinitionBase item)
    {
        OnItemEquipped?.Invoke(item);
    }

    public void ItemUnequipped(ItemDefinitionBase item)
    {
        OnItemUnequipped?.Invoke(item);
    }
}
