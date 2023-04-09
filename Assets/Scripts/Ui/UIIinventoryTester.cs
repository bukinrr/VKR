using System.Collections.Generic;
using Random = UnityEngine.Random;

public class UIIinventoryTester
{
    private InventoryItemInfo _appleInfo;
    private InventoryItemInfo _pepperInfo;
    private UIInventorySlot[] _uiSlots;

    public InventoryWithSlots inventory { get; }

    public UIIinventoryTester(InventoryItemInfo appleInfo, InventoryItemInfo pepperInfo, UIInventorySlot[] uiSlots)
    {
        _appleInfo = appleInfo;
        _pepperInfo = pepperInfo;
        _uiSlots = uiSlots;

        inventory = new InventoryWithSlots(15);
        inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
    }

    public void FillSlots()
    {
        var allSlots = inventory.GetAllSlots();
        var availableSlots = new List<IInventorySlot>(allSlots);

        var filledSlots = 5;
        for (int i = 0; i < filledSlots; i++)
        {
            var filledSlot = AddRandomApplesIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
            
            filledSlot = AddRandomPeppersIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
        }
        
        SetupInventoryUI(inventory); 
    }

    private IInventorySlot AddRandomApplesIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = Random.Range(0, slots.Count);
        var rSlot = slots[rSlotIndex];
        var rCount = Random.Range(1, 4);
        var apple = new Apple(_appleInfo);
        apple.State.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, apple);
        return rSlot;
    }

    private IInventorySlot AddRandomPeppersIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = Random.Range(0, slots.Count);
        var rSlot = slots[rSlotIndex];
        var rCount = Random.Range(1, 4);
        var pepper = new Pepper(_pepperInfo);
        pepper.State.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, pepper);
        return rSlot;
    }

    private void SetupInventoryUI(InventoryWithSlots inventory)
    {
        var allSlots = inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;
        for (int i = 0; i < allSlotsCount; i++)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }

    private void OnInventoryStateChanged(object sender)
    {
        foreach (var uiSlot in _uiSlots)
            uiSlot.Refresh();
    }
}