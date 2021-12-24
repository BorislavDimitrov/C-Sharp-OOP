using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddRemove : IAdd
    {
        string Remove();
    }
}
