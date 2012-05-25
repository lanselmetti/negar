#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Aftab;
#endregion

namespace Sepehr.Forms
{
    /// <summary>
    /// فرم مدیریت اطلاعات دیسكت
    /// </summary>
    internal partial class frmMainForm : Form
    {

        #region Fields

        #region String _FolderPath
        private String _FolderPath;
        #endregion

        #region List<Int32> _DocList
        private List<Int32> _DocList;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Activate();
            Focus();
            BringToFront();
        }
        #endregion

        #region btnSelectBankPath_Click
        private void btnSelectBankPath_Click(object sender, EventArgs e)
        {
            ofdAccess.FileName = txtFolderPath.Text;
            DialogResult Result = ofdAccess.ShowDialog();
            if (Result != DialogResult.OK) return;
            txtFolderPath.Text = ofdAccess.FileName;
        }
        #endregion

        #region btnMakeReport_Click
        /// <summary>
        /// رویداد كلیك بر روی دكمه نمایش اطلاعات
        /// </summary>
        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            #region User Data Validation
            if (txtFolderPath.Text[txtFolderPath.Text.Length - 1] != '\\') txtFolderPath.Text += "\\";
            if (!Directory.Exists(txtFolderPath.Text))
            {
                DialogResult result = PMBox.Show(
                    "پوشه انتخاب شده وجود ندارد. آیا مایلید پوشه ساخته شود؟", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes) Directory.CreateDirectory(txtFolderPath.Text);
                else return;
            }
            #endregion
            btnRegister.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            _FolderPath = txtFolderPath.Text.Trim();
            _DocList = DBLayerIMS.Manager.DBML.RefDocuments.Select(Data => Data.ID).ToList();
            pBar.Maximum = _DocList.Count;
            pBar.Value = 0;
            pBar.Text = "تعداد موارد: " + pBar.Maximum;
            BGWorkerSearchData.RunWorkerAsync();
        }
        #endregion

        #region BGWorkerSearchData_DoWork
        private void BGWorkerSearchData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (Int32 i = 0; i < _DocList.Count; i++)
                {
                    Binary document = DBLayerIMS.Manager.DBML.RefDocuments.
                        Where(Data => Data.ID == _DocList[i]).Select(Data => Data.ReportData).First();
                    String FolderPath = _FolderPath + ((_DocList[i] / 1000) + 1);
                    if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);
                    File.WriteAllBytes(FolderPath + "\\" + _DocList[i] + ".zip", document.ToArray());
                    BGWorkerSearchData.ReportProgress(1);
                }
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("خطا در ثبت اطلاعات.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Document Update", Ex.Message, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region BGWorkerSearchData_ProgressChanged
        private void BGWorkerSearchData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Value += 1;
            pBar.Text = pBar.Value + " items from " + pBar.Maximum + " has transfered.";
        }
        #endregion

        #region BGWorkerSearchData_RunWorkerCompleted
        private void BGWorkerSearchData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PMBox.Show("انتقال با موفقیت پایان یافت!", "تبریك!");
            Cursor.Current = Cursors.Default;
            btnRegister.Enabled = true;
            if (e.Cancelled) return;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید از برنامه خارج شوید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) { e.Cancel = true; return; }
            Dispose();
        }
        #endregion

        #endregion

    }
}