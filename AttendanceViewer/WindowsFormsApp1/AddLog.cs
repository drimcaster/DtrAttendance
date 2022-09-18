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

        Models.Employee _Employee;

        public AddLog( Models.Employee employee, int month, int year)
        {
            InitializeComponent();

            _Employee = employee;
            int maxday = DateTime.DaysInMonth(year, month);
            dateTimePicker1.Value = DateTime.Parse(year + "-" + month + "-1");
            dateTimePicker1.MinDate = DateTime.Parse(year + "-" + month + "-1");//.MinValue;
            dateTimePicker1.MaxDate = DateTime.Parse(year + "-" + month + "-" + maxday);

            comboBox1.SelectedIndex = 0;
            comboBox2.DataSource = Helpers.ServiceHelper.global_schedules;
            comboBox2.DisplayMember = "name";
            comboBox2.SelectedItem = Helpers.ServiceHelper.global_schedules.Where(a => a.id == employee.att_sched_id).FirstOrDefault();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action is irreversable.\n Would you like to proceed adding manually?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var _sched = comboBox2.SelectedItem as Models.Schedule;
                StaticClasses.AttLogs.AddManualLog(_Employee, dateTimePicker1.Value, _sched.id, comboBox1.SelectedIndex + 1);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
