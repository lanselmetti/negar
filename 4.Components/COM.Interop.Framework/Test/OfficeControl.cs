#region using
using System.Windows.Forms;
using Negar.ComHelper;
#endregion

namespace Test_Projects
{
    public partial class OfficeControl : UserControl
    {

        #region Ctor
        public OfficeControl()
        {
            InitializeComponent();
            ComHelperPooled ControlComHelper = new ComHelperPooled();
            ControlComHelper.Register(InitializeOfficeViewer);
            ControlComHelper.Execute();
            ControlComHelper.WaitOnAllOperations();
            //Controls.Add(OfficeViewer);
        }
        #endregion

        #region Methods

        #region void InitializeOfficeViewer()
        /// <summary>
        /// تابعی برای ایجاد كنترل نمایش آفیس
        /// </summary>
        void InitializeOfficeViewer()
        {
            //OfficeViewer = new AxOA();
            //((ISupportInitialize)(OfficeViewer)).BeginInit();
            //((ISupportInitialize)(OfficeViewer)).EndInit();
        }
        #endregion

        #endregion

    }
}