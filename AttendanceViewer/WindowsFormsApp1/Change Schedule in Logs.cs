using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance
{
    public partial class Change_Schedule_in_Logs : Form
    {
        public Change_Schedule_in_Logs(int Month, int Year)
        {
            InitializeComponent();
            
            dateTimePicker1.Value = DateTime.Parse(Year + "-" + Month + "-1");
            dateTimePicker1.MinDate = DateTime.Parse(Year + "-" + Month + "-1");
            dateTimePicker1.MaxDate = DateTime.Parse(Year + "-" + Month + "-" + DateTime.DaysInMonth(Year, Month));

            dateTimePicker2.Value = DateTime.Parse(Year + "-" + Month + "-" + DateTime.DaysInMonth(Year, Month)); 
            dateTimePicker2.MinDate = DateTime.Parse(Year + "-" + Month + "-1");
            dateTimePicker2.MaxDate = DateTime.Parse(Year + "-" + Month + "-" + DateTime.DaysInMonth(Year, Month));

            comboBox2.DataSource = Helpers.ServiceHelper.global_schedules;
            comboBox2.DisplayMember = "name";

        }
    }
}
