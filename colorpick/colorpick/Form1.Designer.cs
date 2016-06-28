namespace colorpick
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btligar = new System.Windows.Forms.Button();
            this.cbcom = new System.Windows.Forms.ComboBox();
            this.btred = new System.Windows.Forms.Button();
            this.btgreen = new System.Windows.Forms.Button();
            this.btblue = new System.Windows.Forms.Button();
            this.btrgb = new System.Windows.Forms.Button();
            this.timerCOM = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lbred = new System.Windows.Forms.Label();
            this.lbgreen = new System.Windows.Forms.Label();
            this.lbblue = new System.Windows.Forms.Label();
            this.viewcolor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbrx = new System.Windows.Forms.Label();
            this.lbrx2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btligar
            // 
            this.btligar.Location = new System.Drawing.Point(12, 12);
            this.btligar.Name = "btligar";
            this.btligar.Size = new System.Drawing.Size(90, 90);
            this.btligar.TabIndex = 0;
            this.btligar.Text = "Ligar ";
            this.btligar.UseVisualStyleBackColor = true;
            this.btligar.Click += new System.EventHandler(this.btligar_Click);
            // 
            // cbcom
            // 
            this.cbcom.FormattingEnabled = true;
            this.cbcom.Location = new System.Drawing.Point(108, 12);
            this.cbcom.Name = "cbcom";
            this.cbcom.Size = new System.Drawing.Size(121, 21);
            this.cbcom.TabIndex = 1;
            // 
            // btred
            // 
            this.btred.Location = new System.Drawing.Point(12, 109);
            this.btred.Name = "btred";
            this.btred.Size = new System.Drawing.Size(90, 90);
            this.btred.TabIndex = 2;
            this.btred.Text = "Red";
            this.btred.UseVisualStyleBackColor = true;
            this.btred.Click += new System.EventHandler(this.btred_Click);
            // 
            // btgreen
            // 
            this.btgreen.Location = new System.Drawing.Point(108, 109);
            this.btgreen.Name = "btgreen";
            this.btgreen.Size = new System.Drawing.Size(90, 90);
            this.btgreen.TabIndex = 3;
            this.btgreen.Text = "Green";
            this.btgreen.UseVisualStyleBackColor = true;
            this.btgreen.Click += new System.EventHandler(this.btgreen_Click);
            // 
            // btblue
            // 
            this.btblue.Location = new System.Drawing.Point(12, 209);
            this.btblue.Name = "btblue";
            this.btblue.Size = new System.Drawing.Size(90, 90);
            this.btblue.TabIndex = 4;
            this.btblue.Text = "Blue";
            this.btblue.UseVisualStyleBackColor = true;
            this.btblue.Click += new System.EventHandler(this.btblue_Click);
            // 
            // btrgb
            // 
            this.btrgb.Location = new System.Drawing.Point(108, 209);
            this.btrgb.Name = "btrgb";
            this.btrgb.Size = new System.Drawing.Size(90, 90);
            this.btrgb.TabIndex = 5;
            this.btrgb.Text = "RGB";
            this.btrgb.UseVisualStyleBackColor = true;
            this.btrgb.Click += new System.EventHandler(this.btrgb_Click);
            // 
            // timerCOM
            // 
            this.timerCOM.Enabled = true;
            this.timerCOM.Interval = 1000;
            this.timerCOM.Tick += new System.EventHandler(this.timerCOM_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // lbred
            // 
            this.lbred.AutoSize = true;
            this.lbred.Location = new System.Drawing.Point(283, 15);
            this.lbred.Name = "lbred";
            this.lbred.Size = new System.Drawing.Size(13, 13);
            this.lbred.TabIndex = 7;
            this.lbred.Text = "0";
            // 
            // lbgreen
            // 
            this.lbgreen.AutoSize = true;
            this.lbgreen.Location = new System.Drawing.Point(283, 51);
            this.lbgreen.Name = "lbgreen";
            this.lbgreen.Size = new System.Drawing.Size(13, 13);
            this.lbgreen.TabIndex = 8;
            this.lbgreen.Text = "0";
            // 
            // lbblue
            // 
            this.lbblue.AutoSize = true;
            this.lbblue.Location = new System.Drawing.Point(283, 89);
            this.lbblue.Name = "lbblue";
            this.lbblue.Size = new System.Drawing.Size(13, 13);
            this.lbblue.TabIndex = 9;
            this.lbblue.Text = "0";
            // 
            // viewcolor
            // 
            this.viewcolor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.viewcolor.Location = new System.Drawing.Point(215, 109);
            this.viewcolor.Name = "viewcolor";
            this.viewcolor.Size = new System.Drawing.Size(224, 190);
            this.viewcolor.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "RED:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "GREEN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "BLUE:";
            // 
            // lbrx
            // 
            this.lbrx.AutoSize = true;
            this.lbrx.Location = new System.Drawing.Point(108, 50);
            this.lbrx.Name = "lbrx";
            this.lbrx.Size = new System.Drawing.Size(25, 13);
            this.lbrx.TabIndex = 14;
            this.lbrx.Text = "RX:";
            // 
            // lbrx2
            // 
            this.lbrx2.AutoSize = true;
            this.lbrx2.Location = new System.Drawing.Point(139, 50);
            this.lbrx2.Name = "lbrx2";
            this.lbrx2.Size = new System.Drawing.Size(0, 13);
            this.lbrx2.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 311);
            this.Controls.Add(this.lbrx2);
            this.Controls.Add(this.lbrx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewcolor);
            this.Controls.Add(this.lbblue);
            this.Controls.Add(this.lbgreen);
            this.Controls.Add(this.lbred);
            this.Controls.Add(this.btrgb);
            this.Controls.Add(this.btblue);
            this.Controls.Add(this.btgreen);
            this.Controls.Add(this.btred);
            this.Controls.Add(this.cbcom);
            this.Controls.Add(this.btligar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Color Pick";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btligar;
        private System.Windows.Forms.ComboBox cbcom;
        private System.Windows.Forms.Button btred;
        private System.Windows.Forms.Button btgreen;
        private System.Windows.Forms.Button btblue;
        private System.Windows.Forms.Button btrgb;
        private System.Windows.Forms.Timer timerCOM;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lbred;
        private System.Windows.Forms.Label lbgreen;
        private System.Windows.Forms.Label lbblue;
        private System.Windows.Forms.Panel viewcolor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbrx;
        private System.Windows.Forms.Label lbrx2;
    }
}

