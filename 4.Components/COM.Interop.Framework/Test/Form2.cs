using System;
using System.Windows.Forms;
using Negar.ComHelper;

namespace Test_Projects
{
    public partial class Form2 : Form
    {
        private OfficeControl FormOfficeViewer;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void InitializeOfficeViewer()
        {
            FormOfficeViewer = new OfficeControl();
            FormOfficeViewer.Dock = DockStyle.Fill;
            Controls.Add(FormOfficeViewer);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (FormOfficeViewer == null)
            {
                InitializeOfficeViewer();
            }
            if (!Controls.Contains(FormOfficeViewer))
                Controls.Add(FormOfficeViewer);
        }
        
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormOfficeViewer.Dispose();
            FormOfficeViewer = null;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            ComHelperPooled TheASPCompatRunner = new ComHelperPooled();
            TheASPCompatRunner.Register(Saeed);
            TheASPCompatRunner.Execute();
            TheASPCompatRunner.WaitOnAllOperations();
        }

        void Saeed()
        {
            try
            {

            }
            catch (Exception)
            {
            }
        }


    }
}
