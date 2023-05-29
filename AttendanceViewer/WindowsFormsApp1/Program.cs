using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AppServ;

namespace DTRAttendance
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string base_url = Properties.Settings.Default.IsTest ? Properties.Settings.Default.TEST_BASE_URL : Properties.Settings.Default.PROD_BASE_URL;
            string base_api_url = Properties.Settings.Default.IsTest ? Properties.Settings.Default.TEST_BASE_API_URL : Properties.Settings.Default.PROD_BASE_API_URL;
            
            ApiMainRequest.StartLicenseValidation(base_url, base_api_url, ApplicationList.DTRSystem_WindowsApp, "DTR System Licensing", (string validationInfo) =>
            {
                Form1.LicenseInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<AppServ.Models.ValidationInfo>(validationInfo);
                Application.Run(new Security());
            }); 

        }
    }
}
