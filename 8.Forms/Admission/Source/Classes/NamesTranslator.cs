#region using

using System;
using System.Globalization;
using System.Windows.Forms;
using Negar;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Sepehr.Forms.Admission.Properties;

#endregion

namespace Sepehr.Forms.Admission.Classes
{
    /// <summary>
    /// فرم ثبت نام یا نام خانوادگی جدید
    /// </summary>
    internal partial class frmNamesTranslator : Form
    {

        #region Fields & Properties

        #region Boolean _IsFormControlsModified
        /// <summary>
        /// تعیین ویرایش شدن مراجعه جاری توسط كاربر از حالت اولیه
        /// </summary>
        private Boolean _IsFormControlsModified;
        #endregion

        #region readonly Boolean _IsFirstName
        private readonly Boolean _IsFirstName;
        #endregion

        #region public String LocaleName
        /// <summary>
        /// نام فارسی تولید شده
        /// </summary>
        public String LocaleName;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم برای ثبت پزشك جدید
        /// </summary>
        public frmNamesTranslator(String LocaleName, Boolean IsFirstName)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            if (String.IsNullOrEmpty(LocaleName)) { Close(); return; }
            _IsFirstName = IsFirstName;
            txtLocaleName.Text = LocaleName;
            txtLocaleName.Focus();
            txtLocaleName.SelectionStart = txtLocaleName.Text.Length;
            txtLocaleName.SelectionLength = 0;
            #region Find English LocaleName
            String EnglishName = Negar.DBLayerPMS.Patients.GetEnglishName(LocaleName, IsFirstName);
            if (!String.IsNullOrEmpty(EnglishName)) txtEnglishName.Text = EnglishName.Trim();
            #endregion
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            SetFormControlsChangeEventHandlers();
            SetControlsToolTipTexts();
            _IsFormControlsModified = false;
        }
        #endregion

        #region FormControls_ValuesChanged
        /// <summary>
        /// دستگیره ی مدیریت ایجاد تغییرات در كنترل های فرم
        /// </summary>
        void FormControls_ValuesChanged(object sender, EventArgs e)
        {
            // در صورتی كه یك مقدار در یك كنترل تغییر كند ، این متغیر تغییر می كند
            _IsFormControlsModified = true;
        }
        #endregion

        #region txtLocaleName_Enter
        private void txtLocaleName_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
        }
        #endregion

        #region txtLocaleName_KeyPress
        private void txtLocaleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
        }
        #endregion

        #region txtEnglishName_Enter
        private void txtEnglishName_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("En-Us"));
        }
        #endregion

        #region txtEnglishName_KeyPress
        private void txtEnglishName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("En-Us"));
        }
        #endregion

        #region Controls_PreviewKeyDown
        private void Controls_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down) SelectNextControl(((Control)sender), true, true, true, true);
            else if (e.KeyCode == Keys.Up) SelectNextControl(((Control)sender), false, true, true, true);
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLocaleName.Text.Trim()) ||
                String.IsNullOrEmpty(txtEnglishName.Text.Trim()))
            {
                PMBox.Show("نام فارسی و انگلیسی را دقیق تكمیل نمایید!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!AddName()) return;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (_IsFormControlsModified)
            {
                DialogResult Dr = PMBox.Show("آیا مایلید بدون ذخیره سازی فرم را ببندید؟",
                    "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (Dr == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            Dispose();
            Cursor.Current = Cursors.Default;
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnSave
            TooltipText = ToolTipManager.GetText("btnAccept", "IMS");
            FormToolTip.SetSuperTooltip(btnSave, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void SetFormControlsChangeEventHandlers()
        /// <summary>
        /// تابعی برای تنظیم رخداد تغییر برای كنترل های روی فرم
        /// </summary>
        private void SetFormControlsChangeEventHandlers()
        {
            foreach (Control ctrl in Controls)
                if (ctrl is TextBoxX) ctrl.TextChanged += (FormControls_ValuesChanged);
        }
        #endregion

        #region Boolean AddName()
        /// <summary>
        /// تابع افزودن ردیف جدید
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean AddName()
        {
            LocaleName = txtLocaleName.Text.Trim().Normalize();
            return Negar.DBLayerPMS.Patients.AddNewNameTranslation(txtLocaleName.Text, txtEnglishName.Text, _IsFirstName);
        }
        #endregion

        #endregion

    }
}