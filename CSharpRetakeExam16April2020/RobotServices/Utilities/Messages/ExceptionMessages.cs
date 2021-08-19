using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidNappiness = "Invalid happiness";
        public const string InvalidEnergy = "Invalid energy";
        public const string AlreadyChipped = "{0} is already chipped";
        public const string InsufficientProduceTime = "Robot doesn't enough produce time";
        public const string NotEnoughCapacity = "Not enough capacity";
        public const string InvalidRobotType = "{0} type doesn't exist";
        public const string ExistingRobot = "Robot {0} already Exist";
        public const string InexistingRobot = "Robot {0} does not exist";
    }
}
