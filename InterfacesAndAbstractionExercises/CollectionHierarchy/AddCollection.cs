using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    class AddCollection : IAdd
    {
        private List<string> items;

        public AddCollection()
        {
            this.items = new List<string>();
        }

        public int Add(string item)
        {
            items.Add(item);
            return items.Count - 1;
        }
    }
}
