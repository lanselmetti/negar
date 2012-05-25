using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace gfoidl.Windows.Forms
{
    [Description("DataGridView that Saves Column Order, Width and Visibility to user.config")]
    [ToolboxBitmap(typeof (DataGridView))]
    public class gfDataGridView : DataGridView
    {
        private void SetColumnOrder()
        {
            if (!gfDataGridViewSetting.Default.ColumnOrder.ContainsKey(Name))
                return;

            List<ColumnOrderItem> columnOrder =
                gfDataGridViewSetting.Default.ColumnOrder[Name];

            if (columnOrder != null)
            {
                IOrderedEnumerable<ColumnOrderItem> sorted = columnOrder.OrderBy(i => i.DisplayIndex);
                foreach (ColumnOrderItem item in sorted)
                {
                    Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
                    Columns[item.ColumnIndex].Visible = item.Visible;
                    Columns[item.ColumnIndex].Width = item.Width;
                }
            }
        }

        //---------------------------------------------------------------------
        private void SaveColumnOrder()
        {
            if (AllowUserToOrderColumns)
            {
                var columnOrder = new List<ColumnOrderItem>();
                DataGridViewColumnCollection columns = Columns;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnOrder.Add(new ColumnOrderItem
                                        {
                                            ColumnIndex = i,
                                            DisplayIndex = columns[i].DisplayIndex,
                                            Visible = columns[i].Visible,
                                            Width = columns[i].Width
                                        });
                }

                gfDataGridViewSetting.Default.ColumnOrder[Name] = columnOrder;
                gfDataGridViewSetting.Default.Save();
            }
        }

        //---------------------------------------------------------------------
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetColumnOrder();
        }

        //---------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            SaveColumnOrder();
            base.Dispose(disposing);
        }
    }

    //-------------------------------------------------------------------------
    internal sealed class gfDataGridViewSetting : ApplicationSettingsBase
    {
        private static readonly gfDataGridViewSetting _defaultInstace =
            (gfDataGridViewSetting) Synchronized(new gfDataGridViewSetting());

        //---------------------------------------------------------------------
        public static gfDataGridViewSetting Default
        {
            get { return _defaultInstace; }
        }

        //---------------------------------------------------------------------
        // Because there can be more than one DGV in the user-application
        // a dictionary is used to save the settings for this DGV.
        // As key the name of the control is used.
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        [DefaultSettingValue("")]
        public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
        {
            get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>; }
            set { this["ColumnOrder"] = value; }
        }
    }

    //-------------------------------------------------------------------------
    [Serializable]
    public sealed class ColumnOrderItem
    {
        public int DisplayIndex { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public int ColumnIndex { get; set; }
    }
}