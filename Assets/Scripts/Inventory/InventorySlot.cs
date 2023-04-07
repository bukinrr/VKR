using System;

public class InventorySlot : IInventorySlot
{
    public bool isFull => !isEmpty && amount == capacity;
    public bool isEmpty => Item == null;
    public IInventoryItem Item { get; private set; }
    public Type itemType => Item.Type;
    public int amount => isEmpty ? 0 : Item.State.amount;
    public int capacity { get; private set; }


    public void SetItem(IInventoryItem item)
    {
        if (!isEmpty)
            return;

        this.Item = item;
        this.capacity = item.Info.maxItemsInInventorySlot;
    }

    public void Clear()
    {
        if (isEmpty)
            return;

        Item.State.amount = 0;
        Item = null;
    }
}