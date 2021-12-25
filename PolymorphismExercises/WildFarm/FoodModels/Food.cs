using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.FoodModels
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity {get; set;}
    }
}
