#region using
using System;
using System.Windows.Forms;
#endregion

namespace Sepehr.Forms
{
    /// <summary>
    /// فرم نمایش خطاهای موجود در اطلاعات جستجو شده دیسكت بیمه
    /// </summary>
    public partial class frmErrorMessageBox : Form
    {
        #region Ctor
        public frmErrorMessageBox(string SentMessage, Int32 ErrorCount)
        {
            InitializeComponent();
            txtErrorMessage.Text = SentMessage;
            txtErrorMessage.SelectionStart = 0;
            txtErrorMessage.SelectionLength = 0;
            lblErrorCount.Text += ErrorCount.ToString();
            ShowDialog();
        }
        #endregion
    }
}