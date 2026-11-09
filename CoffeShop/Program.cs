using System.Runtime.Serialization.Json;

namespace CoffeShop;

class Program
{
    private static float viruchka = 0;

    static void Main(string[] args)
    {
        static void Clear()
        {
            Console.Clear();
        }

        CoffeShop coffeShop = new CoffeShop();

        List<Drinks> drinksList = new List<Drinks>();
        List<Ingredient> ingredientsList = new List<Ingredient>();
        float summ = 0;
        while (true)
        {
            Console.WriteLine("CoffeShop \n" +
                              "1. Сделать заказ \n" +
                              "2. Вывести выручку \n" +
                              "3. Выйти ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                    {
                        Clear();

                        Console.WriteLine("Выберите напиток: ");
                        coffeShop.GetAllDrinks();

                        int.TryParse(Console.ReadLine(), out int choiceDrink);

                        Drinks? drink = coffeShop.ChoiceDrink(choiceDrink);
                       
                        drinksList.Add(drink!);
                        
                        Console.WriteLine($"Выбранно {drink!.Name}");
                        Clear();
                        
                        bool flag = true;
                        while (flag)
                        {
                            Console.WriteLine("Выберите ингредиент: (0 если хотите продолжить)");
                            coffeShop.GetAllIngredients();
                            int.TryParse(Console.ReadLine(), out int choiceIngredient);
                            if (choiceIngredient == 0)
                            {
                                flag = false;
                                Clear();
                                 continue;
                            }
                            
                            Ingredient? ingr = coffeShop.ChoiceIngredient(choiceIngredient);
                            if (ingr == null)
                            {
                                continue;
                            }
                            ingredientsList.Add(ingr!);
                            
                            Console.WriteLine($"Добавлено {ingr!.Name} к {drink.Name}");
                        }
                        Console.WriteLine(" === ЧЕК === ");

                        foreach (var coffeDrink in drinksList)
                        {
                            
                            Console.WriteLine($"{coffeDrink.Name} -> {coffeDrink.Price}");
                            foreach (var ingredient in ingredientsList)
                            {
                                ingredient.Count = 0;
                                Console.WriteLine($" + {ingredient.Name} -> {ingredient.Price}");
                                summ += ingredient.Price;
                            }
                            summ += coffeDrink.Price;
                            
                        }
                        
                        Console.WriteLine($"Итого: {summ}");
                        Console.WriteLine("================");
                        
                        coffeShop.Pay(summ);
                        viruchka += summ;
                        drinksList.Clear();
                        ingredientsList.Clear();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine(viruchka);
                        break;
                    }
                    case 3:
                    {
                        return;
                    }
                }
            }
        }
    }
}