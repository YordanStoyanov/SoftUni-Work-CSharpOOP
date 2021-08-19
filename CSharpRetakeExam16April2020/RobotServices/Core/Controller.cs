using RobotServices.Core.Contracts;
using RobotServices.Models.Garages;
using RobotServices.Models.Garages.Contracts;
using RobotServices.Models.Procedures;
using RobotServices.Models.Procedures.Contracts;
using RobotServices.Models.Robots;
using RobotServices.Models.Robots.Contracts;
using RobotServices.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Core
{
    public class Controller : IController
    {
        //private IList<IRobot> robots;
        private IRobot robot;
        private readonly IGarage garage;
        private IList<IProcedure> procedures;
        private IProcedure procedure;
        private Chip chip;
        private Change change;
        private Work work;
        private TechCheck techCheck;
        private Polish polish;
        private Rest rest;
        public Controller()
        {
            //this.robots = new List<IRobot>();
            this.garage = new Garage();
            this.procedures = new List<IProcedure>();
            this.chip = new Chip();
            this.techCheck = new TechCheck();
            this.change = new Change();
            this.work = new Work();
            this.polish = new Polish();
            this.rest = new Rest();
        }
        public string Change(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            change.DoService(robot, procedureTime);
            procedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.ChangeProcedure, robotName);

        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            if (!this.robot.IsChipped)
            {
                throw new AggregateException(string.Format(ExceptionMessages.AlreadyChipped, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            chip.DoService(robot, procedureTime);
            procedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string Hystory(string procedureType)
        {
            IProcedure procedure = this.procedures[procedureType.Length];
            return procedure.History().ToString();
        }

        public string Manufacturer(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            //if (robotType == nameof(HouseholdRobot))
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            //}
            robot = null;
            if (robotType.Contains("PetRobot"))
            {
                this.robot = (new PetRobot(name, energy, happiness, procedureTime));
            }
            if (robotType.Contains("HouseholdRobot"))
            {
                this.robot = (new HouseholdRobot(name, energy, happiness, procedureTime));
            }
            if (robotType.Contains("WalkerRobot"))
            {
                this.robot = (new WalkerRobot(name, energy, happiness, procedureTime));
            }

            this.garage.Manufacturer(robot);
            return string.Format(OutputMessages.RobotManufacturer, robot.Name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            polish.DoService(robot, procedureTime);
            procedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            rest.DoService(robot, procedureTime);
            procedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            //IRobot robot = this.garage.Robots[robotName];
            if (this.robot.IsChipped)
            {
                this.garage.Sell(robotName, ownerName);
                return string.Format(OutputMessages.SellChippedRobot, robotName);
            }
            if (!this.robot.IsChipped)
            {
                this.garage.Sell(robotName, ownerName);
                return string.Format(OutputMessages.SellNotChippedRobot, robotName);
            }
            return string.Empty;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            techCheck.DoService(robot, procedureTime);
            procedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            this.work.DoService(robot, procedureTime);
            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }
    }
}
