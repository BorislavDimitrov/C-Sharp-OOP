using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> carInput = Console.ReadLine().Split().ToList();
            List<string> truckInput = Console.ReadLine().Split().ToList();

            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);
            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);

            double truckFuelQuantity = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNumber; i++)
            {
                List<string> vehicleInput = Console.ReadLine().Split().ToList();
                string command = vehicleInput[0];
                string vehicleType = vehicleInput[1];
                double value = double.Parse(vehicleInput[2]);

                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        if (car.CanDrive(value) == true)
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else if (vehicleType == "Truck")
                    {
                        if (truck.CanDrive(value) == true)
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
