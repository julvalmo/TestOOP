using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscClasses
{
    public class BankAccount
    {
        private static int s_accountNumberSeed = 1234567890;
        private readonly decimal _minimumBalance;
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
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        // Constructor
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Owner = name;
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            }
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
            // update balance after newly done transaction
            // TODO do something to do this automatically
            deposit.UpdateCurrentBalanceAfterTransaction(this.Balance);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            // TODO check how this works with the old hardcoded 0 vs the _minimumBalance prop
            if (Balance - amount < _minimumBalance)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
            // update balance after newly done transaction
            // TODO do something to do this automatically
            withdrawal.UpdateCurrentBalanceAfterTransaction(this.Balance);
        }

        public void Get_allTransactions()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var transaction in _allTransactions)
            {
                Console.WriteLine($"Account {this.Number} from {this.Owner} - {(transaction.Amount < 0 ? "Widthdrawal" : "Deposit")} of USD ${transaction.Amount}\n\t{transaction.Notes} @ {transaction.Date}" +
                    $"\n\tFinal Balance: {transaction.CurrentBalance}\n");
            }
            Console.WriteLine("-----------------------------------------------------------------\n");
        }

        // for derived classes
        public virtual void PerformMonthEndTransactions()
        {
        }

    }

}
