namespace ReadSerialDataUsingThreading
{
    partial class Mainfrm
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
            this.components = new System.ComponentModel.Container();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtstopbits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdatabits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtparity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbaudrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtportname = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btnsend = new System.Windows.Forms.Button();
            this.txtreaddata = new System.Windows.Forms.RichTextBox();
            this.txtwritedata = new System.Windows.Forms.TextBox();
            this.Btnconnect = new System.Windows.Forms.Button();
            this.Btndisconnect = new System.Windows.Forms.Button();
            this.Btnedit = new System.Windows.Forms.Button();
            this.Btnsave = new System.Windows.Forms.Button();
            this.serialPortIn = new System.IO.Ports.SerialPort(this.components);
            this.buttonPlatformSelect = new System.Windows.Forms.Button();
            this.comboBoxPlatform = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gbConnection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.label5);
            this.gbConnection.Controls.Add(this.txtstopbits);
            this.gbConnection.Controls.Add(this.label4);
            this.gbConnection.Controls.Add(this.txtdatabits);
            this.gbConnection.Controls.Add(this.label3);
            this.gbConnection.Controls.Add(this.txtparity);
            this.gbConnection.Controls.Add(this.label2);
            this.gbConnection.Controls.Add(this.txtbaudrate);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.txtportname);
            this.gbConnection.Location = new System.Drawing.Point(22, 44);
            this.gbConnection.Margin = new System.Windows.Forms.Padding(4);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Padding = new System.Windows.Forms.Padding(4);
            this.gbConnection.Size = new System.Drawing.Size(296, 183);
            this.gbConnection.TabIndex = 0;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 160);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Stop Bits";
            // 
            // txtstopbits
            // 
            this.txtstopbits.FormattingEnabled = true;
            this.txtstopbits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.txtstopbits.Location = new System.Drawing.Point(104, 156);
            this.txtstopbits.Margin = new System.Windows.Forms.Padding(4);
            this.txtstopbits.Name = "txtstopbits";
            this.txtstopbits.Size = new System.Drawing.Size(173, 24);
            this.txtstopbits.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data Bits";
            // 
            // txtdatabits
            // 
            this.txtdatabits.FormattingEnabled = true;
            this.txtdatabits.Items.AddRange(new object[] {
            "8",
            "7"});
            this.txtdatabits.Location = new System.Drawing.Point(104, 123);
            this.txtdatabits.Margin = new System.Windows.Forms.Padding(4);
            this.txtdatabits.Name = "txtdatabits";
            this.txtdatabits.Size = new System.Drawing.Size(173, 24);
            this.txtdatabits.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Parity";
            // 
            // txtparity
            // 
            this.txtparity.FormattingEnabled = true;
            this.txtparity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.txtparity.Location = new System.Drawing.Point(104, 90);
            this.txtparity.Margin = new System.Windows.Forms.Padding(4);
            this.txtparity.Name = "txtparity";
            this.txtparity.Size = new System.Drawing.Size(173, 24);
            this.txtparity.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // txtbaudrate
            // 
            this.txtbaudrate.FormattingEnabled = true;
            this.txtbaudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "115200"});
            this.txtbaudrate.Location = new System.Drawing.Point(104, 57);
            this.txtbaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.txtbaudrate.Name = "txtbaudrate";
            this.txtbaudrate.Size = new System.Drawing.Size(173, 24);
            this.txtbaudrate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port Name";
            // 
            // txtportname
            // 
            this.txtportname.FormattingEnabled = true;
            this.txtportname.Location = new System.Drawing.Point(104, 23);
            this.txtportname.Margin = new System.Windows.Forms.Padding(4);
            this.txtportname.Name = "txtportname";
            this.txtportname.Size = new System.Drawing.Size(173, 24);
            this.txtportname.TabIndex = 3;
            this.txtportname.DropDown += new System.EventHandler(this.txtportname_DropDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btnsend);
            this.groupBox1.Controls.Add(this.txtreaddata);
            this.groupBox1.Controls.Add(this.txtwritedata);
            this.groupBox1.Location = new System.Drawing.Point(352, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(492, 300);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Monitor";
            // 
            // Btnsend
            // 
            this.Btnsend.Location = new System.Drawing.Point(384, 21);
            this.Btnsend.Margin = new System.Windows.Forms.Padding(4);
            this.Btnsend.Name = "Btnsend";
            this.Btnsend.Size = new System.Drawing.Size(100, 28);
            this.Btnsend.TabIndex = 15;
            this.Btnsend.Text = "Send";
            this.Btnsend.UseVisualStyleBackColor = true;
            this.Btnsend.Click += new System.EventHandler(this.Btnsend_Click);
            // 
            // txtreaddata
            // 
            this.txtreaddata.Location = new System.Drawing.Point(8, 57);
            this.txtreaddata.Margin = new System.Windows.Forms.Padding(4);
            this.txtreaddata.Name = "txtreaddata";
            this.txtreaddata.Size = new System.Drawing.Size(475, 229);
            this.txtreaddata.TabIndex = 1;
            this.txtreaddata.Text = "";
            // 
            // txtwritedata
            // 
            this.txtwritedata.Location = new System.Drawing.Point(8, 23);
            this.txtwritedata.Margin = new System.Windows.Forms.Padding(4);
            this.txtwritedata.Name = "txtwritedata";
            this.txtwritedata.Size = new System.Drawing.Size(367, 22);
            this.txtwritedata.TabIndex = 0;
            // 
            // Btnconnect
            // 
            this.Btnconnect.Location = new System.Drawing.Point(22, 294);
            this.Btnconnect.Margin = new System.Windows.Forms.Padding(4);
            this.Btnconnect.Name = "Btnconnect";
            this.Btnconnect.Size = new System.Drawing.Size(100, 28);
            this.Btnconnect.TabIndex = 2;
            this.Btnconnect.Text = "Connect";
            this.Btnconnect.UseVisualStyleBackColor = true;
            this.Btnconnect.Click += new System.EventHandler(this.Btnconnect_Click);
            // 
            // Btndisconnect
            // 
            this.Btndisconnect.Location = new System.Drawing.Point(163, 294);
            this.Btndisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.Btndisconnect.Name = "Btndisconnect";
            this.Btndisconnect.Size = new System.Drawing.Size(100, 28);
            this.Btndisconnect.TabIndex = 12;
            this.Btndisconnect.Text = "Disconnect";
            this.Btndisconnect.UseVisualStyleBackColor = true;
            this.Btndisconnect.Click += new System.EventHandler(this.Btndisconnect_Click);
            // 
            // Btnedit
            // 
            this.Btnedit.Location = new System.Drawing.Point(22, 248);
            this.Btnedit.Margin = new System.Windows.Forms.Padding(4);
            this.Btnedit.Name = "Btnedit";
            this.Btnedit.Size = new System.Drawing.Size(100, 28);
            this.Btnedit.TabIndex = 13;
            this.Btnedit.Text = "Edit";
            this.Btnedit.UseVisualStyleBackColor = true;
            this.Btnedit.Click += new System.EventHandler(this.Btnedit_Click);
            // 
            // Btnsave
            // 
            this.Btnsave.Location = new System.Drawing.Point(163, 248);
            this.Btnsave.Margin = new System.Windows.Forms.Padding(4);
            this.Btnsave.Name = "Btnsave";
            this.Btnsave.Size = new System.Drawing.Size(100, 28);
            this.Btnsave.TabIndex = 14;
            this.Btnsave.Text = "Save";
            this.Btnsave.UseVisualStyleBackColor = true;
            this.Btnsave.Click += new System.EventHandler(this.Btnsave_Click);
            // 
            // buttonPlatformSelect
            // 
            this.buttonPlatformSelect.Location = new System.Drawing.Point(182, 7);
            this.buttonPlatformSelect.Name = "buttonPlatformSelect";
            this.buttonPlatformSelect.Size = new System.Drawing.Size(81, 28);
            this.buttonPlatformSelect.TabIndex = 15;
            this.buttonPlatformSelect.Text = "Select";
            this.buttonPlatformSelect.UseVisualStyleBackColor = true;
            this.buttonPlatformSelect.Click += new System.EventHandler(this.buttonPlatformSelect_Click);
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Items.AddRange(new object[] {
            "AN",
            "AY",
            "UbootCommand",
            "Log"});
            this.comboBoxPlatform.Location = new System.Drawing.Point(12, 7);
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(140, 24);
            this.comboBoxPlatform.TabIndex = 16;
            this.comboBoxPlatform.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "USB Kontrol";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(471, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(109, 22);
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 351);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxPlatform);
            this.Controls.Add(this.buttonPlatformSelect);
            this.Controls.Add(this.Btnsave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btnedit);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.Btndisconnect);
            this.Controls.Add(this.Btnconnect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Mainfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerialPort";
            this.Load += new System.EventHandler(this.Mainfrm_Load);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtportname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtstopbits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtdatabits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtparity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtbaudrate;
        private System.Windows.Forms.Button Btnsave;
        private System.Windows.Forms.Button Btnedit;
        private System.Windows.Forms.Button Btndisconnect;
        private System.Windows.Forms.Button Btnconnect;
        private System.Windows.Forms.Button Btnsend;
        private System.Windows.Forms.RichTextBox txtreaddata;
        private System.Windows.Forms.TextBox txtwritedata;
        private System.IO.Ports.SerialPort serialPortIn;
        private System.Windows.Forms.Button buttonPlatformSelect;
        private System.Windows.Forms.ComboBox comboBoxPlatform;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

