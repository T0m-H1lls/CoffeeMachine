namespace CoffeShop;

public class Drinks
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public float Price { get; set; }

    public Drinks(int id,string name, float price)
    {
        Id = id;
        Name = name;
        Price = price;
        
    }
}