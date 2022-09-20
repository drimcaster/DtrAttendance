using DTRAttendance.Helpers;
using DTRAttendance.Models;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

            //this.reportViewer1.RefreshReport();

            this.load_table();
            dtr_check_updates.Tick += Dtr_check_updates_Tick;
            dtr_check_updates.Enabled = true;

        }

        private void Dtr_check_updates_Tick(object sender, EventArgs e)
        {
            dtr_check_updates.Enabled = false;
            //throw new NotImplementedException();
            BackgroundWorker dtr_check_bgWorker = new BackgroundWorker();
            dtr_check_bgWorker.DoWork += Dtr_check_bgWorker_DoWork;
            dtr_check_bgWorker.RunWorkerAsync();
        }

        public DateTime? _CheckTime = null;
        private void Dtr_check_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MySqlParameter[] pars = new MySqlParameter[3];
            Models.Employee emp = null;
            Invoke(new Action(() => {
                if(dataGridView1.SelectedRows.Count >0 )
                {
                    emp = dataGridView1.SelectedRows[0].Tag as Models.Employee;
                }
                if (emp != null) {
                    pars[0] = new MySqlParameter("@emp_id", emp.id);
                    pars[1] = new MySqlParameter("@month", dateTimePicker1.Value.Month);
                    pars[2] = new MySqlParameter("@year", dateTimePicker1.Value.Year);
                }
            
            
            }));
            if (emp != null)
            {
                string ss = (SSH_MySQL_Lib.MySqlQuery.QueryResult("SELECT fnGetEmpLatestDtrDateTimeUpdate(10,9,2022) as updated_time;", pars).Rows[0]["updated_time"] ?? "").ToString();
                if (ss == "")
                {
                    _CheckTime = null;
                }
                else
                {
                    if ( _CheckTime != DateTime.Parse(ss))
                    {
                        _CheckTime = DateTime.Parse(ss);
                        Invoke(new Action(() =>
                        {
                            dataGridView1_SelectionChanged(null, null);
                        }));
                    }
                }
            }
            Invoke(new Action(() => {
                dtr_check_updates.Enabled = true;
            }));
        }

        public void load_table()
        {
            dataGridView1.Rows.Clear();

            employees = checkBox1.Checked ? DTRAttendance.StaticClasses.Employees.get_active_employees(textBox1.Text) : DTRAttendance.StaticClasses.Employees.get_all_employees(textBox1.Text);

            foreach(var employee in employees)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = employee;
                row.ContextMenuStrip = employee_details;
                dataGridView1.Rows.Add(row);
            }

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                var emp = row.Tag as Models.Employee;
                emp.row = row;
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
            new DTRAttendance.Devices.Download(dateTimePicker1.Value).ShowDialog();
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
                new ViewLogsForm(sel, dateTimePicker1.Value).ShowDialog();
        }

        private void reloadDataAndServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.ServiceHelper.LoadDataAndServices();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dataGridView1.Rows[e.RowIndex].Selected = true;
            var employee = dataGridView1.Rows[e.RowIndex].Tag as Models.Employee;
            modifyEmployeeToolStripMenuItem.Tag = employee;
        }

        private void modifyEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var emp =   modifyEmployeeToolStripMenuItem.Tag as Models.Employee;
           
            if(emp != null)
            {
                var empform = new Employees.AddEditEmployee(emp);
                if (empform.ShowDialog() == DialogResult.OK)
                {     //load_table();
                    empform.Emp.row = emp.row;
                    emp = empform.Emp;

                    emp.row.SetValues(emp.employee_id, emp.bio_id, emp.getFullName(), emp.is_active);
                    emp.row.Tag = emp;

                }
            }
        }

        private void logSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Management.ScheduleListForm().ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var employee = dataGridView1.SelectedRows[0].Tag as Models.Employee;
            load_report(employee, dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);

        }

        private void load_report(Models.Employee emp, int year, int month)
        {
            //reportViewer1.ProcessingMode = ProcessingMode.Local;
            //reportViewer1.LocalReport.ReportPath = "~/DtrReport.rdlc";
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report.rdlc");
            //Customers dsCustomers = GetData("select top 20 * from customers");
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();

            if (checkBox2.Checked == false)
                DtrReport1(emp, year, month);
            else
                DtrReport2(emp, year, month);



            reportViewer1.RefreshReport();


        }

        public void DtrReport1(Models.Employee emp, int year, int month)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "DTRAttendance.DtrReport.rdlc";

            var table = load_dtr_data(emp, year, month, DateTime.DaysInMonth(year, month));
            ReportDataSource datasource = new ReportDataSource("DataSet1", table);

            ReportParameter[] rpars = new ReportParameter[2];
            rpars[0] = new ReportParameter("full_name", emp.getFullName());
            rpars[1] = new ReportParameter("month_year", DateTime.Parse(year + "-" + month + "-1").ToString("MMMM yyyy"));

            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.SetParameters(rpars);

        }
        public void DtrReport2(Models.Employee emp, int year, int month)
        {
            int month2 = month % 2 == 0 ? month : month + 1;
            month = month2 - 1;
            //month = month % 2 == 1 ? 

            reportViewer1.LocalReport.ReportEmbeddedResource = "DTRAttendance.DtrReport2.rdlc";

            var table = load_dtr_data(emp, year, month, DateTime.DaysInMonth(year, month));
            ReportDataSource datasource = new ReportDataSource("DataSet1", table);

            //int month2 = month % 2 == 1 ? month + 1 : month - 1; 

            var table2 = load_dtr_data(emp, year, month2, DateTime.DaysInMonth(year, month2));
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", table2);

            ReportParameter[] rpars = new ReportParameter[3];
            rpars[0] = new ReportParameter("full_name", emp.getFullName());
            rpars[1] = new ReportParameter("month_year", DateTime.Parse(year + "-" + month + "-1").ToString("MMMM yyyy"));
            rpars[2] = new ReportParameter("month_year2", DateTime.Parse(year + "-" + month2 + "-1").ToString("MMMM yyyy"));

            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.DataSources.Add(datasource2);
            reportViewer1.LocalReport.SetParameters(rpars);

        }

        public DataTable load_dtr_data(Models.Employee employee, int year, int month, int max_day)
        {

            MySqlParameter[] pars = new MySqlParameter[4];
            pars[0] = new MySqlParameter("@emp_id", employee.id);
            pars[1] = new MySqlParameter("@year", year);
            pars[2] = new MySqlParameter("@month", month);
            pars[3] = new MySqlParameter("@maxday", DateTime.DaysInMonth(year, month));
            DataTable dt = SSH_MySQL_Lib.MySqlQuery.QueryResult("CALL spDtrReport(@emp_id, @year, @month, @maxday)", pars);

            foreach(DataRow dr in dt.Rows)
            {
                dr["am_in"] = dr["am_in"].ToString() == string.Empty ? "--:--:--" : DateTime.Parse( dr["am_in"].ToString() ).ToString("hh:mm tt");
                dr["am_out"] = dr["am_out"].ToString() == string.Empty ? "--:--:--": DateTime.Parse(dr["am_out"].ToString()).ToString("hh:mm tt");
                
                //Sunday and Saturday marker
                if(dr["am_in"].ToString() == "--:--:--" && dr["am_out"].ToString() == "--:--:--")
                {
                    string am_day_in_week = DateTime.Parse(dr["date"].ToString()).ToString("dddd");

                    if (am_day_in_week == "Sunday" || am_day_in_week == "Saturday")
                        dr["am_in"] = dr["am_out"] = am_day_in_week;
                }
                
                dr["pm_in"] = dr["pm_in"].ToString() == string.Empty ? "--:--:--": DateTime.Parse(dr["pm_in"].ToString()).ToString("hh:mm tt");
                dr["pm_out"] = dr["pm_out"].ToString() == string.Empty ? "--:--:--" : DateTime.Parse(dr["pm_out"].ToString()).ToString("hh:mm tt");

                ////Sunday and Saturday marker
                if (dr["pm_in"].ToString() == "--:--:--" && dr["pm_out"].ToString() == "--:--:--")
                {
                    string pm_day_in_week = DateTime.Parse(dr["date"].ToString()).ToString("dddd");
                    if (pm_day_in_week == "Sunday" || pm_day_in_week == "Saturday")
                        dr["pm_in"] = dr["pm_out"] = pm_day_in_week;

                }


            }

            return dt;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1_SelectionChanged(null, null);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1_SelectionChanged(null, null);
        }

        private void databaseSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Will restart this application once you successfully setup your database", "Application Restart", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if(new SSH_MySQL_Lib.SetUp().ShowDialog() == DialogResult.OK)
                {
                    Application.Restart();
                }
        }
    }
}
