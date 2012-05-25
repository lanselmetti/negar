/******************************************************
                  DirectShow .NET
		      netmaster@swissonline.ch
*******************************************************/
//					QEdit
// Extended streaming interfaces, ported from qedit.idl

using System;
using System.Runtime.InteropServices;

namespace Negar.DirectShow.Manager
{
    [ComVisible(true), ComImport,
     Guid("6B652FFF-11FE-4fce-92AD-0266B5D7C78F"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISampleGrabber
    {
        [PreserveSig]
        Int32 SetOneShot(
            [In, MarshalAs(UnmanagedType.Bool)] bool OneShot);

        [PreserveSig]
        Int32 SetMediaType(
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 GetConnectedMediaType(
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 SetBufferSamples(
            [In, MarshalAs(UnmanagedType.Bool)] bool BufferThem);

        [PreserveSig]
        Int32 GetCurrentBuffer(ref Int32 pBufferSize, IntPtr pBuffer);

        [PreserveSig]
        Int32 GetCurrentSample(IntPtr ppSample);

        [PreserveSig]
        Int32 SetCallback(ISampleGrabberCB pCallback, Int32 WhichMethodToCallback);
    }


    [ComVisible(true), ComImport,
     Guid("0579154A-2B53-4994-B0D0-E773148EFF85"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISampleGrabberCB
    {
        [PreserveSig]
        Int32 SampleCB(double SampleTime, IMediaSample pSample);

        [PreserveSig]
        Int32 BufferCB(double SampleTime, IntPtr pBuffer, Int32 BufferLen);
    }


    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class VideoInfoHeader // VIDEOINFOHEADER
    {
        public DsRECT SrcRect;
        public DsRECT TargetRect;
        public Int32 BitRate;
        public Int32 BitErrorRate;
        public long AvgTimePerFrame;
        public BitmapInfoHeader BmiHeader;
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class VideoInfoHeader2 // VIDEOINFOHEADER2
    {
        public DsRECT SrcRect;
        public DsRECT TargetRect;
        public Int32 BitRate;
        public Int32 BitErrorRate;
        public long AvgTimePerFrame;
        public Int32 InterlaceFlags;
        public Int32 CopyProtectFlags;
        public Int32 PictAspectRatioX;
        public Int32 PictAspectRatioY;
        public Int32 ControlFlags;
        public Int32 Reserved2;
        public BitmapInfoHeader BmiHeader;
    } ;


    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class WaveFormatEx
    {
        public short wFormatTag;
        public short nChannels;
        public Int32 nSamplesPerSec;
        public Int32 nAvgBytesPerSec;
        public short nBlockAlign;
        public short wBitsPerSample;
        public short cbSize;
    }
} // namespace Negar.DirectShow.Manager