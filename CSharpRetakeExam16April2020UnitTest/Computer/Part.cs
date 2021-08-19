using System;
using System.Collections.Generic;
using System.Text;

namespace Computers
{
    public class Part
    {
        public Part(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
