#region using

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negar.DBLayerPMS.DataLayer;
using Negar.PersianCalendar.UI.Controls;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;

#endregion

namespace Sepehr.Forms.Admission.Patients
{
    /// <summary>
    /// فرم مدیریت بیماران - بخش مدیریت وضعیت فرم از نظر ظاهر
    /// </summary>
    internal partial class frmPatients
    {

        #region Methods

        #region void ChangeToAddingState()
        /// <summary>
        /// تابع تغییر حالت کنترل های فرم به افزودن
        /// </summary>
        private void ChangeToAddingState()
        {
            Text = "پذیرش - مدیریت بیماران - ثبت پرونده بیمار جدید";
            #region Make Buttons
            if (!btnNewPatient.IsDisposed) btnNewPatient.Text = "ثبت و جدید (F2)";
            if (!btnEditMode.IsDisposed) btnEditMode.Text = "ثبت (F3)";
            if (!btnDeletePatient.IsDisposed)
            {
                btnEditMode.ShowSubItems = false;
                btnDeletePatient.Visible = false;
            }
            if (!btnFreePatient.IsDisposed) btnFreePatient.Visible = false;
            if (!btnRefresh.IsDisposed) btnRefresh.Visible = false;
            if (!btnSchList.IsDisposed) btnSchList.Visible = false;
            RibbonBarNavigation.Invalidate();
            #endregion

            #region Set TabPanelBasicData Controls Properties
            foreach (Control ctrl in TabPanelBasicData.Controls)
            {
                #region TextBoxX
                if (ctrl is TextBoxX)
                {
                    ctrl.Text = String.Empty;
                    ((TextBoxX)ctrl).ReadOnly = false;
                    ctrl.BackColor = Color.White;
                }
                #endregion

                #region IntegerInput
                else if (ctrl is IntegerInput)
                {
                    ((IntegerInput)ctrl).IsInputReadOnly = false;
                    ((IntegerInput)ctrl).ValueObject = null;
                }
                #endregion

                #region ComboBox
                else if (ctrl is ComboBox)
                {
                    if (((ComboBox)ctrl).Items.Count > 1)
                        ((ComboBox)ctrl).SelectedIndex = 0;
                    ctrl.Text = String.Empty;
                    ComboBox cbo = (ComboBox)ctrl;
                    SetComboBoxReadOnly(cbo, false);
                }
                #endregion

                #region PersianDatePicker
                else if (ctrl is PersianDatePicker)
                {
                    ((PersianDatePicker)ctrl).SelectedDateTime = null;
                    ((PersianDatePicker)ctrl).IsReadonly = false;
                }
                #endregion

                #region Search In Panel
                else if (ctrl is Panel)
                {
                    foreach (Control cBox in ctrl.Controls)
                    {
                        if (cBox is RadioButton)
                        {
                            ((RadioButton)cBox).Checked = false;
                            ctrl.Enabled = true;
                        }
                    }
                }
                #endregion

                #region ButtonX
                else if (ctrl is ButtonX) ctrl.Enabled = true;
                #endregion
            }
            cboJob.DataSource =
                Negar.DBLayerPMS.Patients.PatientsJobsList.Where(Data => Data.IsActive == true).ToList();
            cboJob.SelectedIndex = 0;
            #endregion

            #region Set TabPanelContactData Controls Properties
            foreach (Control ctrl in TabPanelContactData.Controls)
            {
                if (ctrl is TextBoxX)
                {
                    ctrl.Text = String.Empty;
                    ((TextBoxX)ctrl).ReadOnly = false;
                    ctrl.BackColor = Color.White;
                }
            }
            SetComboBoxReadOnly(cboCountry, false);
            cboCountry.DataSource = Negar.DBLayerPMS.Patients.CountriesList.
                    Where(Data => Data.IsActive == true).ToList();
            cboState.SelectedIndexChanged -= cboState_SelectedIndexChanged;
            cboState.SelectedIndexChanged += cboState_SelectedIndexChanged;
            cboCountry.SelectedIndexChanged -= cboCountry_SelectedIndexChanged;
            cboCountry.SelectedIndexChanged += cboCountry_SelectedIndexChanged;
            cboCountry_SelectedIndexChanged(null, null);
            cboState_SelectedIndexChanged(null, null);
            #endregion

            #region Set TabPanelAddInData Controls Properties
            if (TabPanelAddInData.Controls.Count != 0)
            {
                if (_CanEditPatientAdditionData)
                {
                    foreach (Control ctrl in TabPanelAddInData.Controls)
                        if (ctrl is TextBox)
                        {
                            ctrl.Text = String.Empty;
                            ((TextBox)ctrl).ReadOnly = false;
                            ctrl.BackColor = Color.White;
                        }
                        else if (ctrl is CheckBoxX)
                        {
                            ((CheckBoxX)ctrl).Checked = false;
                            ctrl.Enabled = true;
                        }
                        else if (ctrl is IntegerInput)
                        {
                            ((IntegerInput)ctrl).ValueObject = null;
                            ctrl.Enabled = true;
                        }
                        else if (ctrl is ComboBox)
                        {
                            ((ComboBox)ctrl).SelectedIndex = 0;
                            ctrl.Enabled = true;
                        }
                }
                else
                {
                    foreach (Control ctrl in TabPanelAddInData.Controls)
                        if (ctrl is TextBox)
                        {
                            ctrl.Text = String.Empty;
                            ((TextBox)ctrl).ReadOnly = true;
                        }
                        else if (ctrl is CheckBoxX)
                        {
                            ((CheckBoxX)ctrl).Checked = false;
                            ctrl.Enabled = false;
                        }
                }
            }
            #endregion

            _CurrentPatientData = new PatList();
            _CurrentPatientData.PatDetail = new PatDetail();
            txtPatientID.TextBox.Text = String.Empty;
            dgvData.DataSource = null;
            TabCtrlPatientData.SelectedTabIndex = 0;
            TabCtrlPatientData.Focus();
            TabPanelBasicData.Focus();
            txtFirstName.Focus();
            _IsCurrentPatModified = false;
            cBoxEnterPatientAge_CheckedChanged(null, null);
        }
        #endregion

        #region void ChangeToViewState()
        /// <summary>
        /// تغییر حالت کنترل های فرم به حالت نمایش
        /// </summary>
        private void ChangeToViewState()
        {
            Text = "پذیرش - مدیریت بیماران - نمایش بیمار ثبت شده";

            #region Make Buttons
            if (!btnNewPatient.IsDisposed) btnNewPatient.Text = "بیمار جدید (F2)";
            if (!btnEditMode.IsDisposed) btnEditMode.Text = "ویرایش (F3)";
            if (!btnDeletePatient.IsDisposed)
            {
                btnEditMode.ShowSubItems = true;
                btnDeletePatient.Visible = true;
            }
            if (!btnFreePatient.IsDisposed) btnFreePatient.Visible = true;
            if (!btnSchList.IsDisposed) btnSchList.Visible = true;
            if (!btnRefresh.IsDisposed) btnRefresh.Visible = true;
            RibbonBarNavigation.Invalidate();
            #endregion

            #region Set TabPanelBasicData Controls Properties
            foreach (Control ctrl in TabPanelBasicData.Controls)
            {
                if (ctrl is TextBoxX)
                {
                    ((TextBoxX)ctrl).ReadOnly = true;
                    ctrl.BackColor = Color.Gainsboro;
                }
                else if (ctrl is IntegerInput)
                    ((IntegerInput)ctrl).IsInputReadOnly = true;
                else if (ctrl is ComboBox)
                {
                    ComboBox cbo = (ComboBox)ctrl;
                    SetComboBoxReadOnly(cbo, true);
                }
                else if (ctrl is PersianDatePicker) ((PersianDatePicker)ctrl).IsReadonly = true;
                else if (ctrl is ButtonX) ctrl.Enabled = false;
                else if (ctrl is Panel)
                {
                    foreach (Control cBox in ctrl.Controls)
                        if (cBox is RadioButton) ctrl.Enabled = false;
                }
            }
            #endregion

            #region Set TabPanelContactData Controls Properties
            foreach (Control ctrl in TabPanelContactData.Controls)
                if (ctrl is TextBoxX)
                {
                    ((TextBoxX)ctrl).ReadOnly = true;
                    ctrl.BackColor = Color.Gainsboro;
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox cbo = (ComboBox)ctrl;
                    SetComboBoxReadOnly(cbo, true);
                }
            #endregion

            #region Set TabPanelAddInData Controls Properties
            if (TabPanelAddInData.Controls.Count != 0)
                foreach (Control ctrl in TabPanelAddInData.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).ReadOnly = true;
                        ctrl.BackColor = Color.Gainsboro;
                    }
                    else if (ctrl is CheckBoxX || ctrl is IntegerInput || ctrl is ComboBox) ctrl.Enabled = false;
                }
            #endregion

            _CurrentSchAppointmentID = null;
            TabCtrlPatientData.SelectedTabIndex = 0;
            TabPanelBasicData.Focus();
            txtFirstName.Focus();
            _IsCurrentPatModified = false;
            cBoxEnterPatientAge_CheckedChanged(null, null);
        }
        #endregion

        #region void ChangeToEditState()
        /// <summary>
        /// تغییر حالت کنترل های فرم به حالت ویرایش
        /// </summary>
        private void ChangeToEditState()
        {
            Text = "پذیرش - مدیریت بیماران - ویرایش بیمار ثبت شده";

            #region Make Buttons
            if (!btnNewPatient.IsDisposed) btnNewPatient.Text = "ثبت و جدید (F2)";
            if (!btnEditMode.IsDisposed) btnEditMode.Text = "ثبت (F3)";
            if (!btnDeletePatient.IsDisposed)
            {
                btnEditMode.ShowSubItems = false;
                btnDeletePatient.Visible = false;
            }
            if (!btnFreePatient.IsDisposed) btnFreePatient.Visible = false;
            if (!btnRefresh.IsDisposed) btnRefresh.Visible = false;
            if (!btnSchList.IsDisposed) btnSchList.Visible = true;
            RibbonBarNavigation.Invalidate();
            #endregion

            #region Set TabPanelBasicData Controls Properties
            foreach (Control ctrl in TabPanelBasicData.Controls)
            {
                if (ctrl is TextBoxX)
                {
                    ((TextBoxX)ctrl).ReadOnly = false;
                    ctrl.BackColor = Color.White;
                }
                else if (ctrl is IntegerInput)
                    ((IntegerInput)ctrl).IsInputReadOnly = false;
                else if (ctrl is ComboBox)
                {
                    ComboBox cbo = (ComboBox)ctrl;
                    SetComboBoxReadOnly(cbo, false);
                }
                else if (ctrl is PersianDatePicker) ((PersianDatePicker)ctrl).IsReadonly = false;
                else if (ctrl is ButtonX) ctrl.Enabled = true;
                else if (ctrl is Panel) foreach (Control cBox in ctrl.Controls) if (cBox is RadioButton) ctrl.Enabled = true;
            }
            #endregion

            #region Set TabPanelContactData Controls Properties
            foreach (Control ctrl in TabPanelContactData.Controls)
                if (ctrl is TextBoxX)
                {
                    ((TextBoxX)ctrl).ReadOnly = false;
                    ctrl.BackColor = Color.White;
                }
            SetComboBoxReadOnly(cboCountry, false);
            if (cboCountry.SelectedIndex > 0)
            {
                SetComboBoxReadOnly(cboState, false);
                SetComboBoxReadOnly(cboCity, false);
            }
            #endregion

            #region Set TabPanelAddInData Controls Properties
            if (TabPanelAddInData.Controls.Count != 0)
            {
                if (_CanEditPatientAdditionData)
                    foreach (Control ctrl in TabPanelAddInData.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            ((TextBox)ctrl).ReadOnly = false;
                            ctrl.BackColor = Color.White;
                        }
                        else if (ctrl is CheckBoxX || ctrl is IntegerInput || ctrl is ComboBox) ctrl.Enabled = true;
                    }
                else
                    foreach (Control ctrl in TabPanelAddInData.Controls)
                    {
                        if (ctrl is TextBox) ((TextBox)ctrl).ReadOnly = true;
                        else if (ctrl is CheckBoxX || ctrl is IntegerInput || ctrl is ComboBox) ctrl.Enabled = false;
                    }
            }
            #endregion

            _CurrentSchAppointmentID = null;
            _IsCurrentPatModified = false;
            cBoxEnterPatientAge_CheckedChanged(null, null);
        }
        #endregion

        #region static void SetComboBoxReadOnly(ComboBox cbo, Boolean Readonly)
        /// <summary>
        /// تابع فعال سازی و غیرفعال سازی كمبوباكس
        /// </summary>
        /// <param name="cbo">رفرنس كمبوباكس</param>
        /// <param name="Readonly">تعیین غیر فعال سازی</param>
        private static void SetComboBoxReadOnly(ComboBox cbo, Boolean Readonly)
        {
            if (Readonly)
            {
                cbo.KeyDown -= (cbo_KeyDown);
                cbo.KeyPress -= (cbo_KeyPress);
                cbo.KeyDown += (cbo_KeyDown);
                cbo.KeyPress += (cbo_KeyPress);
                cbo.ContextMenu = new ContextMenu();
                cbo.AccessibleDescription = cbo.DropDownStyle.ToString();
                cbo.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                cbo.KeyDown -= (cbo_KeyDown);
                cbo.KeyPress -= (cbo_KeyPress);
                cbo.ContextMenu = null;
                if (cbo.AccessibleDescription == "DropDown")
                    cbo.DropDownStyle = ComboBoxStyle.DropDown;
                else cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            cbo.Invalidate();
        }

        static void cbo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Delete)
                e.Handled = true;
        }

        static void cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #endregion

    }
}