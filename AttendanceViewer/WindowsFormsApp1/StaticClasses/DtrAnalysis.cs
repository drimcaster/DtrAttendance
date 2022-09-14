using DTRAttendance.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.StaticClasses
{
    public class DtrAnalysis
    {
        public static bool hasRawtoAnalyze()
        {
            return MySQLHelper.countRowQuery(" SELECT * FROM attendance_raws WHERE is_processed = 0 LIMIT 1") > 0;
        }

        public static bool isScheduleRunning()
        {
           return MySQLHelper.Query<List<Models.MySQLProcess>>("SHOW PROCESSLIST").Where(a => a.User == "event_scheduler").ToList().Count > 0;
        }

        public static void disableRawAnalysis()
        {
            MySQLHelper.ExecuteNonQuery("ALTER EVENT EVT_ATT_RAW_PROCESS DISABLE");
        }

        public static void enableRawAnalysis()
        {
            MySQLHelper.ExecuteNonQuery("ALTER EVENT EVT_ATT_RAW_PROCESS ENABLE");
        }
        public static bool MySQLScheduleStart()
        {


            if (StaticClasses.DtrAnalysis.isScheduleRunning() == false)
            {
                MySQLHelper.ExecuteNonQuery("SET GLOBAL event_scheduler = ON");
                System.Threading.Thread.Sleep(5000);
                return StaticClasses.DtrAnalysis.isScheduleRunning();
            }
            //return Query<int>("SELECT count(*) as count FROM information_schema.PROCESSLIST WHERE User='event_scheduler'") > 0 ;
            return true;
        }
        public static bool isRawAnalysisRunning()
        {
            return MySQLHelper.Query<List<Models.MySQLEvents>>("SHOW EVENTS").Where(a =>
                {
                    bool cond_db = a.Db.ToLower().Trim() == SSH_MySQL_Lib.Properties.Settings.Default.DB_Schema;
                    bool cond_event = a.Name.ToUpper().Trim() == "EVT_ATT_RAW_PROCESS";
                    bool cond_stat = a.Status.ToUpper().Trim() == "ENABLED";
                    return cond_db && cond_event && cond_stat;

                }
            ).ToArray().Length > 0;
        }


        public static void checkSystemDefaults()
        {

            //SHOULD BE FIXED ATTENDANCE SCHEDS
             if(MySQLHelper.countRowQuery("SELECT * FROM attendance_scheds WHERE id=1") == 0)
            {
                long id = MySQLHelper.ExecuteNonQuery("INSERT INTO attendance_scheds( `name`, am_in, am_out, pm_in, pm_out) VALUES( 'default', '08:00:00', '12:00:00', '13:00:00', '17:00:00')");
                MySQLHelper.ExecuteNonQuery("UPDATE attendance_scheds SET id = 1 WHERE id=" + id);
            };

            //DAYS FROM 1 to 31 should be complete
            List<Models.DtrDay> days = MySQLHelper.Query<List<Models.DtrDay>>("SELECT day_no FROM dtr_days order by day_no ASC");
            //INSPECTING AND CREATING IF LACKING
            for(int i = 1; i <= 31; i++)
            {
                if( days.Where(a=>a.day_no == i).Count() == 0)
                {
                    long id = MySQLHelper.ExecuteNonQuery("INSERT INTO dtr_days() VALUES()");
                    MySQLHelper.ExecuteNonQuery("UPDATE dtr_days SET day_no = "+i+ " WHERE day_no=" + id);
                }
            }
        }
    }
}
