using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    ///  Capabilities of the audio device such as 
    ///  min/max sampling rate and number of channels available.
    /// </summary>
    public class AudioCapabilities
    {
        // ------------------ Properties --------------------

        /// <summary> Granularity of the channels. For example, channels 2 through 4, in steps of 2. </summary>
        public Int32 ChannelsGranularity;

        /// <summary> Maximum number of audio channels. </summary>
        public Int32 MaximumChannels;

        /// <summary> Maximum number of bits per sample. </summary>
        public Int32 MaximumSampleSize;

        /// <summary> Maximum sample frequency. </summary>
        public Int32 MaximumSamplingRate;

        /// <summary> Minimum number of audio channels. </summary>
        public Int32 MinimumChannels;

        /// <summary> Minimum number of bits per sample. </summary>
        public Int32 MinimumSampleSize;

        /// <summary> Minimum sample frequency. </summary>
        public Int32 MinimumSamplingRate;

        /// <summary> Granularity of the bits per sample. For example, 8 bits per sample through 32 bits per sample, in steps of 8. </summary>
        public Int32 SampleSizeGranularity;

        /// <summary> Granularity of the frequency. For example, 11025 Hz to 44100 Hz, in steps of 11025 Hz. </summary>
        public Int32 SamplingRateGranularity;


        // ----------------- Constructor ---------------------

        /// <summary> Retrieve capabilities of an audio device </summary>
        internal AudioCapabilities(IAMStreamConfig audioStreamConfig)
        {
            if (audioStreamConfig == null)
                throw new ArgumentNullException("audioStreamConfig");

            AMMediaType mediaType = null;
            AudioStreamConfigCaps caps = null;
            IntPtr pCaps = IntPtr.Zero;
            IntPtr pMediaType;
            try
            {
                // Ensure this device reports capabilities
                Int32 c, size;
                Int32 hr = audioStreamConfig.GetNumberOfCapabilities(out c, out size);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                if (c <= 0)
                    throw new NotSupportedException("This audio device does not report capabilities.");
                if (size > Marshal.SizeOf(typeof (AudioStreamConfigCaps)))
                {
                    throw new NotSupportedException(
                        "Unable to retrieve audio device capabilities. This audio device requires a larger AudioStreamConfigCaps structure.");
                }
                if (c > 1)
                    Debug.WriteLine("WARNING: This audio device supports " + c +
                                    " capability structures. Only the first structure will be used.");

                // Alloc memory for structure
                pCaps = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof (AudioStreamConfigCaps)));

                // Retrieve first (and hopefully only) capabilities struct
                hr = audioStreamConfig.GetStreamCaps(0, out pMediaType, pCaps);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);

                // Convert pointers to managed structures
                mediaType = (AMMediaType) Marshal.PtrToStructure(pMediaType, typeof (AMMediaType));
                caps = (AudioStreamConfigCaps) Marshal.PtrToStructure(pCaps, typeof (AudioStreamConfigCaps));

                // Extract info
                MinimumChannels = caps.MinimumChannels;
                MaximumChannels = caps.MaximumChannels;
                ChannelsGranularity = caps.ChannelsGranularity;
                MinimumSampleSize = caps.MinimumBitsPerSample;
                MaximumSampleSize = caps.MaximumBitsPerSample;
                SampleSizeGranularity = caps.BitsPerSampleGranularity;
                MinimumSamplingRate = caps.MinimumSampleFrequency;
                MaximumSamplingRate = caps.MaximumSampleFrequency;
                SamplingRateGranularity = caps.SampleFrequencyGranularity;
            }
            finally
            {
                if (pCaps != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pCaps);
                pCaps = IntPtr.Zero;
                if (mediaType != null)
                    DsUtils.FreeAMMediaType(mediaType);
                mediaType = null;
            }
        }
    }
}