namespace Server
{
    partial class Form1
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
            this.lb_adrress = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.nUDPort = new System.Windows.Forms.NumericUpDown();
            this.tbHostAddress = new System.Windows.Forms.TextBox();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.ListBox();
            this.bSend = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_adrress
            // 
            this.lb_adrress.AutoSize = true;
            this.lb_adrress.Location = new System.Drawing.Point(72, 78);
            this.lb_adrress.Name = "lb_adrress";
            this.lb_adrress.Size = new System.Drawing.Size(91, 25);
            this.lb_adrress.TabIndex = 0;
            this.lb_adrress.Text = "Adrress: ";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(637, 78);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(58, 25);
            this.lb_port.TabIndex = 1;
            this.lb_port.Text = "Port: ";
            // 
            // nUDPort
            // 
            this.nUDPort.Location = new System.Drawing.Point(777, 78);
            this.nUDPort.Name = "nUDPort";
            this.nUDPort.Size = new System.Drawing.Size(169, 29);
            this.nUDPort.TabIndex = 2;
            // 
            // tbHostAddress
            // 
            this.tbHostAddress.Location = new System.Drawing.Point(227, 77);
            this.tbHostAddress.Name = "tbHostAddress";
            this.tbHostAddress.Size = new System.Drawing.Size(214, 29);
            this.tbHostAddress.TabIndex = 3;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(124, 734);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(206, 46);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click_1);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(762, 734);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(201, 46);
            this.bStop.TabIndex = 6;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.FormattingEnabled = true;
            this.lbMessage.ItemHeight = 24;
            this.lbMessage.Location = new System.Drawing.Point(124, 265);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(839, 436);
            this.lbMessage.TabIndex = 7;
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(332, 1030);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(377, 52);
            this.bSend.TabIndex = 8;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.ForeColor = System.Drawing.Color.Gray;
            this.TextBox1.Location = new System.Drawing.Point(129, 965);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(834, 29);
            this.TextBox1.TabIndex = 9;
            this.TextBox1.Text = "Send message...";
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.TextBox1.Enter += new System.EventHandler(this.TextBox1_Enter);
            this.TextBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 24;
            this.ListBox1.Location = new System.Drawing.Point(129, 829);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(834, 100);
            this.ListBox1.TabIndex = 10;
            // 
            // tb_password
            // 
            this.tb_password.ForeColor = System.Drawing.Color.Gray;
            this.tb_password.Location = new System.Drawing.Point(227, 157);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(214, 29);
            this.tb_password.TabIndex = 11;
            this.tb_password.Text = "(Optional)";
            this.tb_password.Enter += new System.EventHandler(this.tb_password_Enter);
            this.tb_password.Leave += new System.EventHandler(this.tb_password_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Password:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 1157);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.tbHostAddress);
            this.Controls.Add(this.nUDPort);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.lb_adrress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_adrress;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.NumericUpDown nUDPort;
        private System.Windows.Forms.TextBox tbHostAddress;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.ListBox lbMessage;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label1;
    }
}

