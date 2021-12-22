using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            List<string> peopleInfo = Console.ReadLine().Split(";" , StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < peopleInfo.Count; i++)
            {
                List<string> personInfo = peopleInfo[i].Split("=" , StringSplitOptions.RemoveEmptyEntries).ToList();
                string personName = personInfo[0];
                double personMoney = double.Parse(personInfo[1]);
                Person newPerson = new Person(personName, personMoney);
                people.Add(newPerson);
            }

            List<String> productsInfo = Console.ReadLine().Split(";" , StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < productsInfo.Count; i++)
            {
                List<string> productInfo = productsInfo[i].Split("=" , StringSplitOptions.RemoveEmptyEntries).ToList();
                string productName = productInfo[0];
                double productCost = double.Parse(productInfo[1]);
                Product newProduct = new Product(productName, productCost);
                products.Add(newProduct);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                List<string> purchaseInfo = input.Split().ToList();
                string personName = purchaseInfo[0];
                string productName = purchaseInfo[1];

                Product boughtProduct = products.First(x => x.Name == productName);
                if (people.First(x => x.Name == personName).Money >= boughtProduct.Cost)
                {
                    people.First(x => x.Name == personName).AddProduct(boughtProduct);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }
                List<string> productNames = new List<string>();
                foreach (var product in person.Products)
                {
                    productNames.Add(product.Name);
                }
                Console.WriteLine($"{person.Name} - {string.Join(", " , productNames)}");
            }
        }
    }
}
