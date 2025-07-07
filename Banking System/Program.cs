using System;
using BankingSystem.Services;
using BankingSystem.Models;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BankService bs = new BankService();

            while (true)
            {
                Console.WriteLine("\n--- Banking System ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter 4-digit PIN: ");
                        int pin = int.Parse(Console.ReadLine());
                        bs.CreateAccount(name, pin);
                        break;

                    case "2":
                        Console.Write("Enter Account Number: ");
                        string accNum = Console.ReadLine();
                        Console.Write("Enter PIN: ");
                        int accPin = int.Parse(Console.ReadLine());

                        Account account = bs.LoginAccount(accNum, accPin);
                        if (account != null)
                        {
                            Console.WriteLine($"\nWelcome {account.AccountHolder}");
                            while (true)
                            {
                                Console.WriteLine("1. Deposit\n2. Withdraw\n3. Check Balance\n4. Logout");
                                Console.Write("Choose: ");
                                string action = Console.ReadLine();

                                switch (action)
                                {
                                    case "1":
                                        Console.Write("Enter deposit amount: ");
                                        double dep = double.Parse(Console.ReadLine());
                                        bs.Deposit(account, dep);
                                        break;
                                    case "2":
                                        Console.Write("Enter withdrawal amount: ");
                                        double with = double.Parse(Console.ReadLine());
                                        bs.Withdraw(account, with);
                                        break;
                                    case "3":
                                        bs.CheckBalance(account);
                                        break;
                                    case "4":
                                        Console.WriteLine("Logged out.");
                                        goto EndInnerLoop;
                                    default:
                                        Console.WriteLine("Invalid choice.");
                                        break;
                                }
                            }
                        EndInnerLoop:;
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
