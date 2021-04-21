using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;
        private string name;
        private int age;
        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception("Age should be between 0 and 15.");
                }
                this.age = value;
            }
        }
        public double CalculateProductPerDay()
        {
            if (age > 0 && age <= 3)
            {
                return 1.5;
            }
            else if (age > 3 && age <= 7)
            {
                return 2;
            }
            else if (age > 7 && age <= 11)
            {
                return 1;
            }
            else
            {
                return 0.75;
            }
        }
    }
    
}
