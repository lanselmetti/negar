/******************************************************
                  DirectShow .NET
		         brian.low@shaw.ca
*******************************************************/
//					DsVmRender
// Video Mixer Renderer, ported from VmRender.idl

using System;
using System.Runtime.InteropServices;

namespace Negar.DirectShow.Manager
{
    [ComVisible(false)]
    public enum VMRMode : uint
    {
        Windowed = 0x00000001,
        Windowless = 0x00000002,
        Renderless = 0x00000004,
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public struct RECT
    {
        private Int32 left;
        private Int32 top;
        private Int32 right;
        private Int32 bottom;
    }

    [ComVisible(true), ComImport,
     Guid("0eb1088c-4dcd-46f0-878f-39dae86a51b7"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVMRWindowlessControl
    {
        //
        //////////////////////////////////////////////////////////
        // Video size and position information
        //////////////////////////////////////////////////////////
        //
        Int32 GetNativeVideoSize(
            [Out] out Int32 lpWidth,
            [Out] out Int32 lpHeight,
            [Out] out Int32 lpARWidth,
            [Out] out Int32 lpARHeight
            );

        Int32 GetMinIdealVideoSize(
            [Out] out Int32 lpHeight
            );

        Int32 GetMaxIdealVideoSize(
            [Out] out Int32 lpWidth,
            [Out] out Int32 lpHeight
            );

        Int32 SetVideoPosition(
            [In, MarshalAs(UnmanagedType.LPStruct)] RECT lpSRCRect,
            [In, MarshalAs(UnmanagedType.LPStruct)] RECT lpDSTRect
            );

        Int32 GetVideoPosition(
            [Out, MarshalAs(UnmanagedType.LPStruct)] out RECT lpSRCRect,
            [Out, MarshalAs(UnmanagedType.LPStruct)] out RECT lpDSTRect
            );

        Int32 GetAspectRatioMode([Out] out uint lpAspectRatioMode);

        Int32 SetAspectRatioMode([In] uint AspectRatioMode);

        //
        //////////////////////////////////////////////////////////
        // Display and clipping management
        //////////////////////////////////////////////////////////
        //
        Int32 SetVideoClippingWindow([In] IntPtr hwnd);

        Int32 RepaintVideo(
            [In] IntPtr hwnd,
            [In] IntPtr hdc
            );

        Int32 DisplayModeChanged();


        //
        //////////////////////////////////////////////////////////
        // GetCurrentImage
        //
        // Returns the current image being displayed.  This images
        // is returned in the form of packed Windows DIB.
        //
        // GetCurrentImage can be called at any time, also
        // the caller is responsible for free the returned memory
        // by calling CoTaskMemFree.
        //
        // Excessive use of this function will degrade video
        // playback performed.
        //////////////////////////////////////////////////////////
        //
        Int32 GetCurrentImage([Out] out IntPtr lpDib);

        //
        //////////////////////////////////////////////////////////
        // Border Color control
        //
        // The border color is color used to fill any area of the
        // the destination rectangle that does not contain video.
        // It is typically used in two instances.  When the video
        // straddles two monitors and when the VMR is trying
        // to maintain the aspect ratio of the movies by letter
        // boxing the video to fit within the specified destination
        // rectangle. See SetAspectRatioMode above.
        //////////////////////////////////////////////////////////
        //
        Int32 SetBorderColor([In] uint Clr);

        Int32 GetBorderColor([Out] out uint lpClr);

        //
        //////////////////////////////////////////////////////////
        // Color key control only meaningful when the VMR is using
        // and overlay
        //////////////////////////////////////////////////////////
        //
        Int32 SetColorKey([In] uint Clr);

        Int32 GetColorKey([Out] out uint lpClr);
    }

    [ComVisible(true), ComImport,
     Guid("9e5530c5-7034-48b4-bb46-0b8a6efc8e36"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVMRFilterConfig
    {
        [PreserveSig]
        Int32 SetImageCompositor([In] IntPtr lpVMRImgCompositor);

        [PreserveSig]
        Int32 SetNumberOfStreams([In] uint dwMaxStreams);

        [PreserveSig]
        Int32 GetNumberOfStreams([Out] out uint pdwMaxStreams);

        [PreserveSig]
        Int32 SetRenderingPrefs([In] uint dwRenderFlags);

        [PreserveSig]
        Int32 GetRenderingPrefs([Out] out uint pdwRenderFlags);

        [PreserveSig]
        Int32 SetRenderingMode([In] uint Mode);

        [PreserveSig]
        Int32 GetRenderingMode([Out] out VMRMode Mode);
    }
}