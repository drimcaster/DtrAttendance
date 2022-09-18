using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.Models
{
    public class Schedule
    {
        public int id { get; set; } = 0;
        public string name { get; set; }
        public string am_in { get; set; }
        public string am_out { get; set; }
        public string pm_in { get; set; }
        public string pm_out { get; set; }
        
    }
}
