namespace emailUtility
{
    partial class FrmUtility
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
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.emailidlst = new System.Windows.Forms.ListBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTemplateLoc = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblinfo = new System.Windows.Forms.Label();
            this.txtLogger = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(1, 2);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(27, 30);
            this.btnLoadExcel.TabIndex = 0;
            this.btnLoadExcel.Text = "+";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // emailidlst
            // 
            this.emailidlst.FormattingEnabled = true;
            this.emailidlst.Location = new System.Drawing.Point(1, 39);
            this.emailidlst.Name = "emailidlst";
            this.emailidlst.Size = new System.Drawing.Size(160, 446);
            this.emailidlst.TabIndex = 1;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(246, 39);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(413, 20);
            this.txtSubject.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sender Mail Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subject";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(579, 9);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(75, 23);
            this.btnSendMail.TabIndex = 7;
            this.btnSendMail.Text = "Send";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // wb
            // 
            this.wb.Location = new System.Drawing.Point(167, 135);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(492, 350);
            this.wb.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Template URL";
            // 
            // txtTemplateLoc
            // 
            this.txtTemplateLoc.Location = new System.Drawing.Point(246, 109);
            this.txtTemplateLoc.Name = "txtTemplateLoc";
            this.txtTemplateLoc.Size = new System.Drawing.Size(327, 20);
            this.txtTemplateLoc.TabIndex = 10;
            this.txtTemplateLoc.Text = "http://dselva.co.in/campaign/welcome-Mailer/";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(611, 107);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(43, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(116, 9);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(165, 20);
            this.txtSender.TabIndex = 12;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(346, 8);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(227, 20);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Sender Name";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(248, 65);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(413, 20);
            this.txtCompany.TabIndex = 14;
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo.Location = new System.Drawing.Point(169, 90);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(0, 13);
            this.lblinfo.TabIndex = 16;
            // 
            // txtLogger
            // 
            this.txtLogger.Location = new System.Drawing.Point(664, 8);
            this.txtLogger.Multiline = true;
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.ReadOnly = true;
            this.txtLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogger.Size = new System.Drawing.Size(276, 466);
            this.txtLogger.TabIndex = 17;
            // 
            // FrmUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 486);
            this.Controls.Add(this.txtLogger);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtTemplateLoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.emailidlst);
            this.Controls.Add(this.btnLoadExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmUtility";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Email Utility";
            this.Load += new System.EventHandler(this.FrmUtility_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.ListBox emailidlst;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTemplateLoc;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.TextBox txtLogger;
    }
}

