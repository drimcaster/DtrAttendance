using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.StaticClasses
{
    public static class Employees
    {
        public static long AddEmployee(Models.Employee employee)
        {
            //Helpers.MySQLHelper.
            List<MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@employee_id", employee.employee_id));
            pars.Add(new MySqlParameter("@bio_id", employee.bio_id));
            pars.Add(new MySqlParameter("@first_name", employee.first_name));
            pars.Add(new MySqlParameter("@middle_name", employee.middle_name));
            pars.Add(new MySqlParameter("@last_name", employee.last_name));
            pars.Add(new MySqlParameter("@is_active", employee.is_active));
            pars.Add(new MySqlParameter("@hired_date", employee.hired_date));

            return Helpers.MySQLHelper.ExecuteNonQuery("INSERT INTO employees(employee_id, bio_id, first_name, middle_name, last_name, hired_date, is_active, created_at) VALUES(@employee_id, @bio_id, @first_name, @middle_name, @last_name, @hired_date, @is_active, NOW())", pars);
 
        }

        public static List<Models.Employee> get_active_employees(string search="")
        {

            List<MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@search", search));

            return Helpers.MySQLHelper.Query<List<Models.Employee>>(" select * from employees where deleted_at IS NULL AND is_active=1 AND CONCAT(IFNULL(employee_id,''), bio_id, first_name, middle_name, last_name) like CONCAT('%', @search ,'%')", pars);
        }

        public static List<Models.Employee> get_all_employees(string search="")
        {
            List<MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@search", search));
            return Helpers.MySQLHelper.Query<List<Models.Employee>>(" select * from employees where deleted_at IS NULL AND CONCAT(IFNULL(employee_id,''), bio_id, first_name, middle_name, last_name) like CONCAT('%', @search ,'%')", pars);
        }
    }
    
}
