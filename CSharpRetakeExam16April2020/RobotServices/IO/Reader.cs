using RobotServices.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
