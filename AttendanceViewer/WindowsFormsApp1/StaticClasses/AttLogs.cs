using DTRAttendance.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.StaticClasses
{
    internal class AttLogs
    {
        public static List<Models.Attendance_Log> get_logs(int employee_id, int month, int year)
        {

            List<MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@employee_id", employee_id));
            pars.Add(new MySqlParameter("@month", month));
            pars.Add(new MySqlParameter("@year", year));

            return MySQLHelper.Query<List<Models.Attendance_Log>>("SELECT *,B.`name` as sched_name FROM attendance_raws AS A, attendance_scheds AS B WHERE A.att_sched_id = B.id AND A.employee_id=@employee_id AND MONTH(date_time)=@month AND YEAR(date_time)=@year order by date_time", pars);
        }

        public static void SetTimeCheck(Models.Attendance_Log log, int check_id)
        {
            List<MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@raw_id", log.id));
            pars.Add(new MySqlParameter("@check_id", check_id));

            MySQLHelper.ExecuteNonQuery("CALL spSetAttRawCheck(@raw_id,@check_id)", pars);

        }

        public static void AddManualLog(Models.Employee employee, DateTime date_time, long schedule_id, int check_dtr_id)
        {
            List<MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@employee_id", employee.id));
            pars.Add(new MySqlParameter("@date_time", date_time));
            pars.Add(new MySqlParameter("@schedule_id", schedule_id));
            pars.Add(new MySqlParameter("@check_dtr_id", check_dtr_id));
            MySQLHelper.ExecuteNonQuery("CALL spAddManualLog(@employee_id,@date_time, @schedule_id, @check_dtr_id )", pars);
        }

    }
}
