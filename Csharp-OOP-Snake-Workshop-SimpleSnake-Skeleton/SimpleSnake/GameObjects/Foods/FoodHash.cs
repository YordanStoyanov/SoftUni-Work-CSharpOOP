using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int points = 3;
        private const ConsoleColor Color = ConsoleColor.DarkYellow;
        public FoodHash(Wall wall) 
            : base(wall, foodSymbol, points, Color)
        {
        }
    }
}
