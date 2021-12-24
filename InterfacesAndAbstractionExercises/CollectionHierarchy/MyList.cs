using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IListable
    {
        private List<string> items;

        public MyList()
        {
            this.items = new List<string>();
        }
        public int Used { get => items.Count; }

        public int Add(string item)
        {
            items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removeItem = items.First();
            items.RemoveAt(0);
            return removeItem;
        }
    }
}
