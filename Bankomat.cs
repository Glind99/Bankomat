using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    // Designmönster implementerade:
    // 1. Singleton för BankAccountFactory
    // 2. Factory Method för att skapa olika typer av bankkonton
    // 3. Strategy för att hantera olika typer av transaktioner
    interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal GetBalance();
    }

    // Factory för att skapa olika typer av bankkonton.
    class BankAccountFactory
    {
        //Singleton instans för factory.
        private static BankAccountFactory instance;

        //Privat för att förhindra externa instaniseringar
        private BankAccountFactory() { }

        // Singleton-metod för att hämta instansen av fabriken
        public static BankAccountFactory GetInstance()
        {
            if (instance == null)
                instance = new BankAccountFactory();
            return instance;
        }

        // Factory Method för att skapa bankkonton baserat på typen
        public IBankAccount CreateAccount(string type)
        {
            switch (type.ToLower())
            {
                case "savings":
                    return new SavingsAccount();
                case "checking":
                    return new CheckingAccount();
                default:
                    throw new ArgumentException("Invalid account type.");
            }
        }
    }

    // implementering av sparkonto
    class SavingsAccount : IBankAccount
    {
        private decimal balance = 0;

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:C}. Current balance: {balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. Current balance: {balance:C}");
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    // implementering av lönkonto
    class CheckingAccount : IBankAccount
    {
        private decimal balance = 0;

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:C}. Current balance: {balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. Current balance: {balance:C}");
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
    // för att hantera banktransaktioner
    interface ITransactionStrategy
    {
        void ExecuteTransaction(IBankAccount account, decimal amount);
    }

    // strategi för insättning
    class DepositStrategy : ITransactionStrategy
    {
        public void ExecuteTransaction(IBankAccount account, decimal amount)
        {
            account.Deposit(amount);
        }
    }

    // strategi för uttag
    class WithdrawStrategy : ITransactionStrategy
    {
        public void ExecuteTransaction(IBankAccount account, decimal amount)
        {
            account.Withdraw(amount);
        }
    }



}
