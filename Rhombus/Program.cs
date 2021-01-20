using System;
using System.Text;

namespace Rhombus
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Rhombus rhombus = new Rhombus();
            var rhombusDraw = rhombus.Draw(n);
            Console.WriteLine(rhombusDraw);
        }
        
    }
}
