using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }

                List<string> animalInfo = Console.ReadLine().Split().ToList();
                string animalName = animalInfo[0];
                int animalAge = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];
                Animal newAnimal;
                
                if (animalAge < 1)
                {
                    animals.Add(null);
                    continue;
                }

                if (gender != "Male" && gender != "Female")
                {
                    animals.Add(null);
                    continue;
                }

                if (animalType != "Frog" && animalType != "Dog" && animalType
                    != "Cat" && animalType != "Kitten" && animalType != "Tomcat")
                {
                    animals.Add(null);
                    continue;
                }

                if (animalType == "Dog")
                {
                    newAnimal = new Dog(animalName, animalAge, gender);
                }
                else if (animalType == "Frog")
                {
                    newAnimal = new Frog(animalName, animalAge, gender);
                }
                else if (animalType == "Cat")
                {
                    newAnimal = new Cat(animalName, animalAge, gender);
                }
                else if (animalType == "Kitten")
                {
                    newAnimal = new Kitten(animalName, animalAge);
                }
                else 
                {
                    newAnimal = new Tomcat(animalName, animalAge);
                }

                animals.Add(newAnimal);
            }

            foreach (var animal in animals)
            {
                if (animal == null)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name}");
                    Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                    Console.WriteLine(animal.ProduceSound());
                }
            }
        }
    }
}
