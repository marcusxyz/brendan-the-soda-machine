class Consumable
{
	public string Id { get; }
	public string Name { get; }
	public int Price { get; }

	public Consumable(string id, string name, int price)
	{
		Name = name;
		Price = price;
		Id = id;
	}
}


