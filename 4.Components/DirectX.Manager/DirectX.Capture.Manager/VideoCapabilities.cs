using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    ///  Capabilities of the video device such as 
    ///  min/max frame size and frame rate.
    /// </summary>
    public class VideoCapabilities
    {
        // ------------------ Properties --------------------

        //#if NEWCODE
        /// <summary> Analog video standard(s) </summary>
        public AnalogVideoStandard AnalogVideoStandard;

        //#endif

        /// <summary> Granularity of the output width. This value specifies the increments that are valid between MinFrameSize and MaxFrameSize. Read-only. </summary>
        public Int32 FrameSizeGranularityX;

        /// <summary> Granularity of the output height. This value specifies the increments that are valid between MinFrameSize and MaxFrameSize. Read-only. </summary>
        public Int32 FrameSizeGranularityY;

        /// <summary> Native size of the incoming video signal. This is the largest signal the filter can digitize with every pixel remaining unique. Read-only. </summary>
        public Size InputSize;

        /// <summary> Maximum supported frame rate. Read-only. </summary>
        public double MaxFrameRate;

        /// <summary> Maximum supported frame size. Read-only. </summary>
        public Size MaxFrameSize;

        /// <summary> Minimum supported frame rate. Read-only. </summary>
        public double MinFrameRate;

        /// <summary> Minimum supported frame size. Read-only. </summary>
        public Size MinFrameSize;

        // ----------------- Constructor ---------------------

        /// <summary> Retrieve capabilities of a video device </summary>
        internal VideoCapabilities(IAMStreamConfig videoStreamConfig)
        {
            if (videoStreamConfig == null)
                throw new ArgumentNullException("videoStreamConfig");

            AMMediaType mediaType = null;
            VideoStreamConfigCaps caps = null;
            IntPtr pCaps = IntPtr.Zero;
            IntPtr pMediaType;
            try
            {
                // Ensure this device reports capabilities
                Int32 c, size;
                Int32 hr = videoStreamConfig.GetNumberOfCapabilities(out c, out size);
                if (hr != 0) Marshal.ThrowExceptionForHR(hr);
                if (c <= 0)
                    throw new NotSupportedException("This video device does not report capabilities.");
                if (size > Marshal.SizeOf(typeof (VideoStreamConfigCaps)))
                    throw new NotSupportedException(
                        "Unable to retrieve video device capabilities. This video device requires a larger VideoStreamConfigCaps structure.");
                if (c > 1)
                    Debug.WriteLine("This video device supports " + c +
                                    " capability structures. Only the first structure will be used.");

                // Alloc memory for structure
                pCaps = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof (VideoStreamConfigCaps)));

#if DEBUG
                for (Int32 i = c - 1; i >= 0; i--)
                {
                    hr = videoStreamConfig.GetStreamCaps(i, out pMediaType, pCaps);
#else
    // Retrieve first (and hopefully only) capabilities struct
				hr = videoStreamConfig.GetStreamCaps( 0, out pMediaType, pCaps );
#endif
                    if (hr != 0) Marshal.ThrowExceptionForHR(hr);

                    // Convert pointers to managed structures
                    mediaType = (AMMediaType) Marshal.PtrToStructure(pMediaType, typeof (AMMediaType));

                    // Convert pointers to managed structures
                    caps = (VideoStreamConfigCaps) Marshal.PtrToStructure(pCaps, typeof (VideoStreamConfigCaps));

                    // Extract info
                    InputSize = caps.InputSize;
                    MinFrameSize = caps.MinOutputSize;
                    MaxFrameSize = caps.MaxOutputSize;
                    FrameSizeGranularityX = caps.OutputGranularityX;
                    FrameSizeGranularityY = caps.OutputGranularityY;
                    MinFrameRate = (double) 10000000/caps.MaxFrameInterval;
                    MaxFrameRate = (double) 10000000/caps.MinFrameInterval;
                    //#if NEWCODE
                    AnalogVideoStandard = caps.VideoStandard;
                    //#endif
#if DEBUG
                    if (caps.VideoStandard > AnalogVideoStandard.None)
                    {
                        Debug.WriteLine("Caps=" +
                                        caps.InputSize + " " +
                                        caps.MinOutputSize + " " +
                                        caps.MaxOutputSize + " " +
                                        MinFrameRate + "-" +
                                        MaxFrameRate + " " +
                                        caps.VideoStandard);
                        Debug.WriteLine("MediaType=" +
                                        mediaType.majorType + " " +
                                        mediaType.subType + " " +
                                        mediaType.formatType + " " +
                                        mediaType.formatSize + " " +
                                        mediaType.fixedSizeSamples + " " +
                                        mediaType.sampleSize + " " +
                                        mediaType.temporalCompression);
                    }
                }
#endif
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