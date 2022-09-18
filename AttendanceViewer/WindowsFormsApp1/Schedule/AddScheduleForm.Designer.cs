namespace DTRAttendance.Schedule
{
    partial class AddScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_schedule_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.time_am_in = new System.Windows.Forms.DateTimePicker();
            this.time_am_out = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.time_pm_out = new System.Windows.Forms.DateTimePicker();
            this.time_pm_in = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_schedule_name
            // 
            this.txt_schedule_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_schedule_name.Location = new System.Drawing.Point(12, 32);
            this.txt_schedule_name.Name = "txt_schedule_name";
            this.txt_schedule_name.Size = new System.Drawing.Size(248, 20);
            this.txt_schedule_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.time_am_out);
            this.groupBox1.Controls.Add(this.time_am_in);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 43);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AM";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "IN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "OUT";
            // 
            // time_am_in
            // 
            this.time_am_in.CustomFormat = "hh:mm tt";
            this.time_am_in.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_am_in.Location = new System.Drawing.Point(30, 13);
            this.time_am_in.Name = "time_am_in";
            this.time_am_in.ShowUpDown = true;
            this.time_am_in.Size = new System.Drawing.Size(72, 20);
            this.time_am_in.TabIndex = 2;
            this.time_am_in.Value = new System.DateTime(2022, 9, 18, 8, 0, 0, 0);
            // 
            // time_am_out
            // 
            this.time_am_out.CustomFormat = "hh:mm tt";
            this.time_am_out.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_am_out.Location = new System.Drawing.Point(159, 13);
            this.time_am_out.Name = "time_am_out";
            this.time_am_out.ShowUpDown = true;
            this.time_am_out.Size = new System.Drawing.Size(84, 20);
            this.time_am_out.TabIndex = 4;
            this.time_am_out.Value = new System.DateTime(2022, 9, 18, 12, 0, 0, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.time_pm_out);
            this.groupBox2.Controls.Add(this.time_pm_in);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 43);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PM";
            // 
            // time_pm_out
            // 
            this.time_pm_out.CustomFormat = "hh:mm tt";
            this.time_pm_out.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_pm_out.Location = new System.Drawing.Point(159, 13);
            this.time_pm_out.Name = "time_pm_out";
            this.time_pm_out.ShowUpDown = true;
            this.time_pm_out.Size = new System.Drawing.Size(84, 20);
            this.time_pm_out.TabIndex = 4;
            this.time_pm_out.Value = new System.DateTime(2022, 9, 18, 17, 0, 0, 0);
            // 
            // time_pm_in
            // 
            this.time_pm_in.CustomFormat = "hh:mm tt";
            this.time_pm_in.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_pm_in.Location = new System.Drawing.Point(30, 13);
            this.time_pm_in.Name = "time_pm_in";
            this.time_pm_in.ShowUpDown = true;
            this.time_pm_in.Size = new System.Drawing.Size(72, 20);
            this.time_pm_in.TabIndex = 2;
            this.time_pm_in.Value = new System.DateTime(2022, 9, 18, 13, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "OUT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "IN";
            // 
            // AddScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 202);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_schedule_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddScheduleForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_schedule_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker time_am_out;
        private System.Windows.Forms.DateTimePicker time_am_in;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker time_pm_out;
        private System.Windows.Forms.DateTimePicker time_pm_in;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}