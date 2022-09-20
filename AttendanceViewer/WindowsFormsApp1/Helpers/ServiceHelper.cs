using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRAttendance.Helpers
{
    public static class ServiceHelper
    {
        public static List<Models.Schedule> global_schedules = new List<Models.Schedule>();

        public static void LoadDataAndServices()
        {
            global_schedules = StaticClasses.Schedules.GetSchedules();

            StaticClasses.DtrAnalysis.checkSystemDefaults();

            //Check DB
            DBVersion.checkDB();
        }


    }
}
