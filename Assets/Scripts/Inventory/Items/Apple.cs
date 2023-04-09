using System;

    public class Apple : IInventoryItem
    {
        public bool isEquiped { get; set; }
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        public Type Type => GetType();

        public Apple(IInventoryItemInfo info)
        {
            this.Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedApple = new Apple(Info);
            clonedApple.State.amount = State.amount;
            return clonedApple;
        }
    }