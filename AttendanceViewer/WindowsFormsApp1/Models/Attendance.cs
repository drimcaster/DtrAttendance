using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.Models
{
    public class Attendance
    {
        public Device device { get; set; }
        //public 
        public List<Log> logs { get; set; } = new List<Log>();
    }
}
