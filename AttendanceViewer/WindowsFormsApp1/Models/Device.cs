using DTRAttendance.Helpers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DTRAttendance.Models
{
    public class Device : ICloneable
    {

        public delegate void SavingResultDelegate(Device device, bool is_completed, bool is_error, int added, int existed, Exception error = null);

        public event SavingResultDelegate SavingResult;
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

        public List<Models.Log> device_logs;
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

        public bool IsSaving = false;
        public bool SaveDataCompleted = false;
        private bool ErrorResult = false;
        private int Existed = 0;
        private int Added = 0;
        public int LogsCount
        {
            get
            {
                if (device_logs == null)
                    return 0;

                return device_logs.Count;

            }
        }
        public int SavedCount
        {
            get
            {
                if (device_logs == null)
                    return 0;

                return device_logs.Where(a => a.IsSaved).Count();

            }
        }
        public void SaveDataLogs()
        {
            if (LogsCount > 0)
            {
                BackgroundWorker bgworker = new BackgroundWorker();
                bgworker.DoWork += Bgworker_DoWork;
                bgworker.RunWorkerAsync();
            }
            else
            {
                SaveDataCompleted = true;
                if (SavingResult != null)
                    SavingResult(this, SaveDataCompleted, ErrorResult, Added, Existed);

            }
        }

        public void ResetSavingData()
        {
            SaveDataCompleted = false;
            ErrorResult = false;
            Existed = 0;
            Added = 0;
        }
        public void RetrySavingData()
        {
            ErrorResult = false;
            SaveDataCompleted = false;
            SaveDataLogs();
        }
        private void Bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            System.Threading.Thread.Sleep(400);
            try
            {
                int rand = new Random().Next(5, 10);
                var list_5 = device_logs.Where(x => x.IsSaved == false).Take(rand);
                if (list_5.Count() >= 1)
                {
                    //throw new Exception(JsonConvert.SerializeObject(list_5));
                    MySqlParameter[] pars = new MySqlParameter[4];
                    pars[0] = new MySqlParameter("@name", "AttendanceRaws");
                    pars[1] = new MySqlParameter("@login_id", 0);
                    pars[2] = new MySqlParameter("@json", JsonConvert.SerializeObject(list_5));
                    pars[3] = new MySqlParameter("@command", "Update Attendance");
                    var list = MySQLHelper.Query<List<Newtonsoft.Json.Linq.JObject>>("CALL spAttendanceRawsCommand(@name, @login_id, @json, @command)", pars).First();
                    Added += list.Value<int>("Added");
                    Existed += list.Value<int>("Existed");

                    foreach (var l in list_5)
                    {
                        l.IsSaved = true;
                    }

                    if (SavingResult != null)
                        SavingResult(this, SaveDataCompleted, ErrorResult, Added, Existed);

                    //Recursive after 1 background instance
                    SaveDataLogs();
                }
                else
                {
                    SaveDataCompleted = true;
                    if (SavingResult != null)
                        SavingResult(this, SaveDataCompleted, ErrorResult, Added, Existed);
                }
            }
            catch(Exception ex)
            {
                ErrorResult = true;

                if (SavingResult != null)
                    SavingResult(this, SaveDataCompleted, ErrorResult, Added, Existed, ex);

                //throw new Exception(ex.Message);
            }
        }
    }
}
