using DTRAttendance.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    }
}
