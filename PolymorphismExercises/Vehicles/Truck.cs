using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{

    public class Truck : Vehicle
    {
        private const double AdditionalAirconConsum = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption { get => base.FuelConsumption + AdditionalAirconConsum; protected set => base.FuelConsumption = value; }

        public override void Refuel(double littlers)
        {
            littlers *= 0.95;
            base.Refuel(littlers);
        }
    }
}
