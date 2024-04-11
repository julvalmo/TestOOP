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
    oAccount1.MakeWithdrawal(300, DateTime.Now, "For groceries");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}

// check for invalid overdraw
//try
//{
//    oAccount1.MakeWithdrawal(56500, DateTime.Now, "Attempt to overdraw, not enought funds");
//}
//catch (InvalidOperationException e)
//{
//    Console.WriteLine("Exception caught trying to overdraw");
//    Console.WriteLine(e.ToString());
//}

//Console.WriteLine(oAccount1.Balance);

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

// check invalid deposit transaction
//try
//{
//    oAccount1.MakeDeposit(-10, DateTime.Now, "Friend paid me back? WRONG");
//}
//catch (InvalidOperationException e)
//{
//    Console.WriteLine("Exception caught trying to deposit a negative value");
//    Console.WriteLine(e.ToString());
//}

//Console.WriteLine(oAccount1.Balance);

// List all the transactions from the account
oAccount1.Get_allTransactions();



// -----------------------------------------------
BankAccount oAccount2;
try
{
    oAccount2 = new BankAccount("Xavier", 650);
} // catch if the account creation is invalid by the exception generated in the class
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}
Console.WriteLine($"New Account was created for {oAccount2.Owner} with a balance of USD: {oAccount2.Balance}");


// check for a valid overdraw
try
{
    oAccount2.MakeWithdrawal(300, DateTime.Now, "Widthdraw for rent");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}

oAccount2.Get_allTransactions();

// gift card part
var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
giftCard.Get_allTransactions();

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
savings.Get_allTransactions();

// --------------------------------------------------
//Line of credit
var lineOfCredit = new LineOfCreditAccount("line of credit", 0);
// How much is too much to borrow?
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
lineOfCredit.Get_allTransactions();