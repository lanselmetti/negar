#region using

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.Utilities;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Sepehr.DBLayerIMS.DataLayer;

#endregion

namespace Sepehr.Forms.Admission.Referrals
{
    /// <summary>
    /// فرم نمایش كامل اطلاعات بیماران
    /// </summary>
    internal partial class frmReferralsAdditionalData : Form
    {

        #region Fields & Properties

        #region readonly Int32 _CurrentRefID
        /// <summary>
        /// كلید مراجعه جاری
        /// </summary>
        private readonly Int32 _CurrentRefID;
        #endregion

        #region readonly frmPatRefManager.CurrentFormState _FormState
        /// <summary>
        /// وضعیت فرم بیماران در سه حالت افزودن , ویرایش و نمایش
        /// </summary>
        private readonly frmPatRefManager.RefFormState _FormState;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده فرم برای ویرایش یا نمایش یك بیمار
        /// </summary>
        /// <param name="RefID">كلید مراجعه بیمار مورد نظر</param>
        /// <param name="FormState">وضعیت نمایش مراجعه</param>
        public frmReferralsAdditionalData(Int32 RefID, frmPatRefManager.RefFormState FormState)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa-Ir"));
            InitializeComponent();
            _FormState = FormState;
            _CurrentRefID = RefID;
            if (_FormState == frmPatRefManager.RefFormState.Viewing) btnSave.Enabled = false;
            #region Edit Referral Additional Data
            //  امكان ویرایش اطلاعات اضافی مراجعه
            else if (SecurityManager.GetCurrentUserPermission(504241) == false)
            {
                _FormState = frmPatRefManager.RefFormState.Viewing;
                btnSave.Enabled = false;
            }
            #endregion
            if (!IsDisposed) ShowDialog();
        }
        #endregion

        #region Event Handlers

        #region Form_Shown
        private void Form_Shown(object sender, EventArgs e)
        {
            if (!FillFormBaseDataSource(_CurrentRefID)) { Close(); return; }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Insert Additional Data
            if (DBLayerIMS.Referrals.RefAddinColsList.Count != 0)
                try
                {
                    // افزودن فیلد های اطلاعاتی اضافی
                    foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                    {
                        if (column.TypeID == 0)
                            DBLayerIMS.Manager.DBML.SP_InsertRefAddinStringData(_CurrentRefID, column.FieldName,
                            PanelAdditionalData.Controls["txt" + column.FieldName].Text);
                        else if (column.TypeID == 1)
                            DBLayerIMS.Manager.DBML.SP_InsertRefAddinBoolData(_CurrentRefID, column.FieldName,
                                ((CheckBoxX)PanelAdditionalData.Controls["cBox" + column.FieldName]).Checked);
                        else if (column.TypeID == 2)
                            DBLayerIMS.Manager.DBML.SP_InsertRefAddinIntData(_CurrentRefID, column.FieldName,
                                ((Int32?)((IntegerInput)PanelAdditionalData.Controls["txt" + column.FieldName]).ValueObject));
                        else if (column.TypeID == 3)
                            DBLayerIMS.Manager.DBML.SP_InsertRefAddinIntData(_CurrentRefID, column.FieldName,
                                ((Int16?)((ComboBox)PanelAdditionalData.Controls["cbo" + column.FieldName]).SelectedValue));
                    }
                }
                #region Catch
                catch (Exception Ex)
                {
                    const String ErrorMessage =
                        "امكان ثبت اطلاعات اضافی مراجعه بیمار در بانك اطلاعات ممكن نیست.\n" +
                        "موارد زیر را بررسی نمایید:\n" +
                        "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                    PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogManager.SaveLogEntry("Sepehr", "Admission Forms", Ex.Message + "\n" +
                        Ex.StackTrace, EventLogEntryType.Error); return;
                }
                #endregion
            #endregion
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Form Closing
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean FillFormBaseDataSource(Int32 RefID)
        /// <summary>
        /// خواندن اطلاعات پایه فرم
        /// </summary>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillFormBaseDataSource(Int32 RefID)
        {
            // خواندن اطلاعات بیمار و مراجعه
            if (!FillPatientAndRefControlsByID(RefID)) return false;
            #region Generate Controls
            // خواندن ستونهای اطلاعات اضافی
            if (DBLayerIMS.Referrals.RefAddinColsList.Count == 0 && PanelAdditionalData.Visible)
            {
                PMBox.Show("فیلد اطلاعاتی اضافی برای مراجعات بیماران تصویربرداری تعریف نشده است!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            // اضافه كردن كنترل های اطلاعات اضافی
            Int32 CtrlHeight = 3;
            for (Int32 i = 0; i < DBLayerIMS.Referrals.RefAddinColsList.Count; i++)
            {
                #region String Value
                if (DBLayerIMS.Referrals.RefAddinColsList[i].TypeID == 0)
                {
                    LabelX lblAdditionalTitle = new LabelX();
                    lblAdditionalTitle.Name = "lbl" + DBLayerIMS.Referrals.RefAddinColsList[i].FieldName;
                    lblAdditionalTitle.Tag = DBLayerIMS.Referrals.RefAddinColsList[i].ID;
                    lblAdditionalTitle.Text = DBLayerIMS.Referrals.RefAddinColsList[i].Title;
                    lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    lblAdditionalTitle.BackColor = Color.Transparent;
                    lblAdditionalTitle.AutoSize = false;
                    lblAdditionalTitle.Size = new Size(PanelAdditionalData.Width - 50, 21);
                    lblAdditionalTitle.Location = new Point(15, CtrlHeight);
                    lblAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                    lblAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                    PanelAdditionalData.Controls.Add(lblAdditionalTitle);
                    CtrlHeight = CtrlHeight + 24;
                    TextBox txtAdditionalData = new TextBox();
                    txtAdditionalData.Name = "txt" + DBLayerIMS.Referrals.RefAddinColsList[i].FieldName;
                    txtAdditionalData.Tag = DBLayerIMS.Referrals.RefAddinColsList[i].ID;
                    txtAdditionalData.AutoSize = false;
                    txtAdditionalData.MaxLength = 48;
                    txtAdditionalData.Size = new Size(PanelAdditionalData.Width - 50, 21);
                    txtAdditionalData.Location = new Point(15, CtrlHeight);
                    txtAdditionalData.Margin = new System.Windows.Forms.Padding(10);
                    txtAdditionalData.Padding = new System.Windows.Forms.Padding(10);
                    PanelAdditionalData.Controls.Add(txtAdditionalData);
                    if (i == 0) txtAdditionalData.Focus();
                    CtrlHeight = CtrlHeight + 24;
                }
                #endregion

                #region Boolean Value
                else if (DBLayerIMS.Referrals.RefAddinColsList[i].TypeID == 1)
                {
                    CheckBoxX cBoxAdditionalTitle = new CheckBoxX();
                    cBoxAdditionalTitle.Name = "cBox" + DBLayerIMS.Referrals.RefAddinColsList[i].FieldName;
                    cBoxAdditionalTitle.Tag = DBLayerIMS.Referrals.RefAddinColsList[i].ID;
                    cBoxAdditionalTitle.Text = DBLayerIMS.Referrals.RefAddinColsList[i].Title;
                    cBoxAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    cBoxAdditionalTitle.BackColor = Color.Transparent;
                    cBoxAdditionalTitle.AutoSize = false;
                    cBoxAdditionalTitle.Size = new Size(PanelAdditionalData.Width - 50, 21);
                    cBoxAdditionalTitle.Location = new Point(15, CtrlHeight);
                    cBoxAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                    cBoxAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                    PanelAdditionalData.Controls.Add(cBoxAdditionalTitle);
                    if (i == 0) cBoxAdditionalTitle.Focus();
                    CtrlHeight = CtrlHeight + 24;
                }
                #endregion

                #region Integer Value
                else if (DBLayerIMS.Referrals.RefAddinColsList[i].TypeID == 2)
                {
                    LabelX lblAdditionalTitle = new LabelX();
                    lblAdditionalTitle.Name = "lbl" + DBLayerIMS.Referrals.RefAddinColsList[i].FieldName;
                    lblAdditionalTitle.Tag = DBLayerIMS.Referrals.RefAddinColsList[i].ID;
                    lblAdditionalTitle.Text = DBLayerIMS.Referrals.RefAddinColsList[i].Title;
                    lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    lblAdditionalTitle.BackColor = Color.Transparent;
                    lblAdditionalTitle.AutoSize = false;
                    lblAdditionalTitle.Size = new Size(PanelAdditionalData.Width - 50, 21);
                    lblAdditionalTitle.Location = new Point(15, CtrlHeight);
                    lblAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                    lblAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                    PanelAdditionalData.Controls.Add(lblAdditionalTitle);
                    CtrlHeight = CtrlHeight + 24;
                    IntegerInput txtAdditionalData = new IntegerInput();
                    txtAdditionalData.Name = "txt" + DBLayerIMS.Referrals.RefAddinColsList[i].FieldName;
                    txtAdditionalData.Tag = DBLayerIMS.Referrals.RefAddinColsList[i].ID;
                    txtAdditionalData.AutoSize = false;
                    txtAdditionalData.MaxValue = 2147483647;
                    txtAdditionalData.ShowUpDown = true;
                    txtAdditionalData.InputHorizontalAlignment = eHorizontalAlignment.Center;
                    txtAdditionalData.Size = new Size(PanelAdditionalData.Width - 50, 21);
                    txtAdditionalData.Location = new Point(15, CtrlHeight);
                    txtAdditionalData.Margin = new System.Windows.Forms.Padding(10);
                    txtAdditionalData.Padding = new System.Windows.Forms.Padding(10);
                    PanelAdditionalData.Controls.Add(txtAdditionalData);
                    if (i == 0) txtAdditionalData.Focus();
                    CtrlHeight = CtrlHeight + 24;
                }
                #endregion

                #region MultiChoice Value
                else if (DBLayerIMS.Referrals.RefAddinColsList[i].TypeID == 3)
                {
                    LabelX lblAdditionalTitle = new LabelX();
                    lblAdditionalTitle.Name = "lbl" + DBLayerIMS.Referrals.RefAddinColsList[i].FieldName;
                    lblAdditionalTitle.Tag = DBLayerIMS.Referrals.RefAddinColsList[i].ID;
                    lblAdditionalTitle.Text = DBLayerIMS.Referrals.RefAddinColsList[i].Title;
                    lblAdditionalTitle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    lblAdditionalTitle.BackColor = Color.Transparent;
                    lblAdditionalTitle.AutoSize = false;
                    lblAdditionalTitle.Size = new Size(PanelAdditionalData.Width - 50, 21);
                    lblAdditionalTitle.Location = new Point(15, CtrlHeight);
                    lblAdditionalTitle.Margin = new System.Windows.Forms.Padding(10);
                    lblAdditionalTitle.Padding = new System.Windows.Forms.Padding(10);
                    PanelAdditionalData.Controls.Add(lblAdditionalTitle);
                    CtrlHeight = CtrlHeight + 24;
                    ComboBox cboAdditionalData = new ComboBox();
                    cboAdditionalData.Name = "cbo" + DBLayerIMS.Referrals.RefAddinColsList[i].FieldName;
                    cboAdditionalData.Tag = DBLayerIMS.Referrals.RefAddinColsList[i].ID;
                    cboAdditionalData.AutoSize = false;
                    cboAdditionalData.Size = new Size(PanelAdditionalData.Width - 50, 21);
                    cboAdditionalData.Location = new Point(15, CtrlHeight);
                    cboAdditionalData.Margin = new System.Windows.Forms.Padding(10);
                    cboAdditionalData.Padding = new System.Windows.Forms.Padding(10);
                    cboAdditionalData.DropDownStyle = ComboBoxStyle.DropDownList;
                    cboAdditionalData.FlatStyle = FlatStyle.Standard;
                    cboAdditionalData.ValueMember = "ID";
                    cboAdditionalData.DisplayMember = "Title";
                    cboAdditionalData.DataSource = DBLayerIMS.Manager.DBML.
                        SP_SelectRefMultiSelectItems(DBLayerIMS.Referrals.RefAddinColsList[i].ID).ToList();
                    PanelAdditionalData.Controls.Add(cboAdditionalData);
                    if (i == 0) cboAdditionalData.Focus();
                    CtrlHeight = CtrlHeight + 24;
                }
                #endregion
            }
            #endregion

            #region Read & Fill Data
            if (_FormState == frmPatRefManager.RefFormState.AddingPatRef) return true;
            DataTable TempDataTable = DBLayerIMS.Manager.ExecuteQuery(
                "EXECUTE [Referrals].[SP_SelectRefAdditionalData] " + RefID, 10);
            if (TempDataTable == null)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات اضافی مراجعات تصویربرداری بیمار از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            if (TempDataTable.Rows.Count != 0)
                foreach (RefAdditionalColumn column in DBLayerIMS.Referrals.RefAddinColsList)
                {
                    if (column.TypeID == 0) PanelAdditionalData.Controls["txt" + column.FieldName].Text =
                        TempDataTable.Rows[0][column.FieldName].ToString();
                    else if (column.TypeID == 1)
                        ((CheckBoxX)PanelAdditionalData.Controls["cBox" + column.FieldName]).Checked =
                            Convert.ToBoolean(TempDataTable.Rows[0][column.FieldName]);
                    else if (column.TypeID == 2)
                    {
                        Object Data = TempDataTable.Rows[0][column.FieldName];
                        if (Data != null && Data != DBNull.Value)
                            ((IntegerInput)PanelAdditionalData.Controls["txt" + column.FieldName]).ValueObject = (Int32?)Data;
                    }
                    else if (column.TypeID == 3)
                    {
                        Object Data = TempDataTable.Rows[0][column.FieldName];
                        if (Data != null && Data != DBNull.Value)
                            ((ComboBox)PanelAdditionalData.Controls["cbo" + column.FieldName]).SelectedValue = (Int16)Data;
                    }
                }
            #endregion

            #region Change Form State
            if (_FormState == frmPatRefManager.RefFormState.Viewing)
                foreach (Control ctrl in PanelAdditionalData.Controls)
                {
                    if (ctrl is CheckBoxX || ctrl is IntegerInput || ctrl is ComboBox) ctrl.Enabled = false;
                    else if (ctrl is TextBox) ((TextBox)ctrl).ReadOnly = true;
                }
            #endregion
            return true;
        }
        #endregion

        #region Boolean FillPatientAndRefControlsByID(Int32 RefID)
        /// <summary>
        /// تابع خواندن اطلاعات بیمار
        /// </summary>
        /// <param name="RefID">كلید بیمار</param>
        /// <returns>صحت انجام كار</returns>
        private Boolean FillPatientAndRefControlsByID(Int32 RefID)
        {
            #region Try Fill Data
            RefList RefData = DBLayerIMS.Referrals.GetRefDataByID(RefID);
            if (RefData == null)
            {
                PMBox.Show("مراجعه ای با كلید ارسال شده وجود ندارد!", "خطا!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            PatList _CurrentPatientData = Negar.DBLayerPMS.Patients.GetPatFullDataByPatListID(RefData.PatientIX);
            if (_CurrentPatientData == null)
            {
                const String ErrorMessage = "امكان خواندن اطلاعات بیمار مورد نظر از بانك اطلاعات ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
            }
            #endregion

            #region Fill Controls

            PersianDate PersianDate = RefData.RegisterDate.ToPersianDate();
            txtRefDate.Text = PersianDate.Hour + ":" + PersianDate.Minute + ":" + PersianDate.Second + " - " +
                PersianDate.Year + "/" + PersianDate.Month + "/" + PersianDate.Day;

            #region Patient ID
            if (!txtPatientID.IsDisposed)
            {
                if (_CurrentPatientData.PatientID != null) txtPatientID.Text = _CurrentPatientData.PatientID;
                else txtPatientID.Text = String.Empty;
            }
            #endregion

            #region First Name & Last Name
            if (!String.IsNullOrEmpty(_CurrentPatientData.FirstName))
                txtPatientFullName.Text = _CurrentPatientData.FirstName + " " + _CurrentPatientData.LastName;
            else txtPatientFullName.Text = _CurrentPatientData.LastName;
            #endregion

            #region Birth Year
            if ((_CurrentPatientData.BirthDate) != null)
            {
                PersianDate = _CurrentPatientData.BirthDate.Value.ToPersianDate();
                txtBirthDate.Text = PersianDate.Year + "/" + PersianDate.Month + "/" + PersianDate.Day;
            }
            #endregion

            #endregion

            return true;
        }
        #endregion

        #endregion

    }
}