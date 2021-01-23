using System;

namespace PointDrawer
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(3, 1, 1, 3);
            var ifIntRectangle = rectangle.Contains(new Point(2, 2));
            Console.WriteLine(ifIntRectangle);
        }
    }
}
