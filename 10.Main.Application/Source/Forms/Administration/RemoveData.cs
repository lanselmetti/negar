#region using
using System;
using System.Text;
using System.Windows.Forms;
using Negar;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using Sepehr.Properties;
#endregion

namespace Sepehr.Forms.Administration
{
    /// <summary>
    /// فرم بازیابی فایل پشتیبانی بانك اطلاعاتی
    /// </summary>
    public partial class frmRemoveData : Form
    {

        #region Fields

        #region readonly TreeNode _DevelopersTreeNode
        /// <summary>
        /// گره ویژه برنامه نویسی
        /// </summary>
        private readonly TreeNode _DevelopersTreeNode;
        #endregion

        #region StringBuilder _DeleteString
        /// <summary>
        /// رشته فرمان برای حذف اطلاعات
        /// </summary>
        private StringBuilder _DeleteString;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض فرم
        /// </summary>
        public frmRemoveData()
        {
            InitializeComponent();
            _DevelopersTreeNode = TreeViewOptions.Nodes[1];
            TreeViewOptions.Nodes.Remove(TreeViewOptions.Nodes[1]);
            #region Set DateTime.Now
            PersianDate PersianMonthBeginDate = DateTime.Now.ToPersianDate();
            PersianMonthBeginDate.Year -= 1;
            PersianMonthBeginDate.Day = 1;
            PersianMonthBeginDate.Month = 1;
            DateTime GregorianMonthBeginDate = PersianMonthBeginDate.ToGregorianDateTime();
            FromDateRef.SelectedDateTime = GregorianMonthBeginDate;
            PersianMonthBeginDate.Month = 12;
            try { PersianMonthBeginDate.Day = PersianMonthBeginDate.MonthDays; }
            catch (Exception)
            { PersianMonthBeginDate.Day = PersianMonthBeginDate.MonthDays - 1; }
            GregorianMonthBeginDate = PersianMonthBeginDate.ToGregorianDateTime();
            ToDateRef.SelectedDateTime = GregorianMonthBeginDate;
            FromTimeRef.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            ToTimeRef.Value = new DateTime(2000, 1, 1, 23, 59, 59);
            #endregion
            ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            SetControlsToolTipTexts();
            TreeViewOptions.ExpandAll();
        }
        #endregion

        #region btnDev_Click
        private void btnDev_Click(object sender, EventArgs e)
        {
            if (TreeViewOptions.Nodes.Contains(_DevelopersTreeNode))
            {
                TreeViewOptions.Nodes.Remove(_DevelopersTreeNode);
                return;
            }
            DialogResult Result =
                PMBox.Show("كدام گزینه؟!!!", "مخصوص برنامه نویسان!",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (Result == DialogResult.No) TreeViewOptions.Nodes.Add(_DevelopersTreeNode);
        }
        #endregion

        #region btnAccept_Click
        private void btnAccept_Click(object sender, EventArgs e)
        {
            GenerateDeleteDataString();
            if (String.IsNullOrEmpty(_DeleteString.ToString()))
            {
                PMBox.Show("هیچ گزینه ای برای اعمال حذف بر روی اطلاعات انتخاب نشده است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult Result = PMBox.Show("آیا نسبت به حذف اطلاعات انتخاب شده اطمینان دارید؟!", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result == DialogResult.No) return;
            Result = PMBox.Show("با حذف اطلاعات امكان بازگشت اطلاعات وجود ندارد!\n" +
                "آیا هنوز نسبت به حذف اطلاعات انتخاب شده اطمینان دارید؟!", "پرسش؟",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Result == DialogResult.No) return;
            Enabled = false;
            ProgressBarForm.ProgressType = eProgressItemType.Marquee;
            ProgressBarForm.Text = "در حال حذف اطلاعات";
            BGWorker.RunWorkerAsync();
        }
        #endregion

        #region BGWorker_DoWork
        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (!Negar.DBLayerPMS.Manager.ExecuteCommand(_DeleteString.ToString(), 0)) e.Cancel = true;
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                PMBox.Show("حذف اطلاعات با خطا مواجه شد!", "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else PMBox.Show("حذف اطلاعات با موفقیت انجام شد!", "تبریك!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProgressBarForm.ProgressType = eProgressItemType.Standard;
            Enabled = true;
            ProgressBarForm.Text = "در انتظار حذف اطلاعات";
            BringToFront();
            Focus();
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
            TooltipText = ToolTipManager.GetText("btnCancel_NoApply", "IMS");
            FormToolTip.SetSuperTooltip(btnCancel, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

            #region btnAccept
            TooltipText = ToolTipManager.GetText("btnRemoveData", "IMS");
            FormToolTip.SetSuperTooltip(btnAccept, new SuperTooltipInfo(TooltipHeader, TooltipFooter, TooltipText,
                Resources.Help, Resources.SepehrIcon, eTooltipColor.Lemon));
            #endregion

        }
        #endregion

        #region void GenerateDeleteDataString()
        /// <summary>
        /// تابعی برای حذف اطلاعات بیمار بر اساس تنظیمات انتخاب شده
        /// </summary>
        private void GenerateDeleteDataString()
        {
            _DeleteString = new StringBuilder();
            #region User Removing
            // حذف اطلاعات مراجعات بیماران
            if (TreeViewOptions.Nodes["NodeRefData"].Checked)
            {
                DateTime DateBegin = new DateTime(FromDateRef.SelectedDateTime.Value.Year,
                    FromDateRef.SelectedDateTime.Value.Month, FromDateRef.SelectedDateTime.Value.Day,
                    FromTimeRef.Value.Hour, FromTimeRef.Value.Minute, FromTimeRef.Value.Second);
                DateTime DateEnd = new DateTime(ToDateRef.SelectedDateTime.Value.Year,
                    ToDateRef.SelectedDateTime.Value.Month, ToDateRef.SelectedDateTime.Value.Day,
                    ToTimeRef.Value.Hour, ToTimeRef.Value.Minute, ToTimeRef.Value.Second);
                _DeleteString.Append("USE [ImagingSystem]; ");
                _DeleteString.Append("DELETE FROM [ImagingSystem].[Referrals].[List] " +
                    "WHERE [RegisterDate] >= '" + DateBegin.ToString("yyyy/MM/dd HH:mm:ss") +
                    "' AND [RegisterDate] <= '" + DateEnd.ToString("yyyy/MM/dd HH:mm:ss") + "'; ");
            }
            #endregion

            #region Developer Removing
            if (TreeViewOptions.Nodes.Contains(_DevelopersTreeNode) && TreeViewOptions.Nodes[1].Checked)
            {
                if (TreeViewOptions.Nodes[1].Nodes["NodePMS"].Checked)
                    _DeleteString.Append(Resources.ResourceManager.GetString("PMSClearCommand"));
                if (TreeViewOptions.Nodes[1].Nodes["NodeIMS"].Checked)
                    _DeleteString.Append(Resources.ResourceManager.GetString("IMSClearCommand"));
            }
            #endregion
        }
        #endregion

        #endregion

    }
}