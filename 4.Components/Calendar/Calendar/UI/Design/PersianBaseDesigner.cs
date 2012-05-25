using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms.Design;
using Negar.PersianCalendar.UI.BaseClasses;

namespace Negar.PersianCalendar.UI.Design
{
    /// <summary>
    /// Base designer for all designer classes.
    /// </summary>
    internal class PersianBaseDesigner : ControlDesigner
    {
        #region Fields

        protected static ArrayList Designers;
        private readonly DesignerVerbCollection verbs;
        private IComponentChangeService changeService;
        protected DesignerVerb ShowAbout;

        #endregion

        #region Props

        public IComponentChangeService ChangeService
        {
            get { return changeService; }
        }

        public virtual Component Editor
        {
            get { return (Component as BaseControl); }
        }

        protected virtual Boolean IsSetTextProperty
        {
            get { return true; }
        }

        public override DesignerVerbCollection Verbs
        {
            get { return verbs; }
        }

        #endregion

        #region Ctors
        /// <summary>
        /// سازنده استاتیك پیش فرض
        /// </summary>
        static PersianBaseDesigner()
        {
            Designers = new ArrayList();
        }
        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public PersianBaseDesigner()
        {
            changeService = null;
            verbs = new DesignerVerbCollection();
            ShowAbout = new DesignerVerb("درباره كتابخانه فارسی رایان پرتونگار", OnShowAbout);
            ShowAbout.Checked = false;
            verbs.Add(ShowAbout);
            Designers.Add(this);
        }
        #endregion

        #region Verbs
        private static void OnShowAbout(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
        #endregion

        #region Overrides

        protected override void Dispose(Boolean disposing)
        {
            Designers.Remove(this);

            if (disposing)
            {
                if (changeService != null)
                {
                    changeService.ComponentRename -= OnComponentRename;
                }

                changeService = null;
            }
            base.Dispose(disposing);
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            if (component.Site != null)
            {
                changeService = component.Site.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                changeService.ComponentRename += OnComponentRename;
            }
        }

        protected void OnComponentRename(object sender, ComponentRenameEventArgs e)
        {
            if (e.Component == Editor)
            {
                ResetReferenceName();
            }
        }

        protected virtual void ResetReferenceName()
        {
            var svc = GetService(typeof(IReferenceService)) as IReferenceService;
            if (svc != null)
            {
                FieldInfo fi = svc.GetType().GetField("referenceList",
                                                      BindingFlags.GetField |
                                                      (BindingFlags.NonPublic | BindingFlags.Instance));
                if (fi != null)
                {
                    var values = fi.GetValue(svc) as ArrayList;
                    if (values != null)
                    {
                        foreach (object val in values)
                        {
                            PropertyInfo pi = val.GetType().GetProperty("SitedComponent",
                                                                        BindingFlags.GetProperty |
                                                                        (BindingFlags.Public | BindingFlags.Instance));
                            if (pi != null)
                            {
                                object obj = pi.GetValue(val, null);
                                if (obj == Editor)
                                {
                                    MethodInfo mi = val.GetType().GetMethod("ResetName",
                                                                            BindingFlags.InvokeMethod |
                                                                            (BindingFlags.NonPublic |
                                                                             BindingFlags.Instance));
                                    if (mi != null)
                                    {
                                        mi.Invoke(val, null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

    }
}