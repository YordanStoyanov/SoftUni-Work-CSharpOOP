using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computers
{
    public class Computer
    {
        private string name;
        private List<Part> parts;

        public Computer(string name)
        {
            this.Name = name;
            this.parts = new List<Part>();
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can not be null");
                }
                this.name = value;
            }
        }

        public IReadOnlyCollection<Part> Parts { get { return parts.AsReadOnly(); } }

        public decimal TotalPrice { get { return this.Parts.Sum(x => x.Price); } }

        public void AddParts(Part part)
        {
            if (part == null)
            {
                throw new ArgumentException("Part can not be null");
            }
            this.parts.Add(part);
        }

        public bool RemovePart(Part part)
        {
            Part findPart = parts.FirstOrDefault(p => p.Name == part.Name);
            if (findPart == null)
            {
                throw new AggregateException();
                return false;
            }
            this.parts.Remove(part);
            return true;
        }

        public Part GetPart(string partName)
        {
            return this.Parts.FirstOrDefault(p => p.Name == partName);
        }
    }
}
