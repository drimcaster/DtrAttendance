using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.Models
{
    public class Employee : ICloneable
    {
        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
        public int id { get; set; } = 0;
        public string employee_id { get; set; } = "";
        public string bio_id { get; set; } = "";

        public string first_name { get; set; } = "";
        public string middle_name { get; set; } = "";
        public string last_name { get; set; } = "";
        public string hired_date { get; set; } = "";
        public bool is_active { get; set; } = true;

        public long att_sched_id { get; set; } = 1;
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }


        public DataGridViewRow row;


        public string getFullName()
        {
            return (this.last_name ?? "") + ", " + (this.first_name ?? "") + " " + (this.middle_name ?? "");
        }
    }
}
