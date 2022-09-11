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
    public partial class Login : MealApi.Templates.Login
    {

        public Login()
        {
            InitializeComponent();
            this.user = new User();

            if (MealApi.Properties.Settings.Default.isTest)
            {
                this.Text = this.Text + " - (Test MODE) ";
                //this.
                this.ForeColor = Color.Red;
                this.button1.Text = "Login (Test Mode)";
            }

        }

        private void init_login()
        {
            if (!this.thread_login.IsBusy)
            {
                this.toolStripStatusLabel1.Text = "Please wait.....";
                this.username = this.text_usernane.Text;
                this.password = this.text_password.Text;

                this.text_password.Enabled = false;
                this.text_usernane.Enabled = false;

                thread_login.RunWorkerAsync();
            }
            else
                MessageBox.Show(this, "Please wait while the system is processing your request...", "System Busy", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void thread_login_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = UserApi.download_attendance_authentication(this.username, this.password);
        }

        private void thread_login_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ApiResponse response = (ApiResponse)e.Result;
            if (response.success)
            {

                this.Hide();
                Download download = new Download((User)response.data);
                download.ShowDialog();
                if (download.Logout == false)
                    Application.Exit();
                else
                    this.Show();

            }
            else
            {
                MessageBox.Show(this, response.message, "Fetching Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.toolStripStatusLabel1.Text = "Status";
            this.text_password.Enabled = true;
            this.text_usernane.Enabled = true;
            this.text_usernane.Focus();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            this.init_login();
        }

        private void text_usernane_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.init_login();
        }
    }
}
