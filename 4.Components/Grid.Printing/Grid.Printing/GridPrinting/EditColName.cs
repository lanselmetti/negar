#region using
using System;
using System.Globalization;
using System.Windows.Forms;
#endregion

namespace Negar.GridPrinting
{
    /// <summary>
    /// فرم ویرایش عنوان ستون گزارش ها
    /// </summary>
    internal partial class frmEditColName : Form
    {
        #region Ctor
        public frmEditColName(String ColName)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("Fa-Ir"));
            InitializeComponent();
            txtName.Text = ColName;
            ShowDialog();
        }
        #endregion
    }
}