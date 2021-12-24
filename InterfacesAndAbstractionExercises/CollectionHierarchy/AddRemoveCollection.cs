using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    class AddRemoveCollection : IAddRemove
    {
        private List<string> items;

        public AddRemoveCollection()
        {
            this.items = new List<string>();
        }
        public int Add(string item)
        {
            items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removeItem = items.Last();
            items.RemoveAt(items.Count - 1);
            return removeItem;
        }
    }
}
