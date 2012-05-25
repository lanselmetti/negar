using System;
using System.Drawing;
using System.Runtime.InteropServices;

// Extended streaming interfaces, ported from axextend.idl
namespace Negar.DirectShow.Manager
{
    [ComVisible(true), ComImport,
     Guid("93E5A4E0-2D50-11d2-ABFA-00A0C9C6E38D"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICaptureGraphBuilder2
    {
        [PreserveSig]
        Int32 SetFiltergraph([In] IGraphBuilder pfg);

        [PreserveSig]
        Int32 GetFiltergraph([Out] out IGraphBuilder ppfg);

        [PreserveSig]
        Int32 SetOutputFileName(
            [In] ref Guid pType,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpstrFile,
            [Out] out IBaseFilter ppbf,
            [Out] out IFileSinkFilter ppSink);

        [PreserveSig]
        Int32 FindInterface(
            [In] ref Guid pCategory,
            [In] ref Guid pType,
            [In] IBaseFilter pbf,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppint);

        [PreserveSig]
        Int32 RenderStream(
            [In] ref Guid pCategory,
            [In] ref Guid pType,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pSource,
            [In] IBaseFilter pfCompressor,
            [In] IBaseFilter pfRenderer);

        [PreserveSig]
        Int32 ControlStream(
            [In] ref Guid pCategory,
            [In] ref Guid pType,
            [In] IBaseFilter pFilter,
            [In] long pstart,
            [In] long pstop,
            [In] short wStartCookie,
            [In] short wStopCookie);

        [PreserveSig]
        Int32 AllocCapFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpstrFile,
            [In] long dwlSize);

        [PreserveSig]
        Int32 CopyCaptureFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpwstrOld,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpwstrNew,
            [In] Int32 fAllowEscAbort,
            [In] IAMCopyCaptureFileProgress pFilter);


        [PreserveSig]
        Int32 FindPin(
            [In] object pSource,
            [In] Int32 pindir,
            [In] ref Guid pCategory,
            [In] ref Guid pType,
            [In, MarshalAs(UnmanagedType.Bool)] bool fUnconnected,
            [In] Int32 num,
            [Out] out IPin ppPin);
    }


    [ComVisible(true), ComImport,
     Guid("56a868a9-0ad4-11ce-b03a-0020af0ba770"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IGraphBuilder
    {
        #region "IFilterGraph Methods"

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

        #endregion

        [PreserveSig]
        Int32 Connect([In] IPin ppinOut, [In] IPin ppinIn);

        [PreserveSig]
        Int32 Render([In] IPin ppinOut);

        [PreserveSig]
        Int32 RenderFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFile,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrPlayList);

        [PreserveSig]
        Int32 AddSourceFilter(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFilterName,
            [Out] out IBaseFilter ppFilter);

        [PreserveSig]
        Int32 SetLogFile(IntPtr hFile);

        [PreserveSig]
        Int32 Abort();

        [PreserveSig]
        Int32 ShouldOperationContinue();
    }


    // ---------------------------------------------------------------------------------------


    [ComVisible(true), ComImport,
     Guid("a2104830-7c70-11cf-8bce-00aa00a3f1a6"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileSinkFilter
    {
        [PreserveSig]
        Int32 SetFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 GetCurFile(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pszFileName,
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);
    }

    [ComVisible(true), ComImport,
     Guid("00855B90-CE1B-11d0-BD4F-00A0C911CE86"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileSinkFilter2
    {
        [PreserveSig]
        Int32 SetFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 GetCurFile(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pszFileName,
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 SetMode([In] Int32 dwFlags);

        [PreserveSig]
        Int32 GetMode([Out] out Int32 dwFlags);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("670d1d20-a068-11d0-b3f0-00aa003761c5"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMCopyCaptureFileProgress
    {
        [PreserveSig]
        Int32 Progress(Int32 iProgress);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("e46a9787-2b71-444d-a4b5-1fab7b708d6a"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVideoFrameStep
    {
        [PreserveSig]
        Int32 Step(Int32 dwFrames,
                   [In, MarshalAs(UnmanagedType.IUnknown)] object pStepObject);

        [PreserveSig]
        Int32 CanStep(Int32 bMultiple,
                      [In, MarshalAs(UnmanagedType.IUnknown)] object pStepObject);

        [PreserveSig]
        Int32 CancelStep();
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("C6E13340-30AC-11d0-A18C-00A0C9118956"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMStreamConfig
    {
        [PreserveSig]
        Int32 SetFormat(
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        Int32 GetFormat(
            [Out] out IntPtr pmt);

        [PreserveSig]
        Int32 GetNumberOfCapabilities(out Int32 piCount, out Int32 piSize);

        [PreserveSig]
        Int32 GetStreamCaps(Int32 iIndex,
            //[Out, MarshalAs(UnmanagedType.LPStruct)]	out AMMediaType	ppmt,
                            [Out] out IntPtr pmt,
                            [In] IntPtr pSCC);
    }


    // =============================================================================
    //											TUNER
    // =============================================================================

    [ComVisible(false)]
    public enum AMTunerSubChannel
    {
        NoTune = -2, // AMTUNER_SUBCHAN_NO_TUNE : don't tune
        Default = -1 // AMTUNER_SUBCHAN_DEFAULT : use default sub chan
    }

    [ComVisible(false)]
    public enum AMTunerSignalStrength
    {
        NA = -1, // AMTUNER_HASNOSIGNALSTRENGTH : cannot indicate signal strength
        NoSignal = 0, // AMTUNER_NOSIGNAL : no signal available
        SignalPresent = 1 // AMTUNER_SIGNALPRESENT : signal present
    }

    [Flags, ComVisible(false)]
    public enum AMTunerModeType
    {
        Default = 0x0000, // AMTUNER_MODE_DEFAULT : default tuner mode
        TV = 0x0001, // AMTUNER_MODE_TV : tv
        FMRadio = 0x0002, // AMTUNER_MODE_FM_RADIO : fm radio
        AMRadio = 0x0004, // AMTUNER_MODE_AM_RADIO : am radio
        Dss = 0x0008 // AMTUNER_MODE_DSS : dss
    }

    [ComVisible(false)]
    public enum AMTunerEventType
    {
        Changed = 0x0001, // AMTUNER_EVENT_CHANGED : status changed
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("211A8761-03AC-11d1-8D13-00AA00BD8339"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTuner
    {
        [PreserveSig]
        Int32 put_Channel(Int32 lChannel, AMTunerSubChannel lVideoSubChannel, AMTunerSubChannel lAudioSubChannel);

        [PreserveSig]
        Int32 get_Channel(out Int32 plChannel, out Int32 plVideoSubChannel, out Int32 plAudioSubChannel);

        [PreserveSig]
        Int32 ChannelMinMax(out Int32 lChannelMin, out Int32 lChannelMax);

        [PreserveSig]
        Int32 put_CountryCode(Int32 lCountryCode);

        [PreserveSig]
        Int32 get_CountryCode(out Int32 plCountryCode);

        [PreserveSig]
        Int32 put_TuningSpace(Int32 lTuningSpace);

        [PreserveSig]
        Int32 get_TuningSpace(out Int32 plTuningSpace);

        [PreserveSig]
        Int32 Logon(IntPtr hCurrentUser);

        [PreserveSig]
        Int32 Logout();

        [PreserveSig]
        Int32 SignalPresent(out AMTunerSignalStrength plSignalStrength);

        [PreserveSig]
        Int32 put_Mode(AMTunerModeType lMode);

        [PreserveSig]
        Int32 get_Mode(out AMTunerModeType plMode);

        [PreserveSig]
        Int32 GetAvailableModes(out AMTunerModeType plModes);

        [PreserveSig]
        Int32 RegisterNotificationCallBack(IAMTunerNotification pNotify, AMTunerEventType lEvents);

        [PreserveSig]
        Int32 UnRegisterNotificationCallBack(IAMTunerNotification pNotify);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("211A8760-03AC-11d1-8D13-00AA00BD8339"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTunerNotification
    {
        [PreserveSig]
        Int32 OnEvent(AMTunerEventType Event);
    }


    // ---------------------------------------------------------------------------------------
    [Flags, ComVisible(false)]
    public enum AnalogVideoStandard
    {
        None = 0x00000000, // This is a digital sensor
        NTSC_M = 0x00000001, //        75 IRE Setup
        NTSC_M_J = 0x00000002, // Japan,  0 IRE Setup
        NTSC_433 = 0x00000004,
        PAL_B = 0x00000010,
        PAL_D = 0x00000020,
        PAL_G = 0x00000040,
        PAL_H = 0x00000080,
        PAL_I = 0x00000100,
        PAL_M = 0x00000200,
        PAL_N = 0x00000400,
        PAL_60 = 0x00000800,
        SECAM_B = 0x00001000,
        SECAM_D = 0x00002000,
        SECAM_G = 0x00004000,
        SECAM_H = 0x00008000,
        SECAM_K = 0x00010000,
        SECAM_K1 = 0x00020000,
        SECAM_L = 0x00040000,
        SECAM_L1 = 0x00080000,
        PAL_N_COMBO = 0x00100000 // Argentina
    }

    // ---------------------------------------------------------------------------------------

    [ComVisible(false)]
    public enum TunerInputType
    {
        Cable,
        Antenna
    }

    [ComVisible(false)]
    public enum VideoProcAmpProperty
    {
        Brightness,
        Contrast,
        Hue,
        Saturation,
        Sharpness,
        Gamma,
        ColorEnable,
        WhiteBalance,
        BacklightCompensation,
        Gain
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("C6E13360-30AC-11d0-A18C-00A0C9118956"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoProcAmp
    {
        [PreserveSig]
        Int32 GetRange(VideoProcAmpProperty property, [Out] out Int32 min, [Out] out Int32 max,
                       [Out] out Int32 steppingDelta,
                       [Out] out Int32 defaultValue, out Int32 capFlags);

        //Int32 GetRange( Int32 prop, [Out] out Int32 min, [Out] out Int32 max, [Out] out Int32 steppingDelta, [Out] out Int32 defaultValue, out Int32 capFlags);

        [PreserveSig]
        Int32 Set(VideoProcAmpProperty property, Int32 value, Int32 flags);

        [PreserveSig]
        Int32 Get(VideoProcAmpProperty property, out Int32 value, out Int32 flags);
    }

    // ---------------------------------------------------------------------------------------
    [ComVisible(true), ComImport,
     Guid("C6E13350-30AC-11d0-A18C-00A0C9118956"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMAnalogVideoDecoder
    {
        //Gets the supported analog video standards (NTSC/M, PAL/B, SECAM/K1...
        [PreserveSig]
        Int32 get_AvailableTVFormats(out AnalogVideoStandard videoStandard);

        //Sets or gets the current analog video standard (NTSC/M, PAL/B, SECAM/K1, ...
        [PreserveSig]
        Int32 put_TVFormat(AnalogVideoStandard videoStandard);

        // Sets or gets the current analog video standard (NTSC/M, PAL/B, SECAM/K1, ...
        [PreserveSig]
        Int32 get_TVFormat(out AnalogVideoStandard videoStandard);

        // True if horizontal sync is locked
        [PreserveSig]
        Int32 get_HorizontalLocked(out Int32 locked);

        // True if connected to a VCR (changes PLL timing)
        [PreserveSig]
        Int32 put_VCRHorizontalLocking(Int32 VCRHorizontalLocking);

        [PreserveSig]
        Int32 get_VCRHorizontalLocking(out Int32 VCRHorizontalLocking);

        // Returns the number of lines in the video signal")]
        [PreserveSig]
        Int32 get_NumberOfLines(out Int32 numberOfLines);

        // Enables or disables the output bus
        [PreserveSig]
        Int32 put_OutputEnable(Int32 outputEnable);

        [PreserveSig]
        Int32 get_OutputEnable(out Int32 outputEnable);
    }


    // ---------------------------------------------------------------------------------------

    [ComVisible(true), ComImport,
     Guid("211A8766-03AC-11d1-8D13-00AA00BD8339"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTVTuner
    {
        #region "IAMTuner Methods"

        [PreserveSig]
        Int32 put_Channel(Int32 lChannel, AMTunerSubChannel lVideoSubChannel, AMTunerSubChannel lAudioSubChannel);

        [PreserveSig]
        Int32 get_Channel(out Int32 plChannel, out Int32 plVideoSubChannel, out Int32 plAudioSubChannel);

        [PreserveSig]
        Int32 ChannelMinMax(out Int32 lChannelMin, out Int32 lChannelMax);

        [PreserveSig]
        Int32 put_CountryCode(Int32 lCountryCode);

        [PreserveSig]
        Int32 get_CountryCode(out Int32 plCountryCode);

        [PreserveSig]
        Int32 put_TuningSpace(Int32 lTuningSpace);

        [PreserveSig]
        Int32 get_TuningSpace(out Int32 plTuningSpace);

        [PreserveSig]
        Int32 Logon(IntPtr hCurrentUser);

        [PreserveSig]
        Int32 Logout();

        [PreserveSig]
        Int32 SignalPresent(out AMTunerSignalStrength plSignalStrength);

        [PreserveSig]
        Int32 put_Mode(AMTunerModeType lMode);

        [PreserveSig]
        Int32 get_Mode(out AMTunerModeType plMode);

        [PreserveSig]
        Int32 GetAvailableModes(out AMTunerModeType plModes);

        [PreserveSig]
        Int32 RegisterNotificationCallBack(IAMTunerNotification pNotify, AMTunerEventType lEvents);

        [PreserveSig]
        Int32 UnRegisterNotificationCallBack(IAMTunerNotification pNotify);

        #endregion

        [PreserveSig]
        Int32 get_AvailableTVFormats(out AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        Int32 get_TVFormat(out AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        Int32 AutoTune(Int32 lChannel, out Int32 plFoundSignal);

        [PreserveSig]
        Int32 StoreAutoTune();

        [PreserveSig]
        Int32 get_NumInputConnections(out Int32 plNumInputConnections);

        [PreserveSig]
        Int32 put_InputType(Int32 lIndex, TunerInputType inputType);

        [PreserveSig]
        Int32 get_InputType(Int32 lIndex, out TunerInputType inputType);

        [PreserveSig]
        Int32 put_ConnectInput(Int32 lIndex);

        [PreserveSig]
        Int32 get_ConnectInput(out Int32 lIndex);

        [PreserveSig]
        Int32 get_VideoFrequency(out Int32 lFreq);

        [PreserveSig]
        Int32 get_AudioFrequency(out Int32 lFreq);
    }

    // ---------------------------------------------------------------------------------------
    [ComVisible(true), ComImport,
     Guid("C6E13380-30AC-11d0-A18C-00A0C9118956"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMCrossbar
    {
        [PreserveSig]
        Int32 get_PinCounts(
            [Out] out Int32 OutputPinCount,
            [Out] out Int32 InputPinCount);

        [PreserveSig]
        Int32 CanRoute(
            [In] Int32 OutputPinIndex,
            [In] Int32 InputPinIndex);

        [PreserveSig]
        Int32 Route(
            [In] Int32 OutputPinIndex,
            [In] Int32 InputPinIndex);

        [PreserveSig]
        Int32 get_IsRoutedTo(
            [In] Int32 OutputPinIndex,
            [Out] out Int32 InputPinIndex);

        [PreserveSig]
        Int32 get_CrossbarPinInfo(
            [In, MarshalAs(UnmanagedType.Bool)] bool IsInputPin,
            [In] Int32 PinIndex,
            [Out] out Int32 PinIndexRelated,
            [Out] out PhysicalConnectorType PhysicalType
            );
    }

    // ---------------------------------------------------------------------------------------
    [ComVisible(true), ComImport,
     Guid("54C39221-8380-11d0-B3F0-00AA003761C5"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMAudioInputMixer
    {
        // This interface is only supported by the input pins, not the filter
        // If disabled, this channel will not be mixed in as part of the
        // recorded signal.
        Int32 put_Enable(
            [In] bool fEnable); // TRUE=enable FALSE=disable

        //Is this channel enabled?
        Int32 get_Enable(
            [Out] out bool pfEnable);

        // When set to mono mode, making a stereo recording of this channel
        // will have both channels contain the same data... a mixture of the
        // left and right signals
        Int32 put_Mono(
            [In] bool fMono); // TRUE=mono FALSE=multi channel

        //all channels combined into a mono signal?
        Int32 get_Mono(
            [Out] out bool pfMono);

        // !!! WILL CARDS BE ABLE TO BOOST THE GAIN?
        //Set the record level for this channel
        Int32 put_MixLevel(
            [In] double Level); // 0 = off, 1 = full (unity?) volume
        // AMF_AUTOMATICGAIN, if supported,
        // means automatic

        //Get the record level for this channel
        Int32 get_MixLevel(
            [Out] out double pLevel);

        // For instance, when panned full left, and you make a stereo recording
        // of this channel, you will record a silent right channel.
        Int32 put_Pan(
            [In] double Pan); // -1 = full left, 0 = centre, 1 = right

        //Get the pan for this channel
        Int32 get_Pan(
            [Out] out double pPan);

        // Boosts the bass of low volume signals before they are recorded
        // to compensate for the fact that your ear has trouble hearing quiet
        // bass sounds
        Int32 put_Loudness(
            [In] bool fLoudness); // TRUE=on FALSE=off

        Int32 get_Loudness(
            [Out] out bool pfLoudness);

        // boosts or cuts the treble of the signal before it's recorded by
        // a certain amount of dB
        Int32 put_Treble(
            [In] double Treble); // gain in dB (-ve = attenuate)

        //Get the treble EQ for this channel
        Int32 get_Treble(
            [Out] out double pTreble);

        // This is the maximum value allowed in put_Treble.  ie 6.0 means
        // any value between -6.0 and 6.0 is allowed
        Int32 get_TrebleRange(
            [Out] out double pRange); // largest value allowed

        // boosts or cuts the bass of the signal before it's recorded by
        // a certain amount of dB
        Int32 put_Bass(
            [In] double Bass); // gain in dB (-ve = attenuate)

        // Get the bass EQ for this channel
        Int32 get_Bass(
            [Out] out double pBass);

        // This is the maximum value allowed in put_Bass.  ie 6.0 means
        // any value between -6.0 and 6.0 is allowed
        Int32 get_BassRange(
            [Out] out double pRange); // largest value allowed
    }

    // ---------------------------------------------------------------------------------------
    public enum VfwCompressDialogs
    {
        Config = 0x01,
        About = 0x02,
        QueryConfig = 0x04,
        QueryAbout = 0x08
    }

    // ---------------------------------------------------------------------------------------
    [ComVisible(true), ComImport,
     Guid("D8D715A3-6E5E-11D0-B3F0-00AA003761C5"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVfwCompressDialogs
    {
        [PreserveSig]
        // Bring up a dialog for this codec
        Int32 ShowDialog(
            [In] VfwCompressDialogs iDialog,
            [In] IntPtr hwnd);

        // Calls ICGetState and gives you the result
        Int32 GetState(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pState,
            ref Int32 pcbState);

        // Calls ICSetState
        Int32 SetState(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pState,
            [In] Int32 cbState);

        // Send a codec specific message
        Int32 SendDriverMessage(
            Int32 uMsg,
            long dw1,
            long dw2);
    }


    // ---------------------------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class VideoStreamConfigCaps // VIDEO_STREAM_CONFIG_CAPS
    {
        public Guid Guid;
        public AnalogVideoStandard VideoStandard;
        public Size InputSize;
        public Size MinCroppingSize;
        public Size MaxCroppingSize;
        public Int32 CropGranularityX;
        public Int32 CropGranularityY;
        public Int32 CropAlignX;
        public Int32 CropAlignY;
        public Size MinOutputSize;
        public Size MaxOutputSize;
        public Int32 OutputGranularityX;
        public Int32 OutputGranularityY;
        public Int32 StretchTapsX;
        public Int32 StretchTapsY;
        public Int32 ShrinkTapsX;
        public Int32 ShrinkTapsY;
        public long MinFrameInterval;
        public long MaxFrameInterval;
        public Int32 MinBitsPerSecond;
        public Int32 MaxBitsPerSecond;
    }

    // ---------------------------------------------------------------------------------------
    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    public class AudioStreamConfigCaps // AUDIO_STREAM_CONFIG_CAPS
    {
        public Guid Guid;
        public Int32 MinimumChannels;
        public Int32 MaximumChannels;
        public Int32 ChannelsGranularity;
        public Int32 MinimumBitsPerSample;
        public Int32 MaximumBitsPerSample;
        public Int32 BitsPerSampleGranularity;
        public Int32 MinimumSampleFrequency;
        public Int32 MaximumSampleFrequency;
        public Int32 SampleFrequencyGranularity;
    }

    // ---------------------------------------------------------------------------------------
    [ComVisible(true), ComImport,
     Guid("C6E13343-30AC-11d0-A18C-00A0C9118956"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoCompression
    {
        // - Only valid if GetInfo's pCapabilities sets
        //   CompressionCaps_CanKeyFrame
        // - KeyFrameRate < 0 means use the compressor default
        // - KeyFrames == 0 means only the first frame is a key
        Int32 put_KeyFrameRate(Int32 keyFrameRate);

        Int32 get_KeyFrameRate(out Int32 keyFrameRate);

        // - Only valid if GetInfo's pCapabilities sets
        //   CompressionCaps_CanBFrame
        // - If keyframes are every 10, and there are 3 P Frames per key,
        //   they will be spaced evenly between the key frames and the other
        //   6 frames will be B frames
        // - PFramesPerKeyFrame < 0 means use the compressor default
        Int32 put_PFramesPerKeyFrame(Int32 PFramesPerKeyFrame);

        Int32 get_PFramesPerKeyFrame(out Int32 PFramesPerKeyFrame);

        // - Only valid if GetInfo's pCapabilities sets
        //   CompressionCaps_CanQuality
        // - Controls image quality
        // - If you are compressing to a fixed data rate, a high quality
        //   means try and use all of the data rate, and a low quality means
        //   feel free to use much lower than the data rate if you want to.
        // - Quality < 0 means use the compressor default
        Int32 put_Quality(double quality);

        Int32 get_Quality(out double quality);

        // If you have set a data rate of 100K/sec on a 10fps movie, that
        // will normally mean each frame must be <=10K.  But a window size
        // means every consecutive n frames must average to the data rate,
        // but an individual frame (if n > 1) is allowed to exceed the
        // frame size suggested by the data rate
        Int32 put_WindowSize(long windowSize);

        Int32 get_WindowSize(out long windowSize);

        /*
			Remainder of the interface not converted - this next method is a little
			more difficult and they are not needed at this time. Order of
			the methods is important so we cannot just skip it (2003-12-12 BL)
			
				// - pszVersion might be "Version 2.1.0"
				// - pszDescription might be "Danny's awesome video compressor"
				// - pcbVersion and pcbDescription will be filled in with the
				//   required length if they are too short
				// - *pCapabilities is a logical OR of some CompressionCaps flags
				Int32 GetInfo(
					[out, size_is(*pcbVersion)] WCHAR * pszVersion,
													[in,out] Int32 *pcbVersion,
																 [out, size_is(*pcbDescription)] LPWSTR pszDescription,
																									 [in,out] Int32 *pcbDescription,
																												  out Int32 *pDefaultKeyFrameRate,
																															out Int32 *pDefaultPFramesPerKey,
																																	  out double *pDefaultQuality,
																																				out Int32 *pCapabilities  //CompressionCaps
																																						  );

				// - this means when this frame number comes aint after the graph
				//   is running, make it a keyframe even if you weren't going to
				Int32 OverrideKeyFrame(
					[in]  Int32 FrameNumber
							  );

				// - Only valid if GetInfo's pCapabilities sets
				//   CompressionCaps_CanCrunch
				// - this means when this frame number comes aint after the graph
				//   is running, make it this many bytes big instead of whatever size
				//   you were going to make it.
				Int32 OverrideFrameSize(
					[in]  Int32 FrameNumber,
							  [in]  Int32 Size
										);

		*/
    }
} // namespace Negar.DirectShow.Manager