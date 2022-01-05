using NUnit.Framework;
using System;

namespace CarManager.Tests
{
    public class CarTests
    {
        [Test]
        public void ConstructorShouldMakeACar()
        {
            Car car = new Car("Audi", "RS7", 5.90, 120);
        }

        [Test]
        public void FuelAmountPropertyShouldReturnDefaultZeroValue()
        {
            Car car = new Car("Audi", "RS7", 5.90, 120);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("Porsche", "Spyder 918")]
        [TestCase("Toyota", "Land Cruiser")]
        public void MakePropertyShouldReturnRightValue(string make, string model)
        {
            Car car = new Car($"{make}", $"{model}", 5.90, 120);
            Assert.AreEqual(make, car.Make);
        }

        [Test]
        [TestCase("Porsche", "Spyder 918")]
        [TestCase("Toyota", "Land Cruiser")]
        public void ModelPropertyShouldReturnRightValue(string make, string model)
        {
            Car car = new Car($"{make}", $"{model}", 5.90, 120);
            Assert.AreEqual(model, car.Model);
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6)]
        [TestCase("Toyota", "Land Cruiser", 13.9)]
        public void FuelConsumptionPropertyShouldReturnRightValue
            (string make, string model, double fuelConsumption)
        {
            Car car = new Car($"{make}", $"{model}", fuelConsumption, 120);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6, 120)]
        [TestCase("Toyota", "Land Cruiser", 13.9 , 100)]
        public void FuelCapacityPropertyShouldReturnRightValue
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase(null, "Spyder 918", 15.6, 120)]
        [TestCase(null, "Land Cruiser", 13.9, 100)]
        public void MakePropertyShouldThrow
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("Porsche", null, 15.6, 120)]
        [TestCase("Toyota", null, 13.9, 100)]
        public void ModelPropertyShouldThrowArgumentException
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 0, 120)]
        [TestCase("Toyota", "Land Cruiser", -1, 100)]
        public void FuelConsumptioPropertyShouldThrowArgumentException
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6, 0)]
        [TestCase("Toyota", "Land Cruiser", 13.9, -100)]
        public void FuelCapacityPropertyShouldThrowArgumentException
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6, 120, 40)]
        [TestCase("Toyota", "Land Cruiser", 13.9, 100, 70.9)]
        public void RefuelShouldAddFuelRight
            (string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6, 120, 150)]
        [TestCase("Toyota", "Land Cruiser", 13.9, 100, 1500)]
        public void RefuelShouldNotPassItsFuelCapacity
            (string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6, 120, -40)]
        [TestCase("Toyota", "Land Cruiser", 13.9, 100, 0)]
        public void RefuelShouldThrowArgumentException
            (string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity);
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6, 120, 120, 20)]
        [TestCase("Toyota", "Land Cruiser", 13.9, 100, 100, 120)]
        public void DriveShouldReturnRightAmauntAfterIsUsed
            (string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double kmToDrive)
        {
            Car car = new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            double fuelNeeded = (kmToDrive / 100) * fuelConsumption;
            car.Drive(kmToDrive);
            double amaountLeft = fuelToRefuel - fuelNeeded;
            Assert.AreEqual(amaountLeft, car.FuelAmount);
        }

        [Test]
        [TestCase("Porsche", "Spyder 918", 15.6, 120, 50, 1000)]
        [TestCase("Toyota", "Land Cruiser", 13.9, 100, 60, 4000)]
        public void DriveShoulThrowOperationException
            (string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double kmToDrive)
        {
            Car car = new Car($"{make}", $"{model}", fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            Assert.Throws<InvalidOperationException>(() => car.Drive(kmToDrive));
            
        }
    }
}