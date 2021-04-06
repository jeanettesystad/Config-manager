using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Configdata
    {
        public long Id { get; set; }
        public string ConfigName { get; set; }
        public string Application { get; set; }
        public string EnvironmentName { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
