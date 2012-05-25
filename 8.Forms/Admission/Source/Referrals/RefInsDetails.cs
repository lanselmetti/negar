#region using

using System;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Sepehr.DBLayerIMS.DataLayer;
using Sepehr.Forms.Admission.Properties;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرم نمایش خصوصیات بیمه ها
    /// </summary>
    internal partial class frmRefInsDetails : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        /// <param name="InsID">كد بیمه انتخابی</param>
        public frmRefInsDetails(Int16 InsID)
        {
            InitializeComponent();
            if (!FillInsDetailsData(InsID)) { Close(); return; }
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            foreach (Control ctrl in FormPanel.Controls)
                if (ctrl is CheckBoxX)
                    ((CheckBoxX)ctrl).CheckedChanging += (cBoxes_CheckedChanging);
        }
        #endregion

        #region cBoxes_CheckedChanging
        private static void cBoxes_CheckedChanging(object sender, CheckBoxXChangeEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region TextBoxes_KeyPress
        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region void btnCancel_Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

            #region btnCancel
            String TooltipText = ToolTipManager.GetText("btnClose", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region  Boolean FillInsDetailsData(Int16 ID)
        /// <summary>
        /// پر كردن فرم با كد بیمه انتخاب شده
        /// </summary>
        /// <param name="ID">كد بیمه انتخاب شده </param>
        private Boolean FillInsDetailsData(Int16 ID)
        {
            SP_SelectInsFullDataResult InsData = DBLayerIMS.Insurance.InsFullList.Where(Data => Data.ID == ID).ToList().First();

            #region Fill Form Controls

            #region TextBoxes
            txtInsName.Text = InsData.Name;
            txtInsPartLimit.Text = InsData.InsurerPartLimit.ToString();
            txtInsPartLimit.Text = String.Format(InsData.InsurerPartLimit.ToString(), "N0") + " ریال";
            txtPatientPercent.Text = InsData.PatientPercent.ToString();
            txtDescription.Text = InsData.Description;
            #endregion

            #region DateTime
            if (InsData.ContractStartDate.HasValue)
            {
                PersianDate PDate = PersianDateConverter.ToPersianDate(InsData.ContractStartDate.Value.Date);
                DateContract.Text = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
            }
            if (InsData.ContractEndDate.HasValue)
            {
                PersianDate PDate = PersianDateConverter.ToPersianDate(InsData.ContractEndDate.Value.Date);
                DateExpiration.Text = PDate.Year + "/" + PDate.Month + "/" + PDate.Day;
            }
            #endregion

            #region Set Gender Radio Buttons
            if (InsData.IsIns1 == true)
                cBoxIsIns1.Checked = true;
            if (InsData.IsIns2 == true)
                cBoxIsIns2.Checked = true;
            // حالتی كه بیمه انتخابی بیمه دوم نیست
            else
            {
                lblIns2Formula.Visible = false;
                lblDescription.Top = lblIns2Formula.Top;
                txtFormula.Visible = false;
                txtDescription.Top = txtFormula.Top;
                Height -= 26;
            }
            #endregion

            #endregion

            return true;
        }
        #endregion

        #endregion

    }
}