#region using
using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using Negar.DbLayer;

#endregion

namespace Negar
{
    /// <summary>
    /// كلاس تبدیل فایل اكسل به داده دات نت
    /// </summary>
    class ExcelFileToDataSet
    {
        #region Fields
        private String _SheetName;
        private String _SourceFile;
        private OleDbConnection _OleDbConnection;
        private OleDbDataAdapter _OleDbDataAdapter;
        #endregion

        #region Properties

        #region String SheetName
        public String SheetName
        {
            get { return _SheetName; }
            set { _SheetName = value; }
        }
        #endregion

        #region String SourceFile
        public String SourceFile
        {
            get { return _SourceFile; }
            set { _SourceFile = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region Base

        #region public Boolean ConnectionOpen()
        /// <summary>
        /// تابع باز كردن ارتباط با فایل اكسل
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        public Boolean ConnectionOpen()
        {
            try
            {
                _OleDbConnection = new OleDbConnection("provider= Microsoft.ACE.OLEDB.12.0 " +
                                                       ";data Source =" + _SourceFile +
                                                       "; Extended Properties = \"Excel 12.0 Xml;HDR=YES\";");
                _OleDbConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("error" + e.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region public Boolean ConnectionOpen(String ConnectionString)
        public Boolean ConnectionOpen(String ConnectionString)
        {
            try
            {
                _OleDbConnection = new OleDbConnection("provider= Microsoft.ACE.OLEDB.12.0 " +
                                                       ";data Source =" +
                                                       ConnectionString + "; Extended Properties = \"Excel 12.0 Xml;HDR=YES\";");
                _OleDbConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("error" + e.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region public DataSet LoadFile()
        /// <summary>
        /// خواندن اطلاعات از اكسل
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        public DataSet LoadFile()
        {
            OleDbCommand ExcelOleDbCommand = new OleDbCommand("select * from ["
                                                              + _SheetName + "$]");
            ExcelOleDbCommand.Connection = _OleDbConnection;
            _OleDbDataAdapter = new OleDbDataAdapter();
            _OleDbDataAdapter.SelectCommand = ExcelOleDbCommand;

            DataSet TempDataSet = new DataSet();
            try
            {
                _OleDbDataAdapter.Fill(TempDataSet);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "خطا");
                return null;
            }
            return TempDataSet;
        }
        #endregion

        #region public DataSet LoadFile(String TheSheetName)
        /// <summary>
        /// خواندن اطلاعات از اكسل
        /// </summary>
        /// <param name="TheSheetName"></param>
        /// <returns>صحت انجام كار</returns>
        public DataSet LoadFile(String TheSheetName)
        {
            OleDbCommand ExcelOleDbCommand = new OleDbCommand("select * from ["
                                                              + TheSheetName + "$]");
            ExcelOleDbCommand.Connection = _OleDbConnection;
            _OleDbDataAdapter = new OleDbDataAdapter();
            _OleDbDataAdapter.SelectCommand = ExcelOleDbCommand;

            DataSet TempDataSet = new DataSet();
            try
            {
                _OleDbDataAdapter.Fill(TempDataSet);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "خطا");
                return null;
            }
            return TempDataSet;
        }
        #endregion

        #endregion

        #region Boolean Save(DataTable NewDataTable)
        /// <summary>
        /// پر كردن جدول اطلاعات 
        /// </summary>
        /// <param name="NewDataTable"></param>
        /// <returns>صحت انجام كار</returns>
        public Boolean Save(DataTable NewDataTable)
        {
            DbClassIS _DbClassIS = new DbClassIS
                  (@"Data Source=.\SQLDEVELOPER; Initial Catalog=ImagingSystem; UID = 'Sa'; PWD = 'sudnhdvhk';");
            for (Int32 i = 0; i < NewDataTable.Rows.Count; i++)
                try
                {
                    Int32 Price = 0;
                    if (NewDataTable.Rows[i][3] != null && NewDataTable.Rows[i][3] != DBNull.Value)
                        Price = Convert.ToInt32(NewDataTable.Rows[i][3]);
                    String Command = "INSERT INTO [ImagingSystem].[Services].[List] " +
                        "([Code] ,[Name] , [PriceFree] ,[PriceGov]) VALUES ('" + NewDataTable.Rows[i][0] + "' , '" +
                        NewDataTable.Rows[i][2] + "' , " + Price + " , " + Price + ")";
                    _DbClassIS.ExecuteCommand(Command);
                }
                #region Catch
                catch (Exception Ex)
                {
                    String ErrorMessage = "خطادر واردكردن اطلاعات جدول در بانك اطلاعات.\n" + Ex.Message;
                    MessageBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    return false;
                }
                #endregion
            return true;
        }
        #endregion

        #endregion

    }
}