// See https://aka.ms/new-console-template for more information
using MiscClasses;
using System.Security.Principal;


BankAccount oAccount1 = new BankAccount("Jules", 10000);
Console.WriteLine($"New Account was created for {oAccount1.Owner} with a balance of USD: {oAccount1.Balance}");

oAccount1.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(oAccount1.Balance);
oAccount1.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(oAccount1.Balance);

// List all the transactions from the account
oAccount1.Get_allTransactions();