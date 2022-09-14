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
        public ViewLogsForm(Models.Employee employee)
        {
            InitializeComponent();
            _Employee = employee;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddLog().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Change_Schedule_in_Logs().ShowDialog();
        }

        private void modifyCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Modify_Check_In().ShowDialog();
        }
    }
}
