using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters)
            :base(name, price, milliliters)
        {
            base.Name = name;
            base.Price = price;
            base.Milliliters = milliliters;
        }



        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override decimal Price
        {
            get {return base.Price; }
            set { base.Price = value; }
        }

        public override double Milliliters
        {
            get {return base.Milliliters; }
            set { base.Milliliters = value; }
        }

    }
}
