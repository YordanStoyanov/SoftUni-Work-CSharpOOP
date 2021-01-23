using System;
using System.Collections.Generic;
using System.Text;

namespace PointDrawer
{
    public class Point//tepmpeitni stoinosti, t.e. podavame vsichko int double desimal...
    {
        public Point()
        {

        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
