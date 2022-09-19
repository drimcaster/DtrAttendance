using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.Models
{
    public class Schedule
    {
        public long id { get; set; } = 0;
        public string name { get; set; }
        public string am_in { get; set; }
        public string am_out { get; set; }
        public string pm_in { get; set; }
        public string pm_out { get; set; }


        public long Save()
        {

            if (this.id == 0)
            {
                this.id = StaticClasses.Schedules.AddSchedule(this);
                return id;
            }

            throw new Exception("No update yet");
            //return 0;


        }
        
    }
}
