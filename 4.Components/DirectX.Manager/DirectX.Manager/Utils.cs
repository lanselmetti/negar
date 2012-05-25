/******************************************************
                  DirectShow .NET
		      netmaster@swissonline.ch
*******************************************************/
//					DsUtils
// DirectShow utility classes, partial from the SDK Common sources

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Negar.DirectShow.Manager
{
    [ComVisible(false)]
    public class DsUtils
    {
        public static bool IsCorrectDirectXVersion()
        {
            return File.Exists(Path.Combine(Environment.SystemDirectory, @"dpnhpast.dll"));
        }


        public static bool ShowCapPinDialog(ICaptureGraphBuilder2 bld, IBaseFilter flt, IntPtr hwnd)
        {
            object comObj = null;
            ISpecifyPropertyPages spec;
            var cauuid = new DsCAUUID();

            try
            {
                Guid cat = PinCategory.Capture;
                Guid type = MediaType.Interleaved;
                Guid iid = typeof(IAMStreamConfig).GUID;
                Int32 hr = bld.FindInterface(ref cat, ref type, flt, ref iid, out comObj);
                if (hr != 0)
                {
                    type = MediaType.Video;
                    hr = bld.FindInterface(ref cat, ref type, flt, ref iid, out comObj);
                    if (hr != 0)
                        return false;
                }
                spec = comObj as ISpecifyPropertyPages;
                if (spec == null)
                    return false;

                spec.GetPages(out cauuid);
                OleCreatePropertyFrame(hwnd, 30, 30, null, 1,
                    ref comObj, cauuid.cElems, cauuid.pElems, 0, 0, IntPtr.Zero);
                return true;
            }
            catch (Exception ee)
            {
                Trace.WriteLine("!Ds.NET: ShowCapPinDialog " + ee.Message);
                return false;
            }
            finally
            {
                if (cauuid.pElems != IntPtr.Zero) Marshal.FreeCoTaskMem(cauuid.pElems);
                if (comObj != null) Marshal.ReleaseComObject(comObj);
            }
        }

        public static bool ShowTunerPinDialog(ICaptureGraphBuilder2 bld, IBaseFilter flt, IntPtr hwnd)
        {
            object comObj = null;
            ISpecifyPropertyPages spec;
            var cauuid = new DsCAUUID();

            try
            {
                Guid cat = PinCategory.Capture;
                Guid type = MediaType.Interleaved;
                Guid iid = typeof(IAMTVTuner).GUID;
                Int32 hr = bld.FindInterface(ref cat, ref type, flt, ref iid, out comObj);
                if (hr != 0)
                {
                    type = MediaType.Video;
                    hr = bld.FindInterface(ref cat, ref type, flt, ref iid, out comObj);
                    if (hr != 0)
                        return false;
                }
                spec = comObj as ISpecifyPropertyPages;
                if (spec == null)
                    return false;

                spec.GetPages(out cauuid);
                OleCreatePropertyFrame(hwnd, 30, 30, null, 1,
                    ref comObj, cauuid.cElems, cauuid.pElems, 0, 0, IntPtr.Zero);
                return true;
            }
            catch (Exception ee)
            {
                Trace.WriteLine("!Ds.NET: ShowCapPinDialog " + ee.Message);
                return false;
            }
            finally
            {
                if (cauuid.pElems != IntPtr.Zero) Marshal.FreeCoTaskMem(cauuid.pElems);
                if (comObj != null) Marshal.ReleaseComObject(comObj);
            }
        }


        // from 'DShowUtil.cpp'
        public Int32 GetPin(IBaseFilter filter, PinDirection dirrequired, Int32 num, out IPin ppPin)
        {
            ppPin = null;
            IEnumPins pinEnum;
            int hr = filter.EnumPins(out pinEnum);
            if ((hr < 0) || (pinEnum == null)) return hr;
            IPin[] pins = new IPin[1];
            do
            {
                Int32 f;
                hr = pinEnum.Next(1, pins, out f);
                if ((hr != 0) || (pins[0] == null)) break;
                PinDirection dir;
                hr = pins[0].QueryDirection(out dir);
                if ((hr == 0) && (dir == dirrequired))
                {
                    if (num == 0)
                    {
                        ppPin = pins[0];
                        pins[0] = null;
                        break;
                    }
                    num--;
                }
                Marshal.ReleaseComObject(pins[0]);
                pins[0] = null;
            } while (hr == 0);

            Marshal.ReleaseComObject(pinEnum);
            return hr;
        }

        /// <summary> 
        ///  Free the nested structures and release any 
        ///  COM objects within an AMMediaType struct.
        /// </summary>
        public static void FreeAMMediaType(AMMediaType mediaType)
        {
            if (mediaType.formatSize != 0)
                Marshal.FreeCoTaskMem(mediaType.formatPtr);
            if (mediaType.unkPtr != IntPtr.Zero)
                Marshal.Release(mediaType.unkPtr);
            mediaType.formatSize = 0;
            mediaType.formatPtr = IntPtr.Zero;
            mediaType.unkPtr = IntPtr.Zero;
        }

        [DllImport("olepro32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern Int32 OleCreatePropertyFrame(IntPtr hwndOwner, Int32 x, Int32 y,
                                                           string lpszCaption, Int32 cObjects,
                                                           [In, MarshalAs(UnmanagedType.Interface)] ref object ppUnk,
                                                           Int32 cPages, IntPtr pPageClsID, Int32 lcid, Int32 dwReserved,
                                                           IntPtr pvReserved);
    }


    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public struct DsPOINT // POINT
    {
        public Int32 X;
        public Int32 Y;
    }


    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public struct DsRECT // RECT
    {
        public Int32 Left;
        public Int32 Top;
        public Int32 Right;
        public Int32 Bottom;
    }


    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential, Pack = 2), ComVisible(false)]
    public struct BitmapInfoHeader
    {
        public Int32 Size;
        public Int32 Width;
        public Int32 Height;
        public short Planes;
        public short BitCount;
        public Int32 Compression;
        public Int32 ImageSize;
        public Int32 XPelsPerMeter;
        public Int32 YPelsPerMeter;
        public Int32 ClrUsed;
        public Int32 ClrImportant;
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(false)]
    public class DsROT
    {
        private const Int32 ROTFLAGS_REGISTRATIONKEEPSALIVE = 1;

        public static bool AddGraphToRot(object graph, out Int32 cookie)
        {
            cookie = 0;
            UCOMIRunningObjectTable rot = null;
            UCOMIMoniker mk = null;
            try
            {
                Int32 hr = GetRunningObjectTable(0, out rot);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                Int32 id = GetCurrentProcessId();
                IntPtr iuPtr = Marshal.GetIUnknownForObject(graph);
                var iuInt = (Int32)iuPtr;
                Marshal.Release(iuPtr);
                string item = string.Format("FilterGraph {0} pid {1}", iuInt.ToString("x8"), id.ToString("x8"));
                hr = CreateItemMoniker("!", item, out mk);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                rot.Register(ROTFLAGS_REGISTRATIONKEEPSALIVE, graph, mk, out cookie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (mk != null) Marshal.ReleaseComObject(mk);
                if (rot != null) Marshal.ReleaseComObject(rot);
            }
        }

        public static bool RemoveGraphFromRot(ref Int32 cookie)
        {
            UCOMIRunningObjectTable rot = null;
            try
            {
                Int32 hr = GetRunningObjectTable(0, out rot);
                if (hr < 0)
                    Marshal.ThrowExceptionForHR(hr);

                rot.Revoke(cookie);
                cookie = 0;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (rot != null) Marshal.ReleaseComObject(rot);
            }
        }

        [DllImport("ole32.dll", ExactSpelling = true)]
        private static extern Int32 GetRunningObjectTable(Int32 r, out UCOMIRunningObjectTable pprot);

        [DllImport("ole32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern Int32 CreateItemMoniker(string delim, string item, out UCOMIMoniker ppmk);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern Int32 GetCurrentProcessId();
    }


    // ---------------------------------- ocidl.idl ------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("B196B28B-BAB4-101A-B69C-00AA00341D07"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISpecifyPropertyPages
    {
        [PreserveSig]
        Int32 GetPages(out DsCAUUID pPages);
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public struct DsCAUUID // CAUUID
    {
        public Int32 cElems;
        public IntPtr pElems;
    }

    // ---------------------------------------------------------------------------------------


    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class DsOptInt64
    {
        public DsOptInt64(long Value)
        {
            this.Value = Value;
        }

        public long Value;
    }


    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class DsOptIntPtr
    {
        public IntPtr Pointer;
    }
} // namespace Negar.DirectShow.Manager