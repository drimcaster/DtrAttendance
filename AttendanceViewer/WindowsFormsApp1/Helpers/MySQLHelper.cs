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
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    if (pars != null)
                        cmd.Parameters.AddRange(pars);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(q, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string json = JsonConvert.SerializeObject(dt, Formatting.None);
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




    }
}
