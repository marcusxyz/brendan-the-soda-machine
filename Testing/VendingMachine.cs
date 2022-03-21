using System;
using static System.Console;
namespace BrendanTheSodaMachine
{
	class VendingMachine
	{
		public void Start()
        {
			Title = "Brendan The Soda Machine";
			RunMainMenu();
        }

		private void RunMainMenu()
        {
			string prompt = "(Use arrow keys to navigate through options, press enter to select) \n\nHello stranger, what can I offer you today?";
			string[] options =
			{
				"I'm feeling thirsty, what drinks do you have?",
				"I need to check my balance",
				"I need to withraw some eurodollars",
				"I need to check my purchase history",
				"Cya Brendan!",
			};
			Menu mainMenu = new Menu(prompt, options);
			int selectedIndex = mainMenu.Run();

			switch (selectedIndex)
            {
				case 0:
					DisplaySodas();
					break;
				case 1:
					DisplayBalance();
					break;
				case 2:
					DisplayWithraw();
					break;
				case 3:
					DisplayPurchaseHistory();
					break;
				case 4:
					Exit();
					break;
				default:
					break;
            }
        }

		private void DisplaySodas()
        {
			Clear();
			SodaShop BrendansSodas = new SodaShop();
			BrendansSodas.Run();
			
			WriteLine("\n(Press any key to return to the menu)");
			ReadKey(true);
			RunMainMenu();
        }

		private void DisplayBalance()
        {

        }

		private void DisplayWithraw()
        {

        }

		private void DisplayPurchaseHistory()
        {

        }

		private void Exit()
        {
			WriteLine("\nCya stranger");
			//Environment.Exit(0);
        }
	}
}

