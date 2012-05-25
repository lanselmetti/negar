using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    ///  Property pages for a DirectShow filter (e.g. hardware device). These
    ///  property pages do not support persisting their settings. 
    /// </summary>
    public class DirectShowPropertyPage : PropertyPage
    {
        // ---------------- Properties --------------------

        /// <summary> COM ISpecifyPropertyPages interface </summary>
        protected ISpecifyPropertyPages specifyPropertyPages;


        // ---------------- Constructors --------------------

        /// <summary> Constructor </summary>
        public DirectShowPropertyPage(string name, ISpecifyPropertyPages specifyPropertyPages)
        {
            Name = name;
            SupportsPersisting = false;
            this.specifyPropertyPages = specifyPropertyPages;
        }


        // ---------------- Public Methods --------------------

        /// <summary> 
        ///  Show the property page. Some property pages cannot be displayed 
        ///  while previewing and/or capturing. 
        /// </summary>
        public override void Show(Control owner)
        {
            var cauuid = new DsCAUUID();
            try
            {
                Int32 hr = specifyPropertyPages.GetPages(out cauuid);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);

                object o = specifyPropertyPages;
                hr = OleCreatePropertyFrame(owner.Handle, 30, 30, null, 1,
                                            ref o, cauuid.cElems, cauuid.pElems, 0, 0, IntPtr.Zero);
            }
            finally
            {
                if (cauuid.pElems != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(cauuid.pElems);
            }
        }

        /// <summary> Release unmanaged resources </summary>
        public new void Dispose()
        {
            if (specifyPropertyPages != null)
                Marshal.ReleaseComObject(specifyPropertyPages);
            specifyPropertyPages = null;
        }


        // ---------------- DLL Imports --------------------

        [DllImport("olepro32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern Int32 OleCreatePropertyFrame(
            IntPtr hwndOwner, Int32 x, Int32 y,
            string lpszCaption, Int32 cObjects,
            [In, MarshalAs(UnmanagedType.Interface)] ref object ppUnk,
            Int32 cPages, IntPtr pPageClsID, Int32 lcid, Int32 dwReserved, IntPtr pvReserved);
    }
}