using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTRAttendance.Models;
using MySql.Data.MySqlClient;

namespace DTRAttendance.StaticClasses
{
    public static class Devices
    {
        public static List<DTRAttendance.Models.Device> load_active_devices()
        {

          return   Helpers.MySQLHelper.Query<List<Device>>("SELECT * FROM devices WHERE deleted_at IS NULL AND is_active = 1");

        }

        public static List<DTRAttendance.Models.Device> load_devices()
        {

            return Helpers.MySQLHelper.Query<List<Device>>("SELECT * FROM devices WHERE deleted_at IS NULL");

        }

        public static long add_device(Models.Device device)
        {
            List<MySql.Data.MySqlClient.MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@name", device.name));
            pars.Add(new MySqlParameter("@location", device.location));
            pars.Add(new MySqlParameter("@ip_address", device.ip_address));
            pars.Add(new MySqlParameter("@port", device.port));
            pars.Add(new MySqlParameter("@is_active", device.is_active));


            return Helpers.MySQLHelper.ExecuteNonQuery("INSERT INTO devices(`name`, `location`, `ip_address`, `port`, `is_active`, `created_at`) VALUES(@name, @location, @ip_address, @port, @is_active, NOW())", pars);
        }

        public static long update_device(Models.Device device)
        {
            List<MySql.Data.MySqlClient.MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@id", device.id));
            pars.Add(new MySqlParameter("@name", device.name));
            pars.Add(new MySqlParameter("@location", device.location));
            pars.Add(new MySqlParameter("@ip_address", device.ip_address));
            pars.Add(new MySqlParameter("@port", device.port));
            pars.Add(new MySqlParameter("@is_active", device.is_active));
            return Helpers.MySQLHelper.ExecuteNonQuery("UPDATE devices SET `name`=@name,`location`=@location, ip_address=@ip_address, port=@port, `is_active`=@is_active, updated_at = NOW() WHERE id=@id", pars);


        }
        public static long delete_device(Models.Device device)
        {

            List<MySql.Data.MySqlClient.MySqlParameter> pars = new List<MySqlParameter>();
            pars.Add(new MySqlParameter("@id", device.id));
            return Helpers.MySQLHelper.ExecuteNonQuery("UPDATE devices SET deleted_at = NOW() WHERE id=@id", pars);
        }

    }
}
