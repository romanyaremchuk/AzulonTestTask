using System;
using System.Collections.Generic;

public class ShopData : BaseGlobalRuntimeData
{
    public Action OnShopOpened;
    public Action OnShopClosed;
    
    public int SelectedIndex { get; private set; } = -1;
    
    private List<ShopEntry> _shopEntries = new List<ShopEntry>();
    private bool _isOpen;

    public bool IsOpen
    {
        get => _isOpen;
        set
        {
            _isOpen = value;
            if (_isOpen)
                OnShopOpened?.Invoke();
            else
                OnShopClosed?.Invoke();
        }
    }
    
    public void SetEntries(IEnumerable<ShopEntry> entries)
    {
        _shopEntries.Clear();
        _shopEntries.AddRange(entries);
        SelectedIndex = _shopEntries.Count > 0 ? 0 : -1;
    }
    
    public void SelectIndex(int index)
    {
        SelectedIndex = index;
    }

}
