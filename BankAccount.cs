using System;

namespace BankAccountNS
{
    public class BankAccount // Klassen för att hantera bankkontot
    {
        private readonly string m_customerName; // Namnet på kontoinnehavaren
        private double m_balance; // Saldo på bankkontot

        // Konstanta meddelanden för undantag
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance"; // Meddelande om att debitera beloppet överstiger saldot på kontot
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero"; // Meddelande om att debitera beloppet är mindre än noll

        private BankAccount() { } // Privat konstruktor som inte används

        // Konstruktor för BankAccount-klassen
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName; // Tilldelar kundens namn
            m_balance = balance; // Tilldelar saldo på kontot
        }

        // Egenskap för att hämta kundens namn
        public string CustomerName
        {
            get { return m_customerName; } // Returnerar kundens namn
        }

        // Egenskap för att hämta saldo på kontot
        public double Balance
        {
            get { return m_balance; } // Returnerar saldo på kontot
        }

        // Metod för att debitera belopp från kontot
        public void Debit(double amount)
        {
            if (amount < 0) // Kontrollera om beloppet är mindre än noll
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage); // Kasta undantag om beloppet är mindre än noll
            }

            if (amount > m_balance) // Kontrollera om beloppet överskrider saldot på kontot
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage); // Kasta undantag om beloppet överstiger saldot på kontot
            }

            m_balance -= amount; // Dra av beloppet från saldot på kontot
        }

        // Metod för att kreditera belopp till kontot
        public void Credit(double amount)
        {
            if (amount < 0) // Kontrollera om beloppet är mindre än noll
            {
                throw new ArgumentOutOfRangeException("amount"); // Kasta undantag om beloppet är mindre än noll
            }

            m_balance += amount; // Lägg till beloppet till saldot på kontot
        }
    }
}
