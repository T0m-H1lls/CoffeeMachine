namespace CoffeShop;

public class Drink
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    
    public Drink(int id,string name, float price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
    
    
    
    
}