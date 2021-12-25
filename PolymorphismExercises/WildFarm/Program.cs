using System;
using WildFarm.FoodModels;
using WildFarm.AnimalModels;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            List<IFood> foods = new List<IFood>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                List<string> animalInfo = input.Split().ToList();
                string animalType = animalInfo[0];
                string animalName = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                IAnimal newAnimal = null;
                if (animalType == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    newAnimal = new Owl(animalName, weight, wingSize);
                }
                else if (animalType == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    newAnimal = new Hen(animalName, weight, wingSize);
                }
                else if (animalType == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    newAnimal = new Mouse(animalName, weight, livingRegion);
                }
                else if (animalType == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    newAnimal = new Dog(animalName, weight, livingRegion);
                }
                else if (animalType == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    newAnimal = new Cat(animalName, weight, livingRegion, breed);
                }
                else if (animalType == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    newAnimal = new Tiger(animalName, weight, livingRegion, breed);
                }

                List<string> foodInfo = Console.ReadLine().Split().ToList();
                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);
                IFood newFood = null;

                if (foodType == "Fruit")
                {
                    newFood = new Fruit(foodQuantity);
                }
                else if (foodType == "Meat")
                {
                    newFood = new Meat(foodQuantity);
                }
                else if (foodType == "Seeds")
                {
                    newFood = new Seeds(foodQuantity);
                }
                else if (foodType == "Vegetable")
                {
                    newFood = new Vegetable(foodQuantity);
                }

                newAnimal.ProduceSound();
                newAnimal.Feed(newFood);
                animals.Add(newAnimal);
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i].ToString());
            }
        }
    }
}
