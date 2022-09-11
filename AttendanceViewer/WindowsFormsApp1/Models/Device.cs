using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.Models
{
    public class Device : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public long id { get; set; } = 0;
        public string name { get; set; } = "";
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public string ip_address { get; set; } = "";
        public string location { get; set; } = "";
        public DateTime? deleted_at { get; set; }

        public int port { get; set; } = 4370;
        public bool is_active { get; set; } = true;

        public DataGridViewRow bindRow = null;
        public int download_status = 0;//0-pending, 1-downloading, 2-completed, 3-failed


        public long Save()
        {

            if (this.id > 0)
                return StaticClasses.Devices.update_device(this);
            else
                this.id = StaticClasses.Devices.add_device(this);
            return this.id;
        }

        public long Remove()
        {
            return StaticClasses.Devices.delete_device(this);
        }

    }
}
