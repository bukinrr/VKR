using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _appleInfo;
    [SerializeField] private InventoryItemInfo _pepperInfo;

    public InventoryWithSlots inventory => _tester.inventory;

    private UIIinventoryTester _tester;

    private void Start()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        _tester = new UIIinventoryTester(_appleInfo, _pepperInfo, uiSlots);
        _tester.FillSlots();
    }
}