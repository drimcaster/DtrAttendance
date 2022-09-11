using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTRAttendance.Devices
{
    public partial class DeviceList : Form
    {
        public DeviceList()
        {
            InitializeComponent();
            //devices = new List<Models.Device>();



        }
        public List<Models.Device> devices;
        public Models.Device selectedDevice = null;

        public Dictionary<string,Binding> bindings;
        public Binding binds(object Source, string keyname, Control c, string controlProperty, Func<object> omg = null, bool isFormatting = false)
        {
            if(bindings == null) {
                bindings = new Dictionary<string, Binding>();
            }
            
            if ( bindings.ContainsKey(keyname) && bindings[keyname] != null)
            {
                c.DataBindings.Remove(bindings[keyname]);
                bindings.Remove(keyname);
            }
            bindings.Add(keyname, new Binding(controlProperty, Source, keyname, isFormatting));
            if(isFormatting)
            {
                if (omg == null)
                    bindings[keyname].BindingComplete += DeviceList_BindingComplete;
                else
                    bindings[keyname].BindingComplete += (s, e) => { omg(); };
            }
            c.DataBindings.Add(bindings[keyname]);
            return bindings[keyname];
        }

        private void DeviceList_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.BindingCompleteState != BindingCompleteState.Success)
                MessageBox.Show(  e.ErrorText );
            
        }

        public void bindField(object Source, bool is_readonly = true)
        {
            txt_port.ReadOnly =
            txt_ip.ReadOnly =
            txt_location.ReadOnly =
            txt_name.ReadOnly = is_readonly;
            binds(Source, "name", txt_name, "Text");
            binds(Source, "location", txt_location, "Text");
            binds(Source, "ip_address", txt_ip, "Text");
            binds(Source, "port", txt_port, "Text", null, true);
            binds(Source, "is_active", chk_is_active, "Checked");

            binds(Source, "id", button3, "Tag", ()=> {
                button3.Visible = (Source as Models.Device).id > 0;
                return 0;
            }, true);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedDevice = new Models.Device();
            bindField(selectedDevice, false);
            //txt_name.DataBindings.Add()
            button2.Text = "ADD DEVICE";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selected = selectedDevice;

            //CHECK CONNECTION BEFORE ADDING
            if (selectedDevice.id > 0)
            {
                selectedDevice.Save();
                MessageBox.Show("Saved Successfully");
            }
            else
            {
                selectedDevice.Save();
                MessageBox.Show("Added Successfully");

            }
            this.load_list();
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (sender as DataGridView);
            if (dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index >= 0)
            {
                button2.Text = "SAVE DEVICE";
                selectedDevice = (dgv.SelectedRows[0].Tag as Models.Device).Clone() as Models.Device;
                bindField(selectedDevice);
            }
        }
        private void DeviceList_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            this.load_list();
            //dataGridView1_SelectionChanged(dataGridView1, null);

        }
        private void load_list()
        {
            dataGridView1.Rows.Clear();
            devices = StaticClasses.Devices.load_devices();

            foreach (Models.Device device in devices)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = device;
                device.bindRow = row;
                dataGridView1.Rows.Add(row);
            }

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                Models.Device device = row.Tag as Models.Device;
                row.SetValues(device.name, device.is_active);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.selectedDevice.Remove();
            this.load_list();
        }
    }
}
