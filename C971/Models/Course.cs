using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971.Models
{
    [Table("courses")]
    public class Course
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        public int termId { get; set; }
        public string courseName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public int courseStatus { get; set; }

        public string courseInstructorName { get; set; }
        public string courseInstructorPhone { get; set; }

        public string courseInstructorEmail { get; set; }
        public string notes { get; set; }

        public DateTime dueDate { get; set; }

    }
}

