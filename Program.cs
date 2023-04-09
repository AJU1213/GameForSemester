using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class Program
{
    static void Main()
    {
        Inventory<int> rings = new Inventory<int>();
        rings.AddItem(50);
        rings.AddItem(25);
        rings.PrintInventory();
        rings.RemoveItem(25);
        rings.PrintInventory();

        Inventory<int> score = new Inventory<int>();
        score.AddItem(1000);
        score.AddItem(500);
        score.PrintInventory();
        score.RemoveItem(50);
        score.PrintInventory();

        Inventory<int> lives = new Inventory<int>();
        lives.AddItem(3);
        lives.AddItem(2);
        lives.AddItem(1);
        lives.PrintInventory();
        lives.RemoveItem(1);
        lives.PrintInventory();

        Inventory<string> abilities = new Inventory<string>();
        abilities.AddItem("Spin Dash");
        abilities.AddItem("Homing Attack");
        abilities.PrintInventory();
        abilities.RemoveItem("Spin Dash");
        abilities.PrintInventory();
    }
}




