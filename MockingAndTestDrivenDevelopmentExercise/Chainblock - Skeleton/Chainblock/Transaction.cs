using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.From = from;
            this.Status = status;
            this.To = to;
            this.Amount = amount;
        }
        public int Id
        { 
            get => id ;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                id = value;
            }
        }
        public TransactionStatus Status 
        { 
            get => status ;
            set => status = value ; 
        }
        public string From 
        { 
            get => from; 
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.ToCharArray().Any(x => char.IsDigit(x)))
                {
                    throw new ArgumentException();
                }
                from = value;
            }
        }
        public string To 
        { 
            get => to;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.ToCharArray().Any(x => char.IsDigit(x)))
                {
                    throw new ArgumentException();
                }
                to = value;
            }
        }
        public double Amount 
        { 
            get => amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                amount = value;
            }
        }
    }
}
