namespace Client_remake
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Adrress = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nUD_Port = new System.Windows.Forms.NumericUpDown();
            this.bConnect = new System.Windows.Forms.Button();
            this.bSend = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Port)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adrress: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(737, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port: ";
            // 
            // tb_Adrress
            // 
            this.tb_Adrress.Location = new System.Drawing.Point(215, 72);
            this.tb_Adrress.Name = "tb_Adrress";
            this.tb_Adrress.Size = new System.Drawing.Size(227, 29);
            this.tb_Adrress.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(176, 667);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(796, 29);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Write message...";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // nUD_Port
            // 
            this.nUD_Port.Location = new System.Drawing.Point(901, 76);
            this.nUD_Port.Name = "nUD_Port";
            this.nUD_Port.Size = new System.Drawing.Size(202, 29);
            this.nUD_Port.TabIndex = 4;
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(75, 226);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(367, 43);
            this.bConnect.TabIndex = 5;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(390, 750);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(357, 43);
            this.bSend.TabIndex = 6;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(176, 334);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(795, 292);
            this.listBox1.TabIndex = 7;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(742, 226);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(361, 43);
            this.bStop.TabIndex = 8;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password: ";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(215, 141);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(227, 29);
            this.tb_password.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(737, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Set nickname: ";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(901, 145);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(227, 29);
            this.tb_name.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 873);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.nUD_Port);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tb_Adrress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Adrress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown nUD_Port;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name;
    }
}

