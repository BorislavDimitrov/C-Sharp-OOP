using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodModels;

namespace WildFarm.AnimalModels
{
    public class Cat : Feline
    {
        private List<string> OnlyEatableFood = new List<string> { "Meat", "Vegetable" };
        private const double WeightGainPerPiece = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight,livingRegion, breed)
        {
        }

        public override void Feed(IFood food)
        {
            if (!OnlyEatableFood.Contains(food.GetType().Name))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }
            this.Weight += WeightGainPerPiece * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
