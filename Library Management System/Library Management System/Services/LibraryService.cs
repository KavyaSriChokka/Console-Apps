using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

using Library_Management_System.Models;

namespace Library_Management_System.Services
{
    public class LibraryService
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();
        private List<IssueRecord> records = new List<IssueRecord>();

        public void AddBook(Book b) => books.Add(b);
        public void AddMember(Member m) => members.Add(m);
        public void IssueBook(int bookID, int memberID)
        {
            var book = books.FirstOrDefault(b => b.ID == bookID);
            if (book == null || !book.IsAvailable) return;

            records.Add(new IssueRecord
            {
                BookID = bookID, MemberID = memberID, IssueDate = DateTime.Now, DueDate = DateTime.Now.AddDays(14)
            });
            book.IsAvailable = false;
        }
        public void ReturnBook(int bookID)
        {
            var book = books.FirstOrDefault(b => b.ID == bookID);
            if (book != null) book.IsAvailable = true;

            var record = records.FirstOrDefault(r => r.BookID == bookID);
            if (record != null) records.Remove(record);
        }
        public void ListOfBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.ID}.{book.NameOfTheBook} is written by {book.Author}. Availability {(book.IsAvailable? "Yes":"No")}");
            }
        }
        public void DueBooks()
        {
            foreach (var record in records)
            {
                var book = books.First(b => b.ID == record.BookID);
                var member = members.First(m => m.ID == record.MemberID);
                Console.WriteLine($"Book:{book.ID} issued by {member.NameOfStaff} Due Date{record.DueDate.ToShortDateString()}");
            }
        }
    }
}
