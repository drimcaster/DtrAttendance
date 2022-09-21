using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.Models
{
    internal class Attendance_Log
    {
        public int? id { get; set; }
        public string bio_id { get; set; }
        public DateTime date_time { get; set; }
        public int? employee_id { get; set; }
        public bool is_processed { get; set; }

        public int? att_sched_id { get; set; }
        public int? check_dtr_id { get; set; }
        public int? device_id { get; set; }
        public int? is_manual { get; set; }
        public string sched_name { get; set; }
        
        public DataGridViewRow row;

    }
}
