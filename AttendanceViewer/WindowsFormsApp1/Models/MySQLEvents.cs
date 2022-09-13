using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.Models
{
    public class MySQLEvents
    {
        public string Db { get; set; }
        public string Name { get; set; }
        public string Definer { get; set; }
        public string Type { get; set; }

        public string Status { get; set; }
    }
}
