namespace CoffeShop;

public class Ingredient
{
    public Ingredient(int id, string name, float price,int count) 
    {
        Id = id;
        Name = name;
        Price = price;
        Count = count;
    }
    
    public int Id { get; private set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }
   
    
}