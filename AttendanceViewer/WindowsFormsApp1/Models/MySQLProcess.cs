using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.Models
{
    public class MySQLProcess
    {
        public int? Id { get; set; }
        public string User { get; set; }
        public string db { get; set; }

        public string Command { get; set; }

        public int? Time { get; set; }

        public string State { get; set; }

        public string Info { get; set; }


    }
}
