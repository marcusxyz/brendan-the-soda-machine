using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;
using BrendanTheSodaMachine;

public class VendingMachine
{
    public string Name { get; }
    public int Slots { get; }
    public BankAccount Account { get; }
    public Stack TransactionLog { get; }
    public string separator = "----------------------------------------------------";

    SodaMenu sodamenu = new SodaMenu();

    public VendingMachine(string name, int slots, BankAccount account, Stack transactionLog)
    {
		Name = name;
		Slots = slots;
        Account = account;
        TransactionLog = transactionLog;
    }

	public void HelloVendingMachine(BankAccount account, Stack transactionLog)
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
        HelloVendingMachine(Account, TransactionLog);
        AddConsumables();
        RunMainMenu(Account, TransactionLog);
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
            RunMainMenu(Account, TransactionLog);
        }
    }

    public void RunMainMenu(BankAccount account, Stack transactionLog)
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
            ShowConsumables(transactionLog);
            ResetColor();
            GoBack();

        }

        if (choice == "2")
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(options[1]);
            WriteLine(separator);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"Your current balance is {account.Balance} eurodollars");
            GoBack();
        }

        if (choice == "3")
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(options[2]);
            WriteLine(separator);
            Withdraw();
            GoBack();
        }

        if (choice == "4")
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(options[3]);
            WriteLine(separator);
            DisplayTransactions(transactionLog);
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

        if (Int32.TryParse(choice, out int choiceInt) && choiceInt > 5 || choiceInt < 1)
        {
            ErrorMessage();
            RunMainMenu(Account, TransactionLog);
        }
        else
        {
            ErrorMessage();
            RunMainMenu(Account, TransactionLog);
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

    public void ShowConsumables(Stack transactionLog)
    {
        foreach (var item in Items)
        {
            WriteLine($"[{item.Id}] - {item.Name} | Price: {item.Price}");
        }
        PurchaseSoda(transactionLog);
    }

    public void Withdraw()
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("Alright, enter the amount you to want withdraw below.");
        ForegroundColor = ConsoleColor.White;
        string withdraw = ReadLine();

        int balance = Account.Balance;

        if (!Int32.TryParse(withdraw, out int withdrawInt) || withdrawInt < 1)
        {
            ErrorMessage();
            WriteLine(withdrawInt);
            Withdraw();
        } else
        {
            Account.Balance += withdrawInt;
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine($"{withdrawInt} eurodollars has been added to your account.");
        }

    }

    public void PurchaseSoda(Stack transactionLog)
    {
        WriteLine("\nPlease select a number to buy Soda:");

        string sodaChoice = ReadLine();

        int balance = Account.Balance;

        if (!Int32.TryParse(sodaChoice, out int sodaInt) || sodaInt > 6 || sodaInt < 1)
        {
            ErrorMessage();
            WriteLine(sodaInt);
            PurchaseSoda(transactionLog);
        }

        int sodaId = sodaInt - 1;
        int itemPrice = Items[sodaId].Price;

        void ShowReceipt(int balance)
        {
           WriteLine($"Enjoy your {Items[sodaId].Name} \nYour balance is now: {balance} eurodollars.");
        }

        if (Account.Balance < itemPrice)
        {
            PurchaseDeclined();
            GoBack();
        }

        if (Int32.TryParse(sodaChoice, out int sodaInteger))
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (sodaInteger == i + 1)
                {
                    Account.Balance -= itemPrice;
                    //LogTransactions();
                    transactionLog.Push($"{Items[sodaId].Name} \t {itemPrice}");
                    PurchaseSuccess();
                    ShowReceipt(Account.Balance);
                    GoBack();
                }
            }
        }
    }

    public void ErrorMessage()
    {
        WriteLine(separator);
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"That's not a valid input {Account.Owner}..");
        ForegroundColor = ConsoleColor.White;
        WriteLine(separator);
    }

    public void PurchaseDeclined()
    {
        WriteLine(separator);
        Console.ForegroundColor = ConsoleColor.Yellow;
        WriteLine("Poor soul.. You don't have enough to buy this soda.");
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine(separator);
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

    public void DisplayTransactions(Stack transactionLog)
    {
        // Displays the properties and values of the Stack.
        ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Your transactions");
        Console.WriteLine("\tCount:    {0}", transactionLog.Count);
        Console.Write("\tValues:");
        PrintValues(transactionLog);
    }

    public static void PrintValues(IEnumerable myCollection)
    {
        foreach (Object obj in myCollection)
            Console.Write("    {0}", obj);
        Console.WriteLine();
    }
}