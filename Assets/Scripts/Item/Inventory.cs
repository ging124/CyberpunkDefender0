using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public event EventHandler OnItemListChanged;

    public List<Item> itemList { get; }

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
