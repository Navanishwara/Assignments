﻿using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;

namespace PhoneBookApi.Models
{
    [Table("contact")]
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public DateOnly dob { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string picture { get; set; }
    }
}
