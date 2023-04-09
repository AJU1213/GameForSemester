using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory<T>
{
    private List<T> items;

    public Inventory()
    {
        items = new List<T>();
    }

    public void AddItem(T item)
    {
        items.Add(item);
        Console.WriteLine("Added " + item.ToString() + " to inventory.");
    }

    public void RemoveItem(T item)
    {
        items.Remove(item);
        Console.WriteLine("Removed " + item.ToString() + " from inventory.");
    }

    public void PrintInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (T item in items)
        {
            Console.WriteLine("- " + item.ToString());
        }
    }
}
