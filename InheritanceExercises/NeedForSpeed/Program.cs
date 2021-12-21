using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(12, 50);
            vehicle.Drive(22);
            Console.WriteLine(vehicle.Fuel);

            SportCar sport = new SportCar(22 , 13);
            sport.Drive(22);
            Console.WriteLine(sport.Fuel);

            Car carr = new Car(50 , 13);
            carr.Drive(22);
            Console.WriteLine(carr.Fuel);

            RaceMotorcycle car = new RaceMotorcycle(50 , 13);
            car.Drive(22);
            Console.WriteLine(car.Fuel);

        }
    }
}
