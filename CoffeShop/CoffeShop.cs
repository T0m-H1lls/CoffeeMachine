namespace CoffeShop;

public class CoffeShop
{
    
    private List<Drinks> _drinks = new();
    private List<Ingredient> _ingredients = new();

    public CoffeShop()
    {
        _drinks =
        [
            new(1,"Эспрессо", 50),
            new(2,"Американо", 60),
            new(3,"Капучино", 80),
            new(4,"Латте", 85),
            new(5,"Чай(черный/зеленый)", 50)
        ];

        _ingredients =
        [
            new(1,"Молоко", 10,0),
            new(2,"Сахар", 0,0),
            new(3,"Сироп ванильный", 15,0),
            new(4,"Сироп карамельный", 15,0),
            new(5,"Взбитые сливки", 20,0),
            new(6,"Корица", 5,0)
        ];
    }

    public void GetAllDrinks()
    {
      
        foreach (var drink in _drinks)
        {
            Console.WriteLine($"{drink.Id} - {drink.Name} -> {drink.Price}");
        }
    }
    
    public void GetAllIngredients()
    {
        
        foreach (var ingr in _ingredients)
        {
            Console.WriteLine($"{ingr.Id} - {ingr.Name} -> {ingr.Price}");
        }
    }

    public Drinks? ChoiceDrink(int num)
    {
        var findDr = _drinks.FirstOrDefault(x => x.Id == num);
        if(findDr != null)
        {
            return findDr;
        }
        else
        {
            return null;
        }
        
    }

    public Ingredient? ChoiceIngredient(int num)
    {
        var findIngr = _ingredients.FirstOrDefault(x => x.Id == num); 
        
        if (findIngr == null)
        {
            Console.WriteLine($"Ингредиент с Id {num} не найден!");
            return null;
        } 
        
        if (findIngr!.Count == 1) 
        { 
            Console.WriteLine("Нельзя выбрать 2 одинаковых ингредиента!");
            return null;
        } 
        
        findIngr.Count++; 
        return findIngr; 
    }

    public float Pay(float money)
    {
        Console.WriteLine("Подтвердить: " +
                          "1.Да" +
                          "2.Нет");
        var inpNum = int.Parse(Console.ReadLine()!);
        if (inpNum == 1)
        {
            Console.WriteLine("Введите сумму: ");
            float.TryParse(Console.ReadLine(), out float moneyInt);
            if (moneyInt > money)
            {
                moneyInt -= money ;
                Console.WriteLine($"Сдача: {moneyInt}");
                return money;
            }
            else if (moneyInt < money)
            {
                Console.WriteLine("Недостаточно средств");
                return 0;
            }
            else
            {
                Console.WriteLine("Успешно");
            }
        }
        else
            Console.Clear();
        return money;
    }
    
}