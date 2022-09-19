using DTRAttendance.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance
{
    public partial class Security : Form
    {
        public Security()
        {
            InitializeComponent();
        }

        private void Security_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!SSH_MySQL_Lib.MySqlQuery.ConnectionTest())
            {
                if (new SSH_MySQL_Lib.SetUp().ShowDialog() == DialogResult.OK)
                    button1.PerformClick();
            }
            else
            {
                this.Hide();
                MySQLHelper.ExecuteNonQuery("SET names utf8mb4;", new List<MySqlParameter>());
                new Form1().ShowDialog();
                this.Close();
            }

        }
    }
}
