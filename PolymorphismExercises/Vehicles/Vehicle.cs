using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; protected set; }
        public virtual double FuelConsumption { get; protected set; }

        public bool CanDrive(double distance)
        {
            if (distance * FuelConsumption >= FuelQuantity)
            {
                return false;
            }
            return true;
        }

        public void Drive(double distance)
        {
            if (!CanDrive(distance))
            {
                return;
            }
            FuelQuantity -= distance * FuelConsumption;
        }

        public virtual void Refuel(double littlers)
        {
            FuelQuantity += littlers;
        }
    }
}
