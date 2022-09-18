using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.Schedule
{
    public partial class AddScheduleForm : Form
    {
        public AddScheduleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_schedule_name.Text.Trim()== "")
            {
                MessageBox.Show("Please provide a name");
                return;
            }

            if (MessageBox.Show("This action is irreversable.\nHave you reviewed adding schedule?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Models.Schedule sched = new Models.Schedule();
                sched.name = txt_schedule_name.Text.Trim();
                sched.am_in = time_am_in.Value.Hour + ":" + time_am_in.Value.Minute + ":00";
                sched.am_out = time_am_out.Value.Hour + ":" + time_am_out.Value.Minute + ":00";
                sched.pm_in = time_pm_in.Value.Hour + ":" + time_pm_in.Value.Minute + ":00";
                sched.pm_out = time_pm_out.Value.Hour + ":" + time_pm_out.Value.Minute + ":00";
                if (sched.Save() > 0)
                {
                    MessageBox.Show("Successfully Added");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Name already exists");
                }
            }

        }
    }
}
