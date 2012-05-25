#region using
using System;
using System.Runtime.InteropServices;
#endregion

namespace Negar.DirectShow.Manager
{
    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport, Guid("56a868b1-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaControl
    {
        [PreserveSig]
        Int32 Run();

        [PreserveSig]
        Int32 Pause();

        [PreserveSig]
        Int32 Stop();

        [PreserveSig]
        Int32 GetState(Int32 msTimeout, out Int32 pfs);

        [PreserveSig]
        Int32 RenderFile(string strFilename);

        [PreserveSig]
        Int32 AddSourceFilter(
            [In] string strFilename,
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

        [PreserveSig]
        Int32 get_FilterCollection(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

        [PreserveSig]
        Int32 get_RegFilterCollection(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);

        [PreserveSig]
        Int32 StopWhenReady();
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a868b6-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaEvent
    {
        [PreserveSig]
        Int32 GetEventHandle(out IntPtr hEvent);

        [PreserveSig]
        Int32 GetEvent(out DsEvCode lEventCode, out Int32 lParam1, out Int32 lParam2, Int32 msTimeout);

        [PreserveSig]
        Int32 WaitForCompletion(Int32 msTimeout, out Int32 pEvCode);

        [PreserveSig]
        Int32 CancelDefaultHandling(Int32 lEvCode);

        [PreserveSig]
        Int32 RestoreDefaultHandling(Int32 lEvCode);

        [PreserveSig]
        Int32 FreeEventParams(DsEvCode lEvCode, Int32 lParam1, Int32 lParam2);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport, Guid("56a868c0-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaEventEx
    {
        #region "IMediaEvent Methods"

        [PreserveSig]
        Int32 GetEventHandle(out IntPtr hEvent);

        [PreserveSig]
        Int32 GetEvent(out DsEvCode lEventCode, out Int32 lParam1, out Int32 lParam2, Int32 msTimeout);

        [PreserveSig]
        Int32 WaitForCompletion(Int32 msTimeout, [Out] out Int32 pEvCode);

        [PreserveSig]
        Int32 CancelDefaultHandling(Int32 lEvCode);

        [PreserveSig]
        Int32 RestoreDefaultHandling(Int32 lEvCode);

        [PreserveSig]
        Int32 FreeEventParams(DsEvCode lEvCode, Int32 lParam1, Int32 lParam2);

        #endregion

        [PreserveSig]
        Int32 SetNotifyWindow(IntPtr hwnd, Int32 lMsg, IntPtr lInstanceData);

        [PreserveSig]
        Int32 SetNotifyFlags(Int32 lNoNotifyFlags);

        [PreserveSig]
        Int32 GetNotifyFlags(out Int32 lplNoNotifyFlags);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("329bb360-f6ea-11d1-9038-00a0c9697298"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IBasicVideo2
    {
        [PreserveSig]
        Int32 AvgTimePerFrame(out double pAvgTimePerFrame);

        [PreserveSig]
        Int32 BitRate(out Int32 pBitRate);

        [PreserveSig]
        Int32 BitErrorRate(out Int32 pBitRate);

        [PreserveSig]
        Int32 VideoWidth(out Int32 pVideoWidth);

        [PreserveSig]
        Int32 VideoHeight(out Int32 pVideoHeight);


        [PreserveSig]
        Int32 put_SourceLeft(Int32 SourceLeft);

        [PreserveSig]
        Int32 get_SourceLeft(out Int32 pSourceLeft);

        [PreserveSig]
        Int32 put_SourceWidth(Int32 SourceWidth);

        [PreserveSig]
        Int32 get_SourceWidth(out Int32 pSourceWidth);

        [PreserveSig]
        Int32 put_SourceTop(Int32 SourceTop);

        [PreserveSig]
        Int32 get_SourceTop(out Int32 pSourceTop);

        [PreserveSig]
        Int32 put_SourceHeight(Int32 SourceHeight);

        [PreserveSig]
        Int32 get_SourceHeight(out Int32 pSourceHeight);


        [PreserveSig]
        Int32 put_DestinationLeft(Int32 DestinationLeft);

        [PreserveSig]
        Int32 get_DestinationLeft(out Int32 pDestinationLeft);

        [PreserveSig]
        Int32 put_DestinationWidth(Int32 DestinationWidth);

        [PreserveSig]
        Int32 get_DestinationWidth(out Int32 pDestinationWidth);

        [PreserveSig]
        Int32 put_DestinationTop(Int32 DestinationTop);

        [PreserveSig]
        Int32 get_DestinationTop(out Int32 pDestinationTop);

        [PreserveSig]
        Int32 put_DestinationHeight(Int32 DestinationHeight);

        [PreserveSig]
        Int32 get_DestinationHeight(out Int32 pDestinationHeight);

        [PreserveSig]
        Int32 SetSourcePosition(Int32 left, Int32 top, Int32 width, Int32 height);

        [PreserveSig]
        Int32 GetSourcePosition(out Int32 left, out Int32 top, out Int32 width, out Int32 height);

        [PreserveSig]
        Int32 SetDefaultSourcePosition();


        [PreserveSig]
        Int32 SetDestinationPosition(Int32 left, Int32 top, Int32 width, Int32 height);

        [PreserveSig]
        Int32 GetDestinationPosition(out Int32 left, out Int32 top, out Int32 width, out Int32 height);

        [PreserveSig]
        Int32 SetDefaultDestinationPosition();


        [PreserveSig]
        Int32 GetVideoSize(out Int32 pWidth, out Int32 pHeight);

        [PreserveSig]
        Int32 GetVideoPaletteEntries(Int32 StartIndex, Int32 Entries, out Int32 pRetrieved, IntPtr pPalette);

        [PreserveSig]
        Int32 GetCurrentImage(ref Int32 pBufferSize, IntPtr pDIBImage);

        [PreserveSig]
        Int32 IsUsingDefaultSource();

        [PreserveSig]
        Int32 IsUsingDefaultDestination();

        [PreserveSig]
        Int32 GetPreferredAspectRatio(out Int32 plAspectX, out Int32 plAspectY);
    }


    [ComVisible(true), ComImport,
     Guid("56a868b4-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IVideoWindow
    {
        [PreserveSig]
        Int32 put_Caption(string caption);

        [PreserveSig]
        Int32 get_Caption([Out] out string caption);

        [PreserveSig]
        Int32 put_WindowStyle(Int32 windowStyle);

        [PreserveSig]
        Int32 get_WindowStyle(out Int32 windowStyle);

        [PreserveSig]
        Int32 put_WindowStyleEx(Int32 windowStyleEx);

        [PreserveSig]
        Int32 get_WindowStyleEx(out Int32 windowStyleEx);

        [PreserveSig]
        Int32 put_AutoShow(Int32 autoShow);

        [PreserveSig]
        Int32 get_AutoShow(out Int32 autoShow);

        [PreserveSig]
        Int32 put_WindowState(Int32 windowState);

        [PreserveSig]
        Int32 get_WindowState(out Int32 windowState);

        [PreserveSig]
        Int32 put_BackgroundPalette(Int32 backgroundPalette);

        [PreserveSig]
        Int32 get_BackgroundPalette(out Int32 backgroundPalette);

        [PreserveSig]
        Int32 put_Visible(Int32 visible);

        [PreserveSig]
        Int32 get_Visible(out Int32 visible);

        [PreserveSig]
        Int32 put_Left(Int32 left);

        [PreserveSig]
        Int32 get_Left(out Int32 left);

        [PreserveSig]
        Int32 put_Width(Int32 width);

        [PreserveSig]
        Int32 get_Width(out Int32 width);

        [PreserveSig]
        Int32 put_Top(Int32 top);

        [PreserveSig]
        Int32 get_Top(out Int32 top);

        [PreserveSig]
        Int32 put_Height(Int32 height);

        [PreserveSig]
        Int32 get_Height(out Int32 height);

        [PreserveSig]
        Int32 put_Owner(IntPtr owner);

        [PreserveSig]
        Int32 get_Owner(out IntPtr owner);

        [PreserveSig]
        Int32 put_MessageDrain(IntPtr drain);

        [PreserveSig]
        Int32 get_MessageDrain(out IntPtr drain);

        [PreserveSig]
        Int32 get_BorderColor(out Int32 color);

        [PreserveSig]
        Int32 put_BorderColor(Int32 color);

        [PreserveSig]
        Int32 get_FullScreenMode(out Int32 fullScreenMode);

        [PreserveSig]
        Int32 put_FullScreenMode(Int32 fullScreenMode);

        [PreserveSig]
        Int32 SetWindowForeground(Int32 focus);

        [PreserveSig]
        Int32 NotifyOwnerMessage(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam);

        [PreserveSig]
        Int32 SetWindowPosition(Int32 left, Int32 top, Int32 width, Int32 height);

        [PreserveSig]
        Int32 GetWindowPosition(out Int32 left, out Int32 top, out Int32 width, out Int32 height);

        [PreserveSig]
        Int32 GetMinIdealImageSize(out Int32 width, out Int32 height);

        [PreserveSig]
        Int32 GetMaxIdealImageSize(out Int32 width, out Int32 height);

        [PreserveSig]
        Int32 GetRestorePosition(out Int32 left, out Int32 top, out Int32 width, out Int32 height);

        [PreserveSig]
        Int32 HideCursor(Int32 hideCursor);

        [PreserveSig]
        Int32 IsCursorHidden(out Int32 hideCursor);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a868b2-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IMediaPosition
    {
        [PreserveSig]
        Int32 get_Duration(out double pLength);

        [PreserveSig]
        Int32 put_CurrentPosition(double llTime);

        [PreserveSig]
        Int32 get_CurrentPosition(out double pllTime);

        [PreserveSig]
        Int32 get_StopTime(out double pllTime);

        [PreserveSig]
        Int32 put_StopTime(double llTime);

        [PreserveSig]
        Int32 get_PrerollTime(out double pllTime);

        [PreserveSig]
        Int32 put_PrerollTime(double llTime);

        [PreserveSig]
        Int32 put_Rate(double dRate);

        [PreserveSig]
        Int32 get_Rate(out double pdRate);

        [PreserveSig]
        Int32 CanSeekForward(out Int32 pCanSeekForward);

        [PreserveSig]
        Int32 CanSeekBackward(out Int32 pCanSeekBackward);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a868b3-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IBasicAudio
    {
        [PreserveSig]
        Int32 put_Volume(Int32 lVolume);

        [PreserveSig]
        Int32 get_Volume(out Int32 plVolume);

        [PreserveSig]
        Int32 put_Balance(Int32 lBalance);

        [PreserveSig]
        Int32 get_Balance(out Int32 plBalance);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("56a868b9-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IAMCollection
    {
        [PreserveSig]
        Int32 get_Count(out Int32 plCount);

        [PreserveSig]
        Int32 Item(Int32 lItem,
                   [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppUnk);

        [PreserveSig]
        Int32 get_NewEnum(
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppUnk);
    }


    public enum DsEvCode
    {
        None,
        Complete = 0x01, // EC_COMPLETE
        UserAbort = 0x02, // EC_USERABORT
        ErrorAbort = 0x03, // EC_ERRORABORT
        Time = 0x04, // EC_TIME
        Repaint = 0x05, // EC_REPAINT
        StErrStopped = 0x06, // EC_STREAM_ERROR_STOPPED
        StErrStPlaying = 0x07, // EC_STREAM_ERROR_STILLPLAYING
        ErrorStPlaying = 0x08, // EC_ERROR_STILLPLAYING
        PaletteChanged = 0x09, // EC_PALETTE_CHANGED
        VideoSizeChanged = 0x0a, // EC_VIDEO_SIZE_CHANGED
        QualityChange = 0x0b, // EC_QUALITY_CHANGE
        ShuttingDown = 0x0c, // EC_SHUTTING_DOWN
        ClockChanged = 0x0d, // EC_CLOCK_CHANGED
        Paused = 0x0e, // EC_PAUSED
        OpeningFile = 0x10, // EC_OPENING_FILE
        BufferingData = 0x11, // EC_BUFFERING_DATA
        FullScreenLost = 0x12, // EC_FULLSCREEN_LOST
        Activate = 0x13, // EC_ACTIVATE
        NeedRestart = 0x14, // EC_NEED_RESTART
        WindowDestroyed = 0x15, // EC_WINDOW_DESTROYED
        DisplayChanged = 0x16, // EC_DISPLAY_CHANGED
        Starvation = 0x17, // EC_STARVATION
        OleEvent = 0x18, // EC_OLE_EVENT
        NotifyWindow = 0x19, // EC_NOTIFY_WINDOW
        // EC_ ....

        // DVDevCod.h
        DvdDomChange = 0x101, // EC_DVD_DOMAIN_CHANGE
        DvdTitleChange = 0x102, // EC_DVD_TITLE_CHANGE
        DvdChaptStart = 0x103, // EC_DVD_CHAPTER_START
        DvdAudioStChange = 0x104, // EC_DVD_AUDIO_STREAM_CHANGE

        DvdSubPicStChange = 0x105, // EC_DVD_SUBPICTURE_STREAM_CHANGE
        DvdAngleChange = 0x106, // EC_DVD_ANGLE_CHANGE
        DvdButtonChange = 0x107, // EC_DVD_BUTTON_CHANGE
        DvdValidUopsChange = 0x108, // EC_DVD_VALID_UOPS_CHANGE
        DvdStillOn = 0x109, // EC_DVD_STILL_ON
        DvdStillOff = 0x10a, // EC_DVD_STILL_OFF
        DvdCurrentTime = 0x10b, // EC_DVD_CURRENT_TIME
        DvdError = 0x10c, // EC_DVD_ERROR
        DvdWarning = 0x10d, // EC_DVD_WARNING
        DvdChaptAutoStop = 0x10e, // EC_DVD_CHAPTER_AUTOSTOP
        DvdNoFpPgc = 0x10f, // EC_DVD_NO_FP_PGC
        DvdPlaybRateChange = 0x110, // EC_DVD_PLAYBACK_RATE_CHANGE
        DvdParentalLChange = 0x111, // EC_DVD_PARENTAL_LEVEL_CHANGE
        DvdPlaybStopped = 0x112, // EC_DVD_PLAYBACK_STOPPED
        DvdAnglesAvail = 0x113, // EC_DVD_ANGLES_AVAILABLE
        DvdPeriodAStop = 0x114, // EC_DVD_PLAYPERIOD_AUTOSTOP
        DvdButtonAActivated = 0x115, // EC_DVD_BUTTON_AUTO_ACTIVATED
        DvdCmdStart = 0x116, // EC_DVD_CMD_START
        DvdCmdEnd = 0x117, // EC_DVD_CMD_END
        DvdDiscEjected = 0x118, // EC_DVD_DISC_EJECTED
        DvdDiscInserted = 0x119, // EC_DVD_DISC_INSERTED
        DvdCurrentHmsfTime = 0x11a, // EC_DVD_CURRENT_HMSF_TIME
        DvdKaraokeMode = 0x11b // EC_DVD_KARAOKE_MODE
    }
}