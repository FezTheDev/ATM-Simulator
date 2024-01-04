using System;

namespace ATM_Program
{ // Fezeka Mnisi
    public enum Menu
    {
        Withdraw = 1,
        Deposit = 2,
        Transfer = 3,
        Balance = 4,
        Logout = 5
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int AccountPIN = 1234;
            const long AccountNum = 1234567890;
            const int suppPIN2 = 5678;
            const long suppNum2 = 0876543210;
            const int suppPIN3 = 8765;
            const long suppNum3 = 0987654321;
            var logout = "n";

            var balance = 1000; // Set balance for testing

            int pinCode;
            long accNumInput;
            int withdrawRequest;
            int TransferRequest;


            Console.WriteLine("Welcome to the ATM! \nEnter Account Number: ");
            accNumInput = Convert.ToInt64(Console.ReadLine());

            while (accNumInput != AccountNum)
            {
                Console.WriteLine("\nIncorrect Account Number entered. Please try again: ");
                accNumInput = Convert.ToInt64(Console.ReadLine());
            }

            Console.WriteLine("\nEnter PIN code: ");
            pinCode = Convert.ToInt32(Console.ReadLine());

            while (pinCode != AccountPIN) // Concise error correction + input validation
            {
                Console.WriteLine("\nIncorrect PIN entered. Try again: ");
                pinCode = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nLogin Successful.\n\n");

            bool menuLoop = true;

            while (menuLoop = true && logout == "n")
            {

                Console.WriteLine("Account No.     Balance\n{0}        {1}", accNumInput, balance);
                Console.WriteLine("\nPlease choose an option:\n1: {0}\n2: {1}\n3: {2}\n4: {3}\n5:{4}\n", Menu.Withdraw,
                    Menu.Deposit, Menu.Transfer, Menu.Balance, Menu.Logout);

                int menuInput = Convert.ToInt32(Console.ReadLine());

                if (menuInput == Convert.ToInt32(Menu.Withdraw))
                {

                    Console.WriteLine("Enter amount to withdraw: ");
                    withdrawRequest = Convert.ToInt32(Console.ReadLine());

                    while (withdrawRequest > balance)
                    {
                        Console.WriteLine("\nAmount entered exceeds available amount. Enter a lower value"); // Input validation
                        withdrawRequest = Convert.ToInt32(Console.ReadLine());
                    }

                    balance = balance - withdrawRequest;
                    Console.WriteLine("\nWithdrawal Successful!");

                    Console.WriteLine("\nWould you like to logout: (y/n)"); // Menu display or terminate signal
                    logout = Console.ReadLine();
                    if (logout == "n")
                    {
                        Console.Clear();
                    }
                }
                else if (menuInput == Convert.ToInt32(Menu.Deposit))
                {
                    Console.WriteLine("\nHow much are you depositing: ");
                    var depositAmount = Convert.ToInt32(Console.ReadLine()); // For simplicity, we assume the amount entered is the actual amount deposited.
                    Console.WriteLine("\nDeposit successful");
                    balance = balance + depositAmount;

                    Console.WriteLine("\nWould you like to logout: (y/n)");
                    logout = Console.ReadLine();
                    if (logout == "n")
                    {
                        Console.Clear(); // Neatens presentation of the loop
                    }
                }
                else if (menuInput == Convert.ToInt32(Menu.Transfer))
                {
                    Console.WriteLine("Enter Account Number of Recipient: ");
                    long recipientNum = Convert.ToInt64(Console.ReadLine());

                    while (recipientNum != suppNum2 && recipientNum != suppNum3)
                    {
                        Console.WriteLine("\nIncorrect details entered. Try again:");
                        recipientNum = Convert.ToInt64(Console.ReadLine());
                    }

                    Console.WriteLine("\nEnter amount:");
                    TransferRequest = Convert.ToInt32(Console.ReadLine());

                    while (TransferRequest > balance)
                    {
                        Console.WriteLine("\nAmount entered exceeds available amount. Enter a lower value");
                        TransferRequest = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine("\nTransfer successful!");
                    balance = balance - TransferRequest;

                    Console.WriteLine("\nWould you like to logout: (y/n)");
                    logout = Console.ReadLine();
                    if (logout == "n")
                    {
                        Console.Clear();
                    }
                }
                else if (menuInput == Convert.ToInt32(Menu.Balance))
                {
                    Console.WriteLine("\nAvailable Balance: {0}\n", balance);
                }

                else if (menuInput == Convert.ToInt32(Menu.Logout))
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }

            Environment.Exit(0);
        }
    }
}
