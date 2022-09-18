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
        Models.Employee _Employee;
        public Change_Schedule_in_Logs( Models.Employee employee, int Month, int Year)
        {
            InitializeComponent();

            _Employee = employee;
            dateTimePicker1.Value = DateTime.Parse(Year + "-" + Month + "-1");
            dateTimePicker1.MinDate = DateTime.Parse(Year + "-" + Month + "-1");
            dateTimePicker1.MaxDate = DateTime.Parse(Year + "-" + Month + "-" + DateTime.DaysInMonth(Year, Month));

            dateTimePicker2.Value = DateTime.Parse(Year + "-" + Month + "-" + DateTime.DaysInMonth(Year, Month)); 
            dateTimePicker2.MinDate = DateTime.Parse(Year + "-" + Month + "-1");
            dateTimePicker2.MaxDate = DateTime.Parse(Year + "-" + Month + "-" + DateTime.DaysInMonth(Year, Month));

            comboBox2.DataSource = Helpers.ServiceHelper.global_schedules;
            comboBox2.DisplayMember = "name";

            comboBox2.SelectedItem = Helpers.ServiceHelper.global_schedules.Where(a => a.id == employee.att_sched_id).FirstOrDefault();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("This action is irreversable.\n Would you like to proceed change sched of logs?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var _sched = comboBox2.SelectedItem as Models.Schedule;
                StaticClasses.Schedules.UpdateScheduleChanges(_Employee, dateTimePicker1.Value, dateTimePicker2.Value, _sched.id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
