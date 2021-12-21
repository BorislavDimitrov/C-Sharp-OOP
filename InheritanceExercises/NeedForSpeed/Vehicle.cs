using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private const double DefaultFuelConsumption = 1.25;
        public  virtual double FuelConsumption { get => DefaultFuelConsumption; }
        public int HorsePower { get => horsePower; set => horsePower = value;}
        public double Fuel { get => fuel; set => fuel = value; }
        public Vehicle(int horsePower, double fuel)
        {
            this.horsePower = horsePower;
            this.fuel = fuel;          
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}
