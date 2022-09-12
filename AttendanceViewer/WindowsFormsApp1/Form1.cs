using DTRAttendance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DTRAttendance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<DTRAttendance.Models.Employee> employees;

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            this.load_table();



        }
        public void load_table()
        {
            dataGridView1.Rows.Clear();

            employees = checkBox1.Checked ? DTRAttendance.StaticClasses.Employees.get_active_employees(textBox1.Text) : DTRAttendance.StaticClasses.Employees.get_all_employees(textBox1.Text);

            foreach(var employee in employees)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = employee;
                dataGridView1.Rows.Add(row);
            }

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                var emp = row.Tag as Models.Employee;
                row.SetValues(emp.employee_id, emp.bio_id, emp.getFullName(), emp.is_active);
            }

        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DTRAttendance.Employees.AddEditEmployee().ShowDialog();
        }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DTRAttendance.Devices.DeviceList().ShowDialog();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DTRAttendance.Devices.Download().ShowDialog();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.load_table();
            }
        }

        private void analyzeRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.MySQLHelper.MySQLScheduleStart();
            Helpers.MySQLHelper.CreateAttendanceProcessSchedule();
        }
    }
}
