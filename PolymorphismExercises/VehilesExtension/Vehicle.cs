using System;
using System.Collections.Generic;
using System.Text;

namespace VehilesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;          
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get; protected set; }

        public bool isEmpty{ get; set; }

        public bool CanDrive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                return false;
            }
            return true;
        }

        public virtual void Drive(double distance)
        {
            if (!CanDrive(distance))
            {
                return;
            }

            FuelQuantity -= distance * FuelConsumption;
        }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (FuelQuantity + litters > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {litters} fuel in the tank");
            }
            FuelQuantity += litters;
        }
    }
}
