using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class DxUtils : CollectionBase
    {
        #region ColorSpaceEnum enum

        /// <summary>  Possible color spaces. </summary>
        /// <remarks> Note to developers: when adding new color spaces enums ensure you
        /// add the associated Guids in the ColorSpace property.</remarks>
        public enum ColorSpaceEnum
        {
            /// <summary> 4:4:4 YUV format </summary>
            [Label("56555941-0000-0010-8000-00AA00389B71")] AYUV,
            /// <summary> UYVY (packed 4:2:2) </summary>
            [Label("59565955-0000-0010-8000-00AA00389B71")] UYVY,
            /// <summary> Same as Y41P </summary>
            [Label("31313459-0000-0010-8000-00AA00389B71")] Y411,
            /// <summary> Y41P (packed 4:1:1) </summary>
            [Label("50313459-0000-0010-8000-00AA00389B71")] Y41P,
            /// <summary> Y211 </summary>
            [Label("31313259-0000-0010-8000-00AA00389B71")] Y211,
            /// <summary> YUV2 (packed 4:2:2) </summary>
            [Label("32565559-0000-0010-8000-00AA00389B71")] YUV2,
            /// <summary> YVYU (packed 4:2:2) </summary>
            [Label("55595659-0000-0010-8000-00AA00389B71")] YVYU,
            /// <summary> YVYU (packed 4:2:2) </summary>
            [Label("56595559-0000-0010-8000-00AA00389B71")] YUYV,
            /// <summary> YVU9 </summary>
            [Label("39555659-0000-0010-8000-00AA00389B71")] YVU9,
            /// <summary> YV12 </summary>
            [Label("32315659-0000-0010-8000-00AA00389B71")] YV12,
            /// <summary> RGB, 1 bpp, palettized </summary>
            [Label("e436eb78-524f-11ce-9f53-0020af0ba770")] RGB1,
            /// <summary> RGB, 4 bpp, palettized </summary>
            [Label("e436eb79-524f-11ce-9f53-0020af0ba770")] RGB4,
            /// <summary> RGB, 8 bpp </summary>
            [Label("e436eb7a-524f-11ce-9f53-0020af0ba770")] RGB8,
            /// <summary> RGB 565, 16 bpp </summary>
            [Label("e436eb7b-524f-11ce-9f53-0020af0ba770")] RGB565,
            /// <summary> RGB 555, 16 bpp </summary>
            [Label("e436eb7c-524f-11ce-9f53-0020af0ba770")] RGB555,
            /// <summary> RGB, 24 bpp </summary>
            [Label("e436eb7d-524f-11ce-9f53-0020af0ba770")] RGB24,
            /// <summary> RGB 32 bpp, no alpha channel </summary>
            [Label("e436eb7e-524f-11ce-9f53-0020af0ba770")] RGB32,
            /// <summary> RGB, 32 bpp, alpha channel </summary>
            [Label("773c9ac0-3274-11d0-B724-00aa006c1A01")] ARGB32,
            /// <summary> Trust webcam, I420 </summary>
            [Label("30323449-0000-0010-8000-00AA00389B71")] I420,
            /// <summary> IYUV </summary>
            [Label("56555949-0000-0010-8000-00AA00389B71")] IYUV,
            /// <summary>
            /// HCW2 format for the Capture as well as the 656 pin
            /// Hauppauge PVR150 (I420 , IYUV??? 4:2:0 Intel Indeo)
            /// </summary>
            [Label("32574348-005b-4504-99f8-90826c806657")] HCW2,
            /// <summary>
            /// YUY2 (packed 4:2:2), Pinnacle 330eV
            /// </summary>
            [Label("32595559-0000-0010-8000-00AA00389B71")] YUY2,
        }

        #endregion

        /// <summary> Array List </summary>
        protected ArrayList subTypeList;

        /// <summary> Video Decoder </summary>
        protected IAMAnalogVideoDecoder videoDecoder;

        /// <summary>
        /// Check if the Video Decoder interface is available
        /// </summary>
        public bool VideoDecoderAvail
        {
            get { return videoDecoder != null; }
        }

        /// <summary>
        ///  Gets and sets the video standard (NTSC, PAL, etc...)
        ///  Added check on videoDecoder pointer, if value is null,
        ///  then do nothing. An uninitialized pointer might be an
        ///  error but might also indicate that the capture device
        ///  does not support the Video Decoder interface (and that
        ///  is not an error).
        /// </summary>
        public AnalogVideoStandard VideoStandard
        {
            get
            {
                AnalogVideoStandard v;
                if (videoDecoder != null)
                {
                    Int32 hr = videoDecoder.get_TVFormat(out v);
                    if (hr < 0) Marshal.ThrowExceptionForHR(hr);
                    return v;
                }
                else
                {
                    return (AnalogVideoStandard.None);
                }
            }
            set
            {
                if (videoDecoder != null)
                {
                    Int32 hr = videoDecoder.put_TVFormat(value);
                    if (hr < 0) Marshal.ThrowExceptionForHR(hr);
                }
            }
        }

        /// <summary>
        /// Provide available Video Standards
        /// </summary>
        public AnalogVideoStandard AvailableVideoStandards
        {
            get
            {
                AnalogVideoStandard v;
                if (videoDecoder != null)
                {
                    Int32 hr = videoDecoder.get_AvailableTVFormats(out v);
                    if (hr < 0) Marshal.ThrowExceptionForHR(hr);
                    return v;
                }
                else
                {
                    return (AnalogVideoStandard.None);
                }
            }
        }

        /// <summary>
        /// Media subtype list
        /// </summary>
        public string[] SubTypeList
        {
            get
            {
                string[] stringList = null;
                if ((subTypeList != null) && (subTypeList.Count > 0))
                {
                    stringList = new String[subTypeList.Count];
                    for (Int32 i = 0; i < subTypeList.Count; i++)
                    {
                        MakeFourCC((Guid) subTypeList[i], out stringList[i]);
                    }
                }
                return stringList;
            }
        }

        /// <summary>
        /// Dispose DxUtils
        /// </summary>
        public void Dispose()
        {
            videoDecoder = null;
            if (subTypeList != null)
            {
                subTypeList.Clear();
                subTypeList = null;
            }
        }

        /// <summary>
        /// Initialize the video control utilities
        /// </summary>
        /// <param name="videoDeviceFilter"></param>
        /// <returns></returns>
        public bool InitDxUtils(IBaseFilter videoDeviceFilter)
        {
            // Retrieve the IAMAnalogVideoDecoder interface
            // for setting video format (NTSC, PAL, SECAM)
            videoDecoder = videoDeviceFilter as IAMAnalogVideoDecoder;
#if DEBUG
            Int32 hr;

            Debug.WriteLine("-----------------------------------------");

            try
            {
                Debug.WriteLine("");

                // Retrieve the IAMAnalogVideoDecoder interface if available
                Debug.WriteLine("");
                Debug.WriteLine("Testing video format...");
                IAMAnalogVideoDecoder a;
                a = videoDeviceFilter as IAMAnalogVideoDecoder;
                if (a == null)
                {
                    Debug.WriteLine("Failed to get IAMAnalogVideoDecoder interface");
                }
                else
                {
                    Debug.Write("Found IAMAnalogVideoDecoder interface... ");

                    AnalogVideoStandard avs;
                    hr = a.get_TVFormat(out avs);
                    Debug.WriteLine("TV Format = " + (hr == 0 ? avs.ToString() : " FAILED(" + hr + ")"));

                    hr = a.put_TVFormat((AnalogVideoStandard) 0x10);
                    Debug.WriteLine("Setting video format to PAL_B... " + (hr == 0 ? "success" : " FAILED(" + hr + ")"));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            Debug.WriteLine("-----------------------------------------");
#endif
            return (videoDecoder != null) ? true : false;
        }

        /// <summary>
        /// Make FourCC from media subtype
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="mediaSubType"></param>
        /// <returns></returns>
        public bool MakeFourCC(Guid guid, out String mediaSubType)
        {
            mediaSubType = "";
            try
            {
                foreach (object c in Enum.GetValues(typeof (ColorSpaceEnum)))
                {
                    if (guid == new Guid(LabelAttribute.FromMember(c)))
                    {
                        mediaSubType = ((ColorSpaceEnum) c).ToString();
                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// Get the video type for the specified pin interface
        /// </summary>
        /// <param name="streamConfig"></param>
        /// <returns></returns>
        public ColorSpaceEnum getMediaSubType(IAMStreamConfig streamConfig)
        {
            ColorSpaceEnum retval = ColorSpaceEnum.RGB24;
            bool found;
            IntPtr pmt = IntPtr.Zero;
            var mediaType = new AMMediaType();

            try
            {
                // Get the current format info
                Int32 hr = streamConfig.GetFormat(out pmt);
                if (hr < 0)
                {
                    Marshal.ThrowExceptionForHR(hr);
                }
                Marshal.PtrToStructure(pmt, mediaType);

                // Search the Guids to find the correct enum value.
                // Each enum value has a Guid associated with it
                // We store the Guid as a string in a LabelAttribute
                // applied to each enum value. See the ColorSpaceEnum.
                found = false;
                foreach (object c in Enum.GetValues(typeof (ColorSpaceEnum)))
                {
                    if (mediaType.subType == new Guid(LabelAttribute.FromMember(c)))
                    {
                        found = true;
                        retval = (ColorSpaceEnum) c;
                    }
                }
                if (!found)
                {
#if DEBUG
                    String mediaSubType;
                    MakeFourCC(mediaType.subType, out mediaSubType);
                    Debug.WriteLine("Unknown color space (media subtype=" + mediaSubType + "):" + mediaType.subType);
#endif
                    throw new ApplicationException("Unknown color space (media subtype):" + mediaType.subType);
                }
            }
            finally
            {
                DsUtils.FreeAMMediaType(mediaType);
                Marshal.FreeCoTaskMem(pmt);
            }

            return retval;
        }

        /// <summary>
        /// Set video type for the specified pin interface
        /// </summary>
        /// <param name="streamConfig"></param>
        /// <param name="newValue"></param>
        public void setMediaSubType(IAMStreamConfig streamConfig, ColorSpaceEnum newValue)
        {
            IntPtr pmt = IntPtr.Zero;
            var mediaType = new AMMediaType();

            try
            {
                // Get the current format info
                Int32 hr = streamConfig.GetFormat(out pmt);
                if (hr < 0)
                {
                    Marshal.ThrowExceptionForHR(hr);
                }
                Marshal.PtrToStructure(pmt, mediaType);

                // Change the media subtype
                // Each enum value has a Guid associated with it
                // We store the Guid as a string in a LabelAttribute
                // applied to each enum value. See the ColorSpaceEnum.
                mediaType.subType = new Guid(LabelAttribute.FromMember(newValue));

                // Save the changes
                hr = streamConfig.SetFormat(mediaType);
                if (hr < 0)
                {
                    Marshal.ThrowExceptionForHR(hr);
                }
            }
            finally
            {
                DsUtils.FreeAMMediaType(mediaType);
                Marshal.FreeCoTaskMem(pmt);
            }
        }

        /// <summary>
        /// Set video type for the specified pin interface
        /// </summary>
        /// <param name="streamConfig"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public bool setMediaSubType(IAMStreamConfig streamConfig, Guid newValue)
        {
            IntPtr pmt = IntPtr.Zero;
            var mediaType = new AMMediaType();

            try
            {
                // Get the current format info
                Int32 hr = streamConfig.GetFormat(out pmt);
                if (hr < 0)
                {
                    return false;
                }
                Marshal.PtrToStructure(pmt, mediaType);

                // Change the media subtype
                // Each enum value has a Guid associated with it
                // We store the Guid as a string in a LabelAttribute
                // applied to each enum value. See the ColorSpaceEnum.
                mediaType.subType = newValue;

                // Save the changes
                hr = streamConfig.SetFormat(mediaType);
                if (hr < 0)
                {
                    return false;
                }
            }
            finally
            {
                DsUtils.FreeAMMediaType(mediaType);
                Marshal.FreeCoTaskMem(pmt);
            }
            return true;
        }

        /// <summary>
        /// Find media data by trial and error, just try every media type
        /// in the list, the ones that do not return an error, are accepted.
        /// This function might be handy if DShowNET is used as library
        /// instead of DirectShowLib.
        /// This function should be called with a derendered graph only,
        /// so with capture device only and no rendering of audio, video or
        /// VBI.
        /// </summary>
        /// <param name="streamConfig"></param>
        /// <returns></returns>
        public bool FindMediaData(IAMStreamConfig streamConfig)
        {
            bool result = false;
            try
            {
                ColorSpaceEnum currentValue = getMediaSubType(streamConfig);
                if (subTypeList != null)
                {
                    subTypeList.Clear();
                }

                foreach (object c in Enum.GetValues(typeof (ColorSpaceEnum)))
                {
                    var subType = new Guid(LabelAttribute.FromMember(c));
                    if (setMediaSubType(streamConfig, subType))
                    {
                        if (subTypeList == null)
                        {
                            subTypeList = new ArrayList();
                        }
                        // Check if subtype is already in list,
                        // if so then do not add, else add to list
                        bool notinlist = true;
                        for (Int32 i = 0; (i < subTypeList.Count) && (notinlist); i++)
                        {
                            if (((Guid) subTypeList[i]) == subType)
                            {
                                notinlist = false;
                            }
                        }

                        if (notinlist)
                        {
                            subTypeList.Add(subType);
                            result = true;
                        }
                    }
                }
                setMediaSubType(streamConfig, currentValue);
                return result;
            }
            catch
            {
            }
            return result;
        }

        private object GetField(AMMediaType mediaType, String fieldName)
        {
            object formatStruct;
            if (mediaType.formatType == FormatType.WaveEx)
                formatStruct = new WaveFormatEx();
            else if (mediaType.formatType == FormatType.VideoInfo)
                formatStruct = new VideoInfoHeader();
            else if (mediaType.formatType == FormatType.VideoInfo2)
                formatStruct = new VideoInfoHeader2();
            else
                throw new NotSupportedException("This device does not support a recognized format block.");

            // Retrieve the nested structure
            Marshal.PtrToStructure(mediaType.formatPtr, formatStruct);

            // Find the required field
            Type structType = formatStruct.GetType();
            FieldInfo fieldInfo = structType.GetField(fieldName);
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(formatStruct);
            }
            return null;
        }
    }
}