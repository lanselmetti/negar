#region using
using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negar;
#endregion

namespace Negar
{
    /// <summary>
    /// فرم نمایش خصوصیات بیمه ها
    /// </summary>
    internal partial class frmReadfile : Office2007Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmReadfile()
        {
            InitializeComponent();
            txtPath.Text = Application.StartupPath + "\\Aftab IMS Service List.xls";
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region btnSelectPath_Click
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            PpenFileDialogForm.Filter = "فایل اكسل 2003|*.xls";
            DialogResult Result = PpenFileDialogForm.ShowDialog();
            if (Result != DialogResult.OK) return;
            txtPath.Text = PpenFileDialogForm.FileName;
        }
        #endregion

        #region btnReadData_Click
        private void btnReadData_Click(object sender, EventArgs e)
        {
            ExcelFileToDataSet ExcelToGridObject = new ExcelFileToDataSet();
            ExcelToGridObject.SourceFile = txtPath.Text.Trim();
            ExcelToGridObject.SheetName = "رادیولوژی";
            ExcelToGridObject.ConnectionOpen();
            DataSet TempDataSet = ExcelToGridObject.LoadFile();
            if (TempDataSet == null) return;
            for (Int32 i = TempDataSet.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                Boolean HaveValue = false;
                foreach (Object Value in TempDataSet.Tables[0].Rows[i].ItemArray)
                    if (Value != null && Value != DBNull.Value)
                    {
                        HaveValue = true;
                        break;
                    }
                if (!HaveValue) TempDataSet.Tables[0].Rows.RemoveAt(i);
            }
            DgvData.DataSource = TempDataSet.Tables[0];
        }
        #endregion

        #region btnSaveDataInDb_Click
        private void btnSaveDataInDb_Click(object sender, EventArgs e)
        {
            ExcelFileToDataSet ExcelToGridObject = new ExcelFileToDataSet();
            ExcelToGridObject.Save((DataTable)DgvData.DataSource);
        }
        #endregion

        #region void btnCancel_Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #endregion

    }
}