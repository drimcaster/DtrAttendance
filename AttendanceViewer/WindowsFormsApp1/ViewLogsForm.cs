using DTRAttendance.StaticClasses;
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
    public partial class ViewLogsForm : Form
    {
        public Models.Employee _Employee;
        public DateTime _focusDate;
        public ViewLogsForm(Models.Employee employee, DateTime date_time)
        {
            InitializeComponent();
            _Employee = employee;
            _focusDate = date_time;
            load_data(date_time);
        }


        public void load_data(DateTime date_time)
        {
            dataGridView1.Rows.Clear();
            List<Models.Attendance_Log> att_logs = StaticClasses.AttLogs.get_logs(_Employee.id, date_time.Month, date_time.Year);
            foreach(var i in att_logs)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.Tag = i;
                dgvr.ContextMenuStrip = contextMenuStrip1;
                dataGridView1.Rows.Add(dgvr);               
            }
            

            for(int i = 0; i<dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow dgvr = dataGridView1.Rows[i];
                var log = dgvr.Tag as Models.Attendance_Log;
                string chk_type = "";
                dgvr.SetValues(i+1, log.date_time.ToString("MM/dd/yyyy hh:mm:ss tt"), chk_type, log.att_sched_id, log.device_id, log.is_manual == 1 ? "Manual": "Log");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddLog(_focusDate.Month, _focusDate.Year).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Change_Schedule_in_Logs(_focusDate.Month, _focusDate.Year).ShowDialog();
        }

        private void modifyCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Modify_Check_In().ShowDialog();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
           var log =  e.Row.Tag as Models.Attendance_Log;
            if(log.is_manual != 1)
            {
                if (MessageBox.Show("Would you like to delete this log", "Deleting log", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            //dataGridView1.Rows[e.RowIndex].
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            contextMenuStrip1.Tag = dataGridView1.Rows[e.RowIndex].Tag;
        }
    }
}
