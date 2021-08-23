using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Bag : IBag
    {
        public ICollection<string> Items => throw new NotImplementedException();
    }
}
