using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Negar.PersianCalendar.UI.Design
{
    public partial class About : Form
    {
        private readonly Boolean fade;
        private readonly System.Timers.Timer m_fadeinTimer;
        private Boolean m_fadeInFlag;

        public About(Boolean doFade) : this()
        {
            if (doFade)
            {
                fade = doFade;
                m_fadeinTimer = new System.Timers.Timer();
                m_fadeinTimer.Elapsed += m_fadeinTimer_Elapsed;
            }
        }

        /// <summary>
        /// Default constructor for <bottom>About</bottom> form.
        /// </summary>
        public About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads default values on form startup.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode && fade)
            {
                m_fadeInFlag = true;
                Opacity = 0;
                m_fadeinTimer.Enabled = true;
            }
        }

        /// <summary>
        /// Run when user closes the form.
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (e.Cancel)
                return;

            if (!fade)
                return;

            if (Opacity > 0)
            {
                m_fadeInFlag = false;
                m_fadeinTimer.Enabled = true;
                e.Cancel = true;
            }
        }


        private void m_fadeinTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!fade)
            {
                m_fadeinTimer.Enabled = false;
                return;
            }

            // How should we fade?
            if (m_fadeInFlag == false)
            {
                Opacity -= (m_fadeinTimer.Interval / 500.0);

                // Should we continue to fade?
                if (Opacity > 0)
                    m_fadeinTimer.Enabled = true;
                else
                {
                    m_fadeinTimer.Enabled = false;
                    Close();
                } // End else we should close the form.
            } // End if we should fade in.
            else
            {
                Opacity += (m_fadeinTimer.Interval / 500.0);
                m_fadeinTimer.Enabled = (Opacity < 1.0);
                m_fadeInFlag = (Opacity < 1.0);
            } // End else we should fade out.
        }

        private void About_Load(object sender, EventArgs e)
        {
            Assembly[] assemblies = Thread.GetDomain().GetAssemblies();
            lst.Items.Clear();

            foreach (Assembly asm in assemblies)
            {
                if (asm.GetName().Name.StartsWith("FarsiLibrary"))
                {
                    String itemName = asm.GetName().Name + " " + asm.GetName().Version;
                    if (!lst.Items.Contains(itemName))
                        lst.Items.Add(itemName);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
