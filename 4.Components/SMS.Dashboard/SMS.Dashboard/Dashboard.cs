#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar.Controls;
using Sepehr.DBLayerIMS.DataLayer;
#endregion

namespace Sepehr.SMSSender
{
    /// <summary>
    /// فرم اصلی مدیریت ارسال پیام به مقاصد
    /// </summary>
    public partial class frmDashboard : Form
    {

        #region Ctor
        public frmDashboard()
        {
            InitializeComponent();
            if (!FillFormDataSource()) { Close(); return; }
            dgvQueue.AutoGenerateColumns = false;
            dgvSents.AutoGenerateColumns = false;
            dgvFaileds.AutoGenerateColumns = false;
            dgvSelectPatients.AutoGenerateColumns = false;
            dgvSearchSentPatients.AutoGenerateColumns = false;
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region MainForm_Shown
        private void MainForm_Shown(object sender, EventArgs e)
        {
            btnRefreshToday_Click(null, null);
            cboTemplates.SelectedIndex = 0;
            FromDateRef1.SelectedDateTime = DateTime.Now;
            FromDateRef2.SelectedDateTime = DateTime.Now;
            ToDateRef1.SelectedDateTime = DateTime.Now;
            ToDateRef2.SelectedDateTime = DateTime.Now;
        }
        #endregion

        #region btnRefreshToday_Click
        private void btnRefreshToday_Click(object sender, EventArgs e)
        {
            dgvQueue.DataSource = Negar.DBLayerPMS.SMS.GetQueueList();
            dgvSents.DataSource = Negar.DBLayerPMS.SMS.GetTodaySucceedMessages();
            dgvFaileds.DataSource = Negar.DBLayerPMS.SMS.GetTodayFailedMessages();
            lblCount1.Text = "تعداد: " + dgvQueue.Rows.Count;
            lblCount2.Text = "تعداد: " + dgvSents.Rows.Count;
            lblCount3.Text = "تعداد: " + dgvFaileds.Rows.Count;
        }
        #endregion

        #region dgvToday_CellFormatting
        private void dgvToday_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                Int64 MessageID = 0;
                if (sender.Equals(dgvQueue))
                    MessageID = ((SendQueue)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).MessageIX;
                else if (sender.Equals(dgvSents))
                    MessageID = ((SendSucceed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).MessageIX;
                else if (sender.Equals(dgvFaileds))
                    MessageID = ((SendFailed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).MessageIX;

                if (e.ColumnIndex == ColQueueRecieverNum.Index)
                    e.Value = Negar.DBLayerPMS.Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == MessageID).First().RecieverNumber;
                else if (e.ColumnIndex == ColQueueMessage.Index)
                    e.Value = Negar.DBLayerPMS.Manager.DBML.SMSMessages.
                        Where(Data => Data.ID == MessageID).First().MessageText;
                else if (e.ColumnIndex == ColQueueSendDateTime.Index)
                {
                    DateTime? EnDateTime = null;
                    if (sender.Equals(dgvQueue))
                        EnDateTime = ((SendQueue)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    else if (sender.Equals(dgvSents))
                        EnDateTime = ((SendSucceed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    else if (sender.Equals(dgvFaileds))
                        EnDateTime = ((SendFailed)((DataGridViewX)sender).Rows[e.RowIndex].DataBoundItem).SendDateTime;
                    if (EnDateTime == null) return;
                    PersianDate PDate = EnDateTime.Value.ToPersianDate();
                    e.Value = PDate.Year + "/" + PDate.Month + "/" + PDate.Day + "-" +
                        PDate.Hour + ":" + PDate.Minute + ":" + PDate.Second;
                }
            }
            catch { }
        }
        #endregion

        #region btnRetryFaileds_Click
        private void btnRetryFaileds_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFaileds.Rows)
                Negar.DBLayerPMS.SMS.AddMessageToSendQueueFromFailedMessages(((SendFailed)row.DataBoundItem).ID);
            dgvFaileds.DataSource = null;
        }
        #endregion

        #region btnSearchSentMessages_Click
        private void btnSearchSentMessages_Click(object sender, EventArgs e)
        {
            SqlParameter Param1 = new SqlParameter("@Date1", SqlDbType.DateTime);
            Param1.Value = new DateTime(FromDateRef1.SelectedDateTime.Value.Year,
                FromDateRef1.SelectedDateTime.Value.Month, FromDateRef1.SelectedDateTime.Value.Day,
                FromTimeRef1.Value.Hour, FromTimeRef1.Value.Minute, FromTimeRef1.Value.Second);
            SqlParameter Param2 = new SqlParameter("@Date2", SqlDbType.DateTime);
            Param2.Value = new DateTime(ToDateRef1.SelectedDateTime.Value.Year,
                ToDateRef1.SelectedDateTime.Value.Month, ToDateRef1.SelectedDateTime.Value.Day,
                ToTimeRef1.Value.Hour, ToTimeRef1.Value.Minute, ToTimeRef1.Value.Second);
            SqlParameter[] Params = new SqlParameter[2];
            Params[0] = Param1;
            Params[1] = Param2;
            String Command = "SELECT [PatList].[ID] AS [PatListID] , [PatList].[PatientID] AS [PatientID] , " +
                "ISNULL([PatList].[FirstName] + ' ' , '') + [PatList].[LastName] AS [PatFullName] , " +
                "[RefList].[ID] AS [RefID] , [RefList].[RegisterDate] AS [RefDate] " +
                "FROM [PatientsSystem].[Patients].[List] AS [PatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                "ON [PatList].[ID] = [RefList].[PatientIX] " +
                "WHERE [RefList].[RegisterDate] >= @Date1 AND [RefList].[RegisterDate] <= @Date2 ";
            if (cboServCat1.SelectedIndex != 0)
                Command += "AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServs] " +
                    "INNER JOIN [ImagingSystem].[Services].[List] AS [ServList] " +
                    "ON [RefServs].[ServiceIX] = [ServList].[ID] " +
                    "WHERE [RefServs].[ReferralIX] = [RefList].[ID] AND [ServList].[CategoryIX] = " +
                    cboServCat1.SelectedValue + ") > 0;";
            DataTable Result = Negar.DBLayerPMS.Manager.ExecuteQuery(Command, 0, Params);
            if (Result == null)
            {
                PMBox.Show("خطا در خواندن اطلاعات جستجو شده. ارتباط به سرور را بررسی نمایید.", "خطا!");
                dgvSelectPatients.DataSource = null;
            }
            else
            {
                dgvSelectPatients.DataSource = Result;
                foreach (DataGridViewRow row in dgvSelectPatients.Rows)
                    row.Cells[ColCheck1.Index].Value = true;
            }
        }
        #endregion

        #region btnSendMessages_Click
        private void btnSendMessages_Click(object sender, EventArgs e)
        {
            Boolean IsAnySelected = false;
            foreach (DataGridViewRow row in dgvSelectPatients.Rows)
            {
                if (row.Cells[ColCheck1.Index].Value != null && row.Cells[ColCheck1.Index].Value != DBNull.Value &&
                    Convert.ToBoolean(row.Cells[ColCheck1.Index].Value))
                {
                    IsAnySelected = true;
                    DataRowView Data = (DataRowView)row.DataBoundItem;
                    if (!SendMessageToPatient(Convert.ToInt32(Data["RefID"]))) break;
                }
            }
            if (IsAnySelected) PMBox.Show("ارسال پیام انتخاب شده انجام شد.", "تبریك!");
            else PMBox.Show("هیچ بیماری برای ارسال پیام كوتاه انتخاب نشده.", "خطا!");
            btnRefreshToday_Click(null, null);
        }
        #endregion

        #region btnShowTemplate_Click
        private void btnShowTemplate_Click(object sender, EventArgs e)
        {
            UsersSetting SMSText = null;
            switch (cboTemplates.SelectedIndex)
            {
                case 0: SMSText = DBLayerIMS.Settings.ReadSetting(708, null); break;
                case 1: SMSText = DBLayerIMS.Settings.ReadSetting(709, null); break;
                case 2: SMSText = DBLayerIMS.Settings.ReadSetting(710, null); break;
                case 3: SMSText = DBLayerIMS.Settings.ReadSetting(711, null); break;
                case 4: SMSText = DBLayerIMS.Settings.ReadSetting(712, null); break;
            }
            if (SMSText == null) txtMessageTemplate.Text = String.Empty;
            else txtMessageTemplate.Text = SMSText.Value;
        }
        #endregion

        #region btnSearchByName_Click
        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            SearchSentMessages(0);
        }
        #endregion

        #region btnSearchByPatID_Click
        private void btnSearchByPatID_Click(object sender, EventArgs e)
        {
            SearchSentMessages(1);
        }
        #endregion

        #region btnSearchSentPat_Click
        private void btnSearchSentPat_Click(object sender, EventArgs e)
        {
            SearchSentMessages(2);
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            FormClosing -= Form_Closing;
            Close();
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillFormDataSource()
        /// <summary>
        /// تابع خواندن اطلاعات پایه فرم از بانك
        /// </summary>
        private Boolean FillFormDataSource()
        {
            List<Sepehr.DBLayerIMS.DataLayer.SP_SelectCategoriesResult> ServCat = DBLayerIMS.Services.ServCategoriesList;
            if (ServCat == null) return false;
            ServCat[0].Name = "(همه موارد)";
            ServCat = ServCat.Where(Data => Data.IsActive == true || Data.ID == null).OrderBy(Data => Data.Name).ToList();
            cboServCat1.DataSource = ServCat.ToList();
            cboServCat2.DataSource = ServCat.ToList();
            cboTemplates.Items.Add("قالب 1");
            cboTemplates.Items.Add("قالب 2");
            cboTemplates.Items.Add("قالب 3");
            cboTemplates.Items.Add("قالب 4");
            cboTemplates.Items.Add("قالب 5");
            return true;
        }
        #endregion

        #region Boolean SendMessageToPatient(Int32 RefID)
        /// <summary>
        /// تابعی برای ارسال پیام كوتاه به بیمار
        /// </summary>
        public Boolean SendMessageToPatient(Int32 RefID)
        {
            try
            {
                String MessageText = txtMessageTemplate.Text.Trim();
                RefList RefList = DBLayerIMS.Referrals.GetRefDataByID(RefID);
                PatList PatData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(RefList.PatientIX);
                if (PatData.PatDetail == null || String.IsNullOrEmpty(PatData.PatDetail.TelNo2))
                    return true;
                if (MessageText.Contains("[CurrentDate]"))
                {
                    PersianDate PDate = DateTime.Now.ToPersianDate();
                    MessageText = MessageText.Replace("[CurrentDate]", PDate.Year + "/" + PDate.Month + "/" + PDate.Day);
                }
                if (MessageText.Contains("[CurrentTime]")) MessageText = MessageText.Replace("[CurrentTime]",
                    DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                if (MessageText.Contains("[PatFullName]"))
                {
                    String FullName = String.Empty;
                    if (PatData.IsMale != null)
                    {
                        if (PatData.IsMale.Value) FullName = "جناب آقای ";
                        else FullName = "سركار خانم ";
                    }
                    if (!String.IsNullOrEmpty(PatData.FirstName)) FullName += PatData.FirstName + " ";
                    FullName += PatData.LastName;
                    MessageText = MessageText.Replace("[PatFullName]", FullName);
                }
                if (MessageText.Contains("[RefDate]"))
                {
                    PersianDate PDate = RefList.RegisterDate.ToPersianDate();
                    MessageText = MessageText.Replace("[RefDate]", PDate.Year + "/" + PDate.Month + "/" + PDate.Day);
                }
                Negar.DBLayerPMS.SMS.InsertNewSMS(String.Empty, PatData.PatDetail.TelNo2, MessageText, null, RefID);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ارسال پبام كوتاه به بیمار ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Documents Forms", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region void SearchSentMessages(Int16 TheType)
        private void SearchSentMessages(Int16 TheType)
        {
            String Command = "SELECT [PatList].[PatientID] AS [PatientID] , " +
                "ISNULL([PatList].[FirstName] + ' ' , '') + [PatList].[LastName] AS [PatFullName] , " +
                "[RefList].[RegisterDate] AS [RefDate] , " +
                "(CASE WHEN [SMSList].[ID] IS NULL THEN 'پیامی ارسال نشده.' " +
                "WHEN [SMSQueue].[ID] IS NOT NULL THEN 'پیام در انتظار ارسال.' " +
                "WHEN [SMSSucceed].[ID] IS NOT NULL THEN 'پیام با موفقیت ارسال شده.' " +
                "WHEN [SMSFailed].[ID] IS NOT NULL THEN 'پیام ارسال نشده.' " +
                "ELSE 'خطا در بررسی.' END) AS [Status] " +
                "FROM [PatientsSystem].[Patients].[List] AS [PatList] " +
                "INNER JOIN [ImagingSystem].[Referrals].[List] AS [RefList] " +
                "ON [PatList].[ID] = [RefList].[PatientIX] " +
                "LEFT OUTER JOIN [PatientsSystem].[SMS].[Messages] AS [SMSList] " +
                "ON [SMSList].[RefIX] = [RefList].[ID] " +
                "LEFT OUTER JOIN [PatientsSystem].[SMS].[SendQueue] AS [SMSQueue] " +
                "ON [SMSList].[ID] = [SMSQueue].[MessageIX] " +
                "LEFT OUTER JOIN [PatientsSystem].[SMS].[SendSucceed] AS [SMSSucceed] " +
                "ON [SMSList].[ID] = [SMSSucceed].[MessageIX] " +
                "LEFT OUTER JOIN [PatientsSystem].[SMS].[SendFailed] AS [SMSFailed] " +
                "ON [SMSList].[ID] = [SMSFailed].[MessageIX] ";
            SqlParameter[] Params = null;
            switch (TheType)
            {
                case 0:
                    if (String.IsNullOrEmpty(txtFirstName.Text.Trim()) && String.IsNullOrEmpty(txtLastName.Text.Trim()))
                    {
                        PMBox.Show("نام یا نام خانوادگی برای جستجو وارد نشده!", "خطا!");
                        return;
                    }
                    Command += "WHERE ";
                    if (!String.IsNullOrEmpty(txtLastName.Text.Trim()) && !String.IsNullOrEmpty(txtFirstName.Text.Trim()))
                        Command += "[PatList].[FirstName] LIKE N'" + txtFirstName.Text.Trim() +
                            "%' AND [PatList].[LastName] LIKE N'" + txtLastName.Text.Trim() + "%'";
                    else if (!String.IsNullOrEmpty(txtLastName.Text.Trim()))
                        Command += "[PatList].[LastName] LIKE N'" + txtLastName.Text.Trim() + "%'";
                    else Command += "[PatList].[FirstName] LIKE N'" + txtFirstName.Text.Trim() + "%'";
                    break;
                case 1:
                    if (String.IsNullOrEmpty(txtPatID.Text.Trim()))
                    {
                        PMBox.Show("كد بیماری برای جستجو وارد نشده!", "خطا!");
                        return;
                    }
                    Command += "WHERE [PatList].[PatientID] LIKE '" + txtPatID.Text.Trim() + "%'";
                    break;
                case 2:
                    SqlParameter Param1 = new SqlParameter("@Date1", SqlDbType.DateTime);
                    Param1.Value = new DateTime(FromDateRef2.SelectedDateTime.Value.Year,
                        FromDateRef2.SelectedDateTime.Value.Month, FromDateRef2.SelectedDateTime.Value.Day,
                        FromTimeRef2.Value.Hour, FromTimeRef2.Value.Minute, FromTimeRef2.Value.Second);
                    SqlParameter Param2 = new SqlParameter("@Date2", SqlDbType.DateTime);
                    Param2.Value = new DateTime(ToDateRef2.SelectedDateTime.Value.Year,
                        ToDateRef2.SelectedDateTime.Value.Month, ToDateRef2.SelectedDateTime.Value.Day,
                        ToTimeRef2.Value.Hour, ToTimeRef2.Value.Minute, ToTimeRef2.Value.Second);
                    Params = new SqlParameter[2];
                    Params[0] = Param1;
                    Params[1] = Param2;
                    Command += "WHERE [RefList].[RegisterDate] >= @Date1 AND [RefList].[RegisterDate] <= @Date2";
                    if (cboServCat2.SelectedIndex != 0)
                        Command += "AND (SELECT COUNT(*) FROM [ImagingSystem].[Referrals].[RefServices] AS [RefServs] " +
                            "INNER JOIN [ImagingSystem].[Services].[List] AS [ServList] " +
                            "ON [RefServs].[ServiceIX] = [ServList].[ID] " +
                            "WHERE [RefServs].[ReferralIX] = [RefList].[ID] AND [ServList].[CategoryIX] = " +
                            cboServCat1.SelectedValue + ") > 0;";
                    break;
                default: break;
            }
            DataTable Result = Negar.DBLayerPMS.Manager.ExecuteQuery(Command, 0, Params);
            if (Result == null)
            {
                PMBox.Show("خطا در خواندن اطلاعات جستجو شده. ارتباط به سرور را بررسی نمایید.", "خطا!");
                dgvSearchSentPatients.DataSource = null;
            }
            else dgvSearchSentPatients.DataSource = Result;
        }
        #endregion

        #endregion

    }
}