using System;

namespace Task6
{
    public class Account
    {
        // fields
        private int _accountNumber;
        private string _ownerName;
        private double _balance;

        // Properties
        public int AccountNumber
        {
            get => _accountNumber;
            private set => _accountNumber = value > 0 ? value : 1000;
        }

        public string OwnerName
        {
            get => _ownerName;
            set => _ownerName = string.IsNullOrWhiteSpace(value) ? "Unknown Owner" : value.Trim();
        }

        public double Balance { get; private set; }

        // Constructors
        public Account()
        {
            AccountNumber = 1000;
            OwnerName = "Unknown Owner";
            Balance = 0.0;
        }

        public Account(int number, string owner)
        {
            AccountNumber = number;
            OwnerName = owner;
            Balance = 0.0;
        }

        public Account(int number, string owner, double balance)
        {
            AccountNumber = number;
            OwnerName = owner;
            Balance = balance >= 0 ? balance : 0.0;
        }

        // Methods
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited ${amount:F2}. New balance: ${Balance:F2}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${Balance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Account #: {AccountNumber}");
            Console.WriteLine($"Owner: {OwnerName}");
            Console.WriteLine($"Balance: ${Balance:F2}");
            Console.WriteLine("-------------------------------------------------\n");
        }
    }
}