using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BankingSystem.Models;

namespace BankingSystem.Services
{
    public class BankService
    {
        private string connectionString = "server=localhost;user=root;database=banking system;port=3306;password=;";

        public void CreateAccount(string name, int pin)
        {
            string accountNumber = Guid.NewGuid().ToString().Substring(0, 10);

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO Accounts (AccountNumber, AccountHolder, PIN, AccountBalance) VALUES (@num, @holder, @pin, 0)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@num", accountNumber);
            cmd.Parameters.AddWithValue("@holder", name);
            cmd.Parameters.AddWithValue("@pin", pin);
            cmd.ExecuteNonQuery();

            Console.WriteLine($"Account Created! Your account number is {accountNumber}");
        }

        public Account LoginAccount(string accountNumber, int pin)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM Accounts WHERE AccountNumber = @num AND PIN = @pin";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@num", accountNumber);
            cmd.Parameters.AddWithValue("@pin", pin);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Account
                {
                    AccountNumber = reader["AccountNumber"].ToString(),
                    AccountHolder = reader["AccountHolder"].ToString(),
                    PIN = Convert.ToInt32(reader["PIN"]),
                    AccountBalance = Convert.ToDouble(reader["AccountBalance"])
                };
            }

            return null;
        }

        public void Deposit(Account account, double amount)
        {
            account.AccountBalance += amount;

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE Accounts SET AccountBalance = @balance WHERE AccountNumber = @num";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@balance", account.AccountBalance);
            cmd.Parameters.AddWithValue("@num", account.AccountNumber);
            cmd.ExecuteNonQuery();

            Console.WriteLine($"Deposited ₹{amount}. New Balance: ₹{account.AccountBalance}");
        }

        public void Withdraw(Account account, double amount)
        {
            if (amount > account.AccountBalance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            account.AccountBalance -= amount;

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE Accounts SET AccountBalance = @balance WHERE AccountNumber = @num";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@balance", account.AccountBalance);
            cmd.Parameters.AddWithValue("@num", account.AccountNumber);
            cmd.ExecuteNonQuery();

            Console.WriteLine($"Withdrawn ₹{amount}. Remaining Balance: ₹{account.AccountBalance}");
        }

        public void CheckBalance(Account account)
        {
            Console.WriteLine($"Current Balance: ₹{account.AccountBalance}");
        }
    }
}
