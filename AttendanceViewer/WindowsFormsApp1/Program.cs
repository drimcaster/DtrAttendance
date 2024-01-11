using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using AppServ;
using DTRAttendance.Properties;

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
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            //addCertificate();
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

        static void addCertificate()
        {

            // Get the server's certificate
            byte[] Rawdata = Resources.certificate;
            X509Certificate2 serverCertificate = new X509Certificate2(Rawdata);

            // Add the server's certificate to the trusted certificates collection
            X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.Add(serverCertificate);
            store.Close();

        }
    }
}
