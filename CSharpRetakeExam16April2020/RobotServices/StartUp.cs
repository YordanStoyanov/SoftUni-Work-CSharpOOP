using RobotServices.Core;
using RobotServices.Core.Contracts;
using System;

namespace RobotServices
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
