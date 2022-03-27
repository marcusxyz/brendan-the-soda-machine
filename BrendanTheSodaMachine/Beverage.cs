class Beverage
{
	public string Id { get; }
	public string Name { get; }
	public int Price { get; }

	public Beverage(string id, string name, int price)
	{
		Name = name;
		Price = price;
		Id = id;
	}
}


