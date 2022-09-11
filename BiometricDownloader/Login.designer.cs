namespace BiometricDownloader
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.thread_login = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // text_password
            // 
            this.text_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_usernane_KeyDown);
            // 
            // text_usernane
            // 
            this.text_usernane.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_usernane_KeyDown);
            // 
            // button1
            // 
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // thread_login
            // 
            this.thread_login.DoWork += new System.ComponentModel.DoWorkEventHandler(this.thread_login_DoWork);
            this.thread_login.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.thread_login_RunWorkerCompleted);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 223);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Login V2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker thread_login;
    }
}