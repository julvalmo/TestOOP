// See https://aka.ms/new-console-template for more information
using MiscClasses;
using System.Security.Principal;

BankAccount oAccount1;
try
{
    oAccount1 = new BankAccount("Jules", 10000);
} // catch if the account creation is invalid by the exception generated in the class
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}
Console.WriteLine($"New Account was created for {oAccount1.Owner} with a balance of USD: {oAccount1.Balance}");

// check for a valid overdraw
try
{
    oAccount1.MakeWithdrawal(300, DateTime.Now, "Attempt to overdraw, not enought funds");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}
Console.WriteLine(oAccount1.Balance);

// check for invalid overdraw
try
{
    oAccount1.MakeWithdrawal(56500, DateTime.Now, "Attempt to overdraw, not enought funds");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}

Console.WriteLine(oAccount1.Balance);

// check valid deposit transaction
try
{
    oAccount1.MakeDeposit(100, DateTime.Now, "Friend paid me back");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to deposit a negative value");
    Console.WriteLine(e.ToString());
}

Console.WriteLine(oAccount1.Balance);

// check invalid deposit transaction
try
{
    oAccount1.MakeDeposit(-10, DateTime.Now, "Friend paid me back? WRONG");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to deposit a negative value");
    Console.WriteLine(e.ToString());
}

Console.WriteLine(oAccount1.Balance);

// List all the transactions from the account
oAccount1.Get_allTransactions();