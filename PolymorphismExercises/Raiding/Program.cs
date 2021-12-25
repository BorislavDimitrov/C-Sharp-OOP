using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBaseHero> heroes = new List<IBaseHero>();

            int numberOfInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInput; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType != "Druid" && heroType != "Paladin" && heroType != "Rogue" && heroType != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                    i -= 1;
                    continue;
                }
                
                IBaseHero newHero = null;
                if (heroType == "Druid")
                {
                    newHero = new Druid(heroName);
                }
                else if (heroType == "Paladin")
                {
                    newHero = new Paladin(heroName);
                }
                else if (heroType == "Rogue")
                {
                    newHero = new Rogue(heroName);
                }
                else
                {
                    newHero = new Warrior(heroName);
                }
                heroes.Add(newHero);
            }

            int bossHealth = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossHealth -= hero.Power;
            }

            if (bossHealth <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
