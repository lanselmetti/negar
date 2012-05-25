#region using
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Negar;
#endregion

namespace NamesBankManager
{
    public partial class MainForm : Form
    {

        #region Fields

        #region SqlConnection _SqlConnection
        /// <summary>
        /// شی اتصال به بانك اطلاعات تصویربرداری
        /// </summary>
        private readonly SqlConnection _SqlConnection;
        #endregion

        #region StringBuilder _ReplaceQuery
        /// <summary>
        /// شی نگهدارنده متن دستور تصحیح
        /// </summary>
        private StringBuilder _ReplaceQuery;
        #endregion

        #region DataTable _MyDataTable
        private DataTable _MyDataTable;
        #endregion

        #region String _ImportFilePath
        private String _ImportFilePath;
        #endregion

        #region String _ExportFilePath
        private String _ExportFilePath;
        #endregion

        #region Int32 _RowsCount
        /// <summary>
        /// نگهدارنده تعداد سطر های برگشتی گزارش
        /// </summary>
        private Int32 _RowsCount;
        #endregion

        #endregion

        #region Ctor
        public MainForm()
        {
            InitializeComponent();
            CSManager.CurrentSetting = "اتصال به سرور محلی";
            String CS = CSManager.GetConnectionString("PatientsSystem");
            _SqlConnection = new SqlConnection(CS);
        }
        #endregion

        #region Event Handlers

        #region btnImport_Click
        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            DialogResult Result = openFileDialog.ShowDialog();
            if (Result != DialogResult.OK) return;
            _ImportFilePath = openFileDialog.FileName;
            _MyDataTable = new DataTable("Table1");
            _MyDataTable.Columns.Add("LocaleName", typeof(String));
            _MyDataTable.Columns.Add("EnglishName", typeof(String));
            _MyDataTable.Columns.Add("IsFirstName", typeof(Boolean));
            try { _MyDataTable.ReadXml(_ImportFilePath); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "خواندن اطلاعات از فایل ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Ex.Message); return;
            }
            #endregion
            _RowsCount = _MyDataTable.Rows.Count;
            progressBar.Maximum = _RowsCount;
            btnRead.Enabled = false;
            btnWrite.Enabled = false;
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region btnExport_Click
        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            DialogResult Result = saveFileDialog.ShowDialog();
            if (Result != DialogResult.OK) return;
            _ExportFilePath = saveFileDialog.FileName;
            btnRead.Enabled = false;
            btnWrite.Enabled = false;
            _MyDataTable = new DataTable("Table1");
            _MyDataTable.Columns.Add("LocaleName", typeof(String));
            _MyDataTable.Columns.Add("EnglishName", typeof(String));
            _MyDataTable.Columns.Add("IsFirstName", typeof(Boolean));
            SqlCommand MyCommand = new SqlCommand();
            try
            {
                _ReplaceQuery = new StringBuilder();
                MyCommand.Connection = _SqlConnection;
                _ReplaceQuery.Append("SELECT * FROM [PatientsSystem].[Patients].[NamesBank];");
                MyCommand.CommandText = _ReplaceQuery.ToString();
                MyCommand.Connection.Open();
                // ReSharper disable AssignNullToNotNullAttribute
                _MyDataTable.Load(MyCommand.ExecuteReader());
                // ReSharper restore AssignNullToNotNullAttribute
                _MyDataTable.WriteXml(_ExportFilePath);
            }
            #region Catch
            catch (Exception)
            {
                PMBox.Show("امكان ذخیره اطلاعات از بانك اطلاعاتی وجود ندارد !" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا !"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            finally
            {
                btnRead.Enabled = true;
                btnWrite.Enabled = true;
                MyCommand.Connection.Close();
            }
            #endregion
            PMBox.Show("انتقال اطلاعات با موفقیت انجام شد!", "تبریك", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!ImportFromFile()) { e.Cancel = true; return; }
        }
        #endregion

        #region BGWorker_ProgressChanged
        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblProgress.Text = "ردیف: " + e.ProgressPercentage + " از " + _RowsCount;
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRead.Enabled = true;
            btnWrite.Enabled = true;
            if (!e.Cancelled)
                PMBox.Show("انتقال اطلاعات با موفقیت انجام شد!", "تبریك", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else PMBox.Show("انتقال اطلاعات با موفقیت انجام نشد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean ImportFromFile()
        private Boolean ImportFromFile()
        {
            for (Int32 i = 0; i < _MyDataTable.Rows.Count; i++)
            {
                String LocaleName = _MyDataTable.Rows[i]["LocaleName"].ToString().Normalize();
                if (LocaleName.Length > 29) LocaleName = LocaleName.Substring(0, 30);
                String EnglishName = _MyDataTable.Rows[i]["EnglishName"].ToString().Normalize();
                if (EnglishName.Length > 29) EnglishName = EnglishName.Substring(0, 30);
                if (EnglishName.Contains("'")) EnglishName = EnglishName.Replace("'", "");
                if (!String.IsNullOrEmpty(LocaleName) && !String.IsNullOrEmpty(EnglishName))
                { if (!InsertRowToDb(LocaleName, EnglishName, Convert.ToBoolean(_MyDataTable.Rows[i]["IsFirstName"]))) return false; }
                BGWorker.ReportProgress(i + 1);
            }
            return true;
        }
        #endregion

        #region Boolean InsertRowToDb(String LocaleName, String EnglishName, Boolean IsFirstName)
        private Boolean InsertRowToDb(String LocaleName, String EnglishName, Boolean IsFirstName)
        {
            SqlCommand MyCommand = new SqlCommand();
            _ReplaceQuery = new StringBuilder();
            MyCommand.Connection = _SqlConnection;
            #region Prepare ExecReplace Query
            _ReplaceQuery.Append("DECLARE @LocaleName NVARCHAR(50) ");
            _ReplaceQuery.Append("DECLARE @EnglishName NVARCHAR(50) ");
            _ReplaceQuery.Append("DECLARE @IsFirstName BIT ");
            _ReplaceQuery.Append("SET @LocaleName = N'" + LocaleName + "' ");
            _ReplaceQuery.Append("SET @EnglishName = '" + EnglishName + "' ");
            _ReplaceQuery.Append("SET @IsFirstName = '" + IsFirstName + "' ");
            _ReplaceQuery.Append("IF EXISTS(SELECT [LocaleName] FROM [PatientsSystem].[Patients].[NamesBank] ");
            _ReplaceQuery.Append("WHERE [LocaleName] = @LocaleName AND [IsFirstName] = @IsFirstName) ");
            _ReplaceQuery.Append("BEGIN ");
            _ReplaceQuery.Append("IF EXISTS ( SELECT [LocaleName] FROM [PatientsSystem].[Patients].[NamesBank] ");
            _ReplaceQuery.Append("WHERE [LocaleName] = @LocaleName AND [IsFirstName] =@IsFirstName ");
            _ReplaceQuery.Append("AND ([EnglishName] IS NULL OR [EnglishName]  = '')) ");
            _ReplaceQuery.Append("UPDATE [PatientsSystem].[Patients].[NamesBank] ");
            _ReplaceQuery.Append("SET [EnglishName] = @EnglishName WHERE [LocaleName] = @LocaleName; ");
            _ReplaceQuery.Append("END ");
            _ReplaceQuery.Append("ELSE INSERT INTO [PatientsSystem].[Patients].[NamesBank] ");
            _ReplaceQuery.Append("([LocaleName] ,[EnglishName] ,[IsFirstName]) VALUES (@LocaleName, @EnglishName ,@IsFirstName) ");
            #endregion
            MyCommand.CommandText = _ReplaceQuery.ToString();
            try
            {
                MyCommand.Connection.Open();
                MyCommand.ExecuteNonQuery();
            }
            #region Catch
            catch (Exception Ex)
            {
                PMBox.Show("امكان خواندن اطلاعات از بانك اطلاعاتی وجود ندارد!\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟.\n" +
                    "2. آیا سرور در وضعیت متعادلی است و شبكه دارای ترافیك بالا نیست؟.", "خطا!"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(Ex.Message); return false;
            }
            finally { MyCommand.Connection.Close(); }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}