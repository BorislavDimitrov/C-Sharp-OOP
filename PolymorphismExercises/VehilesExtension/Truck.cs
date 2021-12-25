using System;
using System.Collections.Generic;
using System.Text;

namespace VehilesExtension
{
    public class Truck : Vehicle
    {
        private const double AdditionalAirconConsum = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption { get => base.FuelConsumption + AdditionalAirconConsum; protected set => base.FuelConsumption = value; }
        public override void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (FuelQuantity + litters > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {litters} fuel in the tank");
            }
            litters *= 0.95;
            base.Refuel(litters);
        }
    }
}
