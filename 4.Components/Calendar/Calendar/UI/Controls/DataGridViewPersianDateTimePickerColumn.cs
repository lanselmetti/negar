#region using

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Negar.PersianCalendar.Utilities;

#endregion

namespace Negar.PersianCalendar.UI.Controls
{

    #region public class DataGridViewPersianDateTimePickerColumn : DataGridViewColumn
    /// <summary>
    /// كلاس تقویم پارسی كنترل جدول رایان پرتونگار
    /// </summary>
    [ToolboxBitmap(typeof(DataGridViewPersianDateTimePickerColumn),
        "Images\\DataGridViewPersianDateTimePickerColumn.bmp")]
    [Description("كلاس تقویم پارسی كنترل جدول رایان پرتونگار")]
    [ToolboxItem(typeof(DataGridViewColumn))]
    public class DataGridViewPersianDateTimePickerColumn : DataGridViewColumn
    {

        #region Fields

        private DataGridViewPersianDateTimePickerCell _dgvPersianDateTimePickerCell;
        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public DataGridViewPersianDateTimePickerColumn()
            : base(new DataGridViewPersianDateTimePickerCell())
        {
            _dgvPersianDateTimePickerCell = new DataGridViewPersianDateTimePickerCell();
            ShowTime = true;
        }
        #endregion

        #region Properties

        #region Boolean ShowTime
        /// <summary>
        /// نمایش ساعت كنترل
        /// </summary>
        [Description("تعیین نمایش ساعت كنترل")]
        [Category("تنظیمات كنترل")]
        public Boolean ShowTime { get; set; }
        #endregion

        #region public override DataGridViewCell CellTemplate
        /// <summary>
        /// تعیین تنظیمات قالب سلول ها
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get { return _dgvPersianDateTimePickerCell; }
            set
            {
                _dgvPersianDateTimePickerCell = (DataGridViewPersianDateTimePickerCell)value;
                base.CellTemplate = value;
            }
        }
        #endregion

        #endregion

        #region Overrided Methods

        #region public override String ToString()
        /// <summary>
        /// مقدار رشته ای ردیف مورد نظر را باز میگرداند
        /// </summary>
        public override String ToString()
        {
            var StringCollection = new StringBuilder(64);
            StringCollection.Append("DataGridViewPersianDateTimePickerCell { Name=");
            StringCollection.Append(Name);
            StringCollection.Append(", Index=");
            StringCollection.Append(Index.ToString(CultureInfo.CurrentCulture));
            StringCollection.Append(" }");
            return StringCollection.ToString();
        }
        #endregion

        #endregion
    }
    #endregion

    #region public class DataGridViewPersianDateTimePickerCell : DataGridViewTextBoxCell
    public class DataGridViewPersianDateTimePickerCell : DataGridViewTextBoxCell
    {

        #region Fields
        private static readonly Type _EditType = typeof(DataGridViewPersianDateTimePickerEditor);
        private static readonly Type _ValueType = typeof(DateTime);
        #endregion

        #region Properties

        #region DateTime? SelectedDateTime
        public DateTime? SelectedDateTime { get; set; }
        #endregion

        #region public override Type EditType
        public override Type EditType
        {
            get { return _EditType; }
        }
        #endregion

        #region public override Type ValueType
        public override Type ValueType
        {
            get { return _ValueType; }
        }
        #endregion

        #region private DataGridViewPersianDateTimePickerEditor EditingPersianDatePicker
        /// <summary>
        /// Returns the current DataGridView EditingControl as a 
        /// DataGridViewPersianDateTimePickerEditor control
        /// </summary>
        private DataGridViewPersianDateTimePickerEditor EditingPersianDatePicker
        {
            get { return DataGridView.EditingControl as DataGridViewPersianDateTimePickerEditor; }
        }
        #endregion

        #endregion

        #region Methods

        #region public override void InitializeEditingControl(...)
        public override void InitializeEditingControl(Int32 rowIndex, object initialFormattedValue,
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewPersianDateTimePickerEditor editor =
                (DataGridViewPersianDateTimePickerEditor)DataGridView.EditingControl;
            if (editor != null)
            {
                editor.RightToLeft = DataGridView.RightToLeft;
                String formattedValue = initialFormattedValue.ToString();
                if (String.IsNullOrEmpty(formattedValue))
                {
                    editor.SelectedDateTime = null;
                    editor._PersianMonthViewContainer.MonthViewControl.SelectedDateTime = null;
                }
                else editor.SelectedDateTime = Convert.ToDateTime(formattedValue);
            }
        }
        #endregion

        #region protected override void Paint(...)
        protected override void Paint(Graphics graphics, Rectangle clipBounds,
            Rectangle cellBounds, Int32 rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
            String errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            if (DataGridView == null || DataGridView.Visible == false) return;
            // First paint the borders and background of the cell.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
                formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~(DataGridViewPaintParts.ErrorIcon |
                DataGridViewPaintParts.ContentForeground));

            Point ptCurrentCell = DataGridView.CurrentCellAddress;
            Boolean cellCurrent = ptCurrentCell.X == ColumnIndex && ptCurrentCell.Y == rowIndex;
            Boolean cellEdited = cellCurrent && DataGridView.EditingControl != null;

            // اگر سلول در حالت ویرایش باشد ، بخش دیگری رسم نمیگردد
            if (!cellEdited && value != null && !String.IsNullOrEmpty(value.ToString()))
            {
                PersianDate pd = null;
                if (value is DateTime) pd = Convert.ToDateTime(value);
                else if (value is String) pd = PersianDate.Parse(value.ToString());

                if (pd != null)
                {
                    using (SolidBrush brFG = new SolidBrush(cellStyle.ForeColor))
                    using (SolidBrush brSelected = new SolidBrush(cellStyle.SelectionForeColor))
                    using (StringFormat stringFormat = new StringFormat())
                    {
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.Trimming = StringTrimming.None;
                        stringFormat.FormatFlags = StringFormatFlags.LineLimit;
                        stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                        String TextToPrint = pd.Year + "/" + pd.Month + "/" + pd.Day;
                        if (OwningColumn.GetType().Equals(typeof(DataGridViewPersianDateTimePickerColumn)) &&
                            ((DataGridViewPersianDateTimePickerColumn)OwningColumn).ShowTime)
                            TextToPrint = pd.Hour + ":" + pd.Minute + ":" + pd.Second + " - " + TextToPrint;
                        // رسم متن تاریخ
                        graphics.DrawString(TextToPrint, cellStyle.Font, IsInState(cellState, DataGridViewElementStates.Selected)
                            ? brSelected : brFG, cellBounds, stringFormat);
                    }
                }
            }
            // رسم تاریخ دارای خطا
            if (PartPainted(paintParts, DataGridViewPaintParts.ErrorIcon))
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
                           formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.ErrorIcon);
        }
        #endregion

        #region private static Boolean IsInState(...)
        private static Boolean IsInState(DataGridViewElementStates currentState,
            DataGridViewElementStates checkState)
        {
            return (currentState & checkState) != 0;
        }
        #endregion

        #region private static Boolean PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
        /// <summary>
        /// Little utility function called by the Paint function to see if a 
        /// particular part needs to be painted. 
        /// </summary>
        private static Boolean PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
        {
            return (paintParts & paintPart) != 0;
        }
        #endregion

        #region private Boolean OwnsEditor(Int32 rowIndex)
        /// <summary>
        /// Determines whether this cell, at the given row index, 
        /// shows the grid's editing control or not.
        /// The row index needs to be provided as a parameter because this 
        /// cell may be shared among multiple rows.
        /// </summary>
        private Boolean OwnsEditor(Int32 rowIndex)
        {
            if (rowIndex == -1 || DataGridView == null) return false;
            DataGridViewPersianDateTimePickerEditor editor =
                DataGridView.EditingControl as DataGridViewPersianDateTimePickerEditor;
            return editor != null && rowIndex == editor.EditingControlRowIndex;
        }
        #endregion

        #region internal void SetValue(Int32 rowIndex, DateTime? value)
        internal void SetValue(Int32 rowIndex, DateTime? value)
        {
            SelectedDateTime = value;
            if (OwnsEditor(rowIndex)) EditingPersianDatePicker.SelectedDateTime = value;
        }
        #endregion

        #endregion
    }
    #endregion

    #region public class DataGridViewPersianDateTimePickerEditor
    public class DataGridViewPersianDateTimePickerEditor : PersianDatePicker, IDataGridViewEditingControl
    {
        #region Ctor

        public DataGridViewPersianDateTimePickerEditor()
        {
            SelectedDateTimeChanged += OnInternalSelectedDateTimeChanged;
        }

        #endregion

        #region Event Handlers

        #region OnInternalSelectedDateTimeChanged

        private void OnInternalSelectedDateTimeChanged(object sender, EventArgs e)
        {
            EditingControlValueChanged = true;
            NotifyDataGridViewOfValueChange();
        }

        #endregion

        #endregion

        #region Properties

        #region DataGridView EditingControlDataGridView
        ///<summary>
        ///Gets or sets the <see cref="T:System.Windows.Forms.DataGridView"></see> 
        /// that contains the cell.
        ///</summary>
        ///<returns>
        /// The <see cref="T:System.Windows.Forms.DataGridView"></see> that contains 
        /// the <see cref="T:System.Windows.Forms.DataGridViewCell"></see> that is 
        /// being edited; null if there is no associated 
        /// <see cref="T:System.Windows.Forms.DataGridView"></see>.
        ///</returns>
        public DataGridView EditingControlDataGridView { get; set; }
        #endregion

        #region object EditingControlFormattedValue
        ///<summary>
        ///Gets or sets the formatted value of the cell being modified by the editor.
        ///</summary>
        ///<returns>
        /// An <see cref="T:System.Object"></see> that 
        /// represents the formatted value of the cell.
        ///</returns>
        public object EditingControlFormattedValue
        {
            get { return SelectedDateTime; }
            set
            {
                if (value == null) SelectedDateTime = null;
                else SelectedDateTime = Convert.ToDateTime(value);
            }
        }
        #endregion

        #region Int32 EditingControlRowIndex
        ///<summary>
        /// Gets or sets the index of the hosting cell's parent row.
        ///</summary>
        ///<returns>
        /// The index of the row that contains the cell, or –1 if there is no parent row.
        ///</returns>
        public Int32 EditingControlRowIndex { get; set; }
        #endregion

        #region Cursor EditingPanelCursor
        ///<summary>
        /// Gets the cursor used when the mouse pointer is over the 
        /// <see cref="P:System.Windows.Forms.DataGridView.EditingPanel"></see> 
        /// but not over the editing control.
        ///</summary>
        ///<returns>
        /// A <see cref="T:System.Windows.Forms.Cursor"></see> that represents the 
        /// mouse pointer used for the editing panel. 
        ///</returns>
        public Cursor EditingPanelCursor
        {
            get { return Cursors.Default; }
        }
        #endregion

        #region Boolean RepositionEditingControlOnValueChange
        ///<summary>
        /// Gets or sets a value indicating whether the cell contents need to 
        /// be repositioned whenever the value changes.
        ///</summary>
        ///<returns>
        /// true if the contents need to be repositioned; otherwise, false.
        ///</returns>
        public Boolean RepositionEditingControlOnValueChange
        {
            get { return true; }
        }
        #endregion

        #region virtual Boolean EditingControlValueChanged
        /// <summary>
        /// Property which indicates whether the value of the 
        /// editing control has changed or not
        /// </summary>
        public virtual Boolean EditingControlValueChanged { get; set; }
        #endregion

        #endregion

        #region Methods

        #region public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        ///<summary>
        /// Changes the control's user interface (UI) to be consistent with the specified cell style.
        ///</summary>
        ///<param name="dataGridViewCellStyle">The 
        /// <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> 
        /// to use as the model for the UI.</param>
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
        }
        #endregion

        #region public Boolean EditingControlWantsInputKey(Keys keyData, Boolean dataGridViewWantsInputKey)
        ///<summary>
        ///Determines whether the specified key is a regular input key that the editing 
        /// control should process or a special key that 
        /// the <see cref="T:System.Windows.Forms.DataGridView"></see> should process.
        ///</summary>
        ///<returns>
        /// true if the specified key is a regular input key that should be 
        /// handled by the editing control; otherwise, false.
        ///</returns>
        /// <param name="keyData">A 
        /// <see cref="T:System.Windows.Forms.Keys"></see> that represents 
        /// the key that was pressed.</param>
        /// <param name="dataGridViewWantsInputKey">true when the 
        /// <see cref="T:System.Windows.Forms.DataGridView"></see> 
        /// wants to process the <see cref="T:System.Windows.Forms.Keys"></see> in 
        /// keyData; otherwise, false.</param>
        public Boolean EditingControlWantsInputKey(Keys keyData, Boolean dataGridViewWantsInputKey)
        {
            return true;
        }
        #endregion

        #region public object GetEditingControlFormattedValue(...)
        ///<summary>
        ///Retrieves the formatted value of the cell.
        ///</summary>
        ///<returns>
        /// An <see cref="T:System.Object"></see> that represents the 
        /// formatted version of the cell contents.
        ///</returns>
        ///<param name="context">A bitwise combination of 
        /// <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> 
        /// values that specifies the context in which the data is needed.</param>
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            if (_PersianMonthViewContainer.MonthViewControl.SelectedDateTime == null)
                return String.Empty;
            return SelectedDateTime.Value.ToString();
        }
        #endregion

        #region public void PrepareEditingControlForEdit(Boolean selectAll)

        ///<summary>
        /// Prepares the currently selected cell for editing.
        ///</summary>
        ///<param name="selectAll">true to select all of the cell's content; otherwise, 
        /// false.</param>
        public void PrepareEditingControlForEdit(Boolean selectAll)
        {
            if (selectAll)
                TextBox.SelectAll();
            else
                TextBox.SelectionStart = TextBox.Text.Length;
        }

        #endregion

        #region private void NotifyDataGridViewOfValueChange()
        /// <summary>
        /// Small utility function that updates the local dirty state and 
        /// notifies the grid of the value change.
        /// </summary>
        private void NotifyDataGridViewOfValueChange()
        {
            if (EditingControlValueChanged)
                EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }
        #endregion

        #endregion
    }
    #endregion

}