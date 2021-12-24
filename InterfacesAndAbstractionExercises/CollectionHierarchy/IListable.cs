using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IListable : IAddRemove
    {
        public int Used { get; }
    }
}
