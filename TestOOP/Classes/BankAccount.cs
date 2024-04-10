﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscClasses
{
    public class BankAccount
    {
        private static int s_accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        // Constructor
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        List<Transaction> _allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }

        public void Get_allTransactions()
        {
            foreach (var transaction in _allTransactions)
            {
                Console.WriteLine($"Account {this.Number} from {this.Owner} - {transaction.Notes} @ {transaction.Date}");
            }
        }
    }
}
