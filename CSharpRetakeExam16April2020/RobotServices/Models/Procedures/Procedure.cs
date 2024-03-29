﻿using RobotServices.Models.Procedures.Contracts;
using RobotServices.Models.Robots.Contracts;
using RobotServices.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServices.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private IRobot robot;
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }
        protected IList<IRobot> Robots { get; }   
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new AggregateException(string.Format(ExceptionMessages.InsufficientProduceTime));
            }
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (IRobot robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
