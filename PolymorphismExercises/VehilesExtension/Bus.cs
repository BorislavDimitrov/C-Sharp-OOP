using System;
using System.Collections.Generic;
using System.Text;

namespace VehilesExtension
{
    public class Bus : Vehicle
    {
        private const double AdditionalAirconConsum = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
        {
            get
            {
                if (isEmpty == true)
                {
                    return base.FuelConsumption;
                }
                else
                {
                    return base.FuelConsumption + AdditionalAirconConsum;
                }
            }
        }
    }
}
