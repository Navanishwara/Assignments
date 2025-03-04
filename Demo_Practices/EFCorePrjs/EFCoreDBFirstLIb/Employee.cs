using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDBFirstLIb
{
    //[Table("employee")]
    public class Employee
    {
        [Key]
        //[Column("empcode")]
        public int empid { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int depid { get; set; }
    }

}
