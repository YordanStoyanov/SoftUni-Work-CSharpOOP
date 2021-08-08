using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {
        private const double cubicCentimeters = 3000;
        private const int minHorsePower = 250;
        private const int maxHorsePower = 450;
        /*The cubic centimeters for this type of car are 3000. Minimum horsepower is 250 and maximum horsepower is 450.
If you receive horsepower which is not in the given range throw ArgumentException with message "Invalid horse power: {horsepower}.".

         */
        public SportsCar(string model, int horsePower) : 
            base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
