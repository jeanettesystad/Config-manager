using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Admin")]
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
