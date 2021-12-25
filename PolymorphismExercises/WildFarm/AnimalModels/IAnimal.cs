using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodModels;

namespace WildFarm.AnimalModels
{
    public interface IAnimal
    {
        public string Name { get;}
        public double Weight { get;}
        public int FoodEaten { get; }
        public void Feed(IFood food);
        public void ProduceSound();
    }
}
