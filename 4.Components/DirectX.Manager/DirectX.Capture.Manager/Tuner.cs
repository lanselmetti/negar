using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    ///  Control and query a hardware TV Tuner.
    /// </summary>
    public class Tuner : IDisposable
    {
        // ---------------- Private Properties ---------------

        /// <summary>
        /// Access to IAMTVTuner interface functions
        /// </summary>
        protected IAMTVTuner tvTuner;


        // ------------------- Constructors ------------------

        /// <summary> Initialize this object with a DirectShow tuner </summary>
        public Tuner(IAMTVTuner tuner)
        {
            tvTuner = tuner;
        }

        /// <summary>
        /// Added for TVFineTune.cs
        /// </summary>
        internal Tuner()
        {
        }

        // ---------------- Public Properties ---------------

        /// <summary>
        ///  Get or set the TV Tuner channel.
        /// </summary>
        public Int32 Channel
        {
            get
            {
                Int32 channel;
                Int32 v, a;
                Int32 hr = tvTuner.get_Channel(out channel, out v, out a);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                return (channel);
            }

            set
            {
                Int32 hr = tvTuner.put_Channel(value, AMTunerSubChannel.Default, AMTunerSubChannel.Default);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
            }
        }

        /// <summary>
        ///  Get or set the tuner frequency (cable or antenna).
        /// </summary>
        public TunerInputType InputType
        {
            get
            {
                TunerInputType t;
                Int32 hr = tvTuner.get_InputType(0, out t);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                return (t);
            }
            set
            {
                TunerInputType t = value;
                Int32 hr = tvTuner.put_InputType(0, t);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
            }
        }

        /// <summary>
        ///  Indicates whether a signal is present on the current channel.
        ///  If the signal strength cannot be determined, a NotSupportedException
        ///  is thrown.
        /// </summary>
        public bool SignalPresent
        {
            get
            {
                AMTunerSignalStrength sig;
                Int32 hr = tvTuner.SignalPresent(out sig);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                if (sig == AMTunerSignalStrength.NA)
                {
                    throw new NotSupportedException("Signal strength not available.");
                }
                return (sig == AMTunerSignalStrength.SignalPresent);
            }
        }

        // ---------------- Public Methods ---------------

        // Start of code based on code written by fdaupias, february 25, 2003
        // http://www.codeproject.com/cs/media/DirectXCapture.asp?msg=427626#xx427626xx

        /// <summary>
        /// get minimum and maximum channels
        /// </summary>
        public Int32[] ChanelMinMax
        {
            get
            {
                Int32 min;
                Int32 max;
                Int32 hr = tvTuner.ChannelMinMax(out min, out max);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                var myArray = new[] {min, max};
                return myArray;
            }
        }

        /// <summary>
        /// useful for checking purposes
        /// </summary>
        public Int32 GetVideoFrequency
        {
            get
            {
                Int32 theFreq;
                Int32 hr = tvTuner.get_VideoFrequency(out theFreq);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                return theFreq;
            }
        }

        /// <summary>
        /// not that useful, but...
        /// </summary>
        public Int32 GetAudioFrequency
        {
            get
            {
                Int32 theFreq;
                Int32 hr = tvTuner.get_AudioFrequency(out theFreq);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                return theFreq;
            }
        }

        /// <summary>
        /// set this to your country code. Frequency Overrides should be set to this code
        /// </summary>
        public Int32 TuningSpace
        {
            get
            {
                Int32 tspace;
                Int32 hr = tvTuner.get_TuningSpace(out tspace);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                return tspace;
            }
            set
            {
                Int32 tspace = value;
                Int32 hr = tvTuner.put_TuningSpace(tspace);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
            }
        }

        /// 
        /// Retrieves or sets the current mode on a multifunction tuner.
        /// 
        public AMTunerModeType AudioMode
        {
            get
            {
                AMTunerModeType AudioMode;
                Int32 hr = tvTuner.get_Mode(out AudioMode);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                return (AudioMode);
            }
            set
            {
                AMTunerModeType AudioMode = value;
                Int32 hr = tvTuner.put_Mode(AudioMode);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
            }
        }


        /// 
        /// Retrieves the tuner's supported modes.
        /// 
        public AvAudioModes AvailableAudioModes
        {
            get
            {
                AMTunerModeType AudioMode;
                Int32 hr = tvTuner.GetAvailableModes(out AudioMode);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                AvAudioModes AvModes;

                if ((Int32) AudioMode == (Int32) AMTunerModeType.TV)
                {
                    AvModes = new AvAudioModes(true, true, false, false, false);
                }
                else if ((Int32) AudioMode == (Int32) AMTunerModeType.TV + (Int32) AMTunerModeType.AMRadio)
                {
                    AvModes = new AvAudioModes(true, true, false, true, false);
                }
                else if ((Int32) AudioMode == (Int32) AMTunerModeType.TV + (Int32) AMTunerModeType.FMRadio)
                {
                    AvModes = new AvAudioModes(true, true, true, false, false);
                }
                else if ((Int32) AudioMode == (Int32) AMTunerModeType.TV + (Int32) AMTunerModeType.Dss)
                {
                    AvModes = new AvAudioModes(true, true, false, false, true);
                }
                else if ((Int32) AudioMode ==
                         (Int32) AMTunerModeType.TV + (Int32) AMTunerModeType.AMRadio + (Int32) AMTunerModeType.FMRadio)
                {
                    AvModes = new AvAudioModes(true, true, true, true, false);
                }
                else if ((Int32) AudioMode ==
                         (Int32) AMTunerModeType.TV + (Int32) AMTunerModeType.AMRadio + (Int32) AMTunerModeType.Dss)
                {
                    AvModes = new AvAudioModes(true, true, false, true, true);
                }
                else if ((Int32) AudioMode ==
                         (Int32) AMTunerModeType.TV + (Int32) AMTunerModeType.FMRadio + (Int32) AMTunerModeType.Dss)
                {
                    AvModes = new AvAudioModes(true, true, true, false, true);
                }
                else if ((Int32) AudioMode ==
                         (Int32) AMTunerModeType.TV + (Int32) AMTunerModeType.AMRadio +
                         (Int32) AMTunerModeType.FMRadio + (Int32) AMTunerModeType.Dss)
                {
                    AvModes = new AvAudioModes(true, true, true, true, true);
                }
                else
                {
                    AvModes = new AvAudioModes(false, false, false, false, false);
                }

                return (AvModes);
            }
        }

        // End of code based on code written by dauboro

        // New code written by Brian Low, dec 2003
        /// <summary>
        ///  Get or set the country code. Use the country code to set default frequency mappings.
        /// </summary>
        /// <remarks>
        /// Below is a sample of available country codes:
        /// <list type="bullet">
        ///   <item>1 - US</item>
        /// </list>
        /// For a full list of country codes, see the DirectX 9.0 
        /// documentation topic "Country/Region Assignments"
        /// </remarks>
        public Int32 CountryCode
        {
            get
            {
                Int32 c;
                Int32 hr = tvTuner.get_CountryCode(out c);
                if (hr < 0) Marshal.ThrowExceptionForHR(hr);
                return (c);
            }
            set
            {
                Int32 hr = tvTuner.put_CountryCode(value);
                if (hr < 0) Marshal.ThrowExceptionForHR(hr);
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Dispose components
        /// </summary>
        public void Dispose()
        {
            if (tvTuner != null)
                Marshal.ReleaseComObject(tvTuner);
            tvTuner = null;
        }

        #endregion

        /// <summary>
        /// Frequency Overrides are stored in the registry, in a key labeled
        /// TS[CountryCode]-[TunerInputType ], so for cable tv in Portugal it
        /// would be TS351-1
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="Frequency"></param>
        /// <param name="TuningSpace"></param>
        /// <param name="InputType"></param>
        /// <returns></returns>
        public bool SetFrequencyOverride(Int32 channel, Int32 Frequency, Int32 TuningSpace, TunerInputType InputType)
        {
            try
            {
                Int32 IType;
                if (InputType == TunerInputType.Cable)
                {
                    IType = 1;
                }
                else
                {
                    IType = 0;
                }
                RegistryKey LocaleOverride;
                LocaleOverride =
                    Registry.LocalMachine.OpenSubKey(
                        "SOFTWARE\\Microsoft\\TV System Services\\TVAutoTune\\TS" + TuningSpace + "-" + IType, true);
                if (LocaleOverride == null)
                {
                    LocaleOverride =
                        Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\TV System Services\\TVAutoTune\\TS" +
                                                           TuningSpace + "-" + IType);
                }
                LocaleOverride.SetValue(channel.ToString(), Frequency);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///  Determines if the tuner can tune to a particular channel.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///  An automated scan to find available channels:
        ///  <list type="number">
        ///   <item>Use <see cref="ChanelMinMax"/> to determine 
        ///			the range of available channels.</item>
        ///   <item>For each channel, call ChannelAvailable. If this method returns false, do not 
        ///			display the channel to the user. If this method returns true, it 
        ///			will have found the exact frequency for the channel.</item>
        ///	  <item>If ChannelAvailable is finding too many channels with just noise then 
        ///			check the <see cref="SignalPresent"/> property after calling ChannelAvailable. 
        ///			If SignalPresent is true, then the channel is most likely a valid, viewable
        ///			channel. However this risks missing viewable channels with moderate noise.
        ///			See <see cref="SignalPresent"/> for more information on locking on to 
        ///			a channel.</item>
        ///  </list>
        ///  </para>
        ///  
        ///  <para>
        ///  It is no longer required to perform a scan for each chanel's exact 
        ///  frequency. The tuner automatically finds the exact frequency each 
        ///  time the channel is changed. </para>
        ///  
        ///  <para>
        ///  This method correctly uses frequency-overrides. As described in
        ///  the DirectX SDK topic "Collecting Fine-Tuning Information", this method
        ///  does not use the IAMTVTuner.AutoTune() method. Instead it uses the
        ///  suggested put_Channel() method. </para>
        /// </remarks>
        /// <param name="channel">TV channel number</param>
        /// <returns>True if the channel's frequence was found, false otherwise.</returns>
        public bool ChannelAvailable(Int32 channel)
        {
            Int32 hr = tvTuner.put_Channel(channel, AMTunerSubChannel.Default, AMTunerSubChannel.Default);
            if (hr < 0) Marshal.ThrowExceptionForHR(hr);
            return (hr == 0);
        }

        #region Nested type: AvAudioModes

        /// <summary>
        /// Audio mode structure
        /// </summary>
        public struct AvAudioModes
        {
            /// <summary> AMRadio audio mode available flag </summary>
            public bool AMRadio;

            /// <summary> Default audio mode available flag </summary>
            public bool Default;

            /// <summary> Dss audio mode available flag </summary>
            public bool Dss;

            /// <summary> FMRadio audio mode available flag </summary>
            public bool FMRadio;

            /// <summary> TV audio mode available flag </summary>
            public bool TV;

            /// <summary> Scan audio modes and set appropriate flags </summary>
            public AvAudioModes(bool Default, bool TV, bool FMRadio, bool AMRadio, bool Dss)
            {
                this.Default = Default;
                this.TV = TV;
                this.FMRadio = FMRadio;
                this.AMRadio = AMRadio;
                this.Dss = Dss;
            }
        }

        #endregion

        // End of code, written by Brian Low
    }
}