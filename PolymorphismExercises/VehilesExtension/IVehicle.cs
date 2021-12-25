using System;
using System.Collections.Generic;
using System.Text;

namespace VehilesExtension
{
    public  interface IVehicle
    {
        public double FuelQuantity { get;}
        public double FuelConsumption { get;}
        public double TankCapacity { get; }
        public bool CanDrive(double distance);
        public bool isEmpty { get; set; }
        public void Drive(double distance);
        public void Refuel(double litters);
    }
}
