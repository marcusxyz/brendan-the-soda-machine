using System;
using static System.Console;

namespace BrendanTheSodaMachine;


public class VendingMachine
{
	public string Name { get; }
	public int Slots { get; }

    private BankAccount BankAccount { get; }

    readonly BankAccount account = new BankAccount("Mr.Silverhand", 1000);

    public VendingMachine(string name, int slots)
    {
		Name = name;
		Slots = slots;

    }

	public void HelloVendingMachine()
	{
 
        WriteLine("----------------------------------------------------");
        ForegroundColor = ConsoleColor.Green;
		WriteLine($"Hello {Name}!");
        ForegroundColor = ConsoleColor.Yellow;
		WriteLine($"Hi {account.Owner}, what can I offer you today?");
		ForegroundColor = ConsoleColor.White;
        WriteLine("----------------------------------------------------");
    }

    public void Start()
    {
        HelloVendingMachine();
        AddConsumables();
        RunMainMenu();
    }


    private void GoBack()
    {
        ResetColor();
        WriteLine("\n(Press Esc to go back)");

        ConsoleKey keyPressed;

        ConsoleKeyInfo keyInfo = ReadKey(true);
        keyPressed = keyInfo.Key;

        if (keyPressed == ConsoleKey.Escape)
        {
            Clear();
            WriteLine("----------------------------------------------------");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("What's it gonna be friendo?");
            ForegroundColor = ConsoleColor.White;
            WriteLine("----------------------------------------------------");
            RunMainMenu();
        }
    }

    public void RunMainMenu()
    {
        List<string> options = new List<string>
        {
            "[1] - I'm feeling thirsty, what drinks do you have?",
            "[2] - I need to check my balance",
            "[3] - I need to withraw some eurodollars",
            "[4] - I need to check my purchase history",
            $"[5] - Cya {Name}!",

        };
            

        foreach (string option in options)
        {
            WriteLine(option);
        }

        string? choice = ReadLine();

        if (choice == "1")
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("----------------------------------------------------");
            WriteLine(options[0]);
            WriteLine("----------------------------------------------------");
            ForegroundColor = ConsoleColor.Yellow;
            //WriteLine("**Brendan shows a list of items available for purchase**");
            ShowConsumables();
            ResetColor();
            GoBack();

        }

        if (choice == "2")
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("----------------------------------------------------");
            WriteLine(options[1]);
            WriteLine("----------------------------------------------------");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"Your current balance is {account.GetBalance()} eurodollars");
            GoBack();
        }

        if (choice == "3")
        {
            Clear();
            WriteLine("Withdraw eurodollars");
            GoBack();
        }

        if (choice == "4")
        {
            Clear();
            WriteLine("Show purchase history");
            GoBack();
        }

        if (choice == "5")
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Cya Brendan 👋");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Ciao!");
        }
    }
   

    private readonly List<Consumable> Items = new List<Consumable>();

    public void AddConsumables()
    {
        Items.Add(new Consumable("NiCola", 10, 7));
        Items.Add(new Consumable("NiCola Sakura", 10, 12));
        Items.Add(new Consumable("NiCola Lime", 10, 14));
        Items.Add(new Consumable("Shwabshwab Blue", 15, 13));
        Items.Add(new Consumable("Shwabshwab Grape", 15, 2));
        Items.Add(new Consumable("Ab-synth", 20, 6));
    }

    public void ShowConsumables()
    {
        

        foreach (var item in Items)
        {
            WriteLine($"{item.Name} | Price: {item.Price}");
        }
    }

}



