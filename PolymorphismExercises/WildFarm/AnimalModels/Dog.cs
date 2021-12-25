using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodModels;

namespace WildFarm.AnimalModels
{
    public class Dog : Mammal
    {
        private const string OnlyEatableFood = "Meat";
        private const double WeightGainPerPiece = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Feed(IFood food)
        {
            if (food.GetType().Name != OnlyEatableFood)
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }
            this.Weight += WeightGainPerPiece * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
