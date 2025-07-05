using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class IssueRecord
    {
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
