/******************************************************
                  DirectShow .NET
		         brian.low@shaw.ca
*******************************************************/
//					DsVmr9.cs
// Video Mixer Renderer 9, ported from Vmr9.idl


using System;
using System.Runtime.InteropServices;

namespace Negar.DirectShow.Manager
{
//#if NEWCODE
    /// <summary>
    /// CLSID_VideoMixingRenderer9
    /// </summary>
    [ComImport, Guid("51b4abf3-748f-4e3b-a276-c828330e926a")]
    public class VideoMixingRenderer9
    {
    }

//#endif

    [ComVisible(false)]
    public enum VMRMode9 : uint
    {
        Windowed = 0x00000001,
        Windowless = 0x00000002,
        Renderless = 0x00000004,
    }

    [ComVisible(false)]
    public enum VMR9AspectRatioMode : uint
    {
        None,
        LetterBox,
    }

    [ComVisible(true), ComImport,
     Guid("5a804648-4f66-4867-9c43-4f5c822cf1b8"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVMRFilterConfig9
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
        Int32 SetRenderingMode([In] VMRMode9 Mode);

        [PreserveSig]
        Int32 GetRenderingMode([Out] out VMRMode9 Mode);
    }

    [ComVisible(true), ComImport,
     Guid("8f537d09-f85e-4414-b23b-502e54c79927"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVMRWindowlessControl9
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

        Int32 GetAspectRatioMode([Out] out VMR9AspectRatioMode lpAspectRatioMode);

        Int32 SetAspectRatioMode([In] VMR9AspectRatioMode AspectRatioMode);

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
    }
}