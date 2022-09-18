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
    public partial class AddLog : Form
    {
        public AddLog(int month, int year)
        {
            InitializeComponent();
            
            int maxday = DateTime.DaysInMonth(year, month);
            dateTimePicker1.Value = DateTime.Parse(year + "-" + month + "-1");
            dateTimePicker1.MinDate = DateTime.Parse(year + "-" + month + "-1");//.MinValue;
            dateTimePicker1.MaxDate = DateTime.Parse(year + "-" + month + "-" + maxday);

            comboBox2.DataSource = Helpers.ServiceHelper.global_schedules;
            comboBox2.DisplayMember = "name";
           


        }
    }
}
