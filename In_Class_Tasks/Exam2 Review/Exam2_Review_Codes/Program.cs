/*
 * This program allows you to create banks then add tellers to those banks. 
 * We add all banks to an array of banks.
 * Bank and Teller are two classes.
 * The class diagram for this program is given under the Exam 2 review on eCampus.
 * 
 */

namespace Exam2_Review_Codes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank[] banks = new Bank[3];

            // ###################### Create and deal with Banks ########################
            Console.WriteLine("\n\n-------- Banks -----------");

            //1. Create a bank without giving any info
            Bank Bank1 = new Bank();
            Bank1.DisplayInfo();

            //2. Create a bank by providing full info
            Bank Bank2 = new Bank(101, "WVU Bank", "Morgantown WV");
            Bank2.DisplayInfo();

            //3. Create a bank by providing name only
            Bank Bank3 = new Bank("Morgantown Bank");
            Bank3.DisplayInfo();

            // add all banks to the array of banks
            banks[0] = Bank1;
            banks[1] = Bank2;
            banks[2] = Bank3;


            // ###################### Create and deal with Tellers ########################
            Console.WriteLine("\n\n-------- Tellers -----------");

            //1. Create a teller without giving any info
            Teller teller1 = new Teller();
            teller1.DisplayInfo();

            //2. Create a teller by providing full info
            Teller teller2 = new Teller(101, "Trinity Hale");
            teller2.DisplayInfo();

            //3. Create a teller by providing name only
            Teller teller3 = new Teller("Sarah Smith");
            teller3.DisplayInfo();


            // ###################### Add tellers to banks ########################
            Console.WriteLine("\n\n-------- Add Tellers to bank1 -----------");

            Bank1.AddTeller(teller1, 0);
            Bank1.AddTeller(teller2, 98);
            Bank1.AddTeller(teller3, 100);

            Console.WriteLine("\n\n-------- Print all tellers in bank1 -----------");
            Bank1.ListTellers();

            Console.WriteLine("\n\n-------- Modify tellers' names and add them again to bank1 -----------");

            teller1.Name = "Ridley Scott";
            teller2.Name = "Hailey Green";
            teller3.Name = "Sarah Conor";

            Bank1.AddTeller(teller1, 0);
            Bank1.AddTeller(teller2, 98);
            Bank1.AddTeller(teller3, 100);

            Bank2.AddTeller(new Teller(200, "Lisa Albert"), 10);
            Bank2.AddTeller(new Teller(300, "David Mathis"), 11);
            Bank2.AddTeller(new Teller(400, "Hassan Jacob"), 12);
            Bank2.AddTeller(new Teller(500, "Tom Blake"), 13);

            Console.WriteLine("\n\n-------- Print all tellers in bank1 after names modification -----------");
            Bank1.ListTellers();


            Console.WriteLine("\n\n-------- Print all banks and tellers in each bank -----------");
            PrintBanks(banks);



// ###################### Create Customers and Acounts ########################

            Console.WriteLine("\n\n================ Customers & Accounts  ================");

            // Create a few customers
            Customer cust1 = new Customer(101, "Alice Johnathan", "304-155-1234", "alicej@gmail.com", "123 High St");
            Customer cust2 = new Customer(202, "John Doeseph", "304-555-9876", "jdoseph2@yahoo.com", "85 High St");

            cust1.DisplayInfo();
            cust2.DisplayInfo();

            // Create accounts using different constructors
            Account acc1 = new Account(5001, "Checking");
            Account acc2 = new Account(5002, "Savings");
            Account acc3 = new Account(cust1);   // uses Customer constructor

            // Assign customers
            acc1.AssignCustomer(cust1);
            acc2.AssignCustomer(cust2);

            // Perform transactions
            acc1.Deposit(320.10);
            acc1.Withdraw(51.99);

            acc2.Deposit(832.00);
            acc2.Withdraw(211.09);

            acc3.Deposit(1500.00);

            Console.WriteLine("\n\n-------- Accounts Information -----------");
            acc1.DisplayInfo();
            acc2.DisplayInfo();
            acc3.DisplayInfo();

        }

        /// <summary>
        /// List all banks in the banks array. Then for each bank, list all tellers.
        /// </summary>
        public static void PrintBanks(Bank[] allBanks)
        {
            for (int intIndex = 0; intIndex < allBanks.Length; intIndex++)
            {
                allBanks[intIndex].DisplayInfo();
                allBanks[intIndex].ListTellers();
            }
        }
    }
}
