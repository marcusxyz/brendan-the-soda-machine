using System;
using System.Collections.Generic;
using static System.Console;
using BrendanTheSodaMachine;

public class VendingMachine
{
    public string Name { get; }
    public int Slots { get; }
    public BankAccount Account { get; }
    public string separator = "----------------------------------------------------";

    SodaMenu sodamenu = new SodaMenu();
    

    public VendingMachine(string name, int slots, BankAccount account)
    {
		Name = name;
		Slots = slots;
        Account = account;
    }

	public void HelloVendingMachine(BankAccount account)
	{
        WriteLine(separator);
        ForegroundColor = ConsoleColor.Green;
		WriteLine($"Hello {Name}!");
        ForegroundColor = ConsoleColor.Yellow;
		WriteLine($"Hi {Account.Owner}, what can I offer you today?");
		ForegroundColor = ConsoleColor.White;
        WriteLine(separator);
    }

    public void Start()
    {
        HelloVendingMachine(Account);
        AddConsumables();
        RunMainMenu(Account);
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
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("What more can I do for you? :)");
            ForegroundColor = ConsoleColor.White;
            WriteLine(separator);
            RunMainMenu(Account);
        }
    }

    public void RunMainMenu(BankAccount account)
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
            WriteLine(options[0]);
            ForegroundColor = ConsoleColor.White;
            WriteLine(separator);
            ShowConsumables();
            ResetColor();
            GoBack();

        }

        if (choice == "2")
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(options[1]);
            WriteLine("----------------------------------------------------");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"Your current balance is {account.Balance} eurodollars");
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
            Environment.Exit(0);
        }
    }

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
            WriteLine($"[{item.Id}] - {item.Name} | Price: {item.Price}");
        }

        PurchaseSoda();
    }

    public void PurchaseSoda()
    {
        WriteLine("\nPlease select a number to buy Soda:");

        string sodaChoice = ReadLine();
        int balance = Account.Balance;
        int sodaId = Int32.Parse(sodaChoice) - 1;
        int itemPrice = Items[sodaId].Price;

        void ShowReceipt(int balance)
        {
           WriteLine(itemPrice + " eurodollars was drawn from your bank account. Enjoy your " + Items[sodaId].Name + "\nYour balance is now: " + balance);
        }


        if (balance < itemPrice)
        {
            WriteLine("Hmm.. Looks like you don't have enough to buy this soda");
        }

        if (Int32.TryParse(sodaChoice, out int sodaInt))
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (sodaInt == i + 1)
                {
                    WriteLine(Account.Balance);
                    Account.Balance -= itemPrice;
                    WriteLine(Account.Balance);
                    PurchaseSuccess();
                    ShowReceipt(Account.Balance);
                    GoBack();
                }
            }
        }

    }

    public void TryAgain()
    {
        WriteLine($"Are you blind {Account.Owner}? Please select a valid option");
    }

    public void PurchaseSuccess()
    {
        WriteLine(separator);
        Console.ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"Pleasure doing business with you {Account.Owner}!");
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine(separator);
        Console.ForegroundColor = ConsoleColor.Magenta;
    }
}