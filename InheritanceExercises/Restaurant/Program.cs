using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Coffee coffee = new Coffee("kafe" , 4);
            Console.WriteLine(coffee.Name);
            Console.WriteLine(coffee.Price);
            Console.WriteLine(coffee.Milliliters);
            Console.WriteLine(coffee.Caffeine);

            Cake cake = new Cake("torta");
            Console.WriteLine(cake.Name);
            Console.WriteLine(cake.Price);
            Console.WriteLine(cake.Grams);
            Console.WriteLine(cake.Calories);

            Fish fish = new Fish("riba" , 45 , 43);
            Console.WriteLine(fish.Name);
            Console.WriteLine(fish.Price);
            Console.WriteLine(fish.Grams);
        }
    }
}
