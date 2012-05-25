#region using
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
#endregion

namespace CorrectFarsiFonts
{
    public partial class frmMainForm : Form
    {

        #region Fields

        #region SqlConnection _Connection
        /// <summary>
        /// شی اتصال به بانك اطلاعات تصویربرداری
        /// </summary>
        private readonly SqlConnection _Connection;
        #endregion

        #region StringBuilder _ReplaceQuery
        /// <summary>
        /// شی نگهدارنده متن دستور تصحیح
        /// </summary>
        private readonly StringBuilder _ReplaceQuery;
        #endregion

        #endregion

        #region Ctor
        public frmMainForm()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            _Connection = new SqlConnection(CSManager.GetConnectionString("Master"));
            _ReplaceQuery = new StringBuilder();
        }
        #endregion

        #region EventHandlers

        #region btnStart_Click
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            ProgressBar.Text = "در حال تصحیح...";
            ProgressBar.ProgressType = eProgressItemType.Marquee;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!ExecReplace()) e.Cancel = true;
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                PMBox.Show("فرایند تصحیح با موفقیت انجام نشد", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Close();
                return;
            }
            ProgressBar.Text = "";
            ProgressBar.ProgressType = eProgressItemType.Standard;
            btnStart.Enabled = true;
            BringToFront();
            Focus();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean ExecReplace()
        /// <summary>
        /// اجرای دستور تصحیح فونت های عربی به فارسی
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean ExecReplace()
        {
            SqlCommand MyCommand = new SqlCommand();
            MyCommand.Connection = _Connection;
            #region Prepare ExecReplace Query
            _ReplaceQuery.Append("DECLARE @C CURSOR ");
            _ReplaceQuery.Append("SET @C = CURSOR FOR ");
            _ReplaceQuery.Append("SELECT [TABLE_CATALOG] , [TABLE_SCHEMA] , [TABLE_NAME] , [COLUMN_NAME] ");
            _ReplaceQuery.Append("FROM [ImagingSystem].INFORMATION_SCHEMA.COLUMNS ");
            _ReplaceQuery.Append("WHERE DATA_TYPE = 'nvarchar' ");
            _ReplaceQuery.Append("UNION ALL ");
            _ReplaceQuery.Append("SELECT [TABLE_CATALOG] , [TABLE_SCHEMA] , [TABLE_NAME] , [COLUMN_NAME] ");
            _ReplaceQuery.Append("FROM [PatientsSystem].INFORMATION_SCHEMA.COLUMNS ");
            _ReplaceQuery.Append("WHERE DATA_TYPE = 'nvarchar' ");
            _ReplaceQuery.Append("OPEN @C ");
            _ReplaceQuery.Append("DECLARE @TABLECATALOG NVARCHAR(128) ");
            _ReplaceQuery.Append("DECLARE @TABLESCHEMA NVARCHAR(128) ");
            _ReplaceQuery.Append("DECLARE @TABLENAME NVARCHAR(128) ");
            _ReplaceQuery.Append("DECLARE @COLUMNNAME NVARCHAR(128) ");
            _ReplaceQuery.Append("WHILE @@FETCH_STATUS = 0 ");
            _ReplaceQuery.Append("BEGIN ");
            _ReplaceQuery.Append("FETCH NEXT FROM @C INTO @TABLECATALOG,@TABLESCHEMA,@TABLENAME,@COLUMNNAME ");
            _ReplaceQuery.Append("BEGIN TRY ");
            _ReplaceQuery.Append("EXEC ('UPDATE '+@TABLECATALOG+'.'+@TABLESCHEMA+'.'+@TABLENAME+");
            _ReplaceQuery.Append("' SET '+@COLUMNNAME+' = REPLACE('+@COLUMNNAME+' , N''ي'' , N''ی'')') ");
            _ReplaceQuery.Append("EXEC ('UPDATE '+@TABLECATALOG+'.'+@TABLESCHEMA+'.'+@TABLENAME+");
            _ReplaceQuery.Append("' SET '+@COLUMNNAME+' = REPLACE('+@COLUMNNAME+' , N''ك'' , N''ك'')') ");
            _ReplaceQuery.Append("END TRY ");
            _ReplaceQuery.Append("BEGIN CATCH ");
            _ReplaceQuery.Append("END CATCH ");
            _ReplaceQuery.Append("END ");
            _ReplaceQuery.Append("CLOSE @C ");
            _ReplaceQuery.Append("DEALLOCATE @C ");
            #endregion
            MyCommand.CommandText = _ReplaceQuery.ToString();
            try
            {
                MyCommand.Connection.Open();
                MyCommand.ExecuteReader();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن اطلاعات از بانك اطلاعاتی وجود ندارد !" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا !"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry(Ex.Message + "\n" + Ex.StackTrace, "Error",
                    "Farsi.Character.Correction", EventLogEntryType.Error);
                return false;
            }
            finally { MyCommand.Connection.Close(); }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}