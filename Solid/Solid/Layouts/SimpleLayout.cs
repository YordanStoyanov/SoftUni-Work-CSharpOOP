using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Template
        {
            get
            {
                return "{0} - {1} - {2}";
            }
        }
    }
}
