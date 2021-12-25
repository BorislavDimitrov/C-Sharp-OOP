using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodModels;

namespace WildFarm.AnimalModels
{
    public class Mouse : Mammal
    {
        private  List<string> OnlyEatableFood = new List<string>{ "Vegetable", "Fruit"};
        private const double WeightGainPerPiece = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
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
            Console.WriteLine("Squeak");
        }
    }
}
