using DTRAttendance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.Employees
{
    public partial class AddEditEmployee : Form
    {
        public AddEditEmployee(Models.Employee _emp = null)
        {
            InitializeComponent();


            comboBox2.DataSource = Helpers.ServiceHelper.global_schedules;
            comboBox2.DisplayMember = "name";


            if (_emp == null)  
                Emp = new Employee();
            else
                Emp = (Employee)_emp.Clone();// new Models.Employee();

            if (Emp.id == 0)
            {
                this.Text = "Add Employee";
                this.button1.Text = "Add Employee";
            }
            else
            {
                this.Text = "Update Employee";
                this.button1.Text = "Save Employee";
            }
            
            txt_emp_id.DataBindings.Add("Text", Emp, "employee_id");
            txt_bio_id.DataBindings.Add("Text", Emp,"bio_id");
            txt_firstname.DataBindings.Add("Text", Emp,"first_name");
            txt_middlename.DataBindings.Add("Text", Emp,"middle_name");
            txt_lastname.DataBindings.Add("Text", Emp,"last_name");
            chk_is_active.DataBindings.Add("Checked", Emp, "is_active");
            txt_hired_date.DataBindings.Add("Text", Emp, "hired_date");


        }

        public Models.Employee Emp;

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = Emp.employee_id;
            if (Emp.id == 0)
            {
                long i = StaticClasses.Employees.AddEmployee(Emp);
                if (i > 0)
                {
                    MessageBox.Show("Successfully Added");
                    this.Close();
                }
            }
            else
            {

            }
        }
    }
}
