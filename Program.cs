namespace Bankomat
{
    internal class Program
    {
        // Designmönster implementerade:
        // 1. Singleton för BankAccountFactory
        // 2. Factory Method för att skapa olika typer av bankkonton
        // 3. Strategy för att hantera olika typer av transaktioner

        static void Main(string[] args)
        {
            // Hämta instansen av fabriken för att skapa bankkonton
            BankAccountFactory factory = BankAccountFactory.GetInstance();

            // Skapa sparkonto och lönekonto
            IBankAccount savingsAccount = factory.CreateAccount("savings");
            IBankAccount checkingAccount = factory.CreateAccount("checking");

            // Skapa strategier för insättning och uttag
            ITransactionStrategy depositStrategy = new DepositStrategy();
            ITransactionStrategy withdrawStrategy = new WithdrawStrategy();

            // Utför transaktioner på sparkonto
            Console.WriteLine("Sätter in och tar ut pengar från sparkonto!");
            ExecuteTransaction(depositStrategy, savingsAccount, 119);
            ExecuteTransaction(withdrawStrategy, savingsAccount, 56);
            Console.WriteLine(" ");

            // Utför transaktioner på lönekonto
            Console.WriteLine("Sätter in och tar ut pengar från lönekonto!");
            ExecuteTransaction(depositStrategy, checkingAccount, 999);
            ExecuteTransaction(withdrawStrategy, checkingAccount, 100);
            //Kommer skriva ut "Insufficient funds." Eftersom den försöker göra ett withdraw på pengar som ej finns. 
            ExecuteTransaction(withdrawStrategy, checkingAccount, 1500);
            //Här kan jag fortsätta med andra execute ifall jag önskar.
        }

        static void ExecuteTransaction(ITransactionStrategy strategy, IBankAccount account, decimal amount)
        {
            // Strategy-mönstret används här för att välja vilken typ av transaktion som ska utföras (depositStrategy eller withdrawStrategy) sen vilket konto sen summa.
            strategy.ExecuteTransaction(account, amount);

        }
    }
}
