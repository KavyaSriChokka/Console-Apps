using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Library_Management_System.Models;
using Library_Management_System.Services;

LibraryService lib = new LibraryService();

while (true)
{
    Console.WriteLine("------Library Management System------");
    Console.WriteLine("1.Add Book \n2.Add Member \n3.Issue Book \n4.Return Book \n5.List of all books \n6.Due Books \n7.Exit");
    Console.WriteLine("Choose an option:");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Book ID:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name of the Book:");
            string name = Console.ReadLine();
            Console.Write("Author:");
            string author = Console.ReadLine();
            lib.AddBook(new Book { ID = id, NameOfTheBook = name, Author = author });
            break;

        case "2":
            Console.Write("Member ID:");
            int idm = int.Parse(Console.ReadLine());
            Console.Write("Name of the Member:");
            string mname = Console.ReadLine();
            lib.AddMember(new Member { ID = idm, NameOfStaff = mname });
            break;

        case "3":
            Console.Write("Book ID:");
            int idb = int.Parse(Console.ReadLine());
            Console.Write("Member ID:");
            int idM = int.Parse(Console.ReadLine());
            lib.IssueBook(idb, idM);
            break;

        case "4":
            Console.Write("Book ID:");
            int idd = int.Parse(Console.ReadLine());
            lib.ReturnBook(idd);
            break;
        case "5":
            lib.ListOfBooks();
            break;
        case "6":
            lib.DueBooks();
            break;
        case "7":
            return;
    }
}