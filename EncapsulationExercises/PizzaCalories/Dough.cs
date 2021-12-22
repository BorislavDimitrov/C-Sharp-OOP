using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>
        {
            {"white" , 1.5},
            {"wholegrain", 1.0 }
        };
        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0}
        };
        private const double BaseModifier = 2;
        private string flourType;
        private string bakingTechnique;
        private double grams;


        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }
        private string FlourType
        {           
             set
             {
                try
                {
                    if (!flourTypeCalories.ContainsKey(value.ToLower()))
                    {
                        throw new Exception();
                    }
                    flourType = value;
                }
                catch 
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);
                }        
             }
        }

        private string BakingTechnique
        {
            set
            {
                try
                {
                    if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                    {
                        throw new Exception();
                    }
                    bakingTechnique = value;
                }
                catch 
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);  
                }
            }
        }

        private double Grams
        {
            get => grams;
            set
            {
                try
                {
                    if (value < 1 || value > 200)
                    {
                        throw new Exception();
                    }
                    grams = value;
                }
                catch 
                {
                    Console.WriteLine("Dough weight should be in rage [1..200].");
                    Environment.Exit(0);
                }            
            }
        }

        public double CalculateCalories()
        {
            return BaseModifier * flourTypeCalories[this.flourType.ToLower()] * bakingTechniqueCalories[bakingTechnique.ToLower()] * Grams;
        }
    }
}
