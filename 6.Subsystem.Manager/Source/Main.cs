#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Negar.DBLayerPMS.DataLayer;
using Negar.Properties;
using Negar.Security.Classes;
using DevComponents.DotNetBar;
using Application = System.Windows.Forms.Application;
#endregion

namespace Negar
{
    /// <summary>
    /// فرم مدیریت ارتباط با بانك اطلاعات
    /// </summary>
    public partial class frmMain : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        #region Fields

        #region String _CurrentCS
        /// <summary>
        /// رشته اتصال جاری ، برای خواندن برنامه های نصب شده و تایید هویت در فرم سوم ویزارد
        /// </summary>
        private String _CurrentCS;
        #endregion

        #region Int16 _WrongPassCount
        /// <summary>
        /// نعداد خطاهای وارد شده برای كلمات عبور
        /// </summary>
        private Int16 _WrongPassCount;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            LoadSavedConnections();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        /// <summary>
        /// تابع مدیریت نمایش اولیه فرم
        /// </summary>
        /// <remarks>در این تابع ، تنظیمات اولیه ظاهر فرم و همچنین ظاهر كنترل ویزارد اعمال می گردد</remarks>
        private void Form_Shown(object sender, EventArgs e)
        {
            Text += " - نسخه: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            SetControlsToolTipTexts();
            WizardControl.HeaderTitleIndent = 60;
            WizardControl.HeaderDescriptionIndent = 60;
            Opacity = 1;
            if (cBoxUseSavedSettings.Checked && dgvConnections.Rows.Count != 0) WizardControl.NavigateNext();
        }
        #endregion

        #region cBoxMakeNewConnection_CheckedChanged
        /// <summary>
        /// تابع مدیریت تغییر نوع انتخاب كاربر برای اتصال
        /// </summary>
        /// <remarks>اگر كاربر ایجاد اتصال جدید را انتخاب نماید ، جدول اتصال های قبلی غیر فعال خواهد شد و بالعكس</remarks>
        private void cBoxMakeNewConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxMakeNewConnection.Checked) dgvConnections.Enabled = false;
            else dgvConnections.Enabled = true;
        }
        #endregion

        #region dgvConnections_UserDeletingRow
        /// <summary>
        /// تابعی برای مدیریت حذف یك ردیف از جدول اتصال های ذخیره شده
        /// </summary>
        private void dgvConnections_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult Dr = PMBox.Show("آیا مایلید اتصال انتخاب شده حذف گردد؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Dr != DialogResult.Yes) { e.Cancel = true; return; }
            if (!CSManager.DeleteCSSetting(e.Row.Cells[1].Value.ToString())) { e.Cancel = true; return; }
            if (dgvConnections.Rows.Count == 0)
            {
                cBoxMakeNewConnection.Checked = true;
                cBoxUseSavedSettings.Enabled = false;
            }
        }
        #endregion

        #region dgvConnections_SelectionChanged
        /// <summary>
        /// روالی برای مدیریت تغییر تعداد آیتم های موجود در جدول اتصال های ذخیره شده
        /// </summary>
        /// <remarks>در صورت حذف كلیه اتصال ها ، جدول اتصال ها غیر فعال شده و فرم به حالت افزودن اتصال جدید میرود</remarks>
        private void dgvConnections_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConnections.Rows.Count == 0)
            {
                cBoxMakeNewConnection.Checked = true;
                cBoxUseSavedSettings.Enabled = false;
            }
            else
            {
                cBoxMakeNewConnection.Checked = false;
                cBoxUseSavedSettings.Checked = true;
                cBoxUseSavedSettings.Enabled = true;
            }
        }
        #endregion

        #region WPage1_NextButtonClick
        /// <summary>
        /// روال مدیریت انتقال از صفحه اول ویزارد
        /// </summary>
        /// <remarks>اگر گزینه اتصال جدید انتخاب شده باشد ، به فرم دوم ویزارد انتقا می یابد.
        /// اگر یكی از تنظیمات قبلی انتخاب شده باشد ، به فرم سوم انتقال می یابد</remarks>
        private void WPage1_NextButtonClick(object sender, CancelEventArgs e)
        {
            if (cBoxMakeNewConnection.Checked == false && dgvConnections.SelectedRows.Count != 0)
            {
                CSManager.CurrentSetting = dgvConnections.SelectedRows[0].Cells[ColSettingName.Index].Value.ToString();
                _CurrentCS = CSManager.GetConnectionString("PatientsSystem", 5);
                if (!CheckCSInAlive(_CurrentCS))
                {
                    PMBox.Show("اتصال به سرور برقرار نمی شود!\n" + "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا قفل سخت افزاری متصل است؟\n" +
                    "2. آیا اتصال شبكه شما برقرار است؟\n" +
                    "3. آیا بانك های اطلاعاتی نصب شده اند و سالم می باشند؟\n" +
                    "4. آیا اتصال شبكه شما برقرار است و ترافیك شبكه در حالت عادیست؟", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); e.Cancel = true; return;
                }
                if (!FillCurrentDBAppsAndUsers()) { e.Cancel = true; return; }
                WizardControl.SelectedPage = WPage3;
            }
        }
        #endregion

        #region WPage2_AfterPageDisplayed
        /// <summary>
        /// تابع مدیریت فراخوانی فرم تعریف اتصال جدید
        /// </summary>
        private void WPage2_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            txtSettingName.Text = "اتصال به سرور محلی";
            txtSettingName.Focus();
            // اولین جعبه رادیویی انتخاب می گردد
            cBoxUseLocalServer.Checked = true;
            // نام تنظیمات اتصال سرور به حالت پیش فرض تغییر می كند
            txtNewServerName.Text = "Negar01";
            txtNewServerSQLInstanceName.Text = "NegarServer01";
        }
        #endregion

        #region cBoxUseLocalServer_CheckedChanged
        /// <summary>
        /// روالی برای مدیریت تغییر در حالت تعریف تنظیمات بر اساس سرور محلی
        /// </summary>
        private void cBoxUseLocalServer_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in WPage2.Controls)
                if (ctrl.Tag != null && (ctrl.Tag.ToString() == "IPName" || ctrl.Tag.ToString() == "ServerName")) ctrl.Enabled = false;
        }
        #endregion

        #region cBoxUseExternalServer_CheckedChanged
        /// <summary>
        /// روالی برای مدیریت تغییر انتخاب تنظیمات جدید از سرور غیر محلی
        /// </summary>
        private void cBoxUseExternalServer_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in WPage2.Controls)
                if (ctrl.Tag != null)
                {
                    if (ctrl.Tag.ToString() == "ServerName") ctrl.Enabled = true;
                    else if (ctrl.Tag.ToString() == "IPName") ctrl.Enabled = false;
                }
        }
        #endregion

        #region WPage2_NextButtonClick
        /// <summary>
        /// تابع مدیریت ثبت تنظیمات جدید اتصال جهت استفاده های بعدی
        /// </summary>
        /// <remarks>در این تابع ، ابتدا بررسی می شود كه آیا اتصال وارد شده صحیح می باشد و امكان برقراری ارتباط وجود دارد یا خیر.
        /// سپس اتصال ذخیره شده و ویزارد به صفحه سوم خواهد رفت.</remarks>
        private void WPage2_NextButtonClick(object sender, CancelEventArgs e)
        {
            // تولبد رشته ی صحیح نام سرور
            String ServerName;
            if (cBoxUseLocalServer.Checked) ServerName = ".";
            else ServerName = txtNewServerName.Text.Trim();
            String InstanceName = txtNewServerSQLInstanceName.Text.Trim();
            // تولید رشته ی اتصال موقت برای تست رشته ی اتصال
            String TempCS = CSManager.GenerateCS(ServerName + "\\" + InstanceName, "PatientsSystem", 4);
            // اگر رشته ی اتصال صحیح باشد ، تنظیمات جدید در رجیستری ذخیره می شود
            // سپس لیست تنظیمات جدید در جدول تنظیمات ذخیره شده بازخوانی شده و گزینه ی جدید انتخاب می گردد
            if (CSManager.CheckConnectionIsAlive(TempCS))
            {
                CSManager.AddCSSetting(txtSettingName.Text.Trim(), ServerName, InstanceName);
                LoadSavedConnections();
                foreach (DataGridViewRow row in dgvConnections.Rows)
                    if (row.Cells[ColSettingName.Index].Value.ToString() == txtSettingName.Text.Trim()) row.Selected = true;
                e.Cancel = true;
                WizardControl.SelectedPageIndex = 0;
                return;
            }
            // اگر رشته اتصال خطا باشد ، پیغام خطایی برای آن نمایش داده می شود
            const String Message = "امكان برقراری ارتباط با سرور یا نمونه بانك اطلاعاتی وارد شده ممكن نشد.\n" +
                "لطفاً موارد زیر را برای رفع اشكال بررسی نمایید:\n" +
                "1. آیا قفل سخت افزاری به سیستم متصل است و سالم می باشد؟\n" +
                "    برای بررسی متصل بودن قفل سخت افزاری از نرم افزار كمكی موجود در پوشه نصب نگار كمك بگیرید\n" +
                "2. آیا نام نمونه ی بانك اطلاعاتی را صحیح وارد نموده اید؟\n" +
                "3. آیا نام نمونه ای كه وارد كرده اید غیر فعال نیست؟\n" +
                "4. آیا نام سرور وارد شده یا آدرس آن را صحیح وارد نموده اید؟\n" +
                "5. آیا اتصال سیستم جاری با شبكه برقراری است؟";
            PMBox.Show(Message, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true; return;
        }
        #endregion

        #region WPage3_AfterPageDisplayed
        /// <summary>
        /// روال مدیریت نمایش صفحه سوم ویزارد - صفحه انتخاب زیر سیستم و تایید هویت
        /// </summary>
        /// <remarks>این روال زمانی فراخوانی می گردد كه اتصال مشخصی انتخاب شده و تست گردیده است</remarks>
        private void WPage3_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            // اعمال آخرین تنظیمات كاربر
            Int32 LastAppID = CSManager.LastOpenedAppID;
            Int16 LastUserID = CSManager.LastUserID;
            if (LastAppID != 0 && LastUserID != 0)
            {
                cBoxSaveLastAuthentication.Checked = true;
                cboInstalledApps.SelectedItem = ((List<HISApplication>)cboInstalledApps.DataSource).
                    Where(Data => Data.ID == LastAppID).First();
                cboUserName.SelectedItem = DBLayerPMS.Security.UsersList.Where(Data => Data.ID == LastUserID).First();
                txtPassword.Focus();
            }
            else cboUserName.Focus();
        }
        #endregion

        #region cboInstalledApps_SelectedIndexChanged
        /// <summary>
        /// روالی برای نمایش توضیحات هر زیر سیستم با تغییر برنامه انتخاب شده در كمبوباكس برنامه ها
        /// </summary>
        private void cboInstalledApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInstalledApps.SelectedValue != null)
                lblAppDescription.Text = ((HISApplication)cboInstalledApps.SelectedItem).Description;
        }
        #endregion

        #region cboUserName_Leave
        /// <summary>
        /// روالی برای انتخاب كاربر مناسب بر اساس نام كاربری تایپ شده در كمبوباكس كاربران
        /// </summary>
        private void cboUserName_Leave(object sender, EventArgs e)
        {
            if (cboUserName.Text.ToLower() == "sa" || cboUserName.Text.ToLower() == "administrator") return;
            Int32 Index = cboUserName.FindString(cboUserName.Text);
            if (Index >= 0) cboUserName.SelectedIndex = Index;
        }
        #endregion

        #region WPage3_txtPassword_Enter
        /// <summary>
        /// روالی برای تغییر زبان كیبورد با ورود به جعبه متن های نام كاربری و كلمه عبور
        /// </summary>
        private void txtAuthentications_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En-Us"));
        }
        #endregion

        #region WPage3_FinishButtonClick
        /// <summary>
        /// روالی برای تایید اعتبار رمز عبور وارد شده توسط كاربر و فراخوانی زیر سیستم انتخاب شده پس از تایید هویت
        /// </summary>
        private void WPage3_FinishButtonClick(object sender, CancelEventArgs e)
        {
            #region Initialize User ID
            Int16 UserID;
            if (cboUserName.Text.ToLower() == "administrator") UserID = 1;
            else if (cboUserName.Text.ToLower() == "sa") UserID = 2;
            else if (cboUserName.SelectedItem != null) UserID = ((SP_SelectUsersResult)cboUserName.SelectedItem).ID.Value;
            else
            {
                PMBox.Show("كاربری جهت ورود به سیستم به درستی انتخاب شده.", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            #endregion

            // بررسی صحت رمز عبور وارد شده
            Boolean? IsPassCorrect = CheckUserPassword(UserID, txtPassword.Text.Trim().Normalize());
            #region If Password Is Correct
            if (IsPassCorrect != null && IsPassCorrect.Value)
            {
                try
                {
                    // درخواست ورود كلمه عبور جدید در صورت نیاز
                    UsersList SelectedUserData = DBLayerPMS.Security.GetUserData(UserID);
                    if (SelectedUserData.MustChangePassword) new ChangeUserPassword(SelectedUserData.ID, true, false).Dispose();
                    SelectedUserData.MustChangePassword = false;
                    DBLayerPMS.Manager.Submit();
                    // ذخیره آخرین زیر سیستم استفاده شده و آخرین كاربر وارد شده در صورت انتخاب كاربر
                    if (cBoxSaveLastAuthentication.Checked)
                        CSManager.SaveLastSettingsToReg(Convert.ToInt16(cboInstalledApps.SelectedValue), SelectedUserData.ID);
                    // حذف آخرین زیر سیستم استفاده شده و آخرین كاربر وارد شده در صورت وجود
                    else CSManager.DeleteLastAppAndUser();

                    #region Call Selected Application
                    Process MyApplicationStart = new Process();
                    String ApplicationPath = CSManager.LoadAppPath(Convert.ToInt32(cboInstalledApps.SelectedValue));
                    if (String.IsNullOrEmpty(ApplicationPath) || !File.Exists(ApplicationPath))
                    {
                        DialogResult Result = PMBox.Show("فایل اجرایی برنامه انتخاب شده قبلا ذخیره نشده است.\n" +
                            "آیا مایلید فایل مورد نظر را انتخاب نمایید؟", "پرسش؟", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (Result == DialogResult.Yes)
                        {
                            if (Directory.Exists("C:\\Negar\\")) OpenFileDialogForm.InitialDirectory = "C:\\Negar\\";
                            else if (Directory.Exists("D:\\Negar\\")) OpenFileDialogForm.InitialDirectory = "D:\\Negar\\";
                            else if (Directory.Exists("E:\\Negar\\")) OpenFileDialogForm.InitialDirectory = "E:\\Negar\\";
                            DialogResult TheResult = OpenFileDialogForm.ShowDialog();
                            if (TheResult != DialogResult.OK) { e.Cancel = true; return; }
                            CSManager.SaveNewAppPathToReg(
                                Convert.ToInt16(cboInstalledApps.SelectedValue), OpenFileDialogForm.FileName);
                            ApplicationPath = OpenFileDialogForm.FileName;
                        }
                        else { e.Cancel = true; return; }
                    }
                    MyApplicationStart.StartInfo.FileName = ApplicationPath;
                    MyApplicationStart.StartInfo.Arguments = SelectedUserData.ID + " " + CSManager.CurrentSetting;
                    for (Int32 i = ApplicationPath.Length - 1; i >= 0; i--)
                        if (ApplicationPath[i] == '\\')
                        {
                            MyApplicationStart.StartInfo.WorkingDirectory = ApplicationPath.Substring(0, i);
                            break;
                        }
                    MyApplicationStart.Start();
                    #endregion
                }
                #region Catch
                catch (Exception)
                {
                    const string Message =
                        "خطا در ذخیره سازی آخرین تنظیمات كاربر و فراخوانی زیر سیستم انتخاب شده." +
                        "\nموارد زیر را برای رفع اشكال بررسی كنید:\n" +
                        "1. آیا نام سرور وارد شده یا آدرس آن را صحیح وارد نموده اید؟\n" +
                        "2. آیا نام نمونه ی بانك اطلاعاتی را صحیح وارد نموده اید؟\n" +
                        "3. آیا نام نمونه ای كه وارد كرده اید غیر فعال نیست؟\n" +
                        "4. آیا اتصال سیستم جاری با شبكه برقراری است؟";
                    PMBox.Show(Message, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormClosing -= Form_Closing; Application.Exit(); return;
                }
                #endregion
                FormClosing -= Form_Closing; Application.Exit(); return;
            }
            #endregion

            #region Wrong Password
            if (IsPassCorrect != null)
            {
                _WrongPassCount++;
                if (_WrongPassCount > 6)
                {
                    PMBox.Show("تعداد دفعات ورود رمز عبور نادرست از 6 مرتبه بیشتر شده است.\n" +
                        " شما به مدت 15 ثانیه قادر به ورود رمز عبور جدید نمی باشید!", "خطا!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(15000);
                }
                txtPassword.SelectAll();
                txtPassword.Focus();
                e.Cancel = true;
            }
            #endregion

            #region Not Accesed To Selected Application
            else
            {
                _WrongPassCount = 0;
                cboUserName.SelectAll();
                cboUserName.Focus();
                e.Cancel = true;
            }
            #endregion
        }
        #endregion

        #region WPage3_BackButtonClick
        /// <summary>
        /// روالی برای مدیریت صفحه مناسب جهت نمایش ، پس از فشردن كلید قبلی در صفحه سوم ویزارد
        /// </summary>
        private void WPage3_BackButtonClick(object sender, CancelEventArgs e)
        {
            if (cBoxUseSavedSettings.Checked)
            {
                e.Cancel = true;
                WizardControl.SelectedPage = WPage1;
            }
        }
        #endregion

        #region btnSubSystemPath_Click
        private void btnSubSystemPath_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CSManager.LoadAppPath(Convert.ToInt16(cboInstalledApps.SelectedValue))))
                MessageBox.Show(CSManager.LoadAppPath(
                    Convert.ToInt16(cboInstalledApps.SelectedValue)), "آدرس فیزیكی زیر سیستم انتخاب شده",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region btnDeletePhysicalFile_Click
        private void btnDeletePhysicalFile_Click(object sender, EventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایلید آدرس فیزیكی تنظیم شده برای زیر سیستم انتخاب شده را حذف كنید؟", "هشدار!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (Result != DialogResult.Yes) return;
            CSManager.SaveNewAppPathToReg(Convert.ToInt16(cboInstalledApps.SelectedValue), String.Empty);
        }
        #endregion

        #region WizardControl_CancelButtonClick
        /// <summary>
        /// روال مدیریت فراخوانی دكمه انصراف در كنترل ویزارد
        /// </summary>
        private void WizardControl_CancelButtonClick(object sender, CancelEventArgs e)
        {
            Close();
        }
        #endregion

        #region pBoxLogin_MouseDoubleClick
        private void pBoxLogin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !btnDeletePhysicalFile.Visible) btnDeletePhysicalFile.Visible = true;
        }
        #endregion

        #region Form_Closing
        /// <summary>
        /// روال مدیریت خروج از فرم
        /// </summary>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult Result = PMBox.Show("آیا مایل به خروج از نرم افزار می باشید؟", "خروج از سیستم؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result == DialogResult.Yes) { FormClosing -= (Form_Closing); Application.Exit(); }
            else e.Cancel = true;
        }
        #endregion

        #endregion

        #region Methods

        #region void SetControlsToolTipTexts()
        /// <summary>
        /// تابع تنظیم متن راهنمای كنترل ها
        /// </summary>
        private void SetControlsToolTipTexts()
        {
            const String TooltipHeader = "راهنمای تنظیمات سیستم";
            const String TooltipFooter = "سیستم مدیریت امنیت نگار";

            #region cBoxMakeNewConnection
            String TooltipText = "ایجاد اتصال جدید بر اساس تنظیمات دلخواه.\n" +
                "با انتخاب این گزینه ، پس از فشردن دكمه \"بعدی >\" " +
                    "فرمی برای ایجاد اتصال جدید به یك سرور بر اساس تنظیمات دلخواه شما نمایش داده خواهد شد.";
            FormToolTip.SetSuperTooltip(cBoxMakeNewConnection, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.Security, eTooltipColor.Lemon));
            #endregion

            #region cBoxUseSavedSettings
            TooltipText = "استفاده از آخرین تنظیمات استفاده شده توسط كاربر ویندوز.\n" +
                "با انتخاب این گزینه ، باید اتصال مورد نظر خود را از بین اتصال ها موجود در جدول پایین انتخاب نمایید.";
            FormToolTip.SetSuperTooltip(cBoxUseSavedSettings, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.Security, eTooltipColor.Red));
            #endregion

            #region txtSettingName
            TooltipText = "انتخاب یك نام اختصاصی برای اتصال.\n" +
                "در اینجا باید یك نام مشخص برای اتصالی كه می خواهید تعریف نمایید انتخاب نمایید.\n" +
                "این نام پس از تعریف ، اتصال جاری را از سایر اتصال ها متمایز می نماید.";
            FormToolTip.SetSuperTooltip(txtSettingName, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.Security, eTooltipColor.BlueMist));
            #endregion

            #region lblServerName
            TooltipText = "در این قسمت نام كامپیوتر سرور مورد نظر خود ، یا آدرس آن كامپیوتر را وارد نمایید.\n" +
                "در صورتی كه كامپیوتر جاری سرور نیز می باشد ، گزینه دوم را انتخاب نمایید.";
            FormToolTip.SetSuperTooltip(lblServerName, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.Security, eTooltipColor.Green));
            #endregion

            #region lblSQLInstance
            TooltipText = "این نام در هنگام نصب بانك اطلاعاتی تنظیم می گردد.";
            FormToolTip.SetSuperTooltip(lblSQLInstance, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.Security, eTooltipColor.Gray));
            #endregion

            #region btnSubSystemPath
            TooltipText = "با فراخوانی این فرمان ، آدرس فیزیكی زیرسیستم انتخاب شده نمایش می شود.";
            FormToolTip.SetSuperTooltip(btnSubSystemPath, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.Security, eTooltipColor.Apple));
            #endregion

            #region btnDeletePhysicalFile
            TooltipText = "با فراخوانی این فرمان ، آدرس فیزیكی زیرسیستم انتخاب شده حذف می شود.";
            FormToolTip.SetSuperTooltip(btnDeletePhysicalFile, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.Security, eTooltipColor.Apple));
            #endregion

        }
        #endregion

        #region void LoadSavedConnections()
        /// <summary>
        /// تابعی برای خواندن تنظیمات ذخیره شده ی اتصال برای كاربر جاری ویندوز
        /// </summary>
        private void LoadSavedConnections()
        {
            // اگر تنظیمات ذخیره شده ی قبلی وجود داشته باشد ، جدول انتخاب اتصال فعال می شود
            if (CSManager.Settings != null && CSManager.Settings.Count() != 0)
            {
                dgvConnections.Rows.Clear();
                foreach (KeyValuePair<String, String> Setting in CSManager.Settings)
                    dgvConnections.Rows.Add(Setting.Value, Setting.Key);
                dgvConnections.Rows[0].Selected = true;
                cBoxUseSavedSettings.Checked = true;
                cBoxUseSavedSettings.Focus();
            }
            // اگر تنظیمات ذخیره شده ی قبلی وجود نداشته باشد ، جدول انتخاب اتصال غیر فعال می شود
            else
            {
                dgvConnections.Rows.Clear();
                cBoxMakeNewConnection.Checked = true;
                cBoxMakeNewConnection.Focus();
                cBoxUseSavedSettings.Enabled = false;
                dgvConnections.Enabled = false;
            }
        }
        #endregion

        #region Boolean CheckCSInAlive(String CS)
        /// <summary>
        /// تابعی برای بررسی یك رشته اتصال
        /// </summary>
        private static Boolean CheckCSInAlive(String CS)
        {
            Boolean ReturnValue;
            DataContext MyDbClass = new DataContext(CS);
            try
            {
                MyDbClass.Connection.Open();
                ReturnValue = true;
            }
            #region Catch
            catch (Exception) { ReturnValue = false; }
            finally
            {
                MyDbClass.Connection.Close();
                MyDbClass.Dispose();
            }
            #endregion
            return ReturnValue;
        }
        #endregion

        #region Boolean FillCurrentDBAppsAndUsers()
        /// <summary>
        /// تابع خواندن اطلاعات جدول برنامه های نصب شده و لیست كاربران سرور انتخاب شده
        /// </summary>
        private Boolean FillCurrentDBAppsAndUsers()
        {
            DBLayerPMS.Manager.DBML = null;
            try
            {
                cboInstalledApps.DataSource = DBLayerPMS.Manager.DBML.HISApplications.Where(Data => Data.ID != 1).ToList();
                cboUserName.DataSource = DBLayerPMS.Security.UsersList.
                    Where(Data => Data.ID > 2 && Data.IsActive == true).ToList();
            }
            #region Catch
            catch (Exception)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات برنامه های نصب شده بر روی سیستم از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion
            if (cboInstalledApps.Items.Count == 0)
            {
                PMBox.Show("هیچ نرم افزاری بر روی سیستم نصب نمی باشد." +
                    " لطفاً با مدیر سیستم تماس بگیرید.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboUserName.DataSource == null)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات كاربران از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Boolean? CheckUserPassword(Int16 UserID, String ClearPassword)
        /// <summary>
        /// تابع بررسی صحت نام كاربری و روز عبور
        /// </summary>
        /// <param name="UserID">كلید جدول كاربران</param>
        /// <param name="ClearPassword">رشته اصلی رمز عبور</param>
        /// <returns>صحیح بودن یا نبودن رمز عبور یا عدم دسترسی كاربر به برنامه انتخاب شده</returns>
        private Boolean? CheckUserPassword(Int16 UserID, String ClearPassword)
        {
            String EncryptedPassword = Cryptographer.EncryptString(ClearPassword, "AftabClearPassword");
            UsersList UserData = DBLayerPMS.Security.GetUserData(UserID);
            #region Check User Existance
            if (UserData == null)
            {
                PMBox.Show("كاربر وارد شده در سیستم موجود نمی باشد.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Is This User Active Or Not
            //چك كردن وجود نام كاربری و همچنین فعال بودن آن
            if (!UserData.IsActive)
            {
                PMBox.Show("كاربر وارد شده غیر فعال می باشد.", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Check User Password
            if (EncryptedPassword != UserData.Password)
            {
                PMBox.Show("كلمه عبور وارد شده صحیح نمی باشد. لطفاً مجددا امتحان كنید.",
                    "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            #region Check User Permission For Selected Application
            if (UserID > 2 && !DBLayerPMS.Security.GetUserPermission(UserID, Convert.ToInt16(cboInstalledApps.SelectedValue)))
            {
                PMBox.Show("كاربر انتخاب شده دسترسی لازم به زیر سیستم انتخاب شده را ندارد!", "محدودیت دسترسی!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
            #endregion

            return true;
        }
        #endregion

        #endregion

    }
}