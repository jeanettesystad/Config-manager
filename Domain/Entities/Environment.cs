using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Environment")]
    public class Environment
    {
        public long Id { get; set; }
        public string EnvironmentName { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<Configdata> Configdatas { get; set; }
    }
}
