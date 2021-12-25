using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AdditionalAirconConsum = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumption { get => base.FuelConsumption + AdditionalAirconConsum; protected set => base.FuelConsumption = value; }
    }
}
