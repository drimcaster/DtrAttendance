using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace DTRAttendance.Helpers
{
    public static class DBVersion
    {
        public static string current_db_version()
        { 
            var dt = SSH_MySQL_Lib.MySqlQuery.QueryResult("SELECT MAX(version) as version FROM (\r\n\tSELECT  version FROM db_version order by id desc LIMIT 1 \r\n) as A");
            string ss = (dt.Rows?[0]?["version"] ?? "1.0.0.0").ToString().Trim();
            dt.Dispose();
            if (ss == String.Empty)
                return "1.0.0.0";
            return ss; 
        }

        public static string app_version()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            return version.Trim();
        }
        public static void checkDB()
        {
            CheckVersionTable();

            var db_version = new Version(  current_db_version() );
            var app_vs = new Version( app_version() );

            var version_compare = db_version.CompareTo(app_vs);


            //DB VERSION IS HIGHER
            if (version_compare > 0)
            {
                if (MessageBox.Show("Would you like to proceed?\r\nYou are using higher version of database. Please use application updated version.", "App requires update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    return;
                }
                Application.Exit();
                return;
            }
            else if(version_compare < 0)
            {
                if (MessageBox.Show("You are using outdated version of database, Would you like to update?.", "DB update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //UPDATE DB SCHEMA
                    UpdateSchema(db_version, app_vs);

                    //UPDATE DB VERSION
                    UpdateDBVersion(app_vs.ToString());
                    return;
                }
            }
        }






        private static void CheckVersionTable()
        {
            /*
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            //MessageBox.Show(version);
            */
            MySqlParameter[] pars = new MySqlParameter[2];
            pars[0] = new MySqlParameter("@table", SSH_MySQL_Lib.Properties.Settings.Default.DB_Schema);
            pars[1] = new MySqlParameter("@db_version", "db_version");
            var dt = SSH_MySQL_Lib.MySqlQuery.QueryResult("SELECT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = @table AND  TABLE_NAME =@db_version) as is_exists", pars);
            //MessageBox.Show(dt.Rows[0]["is_exists"].ToString());
            if (dt.Rows[0]["is_exists"].ToString() == "0")
            {
                //CREATE TABLE
                MySQLHelper.createScript("CREATE TABLE `db_version` (  `id` INT AUTO_INCREMENT NOT NULL, `version` VARCHAR(45) NULL,  `updated_at` DATETIME NULL,  PRIMARY KEY (`id`));");

            }
            dt.Dispose();

        }

        private static void UpdateDBVersion(string version)
        {
            MySqlParameter[] pars = new MySqlParameter[1];
            pars[0] = new MySqlParameter("@version", version);
            MySQLHelper.ExecuteNonQuery("INSERT INTO db_version(version, updated_at) VALUES(@version, NOW())", pars);
        
        }


        private static void UpdateSchema(Version db_version, Version app_ver)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "DTRAttendance.DBVersionUpdate.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string[] result = reader.ReadToEnd().Split('\n');

                bool start_records = false;
                bool record_found = false;
                string results = "";

                foreach (var res in result)
                {
                    if (start_records == false)
                    {
                        if (res.Length > 17 && res.Substring(0, 17).ToLower().Trim() == "###version-update")
                        {
                            var detect_version = new Version(res.ToLower().Replace("###version-update", "").Trim());
                            if (db_version.CompareTo(detect_version) < 0)
                            {
                                record_found = true;
                                start_records = true;
                            }
                        }
                    }
                    //break version
                    else if (res.Length > 17 && res.Substring(0, 17).ToLower().Trim() == "###version-update")
                    {
                        var detect_version = new Version(res.ToLower().Replace("###version-update", "").Trim());
                        if (app_ver.CompareTo(detect_version) < 0)
                        {
                            start_records = false;
                        }
                    }
                    else
                    {
                        results += (res + "\n");
                    }
                }
                if (record_found && results != "")
                {
                    //Script execution here.
                    SSH_MySQL_Lib.MySqlQuery.createScript("SET global log_bin_trust_function_creators = 1;");
                    SSH_MySQL_Lib.MySqlQuery.createScript("use `"+SSH_MySQL_Lib.Properties.Settings.Default.DB_Schema+"`;\r\n" +results); 
                }





            }
        }




    }
}
