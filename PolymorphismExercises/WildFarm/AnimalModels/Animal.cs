using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodModels;

namespace WildFarm.AnimalModels
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void Feed(IFood food);

        public abstract void ProduceSound();
        
    }
}
