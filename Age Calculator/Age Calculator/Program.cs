using System;
using System.Data;
class Program
{
    static void Main()
    {
        Console.Write("Enter Date of birth(dd-mm-yyyy):");
        string? input = Console.ReadLine(); ;
        if (!string.IsNullOrWhiteSpace(input))
        {
            DateTime dob = DateTime.Parse(input);
            int years = DateTime.Now.Year - dob.Year;
            int months = DateTime.Now.Month - dob.Month;
            int days = DateTime.Now.Day - dob.Day;

            TimeSpan time = DateTime.Now - dob;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(DateTime.Now.Year, (DateTime.Now.Month == 1 ? 12 : (DateTime.Now.Month - 1)));
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
            Console.WriteLine($"{years}years, {months}months, {days}days");
            Console.WriteLine($"{time.Hours}hours:{time.Minutes}minutes:{time.Seconds}seconds");
        }
        else
        {
            Console.WriteLine("Enter valid date of birth");
        }
    }
}