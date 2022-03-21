using System;
using static System.Console;
namespace BrendanTheSodaMachine
{
	class Menu
	{
		private int SelectedIndex;
		private string[] Options;
		private string Prompt;
		public Menu(string prompt, string[] options)
        {
			SelectedIndex = 0;
			Options = options;
			Prompt = prompt;
        }

		private void DisplayMenu()
        {
			WriteLine(Prompt);
			WriteLine("#################################################");
            for (int i = 0; i < Options.Length; i++)
            {
				string currentOption = Options[i];
				string prefix;
				string suffix;

                if (i == SelectedIndex)
                {
					prefix = " ->";
					suffix = "<- ";
					ForegroundColor = ConsoleColor.Black;
					BackgroundColor = ConsoleColor.White;
                }
                else
                {
					prefix = "   ";
					suffix = "   ";
					ForegroundColor = ConsoleColor.White;
					BackgroundColor = ConsoleColor.Black;
				}

				WriteLine($"{prefix} {currentOption} {suffix}");
			}
			ResetColor();
        }

		public int Run()
        {
			ConsoleKey keyPressed;
			do
			{
				Clear();
				DisplayMenu();

				ConsoleKeyInfo keyInfo = ReadKey(true);
				keyPressed = keyInfo.Key;

				// Updated SelectedIndex based on arrow keys
				if (keyPressed == ConsoleKey.UpArrow)
                {
					SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
						SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
					SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
						SelectedIndex = 0;
                    }
                }

			} while (keyPressed != ConsoleKey.Enter);

			return SelectedIndex;
        }
	}
}

