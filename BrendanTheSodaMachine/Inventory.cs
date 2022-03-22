using System;
using static System.Console;

namespace BrendanTheSodaMachine;

public class Inventory
{


    private readonly List<Consumable> Items = new List<Consumable>();

    public void ShowConsumables()
    {
        Items.Add(new Consumable("NiCola", 10, 7));
        Items.Add(new Consumable("NiCola Sakura", 10, 12));
        Items.Add(new Consumable("NiCola Lime", 10, 14));
        Items.Add(new Consumable("Shwabshwab Blue", 15, 13));
        Items.Add(new Consumable("Shwabshwab Grape", 15, 2));
        Items.Add(new Consumable("Ab-synth", 20, 6));

        foreach (var item in Items)
        {
            WriteLine($"{item.Name} | Price: {item.Price}");
        }
    }

}


