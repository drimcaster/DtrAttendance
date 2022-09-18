using DTRAttendance.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.StaticClasses
{
    public static class Schedules
    {
        public static List<Models.Schedule> GetSchedules()
        {
            return MySQLHelper.Query<List<Models.Schedule>>("SELECT * FROM attendance_scheds WHERE deleted_at IS NULL");
        }


        public static long AddSchedule(Models.Schedule schedule)
        {
            MySqlParameter[] pars = new MySqlParameter[5];
            pars[0] = new MySqlParameter("@name", schedule.name);
            pars[1] = new MySqlParameter("@am_in", schedule.am_in);
            pars[2] = new MySqlParameter("@am_out", schedule.am_out);
            pars[3] = new MySqlParameter("@pm_in", schedule.pm_in);
            pars[4] = new MySqlParameter("@pm_out", schedule.pm_out);

            if(Helpers.MySQLHelper.countRowQuery("SELECT * FROM attendance_scheds WHERE name=@name", pars) > 0)
            {
                return -1;
            }
            return Helpers.MySQLHelper.ExecuteNonQuery("INSERT INTO attendance_scheds(`name`, am_in, am_out, pm_in, pm_out) VALUES(@name, @am_in, @am_out, @pm_in, @pm_out)", pars);

            
        }



    }
}
