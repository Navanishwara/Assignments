using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization;

namespace PhoneBookWebAPI.Model
{
    [Table("contact")]
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("dob")]
        public string DateofBirth { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("state")]
        public string state { get; set; }
        [Column("country")]
        public string country { get; set; }
        
        [Column("picture")]
        public string picture { get; set; }       

        
    }
}
