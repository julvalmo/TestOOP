namespace MiscClasses;

public class Transaction
{
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Notes { get; }

    public decimal CurrentBalance { get; set; }

    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }

    public void UpdateCurrentBalancaAfterTransaction(decimal currentBalance)
    {
        CurrentBalance = currentBalance;
    }
}