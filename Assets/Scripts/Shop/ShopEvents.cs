using System;

public class ShopEvents : BaseGlobalRuntimeEvents
{
    public Action<ShopEntry> OnEntrySelected;
    public Action<PurchaseResult> OnPurchaseCompleted;
    public Action OnEntriesChanged;

    public void EntriesChanged()
    {
        OnEntriesChanged?.Invoke();
    }
}
