#region using
using System;
using System.Runtime.InteropServices;
using System.Text;
#endregion

// Core streaming interfaces, ported from axcore.idl
namespace Negar.DirectShow.Manager
{
    [ComVisible(false)]
    public enum PinDirection // PIN_DIRECTION
    {
        Input, // PINDIR_INPUT
        Output // PINDIR_OUTPUT
    }

    [ComVisible(false)]
    public enum PhysicalConnectorType
    {
        Video_Tuner = 1,
        Video_Composite,
        Video_SVideo,
        Video_RGB,
        Video_YRYBY,
        Video_SerialDigital,
        Video_ParallelDigital,
        Video_SCSI,
        Video_AUX,
        Video_1394,
        Video_USB,
        Video_VideoDecoder,
        Video_VideoEncoder,
        Video_SCART,

        Audio_Tuner = 4096,
        Audio_Line,
        Audio_Mic,
        Audio_AESDigital,
        Audio_SPDIFDigital,
        Audio_SCSI,
        Audio_AUX,
        Audio_1394,
        Audio_USB,
        Audio_AudioDecoder,
    } ;


    [ComVisible(false)]
    public class DsHlp
    {
        public const Int32 OAFALSE = 0;
        public const Int32 OATRUE = -1;

        [DllImport("quartz.dll", CharSet = CharSet.Auto)]
        public static extern Int32 AMGetErrorText(Int32 hr, StringBuilder buf, Int32 max);
    }


    [ComVisible(true), ComImport,
     Guid("56a86891-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPin
    {
        [PreserveSig]
        Int32 Connect(
            [In] IPin pReceivePin,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 ReceiveConnection(
            [In] IPin pReceivePin,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 Disconnect();

        [PreserveSig]
        Int32 ConnectedTo([Out] out IPin ppPin);

        [PreserveSig]
        Int32 ConnectionMediaType(
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 QueryPinInfo([Out] out PinInfo pInfo);

        [PreserveSig]
        Int32 QueryDirection(out PinDirection pPinDir);

        [PreserveSig]
        Int32 QueryId(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string Id);

        [PreserveSig]
        Int32 QueryAccept(
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 EnumMediaTypes(IntPtr ppEnum);

        [PreserveSig]
        Int32 QueryInternalConnections(IntPtr apPin, [In, Out] ref Int32 nPin);

        [PreserveSig]
        Int32 EndOfStream();

        [PreserveSig]
        Int32 BeginFlush();

        [PreserveSig]
        Int32 EndFlush();

        [PreserveSig]
        Int32 NewSegment(long tStart, long tStop, double dRate);
    }


    [ComVisible(true), ComImport,
     Guid("56a8689f-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFilterGraph
    {
        [PreserveSig]
        Int32 AddFilter(
            [In] IBaseFilter pFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName);

        [PreserveSig]
        Int32 RemoveFilter([In] IBaseFilter pFilter);

        [PreserveSig]
        Int32 EnumFilters([Out] out IEnumFilters ppEnum);

        [PreserveSig]
        Int32 FindFilterByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName,
            [Out] out IBaseFilter ppFilter);

        [PreserveSig]
        Int32 ConnectDirect([In] IPin ppinOut, [In] IPin ppinIn,
                            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 Reconnect([In] IPin ppin);

        [PreserveSig]
        Int32 Disconnect([In] IPin ppin);

        [PreserveSig]
        Int32 SetDefaultSyncSource();
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("0000010c-0000-0000-C000-000000000046"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersist
    {
        [PreserveSig]
        Int32 GetClassID(
            [Out] out Guid pClassID);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("0000010c-0000-0000-C000-000000000046"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistStream
    {
        [PreserveSig]
        Int32 GetClassID(
            [Out] out Guid pClassID);
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a86899-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMediaFilter
    {
        #region "IPersist Methods"

        [PreserveSig]
        Int32 GetClassID(
            [Out] out Guid pClassID);

        #endregion

        [PreserveSig]
        Int32 Stop();

        [PreserveSig]
        Int32 Pause();

        [PreserveSig]
        Int32 Run(long tStart);

        [PreserveSig]
        Int32 GetState(Int32 dwMilliSecsTimeout, out Int32 filtState);

        [PreserveSig]
        Int32 SetSyncSource([In] IReferenceClock pClock);

        [PreserveSig]
        Int32 GetSyncSource([Out] out IReferenceClock pClock);
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a86895-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBaseFilter
    {
        #region "IPersist Methods"

        [PreserveSig]
        Int32 GetClassID(
            [Out] out Guid pClassID);

        #endregion

        #region "IMediaFilter Methods"

        [PreserveSig]
        Int32 Stop();

        [PreserveSig]
        Int32 Pause();

        [PreserveSig]
        Int32 Run(long tStart);

        [PreserveSig]
        Int32 GetState(Int32 dwMilliSecsTimeout, [Out] out Int32 filtState);

        [PreserveSig]
        Int32 SetSyncSource([In] IReferenceClock pClock);

        [PreserveSig]
        Int32 GetSyncSource([Out] out IReferenceClock pClock);

        #endregion

        [PreserveSig]
        Int32 EnumPins(
            [Out] out IEnumPins ppEnum);

        [PreserveSig]
        Int32 FindPin(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Id,
            [Out] out IPin ppPin);

        [PreserveSig]
        Int32 QueryFilterInfo(
            [Out] FilterInfo pInfo);

        [PreserveSig]
        Int32 JoinFilterGraph(
            [In] IFilterGraph pGraph,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName);

        [PreserveSig]
        Int32 QueryVendorInfo(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pVendorInfo);
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode), ComVisible(false)]
    public class FilterInfo //  FILTER_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string achName;
        [MarshalAs(UnmanagedType.IUnknown)] public object pUnk;
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("36b73880-c2c8-11cf-8b46-00805f6cef60"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMediaSeeking
    {
        [PreserveSig]
        Int32 GetCapabilities(out SeekingCapabilities pCapabilities);

        [PreserveSig]
        Int32 CheckCapabilities([In, Out] ref SeekingCapabilities pCapabilities);

        [PreserveSig]
        Int32 IsFormatSupported([In] ref Guid pFormat);

        [PreserveSig]
        Int32 QueryPreferredFormat([Out] out Guid pFormat);

        [PreserveSig]
        Int32 GetTimeFormat([Out] out Guid pFormat);

        [PreserveSig]
        Int32 IsUsingTimeFormat([In] ref Guid pFormat);

        [PreserveSig]
        Int32 SetTimeFormat([In] ref Guid pFormat);

        [PreserveSig]
        Int32 GetDuration(out long pDuration);

        [PreserveSig]
        Int32 GetStopPosition(out long pStop);

        [PreserveSig]
        Int32 GetCurrentPosition(out long pCurrent);

        [PreserveSig]
        Int32 ConvertTimeFormat(out long pTarget, [In] ref Guid pTargetFormat,
                                long Source, [In] ref Guid pSourceFormat);

        [PreserveSig]
        Int32 SetPositions(
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] DsOptInt64 pCurrent,
            SeekingFlags dwCurrentFlags,
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] DsOptInt64 pStop,
            SeekingFlags dwStopFlags);

        [PreserveSig]
        Int32 GetPositions(out long pCurrent, out long pStop);

        [PreserveSig]
        Int32 GetAvailable(out long pEarliest, out long pLatest);

        [PreserveSig]
        Int32 SetRate(double dRate);

        [PreserveSig]
        Int32 GetRate(out double pdRate);

        [PreserveSig]
        Int32 GetPreroll(out long pllPreroll);
    }


    [Flags, ComVisible(false)]
    public enum SeekingCapabilities // AM_SEEKING_SeekingCapabilities AM_SEEKING_SEEKING_CAPABILITIES
    {
        CanSeekAbsolute = 0x001,
        CanSeekForwards = 0x002,
        CanSeekBackwards = 0x004,
        CanGetCurrentPos = 0x008,
        CanGetStopPos = 0x010,
        CanGetDuration = 0x020,
        CanPlayBackwards = 0x040,
        CanDoSegments = 0x080,
        Source = 0x100 // Doesn't pass thru used to count segment ends
    }


    [Flags, ComVisible(false)]
    public enum SeekingFlags // AM_SEEKING_SeekingFlags AM_SEEKING_SEEKING_FLAGS
    {
        NoPositioning = 0x00, // No change
        AbsolutePositioning = 0x01, // Position is supplied and is absolute
        RelativePositioning = 0x02, // Position is supplied and is relative
        IncrementalPositioning = 0x03, // (Stop) position relative to current, useful for seeking when paused (use +1)
        PositioningBitsMask = 0x03, // Useful mask
        SeekToKeyFrame = 0x04, // Just seek to key frame (performance gain)
        ReturnTime = 0x08, // Plug the media time equivalents back into the supplied LONGLONGs
        Segment = 0x10, // At end just do EC_ENDOFSEGMENT, don't do EndOfStream
        NoFlush = 0x20 // Don't flush
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a86897-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IReferenceClock
    {
        [PreserveSig]
        Int32 GetTime(out long pTime);

        [PreserveSig]
        Int32 AdviseTime(long baseTime, long streamTime, IntPtr hEvent, out Int32 pdwAdviseCookie);

        [PreserveSig]
        Int32 AdvisePeriodic(long startTime, long periodTime, IntPtr hSemaphore, out Int32 pdwAdviseCookie);

        [PreserveSig]
        Int32 Unadvise(Int32 dwAdviseCookie);
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a86893-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumFilters
    {
/*
		[PreserveSig]
	Int32 Next(
		[In]															Int32				cFilters,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)]	IBaseFilter[]	ppFilter,
		[Out]															out Int32			pcFetched );
*/

        [PreserveSig]
        Int32 Next(
            [In] uint cFilters,
            out IBaseFilter x,
            [Out] out uint pcFetched);

        [PreserveSig]
        Int32 Skip([In] Int32 cFilters);

        void Reset();
        void Clone([Out] out IEnumFilters ppEnum);
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a86892-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumPins
    {
        [PreserveSig]
        Int32 Next(
            [In] Int32 cPins,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IPin[] ppPins,
            [Out] out Int32 pcFetched);

        [PreserveSig]
        Int32 Skip([In] Int32 cPins);

        void Reset();
        void Clone([Out] out IEnumPins ppEnum);
    }


    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class AMMediaType //  AM_MEDIA_TYPE
    {
        public Guid majorType;
        public Guid subType;
        [MarshalAs(UnmanagedType.Bool)] public bool fixedSizeSamples;
        [MarshalAs(UnmanagedType.Bool)] public bool temporalCompression;
        public Int32 sampleSize;
        public Guid formatType;
        public IntPtr unkPtr;
        public Int32 formatSize;
        public IntPtr formatPtr;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode), ComVisible(false)]
    public struct PinInfo // PIN_INFO
    {
        public IBaseFilter filter;
        public PinDirection dir;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string name;
    }


// ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a8689a-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMediaSample
    {
        [PreserveSig]
        Int32 GetPointer(out IntPtr ppBuffer);

        [PreserveSig]
        Int32 GetSize();

        [PreserveSig]
        Int32 GetTime(out long pTimeStart, out long pTimeEnd);

        [PreserveSig]
        Int32 SetTime(
            [In, MarshalAs(UnmanagedType.LPStruct)] DsOptInt64 pTimeStart,
            [In, MarshalAs(UnmanagedType.LPStruct)] DsOptInt64 pTimeEnd);

        [PreserveSig]
        Int32 IsSyncPoint();

        [PreserveSig]
        Int32 SetSyncPoint(
            [In, MarshalAs(UnmanagedType.Bool)] bool bIsSyncPoint);

        [PreserveSig]
        Int32 IsPreroll();

        [PreserveSig]
        Int32 SetPreroll(
            [In, MarshalAs(UnmanagedType.Bool)] bool bIsPreroll);

        [PreserveSig]
        Int32 GetActualDataLength();

        [PreserveSig]
        Int32 SetActualDataLength(Int32 len);

        [PreserveSig]
        Int32 GetMediaType(
            [Out, MarshalAs(UnmanagedType.LPStruct)] out AMMediaType ppMediaType);

        [PreserveSig]
        Int32 SetMediaType(
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pMediaType);

        [PreserveSig]
        Int32 IsDiscontinuity();

        [PreserveSig]
        Int32 SetDiscontinuity(
            [In, MarshalAs(UnmanagedType.Bool)] bool bDiscontinuity);

        [PreserveSig]
        Int32 GetMediaTime(out long pTimeStart, out long pTimeEnd);

        [PreserveSig]
        Int32 SetMediaTime(
            [In, MarshalAs(UnmanagedType.LPStruct)] DsOptInt64 pTimeStart,
            [In, MarshalAs(UnmanagedType.LPStruct)] DsOptInt64 pTimeEnd);
    }
} // namespace Negar.DirectShow.Manager