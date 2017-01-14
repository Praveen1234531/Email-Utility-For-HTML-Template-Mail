using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emailUtility
{
    public partial class FrmUtility : Form
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(FrmUtility));
        private List<string> mailIds;
        public FrmUtility()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTemplateLoc.Text))
                wb.Navigate(txtTemplateLoc.Text);
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog { Filter = Helper.ExcelFilters };
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mailIds = null;
                    mailIds = new List<string>();
                    ExcelReader getExcelData =
                        new ExcelReader(openFileDialog.FileName);
                    var sheetName = getExcelData.WorkSheetNames[0];
                    var data = getExcelData.GetWorksheet(sheetName);
                    RegexUtilities util = new RegexUtilities();
                    foreach (DataRow dr in data.Rows)
                    {
                        foreach (DataColumn dc in data.Columns)
                        {
                            if (util.IsValidEmail(dr[dc.Ordinal].ToString()))
                                mailIds.Add(dr[dc.Ordinal].ToString());
                        }
                    }
                    lblinfo.Text = string.Format("Found Total : {0} ids , {1} is Correct", data.Rows.Count, mailIds.Count);
                    emailidlst.DataSource = null;
                    emailidlst.DataSource = mailIds;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                Smtpinfo.SenderEmailId = txtSender.Text;
                Smtpinfo.Password = txtPassword.Text;
                if (wb.Document == null)
                {
                    MessageBox.Show("Please Load Template");
                    return;
                }
                string mailText = wb.DocumentText.Replace("img/", txtTemplateLoc.Text + "img/");
                if (mailIds == null || mailIds.Count == 0)
                {
                    MessageBox.Show("Please Load Email ids");
                    return;
                }
                var tasks = new List<Task>();
                mailIds.ForEach(x =>
                {
                    tasks.Add(Task.Factory.StartNew(() => {
                        send(x, mailText);
                    }));
                });
                _log.Info("Mail Queue is created !!");
                Task.Factory.ContinueWhenAll(tasks.ToArray(), FinalWork);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private static void FinalWork(Task[] tasks)
        {
            if (tasks.All(t => t.Status == TaskStatus.RanToCompletion))
            {
                _log.Info("All Mail Send !!");
            }
        }
        public void send(string tomail, string mailText)
        {
            string status = string.Empty;
            Thread.Sleep(1000);
            Mailer.SmtpMailer(txtSender.Text, txtCompany.Text, tomail, "", txtSubject.Text, mailText, ref status);
            _log.Info(string.Format("Email Utility : Mail {0} on {1}", status, tomail));
        }

        private void FrmUtility_Load(object sender, EventArgs e)
        {

            XmlConfigurator.Configure();
            TextBoxAppender.ConfigureTextBoxAppender(txtLogger);
            Smtpinfo.initialize();
            txtSender.Text = Smtpinfo.SenderEmailId;
            txtPassword.Text = Smtpinfo.Password;
            _log.Info("Log Area ..");
            _log.InfoFormat("All Reply Comes On {0}",Smtpinfo.ReplyTo);
        }
    }
}
