// See https://aka.ms/new-console-template for more information
using MiscClasses;


BankAccount oAccount1 = new BankAccount("Jules", 10000);
Console.WriteLine($"New Account was created for {oAccount1.Owner} with a balance of USD: {oAccount1.Balance}");
