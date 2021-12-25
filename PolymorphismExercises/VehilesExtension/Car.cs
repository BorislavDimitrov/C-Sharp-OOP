using System;
using System.Collections.Generic;
using System.Text;

namespace VehilesExtension
{
    public class Car : Vehicle
    {
        private const double AdditionalAirconConsum = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption { get => base.FuelConsumption + AdditionalAirconConsum;}
    }
}
