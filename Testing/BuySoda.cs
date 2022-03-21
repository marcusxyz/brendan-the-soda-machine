using System;
using static System.Console;
namespace BrendanTheSodaMachine
{
	class SodaShop
	{
		public void Run()
		{
			// Run all the shop logic here
			//DisplayIntro();
			DisplayAllSodas();
			DisplayOutro();
		}

		//private void DisplayIntro()
  //      {
		//	WriteLine("I'm feeling thirsty, what drinks do you have? \n\nI have a wide range of sodas just for you my friend :)");
  //      }

		//private readonly List<Soda> Items = new List<Soda>();

		//private void DisplayAllSodas()
  //      {
		//	Items.Add(new Soda("NiCola", 10, 7));
		//	Items.Add(new Soda("NiCola Sakura", 10, 12));
		//	Items.Add(new Soda("NiCola Lime", 10, 14));
		//	Items.Add(new Soda("Shwabshwab Blue", 15, 13));
		//	Items.Add(new Soda("Shwabshwab Grape", 15, 2));
		//	Items.Add(new Soda("Ab-synth", 20, 6));

  //          foreach (var item in Items)
  //          {
  //              WriteLine($"{item.Name} \t {item.Price}Eurodollars \t Stock: {item.Stock}" );
  //          }
		//}

		private void DisplayAllSodas()
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
					SellItem("Nicola", 12);
					SellItem("Nicola Light", 12);
					break;
				case 1:
					break;
				case 2:
					SellItem("Nicola Zero", 12);
					break;
				case 3:
					Exit();
					break;
				default:
					break;
			}
		}

		private void SellItem(string sodaName, int price)
        {
			WriteLine($"{sodaName} \t \t \t Price: {price}");
        }

		private void DisplayNewBalance()
        {

        }

		private void DisplayOutro()
        {
			WriteLine("Pleasure doing business with you!");
			ReadKey();
        }

		private void Exit()
		{
			WriteLine("\nCya stranger");
			//Environment.Exit(0);
		}
	}
}

