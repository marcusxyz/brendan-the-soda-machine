class Consumable
{
	public string Name { get; }
	public int Price { get; }
	public int Stock { get; }

	public Consumable(string name, int price, int stock)
	{
		Name = name;
		Price = price;
		Stock = stock;
	}
}


