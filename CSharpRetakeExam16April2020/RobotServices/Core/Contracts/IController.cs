using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Core.Contracts
{
    public interface IController
    {
        string Manufacturer(string robotType, string name, int energy, int happiness, int procedureTime);
        string Chip(string robotName, int procedureTime);
        string TechCheck(string robotName, int procedureTime);
        string Rest(string robotName, int procedureTime);
        string Work(string robotName, int procedureTime);
        string Change(string robotName, int procedureTime);
        string Polish(string robotName, int procedureTime);
        string Sell(string robotName, string ownerName);
        string Hystory(string procedureType);

    }
}
