using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971.DB;

namespace C971.Models
{

    [Table("terms")]
    public class Term
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string termName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }


}
