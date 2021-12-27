using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Factory
{
    public class LayoutFactory
    {
        public ILayout Create(string type)
        {
            ILayout layout = null;

            if (type == nameof(SimpleLayout))
            {
                layout = new SimpleLayout();
            }
            else if (type == nameof(XmlLayout))
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new ArgumentException();
            }
            return layout;
        }
    }
}
