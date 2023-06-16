using System;

public class Pepper : IInventoryItem
{
    public IInventoryItemInfo Info { get; }
    public IInventoryItemState State { get; }
    public Type Type { get; }

    public Pepper(IInventoryItemInfo info)
    {
        this.Info = info;
        State = new InventoryItemState();
    }

    public IInventoryItem Clone()
    {
        var clonedPepper = new Pepper(Info);
        clonedPepper.State.amount = State.amount;
        return clonedPepper;
    }
}