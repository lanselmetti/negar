using System;
using System.Runtime.InteropServices;

namespace Negar.DirectShow.Manager.Dvd
{
    [Flags]
    public enum DvdGraphFlags // AM_DVD_GRAPH_FLAGS
    {
        Default = 0x00000000,
        HwDecPrefer = 0x00000001, // AM_DVD_HWDEC_PREFER
        HwDecOnly = 0x00000002, // AM_DVD_HWDEC_ONLY
        SwDecPrefer = 0x00000004, // AM_DVD_SWDEC_PREFER
        SwDecOnly = 0x00000008, // AM_DVD_SWDEC_ONLY
        NoVpe = 0x00000100 // AM_DVD_NOVPE
    }

    [Flags]
    public enum DvdStreamFlags // AM_DVD_STREAM_FLAGS
    {
        None = 0x00000000,
        Video = 0x00000001, // AM_DVD_STREAM_VIDEO
        Audio = 0x00000002, // AM_DVD_STREAM_AUDIO
        SubPic = 0x00000004 // AM_DVD_STREAM_SUBPIC
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdRenderStatus //  AM_DVD_RENDERSTATUS
    {
        public Int32 vpeStatus;
        public bool volInvalid;
        public bool volUnknown;
        public bool noLine21In;
        public bool noLine21Out;
        public Int32 numStreams;
        public Int32 numStreamsFailed;
        public DvdStreamFlags failedStreams;
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("FCC152B6-F372-11d0-8E00-00C04FD7C08B"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdGraphBuilder
    {
        [PreserveSig]
        Int32 GetFiltergraph(
            [Out] out IGraphBuilder ppGB);

        [PreserveSig]
        Int32 GetDvdInterface(
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppvIF);

        [PreserveSig]
        Int32 RenderDvdVideoVolume(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwszPathName,
            DvdGraphFlags dwFlags,
            [Out] out DvdRenderStatus pStatus);
    }

    [Flags]
    public enum DvdCmdFlags // DVD_CMD_FLAGS
    {
        None = 0x00000000, // DVD_CMD_FLAG_None
        Flush = 0x00000001, // DVD_CMD_FLAG_Flush
        SendEvt = 0x00000002, // DVD_CMD_FLAG_SendEvents
        Block = 0x00000004, // DVD_CMD_FLAG_Block
        StartWRendered = 0x00000008, // DVD_CMD_FLAG_StartWhenRendered
        EndARendered = 0x00000010 // DVD_CMD_FLAG_EndAfterRendered
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdTimeCode //  DVD_HMSF_TIMECODE
    {
        public byte bHours;
        public byte bMinutes;
        public byte bSeconds;
        public byte bFrames;
    }

    public enum DvdMenuID // DVD_MENU_ID
    {
        Title = 2, // DVD_MENU_Title
        Root = 3, // DVD_MENU_Root
        Subpicture = 4, // DVD_MENU_Subpicture
        Audio = 5, // DVD_MENU_Audio
        Angle = 6, // DVD_MENU_Angle
        Chapter = 7 // DVD_MENU_Chapter
    }


    public enum DvdRelButton // DVD_RELATIVE_BUTTON
    {
        Upper = 1, // DVD_Relative_Upper
        Lower = 2, // DVD_Relative_Lower
        Left = 3, // DVD_Relative_Left
        Right = 4 // DVD_Relative_Right
    }


    public enum DvdOptionFlag // DVD_OPTION_FLAG
    {
        ResetOnStop = 1, // DVD_ResetOnStop
        NotifyParentalLevelChange = 2, // DVD_NotifyParentalLevelChange
        HmsfTimeCodeEvt = 3 // DVD_HMSF_TimeCodeEvents
    }


    public enum DvdAudioLangExt // DVD_AUDIO_LANG_EXT
    {
        NotSpecified = 0, // DVD_AUD_EXT_NotSpecified
        Captions = 1, // DVD_AUD_EXT_Captions
        VisuallyImpaired = 2, // DVD_AUD_EXT_VisuallyImpaired
        DirectorComments1 = 3, // DVD_AUD_EXT_DirectorComments1
        DirectorComments2 = 4 // DVD_AUD_EXT_DirectorComments2
    }

    public enum DvdSubPicLangExt // DVD_SUBPICTURE_LANG_EXT
    {
        NotSpecified = 0, // DVD_SP_EXT_NotSpecified
        CaptionNormal = 1, // DVD_SP_EXT_Caption_Normal
        CaptionBig = 2, // DVD_SP_EXT_Caption_Big
        CaptionChildren = 3, // DVD_SP_EXT_Caption_Children
        ClosedNormal = 5, // DVD_SP_EXT_CC_Normal
        ClosedBig = 6, // DVD_SP_EXT_CC_Big
        ClosedChildren = 7, // DVD_SP_EXT_CC_Children
        Forced = 9, // DVD_SP_EXT_Forced
        DirectorCmtNormal = 13, // DVD_SP_EXT_DirectorComments_Normal
        DirectorCmtBig = 14, // DVD_SP_EXT_DirectorComments_Big
        DirectorCmtChildren = 15, // DVD_SP_EXT_DirectorComments_Children
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("33BC7430-EEC0-11D2-8201-00A0C9D74842"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdControl2
    {
        [PreserveSig]
        Int32 PlayTitle(Int32 ulTitle, DvdCmdFlags dwFlags,
                        [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayChapterInTitle(Int32 ulTitle, Int32 ulChapter, DvdCmdFlags dwFlags,
                                 [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayAtTimeInTitle(Int32 ulTitle, [In] ref DvdTimeCode pStartTime,
                                DvdCmdFlags dwFlags, [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 Stop();

        [PreserveSig]
        Int32 ReturnFromSubmenu(DvdCmdFlags dwFlags, [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayAtTime([In] ref DvdTimeCode pTime, DvdCmdFlags dwFlags,
                         [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayChapter(Int32 ulChapter, DvdCmdFlags dwFlags,
                          [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayPrevChapter(DvdCmdFlags dwFlags,
                              [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 ReplayChapter(DvdCmdFlags dwFlags,
                            [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayNextChapter(DvdCmdFlags dwFlags,
                              [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayForwards(double dSpeed, DvdCmdFlags dwFlags,
                           [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayBackwards(double dSpeed, DvdCmdFlags dwFlags,
                            [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 ShowMenu(DvdMenuID MenuID, DvdCmdFlags dwFlags,
                       [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 Resume(DvdCmdFlags dwFlags,
                     [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 SelectRelativeButton(DvdRelButton buttonDir);

        [PreserveSig]
        Int32 ActivateButton();

        [PreserveSig]
        Int32 SelectButton(Int32 ulButton);

        [PreserveSig]
        Int32 SelectAndActivateButton(Int32 ulButton);

        [PreserveSig]
        Int32 StillOff();

        [PreserveSig]
        Int32 Pause(
            [In, MarshalAs(UnmanagedType.Bool)] bool bState);

        [PreserveSig]
        Int32 SelectAudioStream(Int32 ulAudio, DvdCmdFlags dwFlags,
                                [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 SelectSubpictureStream(Int32 ulSubPicture, DvdCmdFlags dwFlags,
                                     [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 SetSubpictureState(
            [In, MarshalAs(UnmanagedType.Bool)] bool bState,
            DvdCmdFlags dwFlags,
            [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 SelectAngle(Int32 ulAngle, DvdCmdFlags dwFlags,
                          [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 SelectParentalLevel(Int32 ulParentalLevel);

        [PreserveSig]
        Int32 SelectParentalCountry(byte[] bCountry);

        [PreserveSig]
        Int32 SelectKaraokeAudioPresentationMode(Int32 ulMode);

        [PreserveSig]
        Int32 SelectVideoModePreference(Int32 ulPreferredDisplayMode);

        [PreserveSig]
        Int32 SetDVDDirectory(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszwPath);

        [PreserveSig]
        Int32 ActivateAtPosition(DsPOINT point);

        [PreserveSig]
        Int32 SelectAtPosition(DsPOINT point);

        [PreserveSig]
        Int32 PlayChaptersAutoStop(Int32 ulTitle, Int32 ulChapter, Int32 ulChaptersToPlay, DvdCmdFlags dwFlags,
                                   [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 AcceptParentalLevelChange(
            [In, MarshalAs(UnmanagedType.Bool)] bool bAccept);

        [PreserveSig]
        Int32 SetOption(DvdOptionFlag flag,
                        [In, MarshalAs(UnmanagedType.Bool)] bool fState);

        [PreserveSig]
        Int32 SetState(IDvdState pState, DvdCmdFlags dwFlags,
                       [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 PlayPeriodInTitleAutoStop(Int32 ulTitle,
                                        [In] ref DvdTimeCode pStartTime,
                                        [In] ref DvdTimeCode pEndTime,
                                        DvdCmdFlags dwFlags,
                                        [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 SetGPRM(Int32 ulIndex, short wValue, DvdCmdFlags dwFlags,
                      [Out] OptIDvdCmd ppCmd);

        [PreserveSig]
        Int32 SelectDefaultMenuLanguage(Int32 Language);

        [PreserveSig]
        Int32 SelectDefaultAudioLanguage(Int32 Language, DvdAudioLangExt audioExtension);

        [PreserveSig]
        Int32 SelectDefaultSubpictureLanguage(Int32 Language, DvdSubPicLangExt subpictureExtension);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("5a4a97e4-94ee-4a55-9751-74b5643aa27d"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdCmd
    {
        [PreserveSig]
        Int32 WaitForStart();

        [PreserveSig]
        Int32 WaitForEnd();
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("86303d6d-1c4a-4087-ab42-f711167048ef"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdState
    {
        [PreserveSig]
        Int32 GetDiscID([Out] out long pullUniqueID);

        [PreserveSig]
        Int32 GetParentalLevel([Out] out Int32 pulParentalLevel);
    }

    //	DVD INFO

    public enum DvdDomain // DVD_DOMAIN
    {
        FirstPlay = 1, // DVD_DOMAIN_FirstPlay
        VideoManagerMenu = 2, // DVD_DOMAIN_VideoManagerMenu
        VideoTitleSetMenu = 3, // DVD_DOMAIN_VideoTitleSetMenu
        Title = 4, // DVD_DOMAIN_Title
        Stop = 5 // DVD_DOMAIN_Stop
    }

    public enum DvdVideoCompress // DVD_VIDEO_COMPRESSION
    {
        Other = 0, // DVD_VideoCompression_Other
        Mpeg1 = 1, // DVD_VideoCompression_MPEG1
        Mpeg2 = 2 // DVD_VideoCompression_MPEG2
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdPlayLocation // DVD_PLAYBACK_LOCATION2
    {
        public Int32 TitleNum;
        public Int32 ChapterNum;
        public DvdTimeCode timeCode;
        public Int32 TimeCodeFlags;
    }

    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdMenuAttr // DVD_MenuAttributes
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public bool[] compatibleRegion;
        public DvdVideoAttr videoAt; // DVD_VideoAttributes

        public bool audioPresent;
        public DvdAudioAttr audioAt; // DVD_AudioAttributes

        public bool subPicPresent;
        public DvdSubPicAttr subPicAt; // DVD_SubpictureAttributes
    }


    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdVideoAttr // DVD_VideoAttributes
    {
        public bool panscanPermitted;
        public bool letterboxPermitted;
        public Int32 aspectX;
        public Int32 aspectY;
        public Int32 frameRate;
        public Int32 frameHeight;
        public DvdVideoCompress compression;
        public bool line21Field1InGOP;
        public bool line21Field2InGOP;
        public Int32 sourceResolutionX;
        public Int32 sourceResolutionY;
        public bool isSourceLetterboxed;
        public bool isFilmMode;
    }


    // ---------------------------------------------------------------------------------------

    public enum DvdAudioAppMode // DVD_AUDIO_APPMODE
    {
        None = 0, // DVD_AudioMode_None
        Karaoke = 1, // DVD_AudioMode_Karaoke
        Surround = 2, // DVD_AudioMode_Surround
        Other = 3 // DVD_AudioMode_Other
    }

    // ---------------------------------------------------------------------------------------

    public enum DvdAudioFormat // DVD_AUDIO_FORMAT
    {
        Ac3 = 0, // DVD_AudioFormat_AC3
        Mpeg1 = 1, // DVD_AudioFormat_MPEG1
        Mpeg1Drc = 2, // DVD_AudioFormat_MPEG1_DRC
        Mpeg2 = 3, // DVD_AudioFormat_MPEG2
        Mpeg2Drc = 4, // DVD_AudioFormat_MPEG2_DRC
        Lpcm = 5, // DVD_AudioFormat_LPCM
        Dts = 6, // DVD_AudioFormat_DTS
        Sdds = 7, // DVD_AudioFormat_SDDS
        Other = 8 // DVD_AudioFormat_Other
    }


    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdAudioAttr // DVD_AudioAttributes
    {
        public DvdAudioAppMode appMode;
        public Int32 appModeData;
        public DvdAudioFormat audioFormat;
        public Int32 language;
        public DvdAudioLangExt languageExtension;
        public bool hasMultichannelInfo;
        public Int32 frequency;
        public byte quantization;
        public byte numberOfChannels;
        public short dummy;
        public Int32 res1;
        public Int32 res2;
    }


    // ---------------------------------------------------------------------------------------

    public enum DvdSubPicType // DVD_SUBPICTURE_TYPE
    {
        NotSpecified = 0, // DVD_SPType_NotSpecified
        Language = 1, // DVD_SPType_Language
        Other = 2 // DVD_SPType_Other
    }

    public enum DvdSubPicCoding // DVD_SUBPICTURE_CODING
    {
        RunLength = 0, // DVD_SPCoding_RunLength
        Extended = 1, // DVD_SPCoding_Extended
        Other = 2 // DVD_SPCoding_Other
    }


    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdSubPicAttr // DVD_SubpictureAttributes
    {
        public DvdSubPicType type;
        public DvdSubPicCoding coding;
        public Int32 language;
        public DvdSubPicLangExt languageExt;
    }


    // ---------------------------------------------------------------------------------------

    public enum DvdTitleAppMode // DVD_TITLE_APPMODE
    {
        NotSpecified = 0, // DVD_AppMode_Not_Specified
        Karaoke = 1, // DVD_AppMode_Karaoke
        Other = 3 // DVD_AppMode_Other
    }

    // ---------------------------------------------------------------------------------------

    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdTitleAttr // DVD_TitleAttributes
    {
        public DvdTitleAppMode appMode; // DVD_TITLE_APPMODE
        public DvdVideoAttr videoAt; // DVD_VideoAttributes
        public Int32 numberOfAudioStreams;
        // WARNING: incomplete
    }


    // ---------------------------------------------------------------------------------------

    public enum DvdDiscSide // DVD_DISC_SIDE
    {
        A = 1, // DVD_SIDE_A
        B = 2 // DVD_SIDE_B
    }


    // ---------------------------------------------------------------------------------------

    public enum DvdCharSet // DVD_TextCharSet
    {
        Unicode = 0, // DVD_CharSet_Unicode
        Iso646 = 1, // DVD_CharSet_ISO646
        Jis = 2, // DVD_CharSet_JIS_Roman_Kanji
        Iso8859 = 3, // DVD_CharSet_ISO8859_1
        SiftJis = 4 // DVD_CharSet_ShiftJIS_Kanji_Roman_Katakana
    }


    [Flags]
    public enum DvdAudioCaps // DVD_AUDIO_CAPS_xx
    {
        Ac3 = 0x00000001, // DVD_AUDIO_CAPS_AC3
        Mpeg2 = 0x00000002, // DVD_AUDIO_CAPS_MPEG2
        Lpcm = 0x00000004, // DVD_AUDIO_CAPS_LPCM
        Dts = 0x00000008, // DVD_AUDIO_CAPS_DTS
        Sdds = 0x00000010 // DVD_AUDIO_CAPS_SDDS
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1), ComVisible(false)]
    public struct DvdDecoderCaps // DVD_DECODER_CAPS
    {
        public Int32 size; // size of this struct
        public DvdAudioCaps audioCaps;
        public double fwdMaxRateVideo;
        public double fwdMaxRateAudio;
        public double fwdMaxRateSP;
        public double bwdMaxRateVideo;
        public double bwdMaxRateAudio;
        public double bwdMaxRateSP;
        public Int32 res1;
        public Int32 res2;
        public Int32 res3;
        public Int32 res4;
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("34151510-EEC0-11D2-8201-00A0C9D74842"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDvdInfo2
    {
        [PreserveSig]
        Int32 GetCurrentDomain([Out] out DvdDomain pDomain);

        [PreserveSig]
        Int32 GetCurrentLocation([Out] out DvdPlayLocation pLocation);

        [PreserveSig]
        Int32 GetTotalTitleTime([Out] out DvdTimeCode pTotalTime, out Int32 ulTimeCodeFlags);

        [PreserveSig]
        Int32 GetCurrentButton(out Int32 pulButtonsAvailable, out Int32 pulCurrentButton);

        [PreserveSig]
        Int32 GetCurrentAngle(out Int32 pulAnglesAvailable, out Int32 pulCurrentAngle);

        [PreserveSig]
        Int32 GetCurrentAudio(out Int32 pulStreamsAvailable, out Int32 pulCurrentStream);

        [PreserveSig]
        Int32 GetCurrentSubpicture(out Int32 pulStreamsAvailable, out Int32 pulCurrentStream,
                                   [Out, MarshalAs(UnmanagedType.Bool)] out bool pbIsDisabled);

        [PreserveSig]
        Int32 GetCurrentUOPS(out Int32 pulUOPs);

        [PreserveSig]
        Int32 GetAllSPRMs(out IntPtr pRegisterArray);

        [PreserveSig]
        Int32 GetAllGPRMs(out IntPtr pRegisterArray);

        [PreserveSig]
        Int32 GetAudioLanguage(Int32 ulStream, out Int32 pLanguage);

        [PreserveSig]
        Int32 GetSubpictureLanguage(Int32 ulStream, out Int32 pLanguage);

        [PreserveSig]
        Int32 GetTitleAttributes(Int32 ulTitle,
                                 [Out] out DvdMenuAttr pMenu, IntPtr pTitle); // incomplete

        [PreserveSig]
        Int32 GetVMGAttributes([Out] out DvdMenuAttr pATR);

        [PreserveSig]
        Int32 GetCurrentVideoAttributes([Out] out DvdVideoAttr pATR);

        [PreserveSig]
        Int32 GetAudioAttributes(Int32 ulStream, [Out] out DvdAudioAttr pATR);

        [PreserveSig]
        Int32 GetKaraokeAttributes(Int32 ulStream, IntPtr pATR);

        [PreserveSig]
        Int32 GetSubpictureAttributes(Int32 ulStream, [Out] out DvdSubPicAttr pATR);

        [PreserveSig]
        Int32 GetDVDVolumeInfo(out Int32 pulNumOfVolumes, out Int32 pulVolume,
                               out DvdDiscSide pSide, out Int32 pulNumOfTitles);

        [PreserveSig]
        Int32 GetDVDTextNumberOfLanguages(out Int32 pulNumOfLangs);

        [PreserveSig]
        Int32 GetDVDTextLanguageInfo(Int32 ulLangIndex,
                                     out Int32 pulNumOfStrings, out Int32 pLangCode, out DvdCharSet pbCharacterSet);

        [PreserveSig]
        Int32 GetDVDTextStringAsNative(Int32 ulLangIndex, Int32 ulStringIndex,
                                       IntPtr pbBuffer, Int32 ulMaxBufferSize, out Int32 pulActualSize, out Int32 pType);

        [PreserveSig]
        Int32 GetDVDTextStringAsUnicode(Int32 ulLangIndex, Int32 ulStringIndex,
                                        IntPtr pchwBuffer, Int32 ulMaxBufferSize, out Int32 pulActualSize,
                                        out Int32 pType);

        [PreserveSig]
        Int32 GetPlayerParentalLevel(out Int32 pulParentalLevel, [Out] byte[] pbCountryCode);

        [PreserveSig]
        Int32 GetNumberOfChapters(Int32 ulTitle, out Int32 pulNumOfChapters);

        [PreserveSig]
        Int32 GetTitleParentalLevels(Int32 ulTitle, out Int32 pulParentalLevels);

        [PreserveSig]
        Int32 GetDVDDirectory(IntPtr pszwPath, Int32 ulMaxSize, out Int32 pulActualSize);

        [PreserveSig]
        Int32 IsAudioStreamEnabled(Int32 ulStreamNum,
                                   [Out, MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);

        [PreserveSig]
        Int32 GetDiscID(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszwPath,
            out long pullDiscID);

        [PreserveSig]
        Int32 GetState(
            [Out] out IDvdState pStateData);

        [PreserveSig]
        Int32 GetMenuLanguages([Out] Int32[] pLanguages, Int32 ulMaxLanguages, out Int32 pulActualLanguages);

        [PreserveSig]
        Int32 GetButtonAtPosition(DsPOINT point, out Int32 pulButtonIndex);

        [PreserveSig]
        Int32 GetCmdFromEvent(Int32 lParam1,
                              [Out] out IDvdCmd pCmdObj);

        [PreserveSig]
        Int32 GetDefaultMenuLanguage(out Int32 pLanguage);

        [PreserveSig]
        Int32 GetDefaultAudioLanguage(out Int32 pLanguage, out DvdAudioLangExt pAudioExtension);

        [PreserveSig]
        Int32 GetDefaultSubpictureLanguage(out Int32 pLanguage, out DvdSubPicLangExt pSubpictureExtension);

        [PreserveSig]
        Int32 GetDecoderCaps(ref DvdDecoderCaps pCaps);

        [PreserveSig]
        Int32 GetButtonRect(Int32 ulButton, out DsRECT pRect);

        [PreserveSig]
        Int32 IsSubpictureStreamEnabled(Int32 ulStreamNum,
                                        [Out, MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class OptIDvdCmd
    {
        public IDvdCmd dvdCmd;
    }
} // namespace Negar.DirectShow.Manager.Dvd