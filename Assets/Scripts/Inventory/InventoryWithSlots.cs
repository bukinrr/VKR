using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWithSlots : IInventory
{
    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type, int> OnInventoryItemRemovedEvent;
    public event Action<object> OnInventoryStateChangedEvent;

    public int capacity { get; set; }
    public bool isFull => _slots.All(slot => slot.isFull);

    private List<IInventorySlot> _slots; // собственно лист слотов 

    public InventoryWithSlots(int capacity) //конструктор
    {
        this.capacity = capacity;

        _slots = new List<IInventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }

    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.itemType == itemType).Item;
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
            if (!slot.isEmpty)
                allItems.Add(slot.Item);

        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotsOfType = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);
        foreach (var slot in slotsOfType)
            allItemsOfType.Add(slot.Item);
        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var requiredSlots = _slots.FindAll(slot => !slot.isEmpty && slot.Item.State.isEquipped);
        var equippedItems = new List<IInventoryItem>();
        foreach (var slot in requiredSlots)
            equippedItems.Add(slot.Item);
        return equippedItems.ToArray();
    }

    public int GetItemAmount(Type itemType)
    {
        var amount = 0;
        var allItemSlots = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);

        foreach (var itemSlot in allItemSlots)
            amount += itemSlot.amount;
        return amount;
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmppty =
            _slots.Find(slot => !slot.isEmpty && slot.itemType == item.Type && !slot.isFull);
        if (slotWithSameItemButNotEmppty != null)
            return TryToAddToSlot(sender, slotWithSameItemButNotEmppty, item);

        var emptySlot = _slots.Find(slot => slot.isEmpty);
        if (emptySlot != null)
        {
            return TryToAddToSlot(sender, emptySlot, item);
        }

        Debug.Log($"Cannot add item({item.Type}), amount: {item.State.amount}, because there is no place for that.");
        return false;
    }

    public bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.amount + item.State.amount <=
                   item.Info
                       .maxItemsInInventorySlot; //проверка на вместительность слота(можно ли засунуть определенное количество в слот, чтобы не выйти за предел)
        var amountToAdd = fits ? item.State.amount : item.Info.maxItemsInInventorySlot - slot.amount;
        var amountLeft = item.State.amount - amountToAdd;
        var clonedItem = item.Clone();
        clonedItem.State.amount = amountToAdd;

        if (slot.isEmpty)
            slot.SetItem(clonedItem);
        else
            slot.Item.State.amount += amountToAdd;

        Debug.Log($"Item added to inventory. ItemType: {item.Type}, {amountToAdd}");
        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
        OnInventoryStateChangedEvent?.Invoke(sender);

        if (amountLeft <= 0)
            return true;

        item.State.amount = amountLeft;
        return TryToAdd(sender, item);
    }

    public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot.isEmpty)
            return;

        if (toSlot.isFull)
            return;

        if (!toSlot.isEmpty && fromSlot.itemType != toSlot.itemType)
            return;

        var slotCapacity = fromSlot.capacity;
        var fits = fromSlot.amount + toSlot.amount <= slotCapacity;
        var amountToAdd = fits ? fromSlot.amount : slotCapacity - toSlot.amount;
        var amountLeft = fromSlot.amount - amountToAdd;

        if (toSlot.isEmpty) // если слот в который мы кладем предмет пустой
        {
            toSlot.SetItem(fromSlot.Item);
            fromSlot.Clear();
            OnInventoryStateChangedEvent?.Invoke(sender);
        }

        toSlot.Item.State.amount += amountToAdd;
        if (fits)
            fromSlot.Clear();
        else
            fromSlot.Item.State.amount = amountLeft;
        OnInventoryStateChangedEvent?.Invoke(sender);
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotsWithItem = GetAllSlots(itemType);
        if (slotsWithItem.Length == 0)
            return;

        var amountToRemove = amount;
        var count = slotsWithItem.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];
            if (slot.amount >= amountToRemove)
            {
                slot.Item.State.amount -= amountToRemove;
                if (slot.amount <= 0)
                    slot.Clear();

                Debug.Log($"Item removed from inventory. ItemType: {itemType}, {amountToRemove}");
                OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);
                OnInventoryStateChangedEvent?.Invoke(sender);
                break;
            }

            var amountRemoved = slot.amount;
            amountToRemove -= slot.amount;
            slot.Clear();
            Debug.Log($"Item removed from inventory. ItemType: {itemType}, {amountRemoved}");
            OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountRemoved);
            OnInventoryStateChangedEvent?.Invoke(sender);
        }
    }

    public bool HasItem(Type type, out IInventoryItem item)
    {
        item = GetItem(type);
        return item != null;
    }

    public IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
    }

    public IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();
    }
}