public enum PurchaseFailReason
{
    None,
    NotEnoughCurrency,
    NoStock,
    InventoryFull,
    UnknownError,
}

public class PurchaseResult
{
    public bool Success { get; }
    public PurchaseFailReason FailReason { get; }

    public ShopEntry Entry { get; }
    public int Amount { get; }
    public bool IsFailure => !Success;

    public PurchaseResult(bool success, ShopEntry entry, int amount, PurchaseFailReason failReason)
    {
        Success = success;
        Entry = entry;
        Amount = amount;
        FailReason = failReason;
    }

    public static PurchaseResult Ok(ShopEntry entry, int amount = 1)
    {
        return new PurchaseResult(true, entry, amount, PurchaseFailReason.None);
    }

    public static PurchaseResult Fail(ShopEntry entry, PurchaseFailReason reason, int amount = 1)
    {
        return new PurchaseResult(false, entry, amount, reason);
    }
}