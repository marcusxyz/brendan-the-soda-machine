using System;
using static System.Console;

namespace BrendanTheSodaMachine;


public class VendingMachine
{
	public string Name { get; }
	public int Slots { get; }

    private BankAccount BankAccount { get; }

    public VendingMachine(string name, int slots)
    {
		Name = name;
		Slots = slots;

    }

	public void HelloVendingMachine()
	{
        var account = new BankAccount("Mr.Silverhand", 1000);
        WriteLine("----------------------------------------------------");
        ForegroundColor = ConsoleColor.Green;
		WriteLine($"Hello {Name}!");
        ForegroundColor = ConsoleColor.Yellow;
		WriteLine($"Hi {account.Owner}, what can I offer you today?");
		ForegroundColor = ConsoleColor.White;
    }

    public void Start()
    {
        HelloVendingMachine();
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
            RunMainMenu();
        }
    }

    public void RunMainMenu()
    {
        while (true)
        {
            List<string> options = new List<string>
            {
                "----------------------------------------------------",
                "[1] I'm feeling thirsty, what drinks do you have?",
                "[2] I need to check my balance",
                "[3] I need to withraw some eurodollars",
                "[4] I need to check my purchase history",
                $"[5] Cya {Name}!",
                "----------------------------------------------------"
            };

            foreach (string option in options)
            WriteLine(option);
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Clear();
                ForegroundColor = ConsoleColor.Green;
                WriteLine("----------------------------------------------------");
                WriteLine(options[1]);
                WriteLine("----------------------------------------------------");
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("**Brendan shows a list of items available for purchase**");
                //Inventory Sodas = new Inventory();
                //Inventory.ShowConsumables();
                ResetColor();
                GoBack();

                }
         
            if (choice == "2")
            {
                var balance = BankAccount.GetBalance();
                WriteLine($"Your current balance is {balance} eurodollars");
                GoBack();
            }

            if (choice == "3")
            {
                WriteLine("Withdraw eurodollars");
                GoBack();
            }

            if (choice == "4")
            {
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
                break;
            }

        }
    }
}



