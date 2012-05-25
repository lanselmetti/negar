#region using
using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
#endregion

namespace Negar.DirectShow.Manager
{
    public class DsBugWO
    {
        public static object CreateDsInstance(ref Guid clsid, ref Guid riid)
        {
            IntPtr ptrIf;
            Int32 hr = CoCreateInstance(ref clsid, IntPtr.Zero, CLSCTX.Inproc, ref riid, out ptrIf);
            if ((hr != 0) || (ptrIf == IntPtr.Zero)) Marshal.ThrowExceptionForHR(hr);
            Guid iu = new Guid("00000000-0000-0000-C000-000000000046");
            IntPtr ptrXX;
            Marshal.QueryInterface(ptrIf, ref iu, out ptrXX);
            return EnterpriseServicesHelper.WrapIUnknownWithComObject(ptrIf);
        }

        [DllImport("ole32.dll")]
        private static extern Int32 CoCreateInstance(
            ref Guid clsid, IntPtr pUnkOuter, CLSCTX dwClsContext, ref Guid iid, out IntPtr ptrIf);
    }

    [Flags]
    internal enum CLSCTX
    {
        Inproc = 0x03,
        Server = 0x15,
        All = 0x17,
    }
}