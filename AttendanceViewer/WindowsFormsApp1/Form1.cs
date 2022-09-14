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

        public bool isAnalyze = false;
        public Form1()
        {
            InitializeComponent();
        }

        List<DTRAttendance.Models.Employee> employees;

        private void Form1_Load(object sender, EventArgs e)
        {

            StaticClasses.DtrAnalysis.checkSystemDefaults();

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
            if (isAnalyze == false)
            {
                //Helpers.MySQLHelper.MySQLScheduleStart();
                StaticClasses.DtrAnalysis.MySQLScheduleStart();
                Helpers.MySQLHelper.CreateRawAnalysisSchedule();

                //Timer to check if records analysis completed.
                analyzeRawToolStripMenuItem.Text = "Analysing raw..";
                isAnalyze = true;
            }
            else
            {
                StaticClasses.DtrAnalysis.disableRawAnalysis();
                analyzeRawToolStripMenuItem.Text = "Analyze DTR Raw";
                isAnalyze = false;
            }
        }

        private void analysis_checker_Tick(object sender, EventArgs e)
        {
            if (isAnalyze == false)
            {
                //Check if there are Raw to analyzes
                if (StaticClasses.DtrAnalysis.hasRawtoAnalyze())
                {
                    analyzeRawToolStripMenuItem.Visible = true;
                    if (StaticClasses.DtrAnalysis.isScheduleRunning())
                    {
                        if (StaticClasses.DtrAnalysis.isRawAnalysisRunning())
                        {
                            isAnalyze = true;
                            analyzeRawToolStripMenuItem.Text = "Analysing raw..";
                        }
                    }
                }

            }
            else
            {
                if (!StaticClasses.DtrAnalysis.hasRawtoAnalyze())
                {
                    ///StaticClasses.DtrAnalysis.disableRawAnalysis(); -optional due to added to background
                    analyzeRawToolStripMenuItem.Text = "Analyze DTR Raw";
                    analyzeRawToolStripMenuItem.Visible = false;
                    isAnalyze = false;


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Models.Employee sel = dataGridView1.SelectedRows[0]?.Tag as Models.Employee;
            if (sel != null)
                new ViewLogsForm(sel).ShowDialog();
        }
    }
}
