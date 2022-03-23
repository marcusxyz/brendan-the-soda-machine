using System;
using System.Collections.Generic;
using static System.Console;

namespace BrendanTheSodaMachine;
public class SodaMenu
{

    private readonly List<Consumable> Items = new List<Consumable>();

    public void AddConsumables()
    {

        Items.Add(new Consumable("1", "NiCola", 7));
        Items.Add(new Consumable("2", "NiCola Sakura", 12));
        Items.Add(new Consumable("3", "NiCola Lime", 12));
        Items.Add(new Consumable("4", "Shwabshwab Blue", 15));
        Items.Add(new Consumable("5", "Shwabshwab Grape", 15));
        Items.Add(new Consumable("6", "Ab-synth", 20));
    }

    public void ShowConsumables()
    {
        foreach (var item in Items)
        {
            WriteLine($"{item.Id} - {item.Name} | Price: {item.Price}");
        }
    }
}

