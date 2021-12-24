using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<string> items = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();

            List<int> addCollectionResult = new List<int>();
            List<int> addRemoveCollectionResult = new List<int>();
            List<int> myListResult = new List<int>();
            foreach (var item in items)
            {
                addCollectionResult.Add(addCollection.Add(item));
                addRemoveCollectionResult.Add(addRemoveCollection.Add(item));
                myListResult.Add(myList.Add(item));
            }
            Console.WriteLine(string.Join(" " , addCollectionResult));
            Console.WriteLine(string.Join(" " , addRemoveCollectionResult ));
            Console.WriteLine(string.Join(" " , myListResult));

            int numberItemsToDelete = int.Parse(Console.ReadLine());

            List<string> addRemoveItemsResult = new List<string>();
            List<string> myListItemsResult = new List<string>();

            for (int i = 0; i < numberItemsToDelete; i++)
            {
                addRemoveItemsResult.Add(addRemoveCollection.Remove());
                myListItemsResult.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" " , addRemoveItemsResult));
            Console.WriteLine(string.Join(" " , myListItemsResult));
        }
    }
}
