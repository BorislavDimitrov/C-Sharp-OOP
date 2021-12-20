using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog newDog = new Dog();
            newDog.Eat();
            newDog.Bark();

            Cat newCat = new Cat();
            newCat.Eat();
            newCat.Meow();
        }
    }
}
