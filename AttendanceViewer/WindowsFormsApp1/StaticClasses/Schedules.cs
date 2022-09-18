using DTRAttendance.Helpers;
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
    }
}
