﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AnimalModels
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
