using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.Management
{
    public partial class ScheduleListForm : Form
    {
        public ScheduleListForm()
        {
            InitializeComponent();

        }

        public void reload_table()
        {
            dataGridView1.Rows.Clear();
            foreach (var i in Helpers.ServiceHelper.global_schedules)
            {
                dataGridView1.Rows.Add(i.id, i.name, formatTime(i.am_in), formatTime(i.am_out), formatTime(i.pm_in), formatTime(i.pm_out));
            }
        }
        public string formatTime(string s)
        {
            return DateTime.Parse(s).ToString("hh:mm tt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(new Schedule.AddScheduleForm().ShowDialog() == DialogResult.OK)
            {
                Helpers.ServiceHelper.LoadDataAndServices();
                reload_table();
            }

        }

        private void ScheduleListForm_Load(object sender, EventArgs e)
        {
            reload_table();

        }
    }
}
