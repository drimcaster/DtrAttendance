using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace DTRAttendance.Helpers
{
    public class MySQLHelper
    {
        public static string connectionString()
        {
            MySqlConnectionStringBuilder str_builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                UserID = "root",
                Database = "dtr_attendance",
                Password = "",
                Port = 3306
            };

          return  str_builder.ConnectionString;


        }
        public static T Query<T>(string q, MySqlParameter[] pars)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString()))
            {
                con.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(q, con))
                {
                    if (pars != null)
                        da.SelectCommand.Parameters.AddRange(pars);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string json = JsonConvert.SerializeObject(dt, Formatting.None);
                    dt.Dispose();
                    return JsonConvert.DeserializeObject<T>(json);
                }

            }
        }
        public static T Query<T>(string q, List<MySqlParameter> pars = null)
        {
            if (pars == null)
                return Query<T>(q, new MySqlParameter[0]);
            return Query<T>(q, pars.ToArray());
        }

        public static long ExecuteNonQuery(string q, MySqlParameter[] pars)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {


                    if (pars != null)
                        cmd.Parameters.AddRange(pars);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return cmd.LastInsertedId;

                }
            }
        }
        public static long ExecuteNonQuery(string q, List<MySqlParameter> pars=null)
        {
            if (pars == null)
                return ExecuteNonQuery(q, new MySqlParameter[0]);
            return ExecuteNonQuery(q, pars.ToArray());
        }


        public static void createScript(string script)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString()))
            {
                con.Open();
                MySqlScript my_sc = new MySqlScript(con);
                my_sc.Query = script;
                my_sc.Delimiter = "|";
                my_sc.Execute();
            }
        }

        public static bool MySQLScheduleStart()
        {

            ExecuteNonQuery("SET GLOBAL event_scheduler = ON");
            ExecuteNonQuery("DROP EVENT IF EXISTS EVT_ATT_RAW_PROCESS;");
            //return Query<int>("SELECT count(*) as count FROM information_schema.PROCESSLIST WHERE User='event_scheduler'") > 0 ;
            return true;
        }

        public static void CreateAttendanceProcessSchedule()
        {
            createScript(@"
CREATE EVENT IF NOT EXISTS EVT_ATT_RAW_PROCESS
    ON SCHEDULE
      EVERY 1 SECOND 
    DO
      BEGIN
		/*
        DECLARE v INTEGER;
        DECLARE CONTINUE HANDLER FOR SQLEXCEPTION BEGIN END;

        SET v = 0;

        WHILE v < 5 DO
          INSERT INTO t1 VALUES (0);
          UPDATE t2 SET s1 = s1 + 1;
          SET v = v + 1;
        END WHILE;
        */
        #INSERT INTO dtr_attendance.attendance_raws(bio_id,date_time, is_processed) VALUES(1, NOW(),0);
END         ");

        }


    }
}
