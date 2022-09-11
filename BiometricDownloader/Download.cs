using MealApi.Connection;
using MealApi.Sources;
using SintexApiLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiometricDownloader
{
    public partial class Download : Form
    {
        public bool Logout = false;
        int currentMachine = 0;
        List<Machine> machines;
        User user;
        List<MultipleBackgroundHandler> multipleBackGround;
        int _machinCount = 0;



        public Download(User user)
        {

            InitializeComponent();
            this.user = user;
            this.label_user.Text = "Logged in As: " + this.user.name;
            this.Text = "Meal Attendance Download | Logged in As: " + this.user.name;
            this.thread_get_machines.RunWorkerAsync();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now.AddDays(-2);
            comboBox1.SelectedIndex = 0;
             bydownload.SelectedIndex = Properties.Settings.Default.DownloadBySelectedIndex;


            if (MealApi.Properties.Settings.Default.isTest)
            {
                this.Text = this.Text + " - (Test MODE) ";
               
                //this.ForeColor = Color.Red;
            }
            //dataGridView1.MinDate =
        }




        private void button2_Click(object sender, EventArgs e)
        {
            _alreadyRun = new List<MultipleBackgroundHandler>();
            int machine_actives = 0;
            multipleBackGround = new List<MultipleBackgroundHandler>();
            button_download.Enabled = false;
            comboBox1.Enabled = false;
            download_1x1.Enabled = false;
            bydownload.Enabled = false;
            while (this.currentMachine < this.machines.Count )
            {
                if (this.machines[this.currentMachine].selected == false)
                {
                    this.currentMachine++;
                    continue;
                }
                System.ComponentModel.BackgroundWorker bgWork = new BackgroundWorker();
                
                bgWork.DoWork += backgroundWorker1_DoWork;
                bgWork.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

                multipleBackGround.Add(new MultipleBackgroundHandler() {
                    MachineID = this.currentMachine,
                    BackgroundWorker = bgWork,
                    Server = comboBox1.SelectedIndex
                });
              
                //bgWork.RunWorkerAsync();

                this.currentMachine++;
                machine_actives++;
            }
            if(machine_actives == 0)
            {
                button_download.Enabled = true;
                comboBox1.Enabled = true;
                this._machinCount = 0;
                this.currentMachine = 0;
            }
            if (download_1x1.Checked == false)
            {
                foreach (MultipleBackgroundHandler handler in multipleBackGround)
                {
                    handler.BackgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                if(multipleBackGround.Count > 0)
                {
                    _multhander = multipleBackGround;
                    for (int i = 0; i < (bydownload.SelectedIndex + 1) && i < multipleBackGround.Count; i++)
                    {
                        _alreadyRun.Add(multipleBackGround[i]);
                        multipleBackGround[i].BackgroundWorker.RunWorkerCompleted += download1x1_RunWorkerCompleted;
                        multipleBackGround[i].BackgroundWorker.RunWorkerAsync();
                    }
                }

            }
        }
        private List<MultipleBackgroundHandler> _multhander;
        private List<MultipleBackgroundHandler> _alreadyRun ;

        private void download1x1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach(MultipleBackgroundHandler mbh in this._multhander)
            {
                if(!_alreadyRun.Contains(mbh))
                {
                    _alreadyRun.Add(mbh);
                    if (mbh.RunAlready == false)
                    {
                        mbh.RunAlready = true;
                        mbh.BackgroundWorker.RunWorkerCompleted += download1x1_RunWorkerCompleted;
                        mbh.BackgroundWorker.RunWorkerAsync();
                    }
                    break;
                }
            }
        }


        /** END VERSION OF HANDLING DATA
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            var templs = new List<Attendance>();

            //System.Diagnostics.Debug.Print(this.currentMachine.ToString());

            if (this.machines[this.currentMachine].selected == true)
            {

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
                int id = 0;



                zkemkeeper.CZKEM zk = new zkemkeeper.CZKEM();


                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[this.currentMachine].Cells[5].Value = "Connecting....";
                }));


                if (zk.Connect_Net(this.machines[this.currentMachine].ip_address, 4370))
                {


                    Invoke(new Action(() =>
                    {
                        this.dataGridView1.Rows[this.currentMachine].Cells[5].Value = "Downloading....";
                    }));



                    var machineNumber = zk.MachineNumber;

                    if (zk.ReadAllGLogData(machineNumber))
                    {

                        if (zk.IsTFTMachine(machineNumber))
                        {
                            while (zk.SSR_GetGeneralLogData(machineNo, out enrollStr, out verifyMode, out inOutMode, out intYear, out intMonth, out intDay, out intHour, out intMinute, out intSecond,
                                 codeWork))
                            {
                                strTime = Convert.ToInt32(intYear).ToString() + "-" + Convert.ToInt32(intMonth).ToString() + "-" + Convert.ToInt32(intDay).ToString() + " " + intHour.ToString() + ":" + intMinute.ToString() + ":" + intSecond.ToString();
                                templs.Add(new Attendance() { ip_address = this.machines[this.currentMachine].ip_address, biometric_id = enrollStr.ToString(), log_date = DateTime.Parse(strTime), state = inOutMode, id = id, });
                                id++;


                            }
                        }
                        else
                        {
                            while (zk.GetGeneralLogDataStr(machineNo, ref enrollNo, ref verifyMode, ref inOutMode, ref strTime))
                            {
                                templs.Add(new Attendance() { ip_address = this.machines[this.currentMachine].ip_address, biometric_id = enrollNo.ToString(), log_date = DateTime.Parse(strTime), state = inOutMode, id = id, });
                                id++;

                            }
                        }

                    }
                    else
                    {

                        Invoke(new Action(() =>
                        {
                            this.dataGridView1.Rows[this.currentMachine].Cells[5].Value = "FAILED TO LOAD....";
                        }));
                        return;
                    }




                    zk.Disconnect();


                    Invoke(new Action(() =>
                    {
                        this.dataGridView1.Rows[this.currentMachine].Cells[5].Value = "Disconnecting....";
                    }));


                }

                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[this.currentMachine].Cells[5].Value = "Uploading to database...";
                }));


                /// SENDING DATA TO THE SERVER VIA API on datasource.
                AttendanceApi.upload(templs, this.user.id);

                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[this.currentMachine].Cells[5].Value = "Downloaded";
                }));


            }


        }
        **/
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int _CurrentMachine = (from i in multipleBackGround where i.BackgroundWorker == (sender as BackgroundWorker) select i.MachineID).ToList()[0];//; this.currentMachine;
            int _Server = (from i in multipleBackGround where i.BackgroundWorker == (sender as BackgroundWorker) select i.Server).ToList()[0];//; this.currentMachine;

            var templs = new List<Attendance>();
            Attendance2 attendance2 = new Attendance2();
            attendance2.user_name = this.user.name;

            //System.Diagnostics.Debug.Print(this.currentMachine.ToString());

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

            zkemkeeper.CZKEM zk;
            try
            {
                zk = new zkemkeeper.CZKEM();
                
            }
            catch(System.Runtime.InteropServices.COMException ex) {
                //throw new Exception(ex.Message);
                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "System Error";
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                }));
                return;
            }

            
            Invoke(new Action(() =>
            {
                this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Connecting....";
            }));
            //this.machines[_CurrentMachine].ip_address = "172.28.1.1";
            if (zk.Connect_Net(this.machines[_CurrentMachine].ip_address, 4370))
            {

                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Downloading....";
                }));



                var machineNumber = zk.MachineNumber;

               
                if (zk.ReadAllGLogData(machineNumber))
                {
                    //JSON FORMATTING ATTENDANCE LOGS
                    /*
                     * {
                     *      "ip_address": "0.0.0.0",
                     *      "items": [
                     *          {
                     *              "id": 0,
                     *              "biometric_id": "5510000168",
                     *              "log_date": DateTime.Parse(strTime).ToString("yyyy-MM-dd HH:mm:ss"),
                     *              "state": "state"
                     *          }
                     *      ]
                     * }
                     * 
                     * PROCEDURE spAttendanceInputs(_User_Name VARCHAR(200), _IPAddress VARCHAR(200), jsonData TEXT); 
                     */
                    attendance2.ip_address = this.machines[_CurrentMachine].ip_address;
                    attendance2.items = new List<Attendance2Logs>();
                    int log_counts = 0;
                    int log_reads = 0;
                    if (zk.IsTFTMachine(machineNumber))
                    {
                        while (zk.SSR_GetGeneralLogData(machineNo, out enrollStr, out verifyMode, out inOutMode, out intYear, out intMonth, out intDay, out intHour, out intMinute, out intSecond, codeWork))
                        {
                            log_reads++;
                            if (dateTimePicker1.Value.Year == intYear && dateTimePicker1.Value.Month == intMonth && dateTimePicker1.Value.Day == intDay)
                            {
                                log_counts++;
                                strTime = Convert.ToInt32(intYear).ToString() + "-" + Convert.ToInt32(intMonth).ToString() + "-" + Convert.ToInt32(intDay).ToString() + " " + intHour.ToString() + ":" + intMinute.ToString() + ":" + intSecond.ToString();
                                attendance2.items.Add(new Attendance2Logs()
                                {
                                    biometric_id = enrollStr.ToString(),
                                    log_date = DateTime.Parse(strTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    state = inOutMode
                                });

                            }
                            Invoke(new Action(() =>
                            {
                                this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Reading: " + log_reads + " || Current: "+ log_counts;
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
                            if (date_time.Year == intYear && date_time.Month == intMonth && date_time.Day == intDay)
                            {
                                log_counts++;

                                attendance2.items.Add(new Attendance2Logs()
                                {
                                    biometric_id = enrollNo.ToString(),
                                    log_date = DateTime.Parse(strTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    state = inOutMode
                                });

                            }
                            Invoke(new Action(() =>
                            {
                                this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Reading: " + log_reads + " || Current: " + log_counts;
                            }));
                        }
                    }

                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Bio-Machine denies to read logs.";
                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                    }));
                    return;
                }

                if(attendance2.items == null  || attendance2.items.Count <= 0)
                {
                    Invoke(new Action(() =>
                    {
                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "No Data";
                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                    }));
                    return;
                }



                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Disconnecting....";
                }));
                zk.Disconnect();


                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Updating Data.( " + attendance2.items.Count + " )";
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Green;
                    /**
                    * SENDING DATA TO THE SERVER VIA API on datasource.
                    */

                }));

                string[] NotIncludedList = new string[0];
                int NewCount = 0;
                int ExistedCount = 0;
                int ItemCount = 0;
                int NotIncludedCount = 0;
                int RetVal = 1;
                int counting = 0;

                for (int i = 0; i < attendance2.items.Count; i+=30)
                {
                    UploadResultDomain uprd;

                    //UploadResultDomain uploadthis = new UploadResultDomain();
                    Attendance2 attendanceupload = new Attendance2();
                    attendanceupload.items = attendance2.items.Skip(i).Take(30).ToList();
                    counting += attendanceupload.items.Count;
                    attendanceupload.user_name = attendance2.user_name;
                    attendanceupload.ip_address = attendance2.ip_address;
                    //Make an upload of attendance 10by10.
                    //try
                    //{
                    Invoke(new Action(()=>{
                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Uploading( " + counting+'/'+ attendance2.items.Count+")";
                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Blue;
                    }));
                        if (_Server == 1)
                            uprd = AttendanceApi.upload3(attendanceupload);
                        else
                            uprd = AttendanceApi.upload2(attendanceupload);
                        if (uprd.RetVal == "1")
                        {
                            NewCount += uprd.CountDetails.NewCount;
                            ExistedCount += uprd.CountDetails.ExistedCount;
                            ItemCount += uprd.CountDetails.ItemCount;
                            NotIncludedCount += uprd.CountDetails.NotIncluded;
                            NotIncludedList = NotIncludedList.Union(uprd.CountDetails.NotIncludedListArray).ToArray();

                            Invoke(new Action(() =>
                            {
                                if(counting == attendance2.items.Count)
                                {
                                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Successfully Updated.";
                                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Green;
                                }
                                
                                this.machines[_CurrentMachine].selected = false;
                                this.dataGridView1.Rows[_CurrentMachine].DefaultCellStyle.BackColor = Color.White;
                                //6 New
                                this.dataGridView1.Rows[_CurrentMachine].Cells[6].Value = NewCount;
                                //7 Existed
                                this.dataGridView1.Rows[_CurrentMachine].Cells[7].Value = ExistedCount;
                                //8 Total
                                this.dataGridView1.Rows[_CurrentMachine].Cells[8].Value = ItemCount;
                                //9
                                this.dataGridView1.Rows[_CurrentMachine].Cells[9].Value = NotIncludedCount;
                                this.dataGridView1.Rows[_CurrentMachine].Cells[9].Style.ForeColor = Color.Red;
                                this.dataGridView1.Rows[_CurrentMachine].Cells[9].ContextMenuStrip = contextMenuStrip1;
                                this.dataGridView1.Rows[_CurrentMachine].Cells[9].Tag = NotIncludedList;
                            }));
                        }else if (uprd.RetVal == "-1")
                        {
                            Invoke(new Action(() => {
                                this.machines[_CurrentMachine].selected = true;
                                this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Server Failed.";
                            }));
                            break;
                        }
                        else
                        {
                            Invoke(new Action(() => {
                                this.machines[_CurrentMachine].selected = true;
                                this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Update Error(Please Retry).";
                                this.dataGridView1.Rows[_CurrentMachine].DefaultCellStyle.BackColor = Color.Orange;
                                //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                            }));
                            break;
                        }


                    //}
                    // catch
                    //{
                    //    Invoke(new Action(() =>
                    //    {
                    //        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "ERROR ENCOUNTERED";
                    //    }));
                        //RetVal = -1;
                     //   break;
                    //}
                }
                /*
                Invoke(new Action(() =>
                    {

                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Successfully Updated.";
                        this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Blue;

                        if (RetVal == 1)
                        {
                            
                            this.machines[_CurrentMachine].selected = false;
                            this.dataGridView1.Rows[_CurrentMachine].DefaultCellStyle.BackColor = Color.White;
                            //6 New
                            this.dataGridView1.Rows[_CurrentMachine].Cells[6].Value =  NewCount;
                            //7 Existed
                            this.dataGridView1.Rows[_CurrentMachine].Cells[7].Value =  ExistedCount;
                            //8 Total
                            this.dataGridView1.Rows[_CurrentMachine].Cells[8].Value =  ItemCount;
                            //9
                            this.dataGridView1.Rows[_CurrentMachine].Cells[9].Value = NotIncludedCount;
                            this.dataGridView1.Rows[_CurrentMachine].Cells[9].Style.ForeColor = Color.Red;
                            this.dataGridView1.Rows[_CurrentMachine].Cells[9].ContextMenuStrip = contextMenuStrip1;
                            this.dataGridView1.Rows[_CurrentMachine].Cells[9].Tag = NotIncludedList;
                            

                        }
                        else
                        {
                            if (uprd.RetVal == "-1")
                                this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Server Fail.";
                            else
                                this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Update Error(Please Retry).";
                            this.dataGridView1.Rows[_CurrentMachine].DefaultCellStyle.BackColor = Color.Orange;
                            //this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                            this.dataGridView1.Rows[_CurrentMachine].Cells[6].Value = "";
                            this.dataGridView1.Rows[_CurrentMachine].Cells[7].Value = "";
                            this.dataGridView1.Rows[_CurrentMachine].Cells[8].Value = "";
                            this.dataGridView1.Rows[_CurrentMachine].Cells[9].Value = "";
                            this.dataGridView1.Rows[_CurrentMachine].Cells[9].ContextMenuStrip = null;
                            this.dataGridView1.Rows[_CurrentMachine].Cells[9].Tag = null;
                        }
                    }
                ));*/
                //this.currentMachine++;
            }
            else
            {

                Invoke(new Action(() =>
                {
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Value = "Cannot Connect Biometrics Machine";
                    this.dataGridView1.Rows[_CurrentMachine].Cells[5].Style.ForeColor = Color.Red;
                }));
            }

            //}
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this._machinCount++;
            if (this._machinCount == this.multipleBackGround.Count)
            {
                this.currentMachine = 0;
                MessageBox.Show(this, "Freemeal update process completed!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.button_download.Enabled = true;
                this.comboBox1.Enabled = true;
                this.download_1x1.Enabled = true;
                this.bydownload.Enabled = true;
                this._machinCount = 0;
            }
        }


        private void upload_thread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._machinCount++;
        }

        void download()
        {
        }

        private void thread_get_machines_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = AttendanceApi.machines(this.user.id);
        }

        private void thread_get_machines_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            ApiResponse response = (ApiResponse)e.Result;
            if (response.success)
            {


                this.machines = (response.data as List<MealApi.Sources.Machine>).Where(a=>a.type_text=="IN").ToList();
                this.dataGridView1.DataSource = this.machines;
                //6
                this.dataGridView1.Columns.Add("_new", "New Added");
                //7
                this.dataGridView1.Columns.Add("_existed", "Already Exists");

                //8
                this.dataGridView1.Columns.Add("_itemCounts", "Item Counts");
                //9
                this.dataGridView1.Columns.Add("_notAllowed", "Not Allowed");

                //Read Only
                for(int i = 1; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].ReadOnly = true;
                }


                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                

            }
            else
            {
                MessageBox.Show(this, response.message, "Fetching Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        void ExitApp()
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Logout = true;
            this.Close();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //download();
            button_download.PerformClick();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.Rows[row.Index].Cells[0].Value = this.checkBox1.Checked;
            }
        }

        private void Download_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Logout == false)
            {
                if (MessageBox.Show(this, "Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                label1.Text = "Automatically creates freemeal when successfully updated.";
                label1.ForeColor = Color.Black;
            }
            else
            {
                label1.Text = "Slowly but surely.(Freemeal est. 5-10 minutes.)";
                label1.ForeColor = Color.Blue;
            }
        }

        private void viewErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ow = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip);
            string text = "";
            text += "=========================\r\n";
            text += "=== BIOMETRIC LIST ======\r\n";
            text += "=========================\r\n";
            string[] ss = (string[])dataGridView1.CurrentRow.Cells[9].Tag;
            text += "BIOMETRICS COUNT: "+ ss.Length +"\r\n";
            text += "=========================\r\n";
            foreach (string s in ss)
            {
                text += s + "\r\n";
            }
            text += "=========================";

            MessageBoxShowing mbs = new MessageBoxShowing();
            mbs.Text = "Biometric Not Allowed List";
            mbs.textBox1.Text = text;
            mbs.ShowDialog();
            mbs.Dispose();

        }
        private void updatesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tutorials.sportscity.com.ph/directSamples/Freemeal/Biometrics%20Downloads/");
        }

        private void bydownload_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DownloadBySelectedIndex = bydownload.SelectedIndex;
        }
    }
    public class MultipleBackgroundHandler
    {
        public int MachineID { get; set; }
        public System.ComponentModel.BackgroundWorker BackgroundWorker { get; set; }
        public int Server { get; set; }
        public bool RunAlready { get; set; }
    }

    public class AttendanceFetchedArgs : EventArgs
    {
        public string Message { get; set; }
        public AttendanceFetchedArgs(string message)
        {
            this.Message = Message;

        }
    }
}
