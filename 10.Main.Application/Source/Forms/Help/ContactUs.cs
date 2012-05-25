#region using
using System.Windows.Forms;
#endregion

namespace Sepehr.Forms.Help
{
    /// <summary>
    /// فرم اسپلش سیستم
    /// </summary>
    public partial class frmContactUs : Form
    {

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كلاس
        /// </summary>
        public frmContactUs()
        {
            InitializeComponent();
            ShowDialog();
        }
        #endregion

        #region Event Hadlers

        #region PictureBoxLogo_MouseClick
        private void PictureBoxLogo_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
        #endregion

        #endregion
        
    }
}