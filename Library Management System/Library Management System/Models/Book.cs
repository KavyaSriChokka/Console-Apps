using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? NameOfTheBook { get; set; }
        public string? Author { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
