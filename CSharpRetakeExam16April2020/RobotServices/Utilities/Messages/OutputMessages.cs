using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Utilities.Messages
{
    public static class OutputMessages
    {
        public const string RobotManufacturer = "Robot {0} registered successfully";
        public const string RobotInfo = "Robot type: {0} - {1} - happiness: {2} - Energy: {3}";
        public const string ChipProcedure = "{0} had chip procedure";
        public const string TechCheckProcedure = "{0} had tech check procedure";
        public const string RestProcedure = "{0} had rest procedure";
        public const string WorkProcedure = "{0} was working for {1} hours";
        public const string ChangeProcedure = "{0} had change procedure";
        public const string PolishProcedure = "{0} had polish procedure";
        public const string SellChippedRobot = "{0} bought robot with chip";
        public const string SellNotChippedRobot = "{0} bought robot without chip";

    }
}
