using System;
using static System.Console;
namespace BrendanTheSodaMachine
{
	class Soda
	{
		public string Name { get; }
		public int Price { get; }
		public int Stock { get; }

		public Soda(string name, int price, int stock)
		{
			Name = name;
			Price = price;
			Stock = stock;
		}
	}

}

