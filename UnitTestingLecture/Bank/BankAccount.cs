using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BankAccount
    {
        private decimal amount;
        private string name;

        public BankAccount(string name, decimal amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
        public string Name { get; set; }

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Amount can not be 0!");
                }
                this.amount = value;
            }
        }
    }
}
