using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodModels;

namespace WildFarm.AnimalModels
{
    public class Owl : Bird
    {
        private const string OnlyEatableFood = "Meat";
        private const double WeightGainPerPiece = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(IFood food)
        {
            if (food.GetType().Name != OnlyEatableFood)
            {
                Console.WriteLine($"{this.GetType()} does not eat {food.GetType().Name}!");
                return;
            }
            this.Weight += WeightGainPerPiece * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
