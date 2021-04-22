using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                double totalResult = 0;
                while (!input.Contains("END"))
                {
                    string[] pizzaParts = input.Split().ToArray();
                    string pizzaName = pizzaParts[1];
                    Pizza pizza = new Pizza(pizzaName);

                    input = Console.ReadLine();
                    string[] parts = input.Split().ToArray();
                    string flourType = parts[1];
                    string bakingTech = parts[2];
                    double weight = double.Parse(parts[3]);
                    var dough = new Dough(flourType, bakingTech, weight);
                    double result = dough.CalculateTotalCalories();
                    totalResult += result;
                    input = Console.ReadLine();
                    while (!input.Contains("END"))
                    {
                        string[] partsTwo = input.Split().ToArray();
                        string toppingType = partsTwo[1];
                        double toppingWeight = double.Parse(partsTwo[2]);
                        var topping = new Topping(toppingType, toppingWeight);
                        var resultTwo = topping.CalculateTotalCalories();
                        pizza.AddToppingToList(topping);
                        totalResult += resultTwo;
                        input = Console.ReadLine();
                        if (input.Contains("END"))
                        {
                            //Console.WriteLine($"{result:F2}");
                            //Console.WriteLine($"{resultTwo:F2}");
                            Console.WriteLine($"Meatless - {totalResult:F2} Calories.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
