using DTRAttendance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DTRAttendance.Employees.AddEditEmployee().ShowDialog();
        }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DTRAttendance.Devices.DeviceList().ShowDialog();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DTRAttendance.Devices.Download().ShowDialog();
        }
    }
}
