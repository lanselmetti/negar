#region using
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Microsoft.Win32;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.UserSettings
{
    /// <summary>
    /// فرم مدیریت تنظیمات كاربری
    /// </summary>
    public partial class frmManage : Form
    {

        #region Fields

        #region public Int16 _CurrentUserID
        /// <summary>
        /// كلید كاربر جاری
        /// </summary>
        public Int16 _CurrentUserID;
        #endregion

        #region Boolean _IsControlsChangeEventHandlersSet
        private Boolean _IsControlsChangeEventHandlersSet;
        #endregion

        #region String _CaptureSetting
        /// <summary>
        /// كلید ذخیره سازی اطلاعات كام پورت برای كاربر جاری در رجیستری
        /// </summary>
        private const String _CaptureSetting =
            "Software\\Negar\\NegarCaptureVideoStandardSetting";
        #endregion

        #region String _CaptureVideoStandard
        private const String _CaptureVideoStandard = "VideoStandard";
        #endregion

        #region String _CaptureVideoSource
        private const String _CaptureVideoSource = "VideoSource";
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmManage()
        {
            InitializeComponent();
            cbo101.SelectedIndex = 0;
            cbo306.SelectedIndex = 0;
            _CurrentUserID = SecurityManager.CurrentUserID;
            if (!FillFormDataSource()) { Close(); return; }
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (_CurrentUserID < 3)
            {
                PMBox.Show("كاربر جاری امكان ثبت تنظیمات كاربری برای خود را ندارد!",
                    "محدودیت دسترسی!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TabControlForm.Enabled = false;
                btnCopySettings.Enabled = false;
                btnDefaultSettings.Enabled = false;
            }
            else
            {
                if (!ReadCurrentUserSettings()) { Close(); return; }
                TabControlForm.Enabled = true;
                btnCopySettings.Enabled = true;
                btnDefaultSettings.Enabled = true;
            }
            Text = "تنظیمات كاربر - تنظیمات مربوط به بخش های مختلف برای هر كاربر - نام كاربر:" +
                    Negar.DBLayerPMS.Security.UsersList.Where(Data => Data.ID == _CurrentUserID).First().FullName;
            if (!_IsControlsChangeEventHandlersSet)
            {
                SetControlsChangeEventHandlers();
                _IsControlsChangeEventHandlersSet = true;
            }
            Activate();
            Select();
            Focus();
            BringToFront();
            Opacity = 1;
        }
        #endregion

        #region Controls_ValueChanged
        static void Controls_ValueChanged(object sender, EventArgs e)
        {
            if (sender is Control) ((Control)sender).Tag = "Changed";
            else if (sender is CheckBoxItem) ((CheckBoxItem)sender).Tag = "Changed";
            else if (sender is ComboBoxEx) ((ComboBoxEx)sender).Tag = "Changed";
        }
        #endregion

        #region btnChangeUser_Click
        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            frmSelectUser ChangeForm = new frmSelectUser();
            ChangeForm._UsersDataSource = ChangeForm._UsersDataSource.Where(Data => Data.ID != _CurrentUserID).ToList();
            ChangeForm.ShowDialog();
            if (ChangeForm.DialogResult == DialogResult.OK && ChangeForm._SelectedUser != 0)
            {
                _CurrentUserID = ChangeForm._SelectedUser;
                Form_Shown(null, null);
            }
            ChangeForm.Dispose();
        }
        #endregion

        #region btnCopySettings_Click
        private void btnCopySettings_Click(object sender, EventArgs e)
        {
            frmSelectUserForCopy MyForm = new frmSelectUserForCopy(_CurrentUserID);
            if (MyForm.DialogResult == DialogResult.OK)
            {
                foreach (DataGridViewRow row in MyForm.dgvData.Rows)
                    if (row.Cells["ColSelection"].Value != null &&
                        Convert.ToBoolean(row.Cells["ColSelection"].Value))
                        try
                        {
                            Int16 TargetUserID = ((SP_SelectUsersResult)row.DataBoundItem).ID.Value;
                            if (!DBLayerIMS.Settings.ClearUserSettings(TargetUserID)) continue;
                            DBLayerIMS.Manager.DBML.SP_CopyUserSetting(_CurrentUserID, TargetUserID);
                        }
                        #region Catch
                        catch (Exception Ex)
                        {
                            const String ErrorMessage =
                                "امكان تغییر اطلاعات تنظیمات كاربری كاربر جاری در بانك وجود ندارد.\n" +
                                "موارد زیر را بررسی نمایید:\n" +
                                "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                            PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                            return;
                        }
                        #endregion
            }
            BringToFront();
            Focus();
        }
        #endregion

        #region btnDefaultSettings_Click
        private void btnDefaultSettings_Click(object sender, EventArgs e)
        {
            DialogResult Answer =
                PMBox.Show("آیا مایلید كلیه تنظیمات كاربر جاری را به تنظیمات اولیه سیستم بازگردانید؟", "پرسش؟",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Answer != DialogResult.Yes) return;
            if (!DBLayerIMS.Settings.ClearUserSettings(_CurrentUserID)) return;
            if (!ReadCurrentUserSettings()) { Close(); return; }
        }
        #endregion

        #region cBox301_CheckedChanged
        private void cBox301_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBoxX)sender).Checked)
            {
                foreach (CheckBoxX ctrl in Panel1.Controls)
                    if (ctrl.AccessibleName == ((CheckBoxX)sender).AccessibleName &&
                        ctrl.GetHashCode() != sender.GetHashCode())
                    {
                        ctrl.Visible = true;
                        ctrl.Checked = false;
                        break;
                    }
            }
            else
            {
                foreach (CheckBoxX ctrl in Panel1.Controls)
                    if (ctrl.AccessibleName == ((CheckBoxX)sender).AccessibleName &&
                        ctrl.GetHashCode() != sender.GetHashCode())
                    {
                        ctrl.Visible = false;
                        ctrl.Checked = false;
                        break;
                    }
            }
        }
        #endregion

        #region cBox3031_CheckedChanged
        private void cBox3031_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox3031.Checked)
            {
                cBox307.Visible = false;
                txt307.Visible = false;
                lbl307.Visible = false;
            }
            else
            {
                cBox307.Visible = true;
                cBox307.Checked = false;
            }
        }
        #endregion

        #region cBox307_CheckedChanged
        private void cBox307_CheckedChanged(object sender, EventArgs e)
        {
            txt307.Visible = cBox307.Checked;
            lbl307.Visible = cBox307.Checked;
        }
        #endregion

        #region cBox401_CheckedChanged
        private void cBox401_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBoxX)sender).Checked)
            {
                foreach (CheckBoxX ctrl in Panel2.Controls)
                    if (ctrl.AccessibleName == ((CheckBoxX)sender).AccessibleName &&
                        ctrl.GetHashCode() != sender.GetHashCode())
                    {
                        ctrl.Visible = true;
                        ctrl.Checked = false;
                        break;
                    }
            }
            else
            {
                foreach (CheckBoxX ctrl in Panel2.Controls)
                    if (ctrl.AccessibleName == ((CheckBoxX)sender).AccessibleName &&
                        ctrl.GetHashCode() != sender.GetHashCode())
                    {
                        ctrl.Visible = false;
                        ctrl.Checked = false;
                        break;
                    }
            }
        }
        #endregion

        #region cBox40108_CheckedChangedEx
        private void cBox40108_CheckedChangedEx(object sender, CheckBoxXChangeEventArgs e)
        {
            if (e.NewChecked.Checked == false)
            {
                cBox40107.Checked = false;
                cBox40107.Visible = false;
                cBox40108.Checked = false;
                cBox40108.Visible = false;
                cBox40109.Checked = false;
                cBox40109.Visible = false;
                cBox40110.Checked = false;
                cBox40110.Visible = false;
            }
            else
            {
                cBox40107.Visible = true;
                cBox40108.Visible = true;
                cBox40109.Visible = true;
                cBox40110.Visible = true;
            }
        }
        #endregion

        #region cBox40112_CheckedChangedEx
        private void cBox40112_CheckedChangedEx(object sender, CheckBoxXChangeEventArgs e)
        {
            if (e.NewChecked.Checked == false)
            {
                cBox40111.Checked = false;
                cBox40111.Visible = false;
                cBox40112.Checked = false;
                cBox40112.Visible = false;
            }
            else
            {
                cBox40111.Visible = true;
                cBox40112.Visible = true;
            }
        }
        #endregion

        #region cBox40115_CheckedChangedEX
        private void cBox40115_CheckedChangedEx(object sender, CheckBoxXChangeEventArgs e)
        {
            if (e.NewChecked.Checked == false)
            {
                cBox40114.Checked = false;
                cBox40114.Visible = false;
                cBox40115.Checked = false;
                cBox40115.Visible = false;
            }
            else
            {
                cBox40114.Visible = true;
                cBox40115.Visible = true;
            }
        }
        #endregion

        #region cBox409_CheckedChanged
        private void cBox409_CheckedChanged(object sender, EventArgs e)
        {
            cBox403.Visible = cBox409.Checked;
        }
        #endregion

        #region cBox508_CheckedChanged
        private void cBox508_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox508.Checked) txt509.Enabled = true;
            else txt509.Enabled = false;
        }
        #endregion

        #region cBox604_CheckedChanged
        private void cBox604_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox604.Checked) txt605.Enabled = true;
            else txt605.Enabled = false;
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!SaveCurrentUserSettings()) { Close(); return; }
        }
        #endregion

        #region btnHelp_Click
        private void btnHelp_Click(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
        }
        #endregion

        #region Form_Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
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
            const String TooltipFooter = "سیستم مدیریت تصویربرداری سپهر";

            #region btnHelp
            String TooltipText = ToolTipManager.GetText("btnHelp", "IMS");
            FormToolTip.SetSuperTooltip(btnHelp, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnCancel
            TooltipText = ToolTipManager.GetText("btnCancel", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnApply
            TooltipText = ToolTipManager.GetText("btnApply", "IMS");
            FormToolTip.SetSuperTooltip(btnApply, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void SetControlsChangeEventHandlers()
        private void SetControlsChangeEventHandlers()
        {
            foreach (Object ctrl in TCP1.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in TCP2.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in Panel1.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in TCP3.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in TCP4.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in Panel2.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in Panel3.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in Panel4.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in Panel5.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in TCP6.Controls)
            {
                if (ctrl is ComboBoxEx) ((ComboBoxEx)ctrl).SelectedValueChanged += Controls_ValueChanged;
                else if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
                else if (ctrl is IntegerInput) ((IntegerInput)ctrl).ValueChanged += Controls_ValueChanged;
                else if (ctrl is TextBoxX) ((TextBoxX)ctrl).TextChanged += Controls_ValueChanged;
            }
            foreach (Object ctrl in Panel750.Controls)
                if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
            foreach (Object ctrl in Panel751.Controls)
                if (ctrl is CheckBoxX) ((CheckBoxX)ctrl).CheckedChanged += Controls_ValueChanged;
        }
        #endregion

        #region Boolean FillFormDataSource()
        /// <summary>
        /// تابعی برای خواندن اطلاعات كنترل های فرم از بانك
        /// </summary>
        private Boolean FillFormDataSource()
        {
            cbo201.DataSource = DBLayerIMS.Schedules.SchAppList;
            cbo702.DataSource = DBLayerIMS.Document.DocTypesList;

            cbo506.DataSource = DBLayerIMS.Cash.CashFullList.
                Where(Data => Data.IsActive == true || Data.ID == null).ToList();

            cbo703.DataSource = DBLayerIMS.Referrals.RefServPerformers.Where(Data => Data.IsPhysician == true).
                    OrderBy(Data => Data.FullName).ToList();

            cbo201.DisplayMember = "Name";
            cbo201.ValueMember = "ID";

            cbo702.DisplayMember = "Title";
            cbo702.ValueMember = "ID";

            cbo703.DisplayMember = "FullName";
            cbo703.ValueMember = "ID";

            cbo506.DisplayMember = "Name";
            cbo506.ValueMember = "ID";
            return true;
        }
        #endregion

        #region Boolean ReadCurrentUserSettings()
        /// <summary>
        /// تابه خواندن تنظیمات كاربر جاری سیستم
        /// </summary>
        private Boolean ReadCurrentUserSettings()
        {
            List<UsersSetting> UserSettings;
            try
            {
                IQueryable<UsersSetting> TempData =
                    DBLayerIMS.Manager.DBML.UsersSettings.
                    Where(Data => Data.UserIX == _CurrentUserID || Data.UserIX == null);
                DBLayerIMS.Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, TempData);
                UserSettings = TempData.ToList();
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage =
                    "امكان خواندن اطلاعات تنظیمات كاربری كاربر جاری از بانك وجود ندارد.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion

            #region Main Form Settings (100)
            // فرمان پیش فرض بعد از دوبار كلیك روی جدول بیماران
            if (UserSettings.Exists(Data => Data.SettingIX == 101) &&
                !String.IsNullOrEmpty(UserSettings.Where(Data => Data.SettingIX == 101).First().Value) &&
                cbo101.Items.Count > Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 101).First().Value))
                cbo101.SelectedIndex = Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 101).First().Value);
            else cbo101.SelectedIndex = 0;
            // ستون های جدول مراجعات
            if (UserSettings.Exists(Data => Data.SettingIX == 102))
            {
                String Setting102 = UserSettings.Where(Data => Data.SettingIX == 102).First().Value;
                if (!String.IsNullOrEmpty(Setting102))
                    for (Int32 i = 0; i < Setting102.Length; i++)
                    {
                        String CheckValue = Setting102[i].ToString();
                        if (CheckValue == "1") CheckValue = Boolean.TrueString;
                        else CheckValue = Boolean.FalseString;
                        ((CheckBoxItem)lst102.Items[i]).Checked = Boolean.Parse(CheckValue);
                    }
            }
            else foreach (CheckBoxItem item in lst102.Items) item.Checked = true;
            // ستون های جدول بیماران
            if (UserSettings.Exists(Data => Data.SettingIX == 103))
            {
                String Setting103 = UserSettings.Where(Data => Data.SettingIX == 103).First().Value;
                if (!String.IsNullOrEmpty(Setting103))
                    for (Int32 i = 0; i < Setting103.Length; i++)
                    {
                        String CheckValue = Setting103[i].ToString();
                        if (CheckValue == "1") CheckValue = Boolean.TrueString;
                        else CheckValue = Boolean.FalseString;
                        ((CheckBoxItem)lst103.Items[i]).Checked = Boolean.Parse(CheckValue);
                    }
            }
            else foreach (CheckBoxItem item in lst103.Items) item.Checked = true;
            // فرمان پیش فرض بعد از دوبار كلیك روی جدول مراجعات
            if (UserSettings.Exists(Data => Data.SettingIX == 104) &&
                !String.IsNullOrEmpty(UserSettings.Where(Data => Data.SettingIX == 104).First().Value) &&
                cbo104.Items.Count > Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 104).First().Value))
                cbo104.SelectedIndex = Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 104).First().Value);
            else cbo104.SelectedIndex = 0;
            // افزودن آخرین بیماران مشاهده شده به منوی دسترسی
            if (UserSettings.Exists(Data => Data.SettingIX == 105) &&
                UserSettings.Where(Data => Data.SettingIX == 105).First().Boolean != null)
                cBox105.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 105).First().Boolean;
            else cBox105.Checked = true;
            // تنظیمات 106 حذف شد
            if (UserSettings.Exists(Data => Data.SettingIX == 107) &&
                UserSettings.Where(Data => Data.SettingIX == 107).First().Boolean != null)
                cBox107.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 107).First().Boolean;
            else cBox107.Checked = true;
            if (UserSettings.Exists(Data => Data.SettingIX == 108) &&
                UserSettings.Where(Data => Data.SettingIX == 108).First().Boolean != null)
                cBox108.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 108).First().Boolean;
            else cBox108.Checked = true;
            #endregion

            #region Schedules (200)
            if (UserSettings.Exists(Data => Data.SettingIX == 201) &&
                UserSettings.Where(Data => Data.SettingIX == 201).First().Value != null)
            {
                for (Int32 i = 0; i < cbo201.Items.Count; i++)
                    if (((SP_SelectApplicationsResult)cbo201.Items[i]).ID ==
                        Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 201).First().Value))
                        cbo201.SelectedIndex = i;
            }
            else cbo201.SelectedIndex = 0;
            if (UserSettings.Exists(Data => Data.SettingIX == 202))
            {
                String Setting202 = UserSettings.Where(Data => Data.SettingIX == 202).First().Value;
                if (!String.IsNullOrEmpty(Setting202))
                    for (Int32 i = 0; i < Setting202.Length; i++)
                    {
                        String CheckValue = Setting202[i].ToString();
                        if (CheckValue == "1") CheckValue = Boolean.TrueString;
                        else CheckValue = Boolean.FalseString;
                        ((CheckBoxItem)lst202.Items[i]).Checked = Boolean.Parse(CheckValue);
                    }
            }
            else foreach (CheckBoxItem item in lst202.Items) item.Checked = true;
            if (UserSettings.Exists(Data => Data.SettingIX == 203) &&
                UserSettings.Where(Data => Data.SettingIX == 203).First().Boolean != null)
                cBox203.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 203).First().Boolean;
            else cBox203.Checked = false;
            // 204 حذف شد
            String txt205Value = String.Empty;
            if (UserSettings.Exists(Data => Data.SettingIX == 205) &&
                UserSettings.Where(Data => Data.SettingIX == 205).First().Value != null)
                txt205Value = UserSettings.Where(Data => Data.SettingIX == 205).First().Value;
            else { txt2051.Value = 0; txt2052.Value = 7; }
            for (Int32 i = 0; i < txt205Value.Length; i++)
                if (txt205Value[i] == '-')
                {
                    txt2051.Value = Convert.ToInt32(txt205Value.Substring(0, i));
                    txt2052.Value = Convert.ToInt32(txt205Value.Substring(i + 1));
                    break;
                }
            #endregion

            #region Patients (300)
            if (UserSettings.Exists(Data => Data.SettingIX == 301))
            {
                String Setting301 = UserSettings.Where(Data => Data.SettingIX == 301).First().Value;
                if (!String.IsNullOrEmpty(Setting301))
                    for (Int32 i = 0; i < Setting301.Length; i++)
                    {
                        String CheckValue = Setting301[i].ToString();
                        if (CheckValue == "1") CheckValue = Boolean.TrueString;
                        else CheckValue = Boolean.FalseString;
                        ((CheckBoxX)Panel1.Controls[i]).Checked = Boolean.Parse(CheckValue);
                    }
            }
            else
            {
                foreach (CheckBoxX cBox in Panel1.Controls) cBox.Checked = false;
                cBox30101.Checked = true;
                cBox30102.Checked = true;
                cBox30109.Checked = true;
                cBox30110.Checked = true;
            }
            // كلید 302 حذف گردید
            if (UserSettings.Exists(Data => Data.SettingIX == 303) &&
                UserSettings.Where(Data => Data.SettingIX == 303).First().Boolean != null)
            {
                if (UserSettings.Where(Data => Data.SettingIX == 303).First().Boolean.Value) cBox3032.Checked = true;
                else cBox3031.Checked = true;
            }
            else cBox3032.Checked = true;
            if (UserSettings.Exists(Data => Data.SettingIX == 304) &&
                UserSettings.Where(Data => Data.SettingIX == 304).First().Boolean != null)
                cBox304.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 304).First().Boolean;
            else cBox304.Checked = false;
            if (UserSettings.Exists(Data => Data.SettingIX == 305) &&
                UserSettings.Where(Data => Data.SettingIX == 305).First().Boolean != null)
                cBox305.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 305).First().Boolean;
            else cBox305.Checked = false;
            if (UserSettings.Exists(Data => Data.SettingIX == 306) &&
                UserSettings.Where(Data => Data.SettingIX == 306).First().Value != null)
                cbo306.SelectedIndex = Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 306).First().Value);
            else cbo306.SelectedIndex = 0;
            if (UserSettings.Exists(Data => Data.SettingIX == 307) &&
                UserSettings.Where(Data => Data.SettingIX == 307).First().Value != null)
            {
                cBox307.Checked = true;
                txt307.Text = UserSettings.Where(Data => Data.SettingIX == 307).First().Value;
            }
            else cBox307.Checked = false;
            #endregion

            #region Referrals (400)
            if (UserSettings.Exists(Data => Data.SettingIX == 401))
            {
                String Setting401 = UserSettings.Where(Data => Data.SettingIX == 401).First().Value;
                if (!String.IsNullOrEmpty(Setting401))
                    for (Int32 i = 0; i < Setting401.Length; i++)
                    {
                        String CheckValue = Setting401[i].ToString();
                        if (CheckValue == "1") CheckValue = Boolean.TrueString;
                        else CheckValue = Boolean.FalseString;
                        ((CheckBoxX)Panel2.Controls[i]).Checked = Boolean.Parse(CheckValue);
                    }
            }
            else
            {
                foreach (CheckBoxX cBox in Panel2.Controls) cBox.Checked = false;
                cBox40101.Checked = true;
                cBox40103.Checked = true;
                cBox40106.Checked = true;
                cBox40107.Checked = true;
                cBox40108.Checked = true;
                cBox40109.Checked = true;
                cBox40110.Checked = true;
                cBox40111.Checked = true;
                cBox40113.Checked = true;
                cBox40114.Checked = true;
                cBox40115.Checked = true;
            }
            // كلید 402 حذف گردید
            if (UserSettings.Exists(Data => Data.SettingIX == 403) &&
                UserSettings.Where(Data => Data.SettingIX == 403).First().Boolean != null)
                cBox403.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 403).First().Boolean;
            else cBox403.Checked = false;
            // كلید 404 حذف گردید
            if (UserSettings.Exists(Data => Data.SettingIX == 405) &&
                UserSettings.Where(Data => Data.SettingIX == 405).First().Boolean != null)
                cBox405.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 405).First().Boolean;
            else cBox405.Checked = true;
            if (UserSettings.Exists(Data => Data.SettingIX == 406) &&
                UserSettings.Where(Data => Data.SettingIX == 406).First().Boolean != null)
                cBox406.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 406).First().Boolean;
            else cBox406.Checked = true;
            if (UserSettings.Exists(Data => Data.SettingIX == 407) &&
                UserSettings.Where(Data => Data.SettingIX == 407).First().Boolean != null)
                cBox407.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 407).First().Boolean;
            else cBox407.Checked = false;
            if (UserSettings.Exists(Data => Data.SettingIX == 408) &&
               UserSettings.Where(Data => Data.SettingIX == 408).First().Boolean != null)
                cBox408.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 408).First().Boolean;
            else cBox408.Checked = true;
            if (UserSettings.Exists(Data => Data.SettingIX == 409) &&
               UserSettings.Where(Data => Data.SettingIX == 409).First().Boolean != null)
                cBox409.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 409).First().Boolean;
            else cBox409.Checked = true;
            if (UserSettings.Exists(Data => Data.SettingIX == 410) &&
                UserSettings.Where(Data => Data.SettingIX == 410).First().Boolean != null)
                cBox410.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 410).First().Boolean;
            else cBox410.Checked = false;
            #endregion

            #region Account (500)
            // كلید 501 حذف گردید
            // كلید 502 حذف گردید
            if (UserSettings.Exists(Data => Data.SettingIX == 503) &&
                UserSettings.Where(Data => Data.SettingIX == 503).First().Boolean != null)
                cBox503.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 503).First().Boolean;
            else cBox503.Checked = true;

            if (UserSettings.Exists(Data => Data.SettingIX == 504) &&
                UserSettings.Where(Data => Data.SettingIX == 504).First().Boolean != null)
                cBox504.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 504).First().Boolean;
            else cBox504.Checked = true;

            if (UserSettings.Exists(Data => Data.SettingIX == 505) &&
                UserSettings.Where(Data => Data.SettingIX == 505).First().Boolean != null)
                cBox505.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 505).First().Boolean;
            else cBox505.Checked = true;

            if (UserSettings.Exists(Data => Data.SettingIX == 506) &&
                UserSettings.Where(Data => Data.SettingIX == 506).First().Value != null)
            {
                for (Int32 i = 0; i < cbo506.Items.Count; i++)
                    if (((SP_SelectCashesResult)cbo506.Items[i]).ID ==
                        Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 506).First().Value))
                        cbo506.SelectedIndex = i;
            }
            else cbo506.SelectedIndex = 0;

            if (UserSettings.Exists(Data => Data.SettingIX == 507) &&
                UserSettings.Where(Data => Data.SettingIX == 507).First().Boolean != null)
                cBox507.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 507).First().Boolean;
            else cBox507.Checked = true;

            if (UserSettings.Exists(Data => Data.SettingIX == 508) &&
                UserSettings.Where(Data => Data.SettingIX == 508).First().Boolean != null)
                cBox508.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 508).First().Boolean;
            else cBox508.Checked = false;

            if (UserSettings.Exists(Data => Data.SettingIX == 508) &&
                UserSettings.Where(Data => Data.SettingIX == 508).First().Boolean != null)
            {
                if (UserSettings.Exists(Data => Data.SettingIX == 509) &&
                    UserSettings.Where(Data => Data.SettingIX == 509).First().Value != null)
                    txt509.Value = Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 509).First().Value);
            }
            else txt509.Value = 90;
            #endregion

            #region Cash Monitor (600)
            if (UserSettings.Exists(Data => Data.SettingIX == 601) &&
                UserSettings.Where(Data => Data.SettingIX == 601).First().Boolean != null)
                cBox601.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 601).First().Boolean;
            else cBox601.Checked = false;

            if (UserSettings.Exists(Data => Data.SettingIX == 602) &&
                UserSettings.Where(Data => Data.SettingIX == 602).First().Boolean != null)
                cBox602.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 602).First().Boolean;
            else cBox602.Checked = false;

            if (UserSettings.Exists(Data => Data.SettingIX == 603) &&
                UserSettings.Where(Data => Data.SettingIX == 603).First().Value != null)
            {
                String txt603Value = UserSettings.Where(Data => Data.SettingIX == 603).First().Value;
                for (Int32 i = 0; i < txt603Value.Length; i++)
                    if (txt603Value[i] == '-')
                    {
                        txtStart603.Value = Convert.ToInt32(txt603Value.Substring(0, i));
                        txtEnd603.Value = Convert.ToInt32(txt603Value.Substring(i + 1));
                        break;
                    }
            }
            else { txtStart603.Value = 12; txtEnd603.Value = 0; }

            if (UserSettings.Exists(Data => Data.SettingIX == 604) &&
                UserSettings.Where(Data => Data.SettingIX == 604).First().Boolean != null)
                cBox604.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 604).First().Boolean;
            else cBox604.Checked = false;

            if (UserSettings.Exists(Data => Data.SettingIX == 604) &&
                UserSettings.Where(Data => Data.SettingIX == 604).First().Boolean != null)
            {
                if (UserSettings.Exists(Data => Data.SettingIX == 605) &&
                    UserSettings.Where(Data => Data.SettingIX == 605).First().Value != null)
                    txt605.Value = Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 605).First().Value);
            }
            else txt605.Value = 5;
            #endregion

            #region Documents (700)
            if (UserSettings.Exists(Data => Data.SettingIX == 701) &&
                UserSettings.Where(Data => Data.SettingIX == 701).First().Boolean != null)
                cBox701.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 701).First().Boolean;
            else cBox701.Checked = false;

            if (UserSettings.Exists(Data => Data.SettingIX == 702) &&
                UserSettings.Where(Data => Data.SettingIX == 702).First().Value != null)
            {
                for (Int32 i = 0; i < cbo702.Items.Count; i++)
                    if (((SP_SelectTypeResult)cbo702.Items[i]).ID ==
                        Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 702).First().Value))
                        cbo702.SelectedIndex = i;
            }
            else cbo702.SelectedIndex = 0;

            if (UserSettings.Exists(Data => Data.SettingIX == 703) &&
                UserSettings.Where(Data => Data.SettingIX == 703).First().Value != null)
            {
                for (Int32 i = 0; i < cbo703.Items.Count; i++)
                    if (((SP_SelectPerformersResult)cbo703.Items[i]).ID ==
                        Convert.ToInt32(UserSettings.Where(Data => Data.SettingIX == 703).First().Value))
                        cbo703.SelectedIndex = i;
            }
            else cbo703.SelectedIndex = 0;

            // حذف شد
            //if (UserSettings.Exists(Data => Data.SettingIX == 704) &&
            //    UserSettings.Where(Data => Data.SettingIX == 704).First().Boolean != null)
            //    cBox704.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 704).First().Boolean;
            //else cBox704.Checked = true;

            if (UserSettings.Exists(Data => Data.SettingIX == 705) &&
                UserSettings.Where(Data => Data.SettingIX == 705).First().Boolean != null)
                cBox705.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 705).First().Boolean;
            else cBox705.Checked = false;

            if (UserSettings.Exists(Data => Data.SettingIX == 706) &&
                UserSettings.Where(Data => Data.SettingIX == 706).First().Value != null)
            {
                String txt706Value = UserSettings.Where(Data => Data.SettingIX == 706).First().Value;
                for (Int32 i = 0; i < txt706Value.Length; i++)
                    if (txt706Value[i] == '-')
                    {
                        txtStart706.Value = Convert.ToInt32(txt706Value.Substring(0, i));
                        txtEnd706.Value = Convert.ToInt32(txt706Value.Substring(i + 1));
                        break;
                    }
            }
            else { txtStart706.Value = 48; txtEnd706.Value = 24; }

            if (UserSettings.Exists(Data => Data.SettingIX == 707) &&
                UserSettings.Where(Data => Data.SettingIX == 707).First().Boolean != null)
                cBox707.Checked = (Boolean)UserSettings.Where(Data => Data.SettingIX == 707).First().Boolean;
            else cBox707.Checked = false;

            Boolean Setting750 = false;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                if (MyKey != null) Setting750 =
                    Convert.ToBoolean(MyKey.GetValue(_CaptureVideoStandard, true));
            }
            catch (Exception) { }
            if (Setting750) cBox7502.Checked = true;
            else cBox7501.Checked = true;

            Boolean Setting751 = false;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                if (MyKey != null) Setting751 =
                    Convert.ToBoolean(MyKey.GetValue(_CaptureVideoSource, true));
            }
            catch (Exception) { }
            if (Setting751) cBox7512.Checked = true;
            else cBox7511.Checked = true;

            if (UserSettings.Exists(Data => Data.SettingIX == 752) &&
                UserSettings.Where(Data => Data.SettingIX == 752).First().Value != null &&
                !String.IsNullOrEmpty(UserSettings.Where(Data => Data.SettingIX == 752).First().Value))
            {
                String value = UserSettings.Where(Data => Data.SettingIX == 752).First().Value;
                Int32 picWidth = 0;
                Int32 picHeight = 0;
                for (Int32 i = 0; i < value.Length; i++)
                    if (value[i].Equals(','))
                    {
                        picWidth = Convert.ToInt32(value.Substring(0, i));
                        picHeight = Convert.ToInt32(value.Substring(i + 1));
                        break;
                    }
                txt7521.Value = picWidth;
                txt7522.Value = picHeight;
            }
            else
            {
                txt7521.Value = 280;
                txt7522.Value = 210;
            }

            if (UserSettings.Exists(Data => Data.SettingIX == 790) &&
                UserSettings.Where(Data => Data.SettingIX == 790).First().Value != null)
                txt790.Text = UserSettings.Where(Data => Data.SettingIX == 790).First().Value;
            else txt790.Text = String.Empty;

            if (UserSettings.Exists(Data => Data.SettingIX == 791) &&
                UserSettings.Where(Data => Data.SettingIX == 791).First().Value != null)
                txt791.Text = UserSettings.Where(Data => Data.SettingIX == 791).First().Value;
            else txt791.Text = String.Empty;

            #endregion

            return true;
        }
        #endregion

        #region Boolean SaveCurrentUserSettings()
        /// <summary>
        /// تابع ذخیره سازی تنظیمات كاربر جاری
        /// </summary>
        private Boolean SaveCurrentUserSettings()
        {
            try
            {
                #region Main Form Settings (100)
                if (cbo101.Tag != null) DBLayerIMS.Manager.DBML.
                    SP_InsertUserSetting(_CurrentUserID, 101, null, cbo101.SelectedIndex.ToString());
                StringBuilder lst102Selects = new StringBuilder();
                for (Int32 i = 0; i < lst102.Items.Count; i++)
                    lst102Selects.Append(Convert.ToInt32(((CheckBoxItem)lst102.Items[i]).Checked));
                DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 102, null, lst102Selects.ToString());
                StringBuilder lst103Selects = new StringBuilder();
                for (Int32 i = 0; i < lst103.Items.Count; i++)
                    lst103Selects.Append(Convert.ToInt32(((CheckBoxItem)lst103.Items[i]).Checked));
                DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 103, null, lst103Selects.ToString());
                if (cbo104.Tag != null) DBLayerIMS.Manager.DBML.
                    SP_InsertUserSetting(_CurrentUserID, 104, null, cbo104.SelectedIndex.ToString());
                if (cBox105.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 105, cBox105.Checked, null);
                // تنظیمات 106 حذف شد
                if (cBox107.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 107, cBox107.Checked, null);
                if (cBox108.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 108, cBox108.Checked, null);
                #endregion

                #region Schedules (200)
                if (cbo201.Tag != null)
                {
                    if (cbo201.SelectedIndex == 0) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 201, null, null);
                    else DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 201, null, cbo201.SelectedValue.ToString());
                }
                StringBuilder lst202Selects = new StringBuilder();
                for (Int32 i = 0; i < lst202.Items.Count; i++)
                    lst202Selects.Append(Convert.ToInt32(((CheckBoxItem)lst202.Items[i]).Checked));
                DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 202, null, lst202Selects.ToString());
                if (cBox203.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 203, cBox203.Checked, null);
                if (txt2051.Tag != null || txt2052.Tag != null)
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 205, null, txt2051.Value + "-" + txt2052.Value);
                #endregion

                #region Patients (300)
                Boolean IsPanel1Modified = false;
                foreach (CheckBoxX ctrl in Panel1.Controls) if (ctrl.Tag != null) IsPanel1Modified = true;
                if (IsPanel1Modified)
                {
                    StringBuilder Panel1Selects = new StringBuilder();
                    foreach (CheckBoxX ctrl in Panel1.Controls)
                    {
                        if (ctrl.Checked) Panel1Selects.Append("1");
                        else Panel1Selects.Append("0");
                    }
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 301, null, Panel1Selects.ToString());
                }
                // كلید 302 حذف گردید
                if (cBox3031.Tag != null || cBox3032.Tag != null)
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 303, cBox3032.Checked, null);
                if (cBox304.Tag != null) DBLayerIMS.Manager.DBML.
                    SP_InsertUserSetting(_CurrentUserID, 304, cBox304.Checked, null);
                if (cBox305.Tag != null) DBLayerIMS.Manager.DBML.
                    SP_InsertUserSetting(_CurrentUserID, 305, cBox305.Checked, null);
                if (cbo306.Tag != null) DBLayerIMS.Manager.DBML.
                    SP_InsertUserSetting(_CurrentUserID, 306, null, cbo306.SelectedIndex.ToString());
                if (cBox307.Tag != null || txt307.Tag != null)
                {
                    String Setting307 = null;
                    if (cBox307.Checked) Setting307 = txt307.Value.ToString();
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 307, null, Setting307);
                }
                #endregion

                #region Referrals (400)
                Boolean IsPanel2Modified = false;
                foreach (CheckBoxX ctrl in Panel2.Controls) if (ctrl.Tag != null) IsPanel2Modified = true;
                if (IsPanel2Modified)
                {
                    StringBuilder Panel2Selects = new StringBuilder();
                    foreach (CheckBoxX ctrl in Panel2.Controls)
                    {
                        if (ctrl.Checked) Panel2Selects.Append("1");
                        else Panel2Selects.Append("0");
                    }
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 401, null, Panel2Selects.ToString());
                }
                // كلید 402 حذف گردید
                if (cBox403.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 403, cBox403.Checked, null);
                // كلید 404 حذف گردید
                if (cBox405.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 405, cBox405.Checked, null);
                if (cBox406.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 406, cBox406.Checked, null);
                if (cBox407.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 407, cBox407.Checked, null);
                if (cBox408.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 408, cBox408.Checked, null);
                if (cBox409.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 409, cBox409.Checked, null);
                if (cBox410.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 410, cBox410.Checked, null);
                #endregion

                #region Account (500)
                // كلید 501 حذف گردید
                // كلید 502 حذف گردید
                if (cBox503.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 503, cBox503.Checked, null);
                if (cBox504.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 504, cBox504.Checked, null);
                if (cBox505.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 505, cBox505.Checked, null);
                if (cbo506.Tag != null)
                {
                    if (cbo506.SelectedIndex == 0) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 506, null, null);
                    else DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 506, null, cbo506.SelectedValue.ToString());
                }
                if (cBox507.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 507, cBox507.Checked, null);
                if (cBox508.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 508, cBox508.Checked, null);
                if (cBox508.Checked) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 509, null, txt509.Text);
                else DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 509, null, null);

                #endregion

                #region Cash Monitor (600)

                if (cBox601.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 601, cBox601.Checked, null);
                if (cBox602.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 602, cBox602.Checked, null);

                if (cBox604.Tag != null) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 604, cBox604.Checked, null);
                if (cBox604.Checked) DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 605, null, txt605.Text);
                else DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 605, null, null);

                if (txtStart603.Tag != null || txtEnd603.Tag != null)
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 603, null, txtStart603.Value + "-" + txtEnd603.Value);
                else DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 603, null, null);
                #endregion

                #region Documents (700)
                if (cBox701.Tag != null) DBLayerIMS.Manager.DBML.
                    SP_InsertUserSetting(_CurrentUserID, 701, cBox701.Checked, null);
                if (cbo702.Tag != null)
                {
                    if (cbo702.SelectedIndex == 0) DBLayerIMS.Manager.DBML.
                        SP_InsertUserSetting(_CurrentUserID, 702, null, null);
                    else DBLayerIMS.Manager.DBML.
                        SP_InsertUserSetting(_CurrentUserID, 702, null, cbo702.SelectedValue.ToString());
                }
                if (cbo703.Tag != null)
                {
                    if (cbo703.SelectedIndex == 0)
                        DBLayerIMS.Manager.DBML.SP_InsertUserSetting(_CurrentUserID, 703, null, null);
                    else DBLayerIMS.Manager.DBML.
                        SP_InsertUserSetting(_CurrentUserID, 703, null, cbo703.SelectedValue.ToString());
                }
                // تنظیم 704 حذف شد
                if (cBox705.Tag != null) DBLayerIMS.Manager.
                    DBML.SP_InsertUserSetting(_CurrentUserID, 705, cBox705.Checked, null);
                if (txtStart706.Tag != null || txtEnd706.Tag != null)
                    DBLayerIMS.Manager.DBML.
                        SP_InsertUserSetting(_CurrentUserID, 706, null, txtStart706.Value + "-" + txtEnd706.Value);
                else DBLayerIMS.Manager.
                    DBML.SP_InsertUserSetting(_CurrentUserID, 706, null, null);
                if (cBox707.Tag != null) DBLayerIMS.Manager.DBML.
                    SP_InsertUserSetting(_CurrentUserID, 707, cBox707.Checked, null);

                if (cBox7501.Tag != null || cBox7502.Tag != null)
                    try
                    {
                        RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                        if (MyKey == null) Registry.CurrentUser.CreateSubKey(_CaptureSetting);
                        MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                        if (MyKey != null) MyKey.SetValue(_CaptureVideoSource, cBox7502.Checked);
                    }
                    catch (Exception) { }
                if (cBox7511.Tag != null || cBox7512.Tag != null)
                    try
                    {
                        RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                        if (MyKey == null) Registry.CurrentUser.CreateSubKey(_CaptureSetting);
                        MyKey = Registry.CurrentUser.OpenSubKey(_CaptureSetting, true);
                        if (MyKey != null) MyKey.SetValue(_CaptureVideoStandard, cBox7512.Checked);
                    }
                    catch (Exception) { }
                if (txt7521.Tag != null || txt7522.Tag != null)
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(
                        null, 752, null, txt7521.Value + "," + txt7522.Value);

                if (txt790.Tag != null)
                {
                    if (txt790.Text[txt790.Text.Length - 1] != '\\') txt790.Text += "\\";
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(null, 790, null, txt790.Text);
                }
                if (txt791.Tag != null)
                    DBLayerIMS.Manager.DBML.SP_InsertUserSetting(null, 791, null, txt791.Text);
                #endregion
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = "امكان ثبت كردن تنظیمات انجام شده در بانك وجود ندارد.\n" +
                                            "موارد زیر را بررسی نمایید:\n" +
                                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "Main Project", Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}