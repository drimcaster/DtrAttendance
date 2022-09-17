using DTRAttendance.Helpers;
using DTRAttendance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace DTRAttendance.Devices
{
    public partial class Download : Form
    {
        public Download(DateTime dt)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Parse(dt.Year + "-" + dt.Month + "-" + 1);
            dateTimePicker2.Value = DateTime.Parse(dt.Year + "-" + dt.Month + "-" + DateTime.DaysInMonth(dt.Year, dt.Month));


        }

        public List<Models.Device> DeviceList { get; set; } = new List<Models.Device>();



        public void download_bio(Models.Device device)
        {
            zkemkeeper.CZKEM zk;

            int machineNo = 0;
            int verifyMode = 0;
            int inOutMode = 0;
            string enrollStr = string.Empty;
            int intYear = 0;
            int intMonth = 0;
            int intDay = 0;
            int intHour = 0;
            int intMinute = 0;
            int intSecond = 0;
            int codeWork = 0;
            int enrollNo = 0;
            string strTime = string.Empty;
            // Attendance2 attendance2 = new Attendance2();
            //Models.Attendance attendance = new Models.Attendance();

            //var device = DeviceList.Where(a => a.id == device_id).FirstOrDefault();
            //attendance.device = device;

            try
            {
                zk = new zkemkeeper.CZKEM();

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                //throw new Exception(ex.Message);
                Invoke(new Action(() =>
                {
                    device.bindRow.Cells[Col_Status.Index].Value = "System Error";
                    device.bindRow.Cells[Col_Status.Index].Style.ForeColor = Color.Red;
                    //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "System Error";
                    //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                }));
                return;
            }



            Invoke(new Action(() =>
            {
                device.bindRow.Cells[Col_Status.Index].Value = "Connecting....";
                //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Connecting....";
            }));


            //TESTING PURPOSE TO return;
            device.device_logs = new List<Log>();
            device.device_logs.Add(new Log() { bio_id = "1", device_id = device.id, in_out = 1, IsSaved = false, sign_time = "2022-01-01 10:11:12" });
            device.SaveDataLogs();

            return;
            if (zk.Connect_Net(device.ip_address, device.port))//4370
            {
                Invoke(new Action(() =>
                {
                    device.bindRow.Cells[Col_Status.Index].Value = "Downloading....";
                    //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Downloading....";
                }));

                var machineNumber = zk.MachineNumber;
                DateTime? _from = null;
                DateTime? _to = null;

                if (zk.ReadAllGLogData(machineNumber))
                {
                    //attendance2.ip_address = this.machines[_CurrentMachine].ip_address;
                    //attendance2.items = new List<Attendance2Logs>();
                    device.device_logs = new List<Models.Log>();
                    int log_counts = 0;
                    int log_reads = 0;
                    Invoke(new Action(() =>
                    {
                        _from = DateTime.Parse(dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + " 00:00:00");
                        _to = DateTime.Parse(dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day + " 23:59:59");
                    }));
                    if (zk.IsTFTMachine(machineNumber))
                    {
                        while (zk.SSR_GetGeneralLogData(machineNo, out enrollStr, out verifyMode, out inOutMode, out intYear, out intMonth, out intDay, out intHour, out intMinute, out intSecond, codeWork))
                        {
                            log_reads++;
                            DateTime dt = DateTime.Parse(intYear + "-" + intMonth + "-" + intDay + " 00:00:00");
                            if (_from <= dt && dt <= _to)
                            {
                                log_counts++;
                                strTime = Convert.ToInt32(intYear).ToString() + "-" + Convert.ToInt32(intMonth).ToString() + "-" + Convert.ToInt32(intDay).ToString() + " " + intHour.ToString() + ":" + intMinute.ToString() + ":" + intSecond.ToString();


                                /*
                                attendance2.items.Add(new Attendance2Logs()
                                {
                                    biometric_id = enrollStr.ToString(),
                                    log_date = DateTime.Parse(strTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    state = inOutMode
                                });
                                */
                                device.device_logs.Add(new Log()
                                {
                                    bio_id = enrollStr.ToString(),
                                    sign_time = DateTime.Parse(strTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    device_id = device.id,
                                    in_out = inOutMode
                                   
                                });

                            }
                            Invoke(new Action(() =>
                            {
                                device.bindRow.Cells[Col_LogsCount.Index].Value = log_counts;
                                device.bindRow.Cells[Col_Status.Index].Value = "Reading: " + log_reads + " || Current: " + log_counts;
                                //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Reading: " + log_reads + " || Current: " + log_counts;
                            }));
                        }
                    }
                    else
                    {
                        intYear = dateTimePicker1.Value.Year;
                        intMonth = dateTimePicker1.Value.Month;
                        intDay = dateTimePicker1.Value.Day;
                        while (zk.GetGeneralLogDataStr(machineNo, ref enrollNo, ref verifyMode, ref inOutMode, ref strTime))
                        {
                            log_reads++;
                            var date_time = DateTime.Parse(strTime);
                            if (_from <= date_time && date_time <= _to)
                            {
                                log_counts++;
                                /*
                                attendance2.items.Add(new Attendance2Logs()
                                {
                                    biometric_id = enrollNo.ToString(),
                                    log_date = DateTime.Parse(strTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    state = inOutMode
                                });
                                */
                                device.device_logs.Add(new Log()
                                {
                                    bio_id = enrollStr.ToString(),
                                    sign_time = DateTime.Parse(strTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    device_id = device.id,
                                    in_out = inOutMode
                                });

                            }
                            Invoke(new Action(() =>
                            {
                                device.bindRow.Cells[Col_LogsCount.Index].Value = log_counts;
                                device.bindRow.Cells[Col_Status.Index].Value = "Reading: " + log_reads + " || Current: " + log_counts;
                                //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Reading: " + log_reads + " || Current: " + log_counts;
                            }));
                        }
                    }
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        device.bindRow.Cells[Col_Status.Index].Value = "Bio-Machine denies to read logs.";
                        device.bindRow.Cells[Col_Status.Index].Style.ForeColor = Color.Red;
                        //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Bio-Machine denies to read logs.";
                        //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                    }));
                    return;
                }

                if (device.device_logs  == null || device.device_logs.Count <= 0)
                {
                    Invoke(new Action(() =>
                    {
                        device.bindRow.Cells[Col_Status.Index].Value = "Bio-Machine denies to read logs.";
                        device.bindRow.Cells[Col_Status.Index].Style.ForeColor = Color.Red;
                        //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "No Data";
                        //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                    }));
                    return;
                }



                Invoke(new Action(() =>
                {
                    device.bindRow.Cells[Col_Status.Index].Value = "Disconnecting....";
                    //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Disconnecting....";
                }));
                zk.Disconnect();
                System.Threading.Thread.Sleep(2000);


                Invoke(new Action(() =>
                {
                    device.bindRow.Cells[Col_Status.Index].Value = "Updating Data.( " + device.device_logs.Count + " )";
                    device.bindRow.Cells[Col_Status.Index].Style.ForeColor = Color.Green;
                    //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Updating Data.( " + attendance2.items.Count + " )";
                    //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Green;

                }));
                //Updaitng here
                device.SaveDataLogs();
            }



        }

        private void Download_Load(object sender, EventArgs e)
        {

            this.load_list();
        }
        private void load_list()
        {
            dataGridView1.Rows.Clear();
            //Load Active Devices
            DeviceList = StaticClasses.Devices.load_active_devices();

            foreach(Models.Device device in DeviceList)
            {
                device.SavingResult += Device_SavingResult;
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = device;
                device.bindRow = row;
                dataGridView1.Rows.Add(row);
            }
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                Models.Device device = row.Tag as Models.Device;
                row.SetValues(true, device.name, 0, 0, "Pending");
                device.bindRow = row;
            }
        }

        private void Device_SavingResult(Device device, bool is_completed, bool is_error, int added, int existed)
        {
            //throw new NotImplementedException();
            Invoke(new Action(() =>
            {
                int logsCount = 0;
                if (device.device_logs != null)
                    logsCount = device.device_logs.Count;

                device.bindRow.Cells[Col_Status.Index].Value = (is_completed ? "Completed: " : "") + "Added(" + added + "), Existed(" + existed + ") from Data(" + logsCount + ")";
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                Models.Device device = row.Tag as Models.Device;
                if (device != null)
                {
                    device.ResetSavingData();
                    BackgroundWorker bgw = new BackgroundWorker();
                    bgw.DoWork += (b, g) => { 
                            download_bio(device);
                    };
                    bgw.RunWorkerAsync();
                }
            }
        }

    }
}
