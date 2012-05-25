using System;
using System.Runtime.InteropServices;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    ///  Represents a physical connector or source on an 
    ///  audio/video device. This class is used on filters that
    ///  support the IAMCrossbar interface such as TV Tuners.
    /// </summary>
    public class CrossbarSource : Source
    {
        // --------------------- Private/Internal properties -------------------------

        internal PhysicalConnectorType ConnectorType; // type of the connector
        internal IAMCrossbar Crossbar; // crossbar filter (COM object)
        internal Int32 InputPin; // input pin number on the crossbar
        internal Int32 OutputPin; // output pin number on the crossbar
        internal Int32 RelatedInputPin = -1; // usually the audio input pin for the same source
        internal CrossbarSource RelatedInputSource; // the Crossbar source associated with the RelatedInputPin


        // -------------------- Constructors/Destructors ----------------------

        /// <summary> Constructor. This class cannot be created directly. </summary>
        internal CrossbarSource(IAMCrossbar crossbar, Int32 outputPin, Int32 inputPin,
                                PhysicalConnectorType connectorType)
        {
            Crossbar = crossbar;
            OutputPin = outputPin;
            InputPin = inputPin;
            ConnectorType = connectorType;
            name = getName(connectorType);
        }

        /// <summary> Constructor. This class cannot be created directly. </summary>
        internal CrossbarSource(IAMCrossbar crossbar, Int32 outputPin, Int32 inputPin, Int32 relatedInputPin,
                                PhysicalConnectorType connectorType)
        {
            Crossbar = crossbar;
            OutputPin = outputPin;
            InputPin = inputPin;
            RelatedInputPin = relatedInputPin;
            ConnectorType = connectorType;
            name = getName(connectorType);
        }

        /// <summary> Enabled or disable this source. </summary>
        public override bool Enabled
        {
            get
            {
                Int32 i;
                if (Crossbar.get_IsRoutedTo(OutputPin, out i) == 0)
                    if (InputPin == i)
                        return (true);
                return (false);
            }

            set
            {
                if (value)
                {
                    // Enable this route
                    Int32 hr = Crossbar.Route(OutputPin, InputPin);
                    if (hr < 0) Marshal.ThrowExceptionForHR(hr);

                    // Enable the related pin as well
                    if (RelatedInputSource != null)
                    {
                        hr = Crossbar.Route(RelatedInputSource.OutputPin, RelatedInputSource.InputPin);
                        if (hr < 0) Marshal.ThrowExceptionForHR(hr);
                    }
                }
                else
                {
                    // Disable this route by routing the output
                    // pin to input pin -1
                    Int32 hr = Crossbar.Route(OutputPin, -1);
                    if (hr < 0) Marshal.ThrowExceptionForHR(hr);

                    // Disable the related pin as well
                    if (RelatedInputSource != null)
                    {
                        hr = Crossbar.Route(RelatedInputSource.OutputPin, -1);
                        if (hr < 0) Marshal.ThrowExceptionForHR(hr);
                    }
                }
            }
        }

        // --------------------------- Private methods ----------------------------

        /// <summary> Retrieve the friendly name of a connectorType. </summary>
        private static String getName(PhysicalConnectorType connectorType)
        {
            string thename;
            switch (connectorType)
            {
                case PhysicalConnectorType.Video_Tuner:
                    thename = "Video Tuner";
                    break;
                case PhysicalConnectorType.Video_Composite:
                    thename = "Video Composite";
                    break;
                case PhysicalConnectorType.Video_SVideo:
                    thename = "Video S-Video";
                    break;
                case PhysicalConnectorType.Video_RGB:
                    thename = "Video RGB";
                    break;
                case PhysicalConnectorType.Video_YRYBY:
                    thename = "Video YRYBY";
                    break;
                case PhysicalConnectorType.Video_SerialDigital:
                    thename = "Video Serial Digital";
                    break;
                case PhysicalConnectorType.Video_ParallelDigital:
                    thename = "Video Parallel Digital";
                    break;
                case PhysicalConnectorType.Video_SCSI:
                    thename = "Video SCSI";
                    break;
                case PhysicalConnectorType.Video_AUX:
                    thename = "Video AUX";
                    break;
                case PhysicalConnectorType.Video_1394:
                    thename = "Video Firewire";
                    break;
                case PhysicalConnectorType.Video_USB:
                    thename = "Video USB";
                    break;
                case PhysicalConnectorType.Video_VideoDecoder:
                    thename = "Video Decoder";
                    break;
                case PhysicalConnectorType.Video_VideoEncoder:
                    thename = "Video Encoder";
                    break;
                case PhysicalConnectorType.Video_SCART:
                    thename = "Video SCART";
                    break;

                case PhysicalConnectorType.Audio_Tuner:
                    thename = "Audio Tuner";
                    break;
                case PhysicalConnectorType.Audio_Line:
                    thename = "Audio Line In";
                    break;
                case PhysicalConnectorType.Audio_Mic:
                    thename = "Audio Mic";
                    break;
                case PhysicalConnectorType.Audio_AESDigital:
                    thename = "Audio AES Digital";
                    break;
                case PhysicalConnectorType.Audio_SPDIFDigital:
                    thename = "Audio SPDIF Digital";
                    break;
                case PhysicalConnectorType.Audio_SCSI:
                    thename = "Audio SCSI";
                    break;
                case PhysicalConnectorType.Audio_AUX:
                    thename = "Audio AUX";
                    break;
                case PhysicalConnectorType.Audio_1394:
                    thename = "Audio Firewire";
                    break;
                case PhysicalConnectorType.Audio_USB:
                    thename = "Audio USB";
                    break;
                case PhysicalConnectorType.Audio_AudioDecoder:
                    thename = "Audio Decoder";
                    break;

                default:
                    thename = "Unknown Connector";
                    break;
            }
            return (thename);
        }


        // -------------------- IDisposable -----------------------

        /// <summary> Release unmanaged resources. </summary>
        public override void Dispose()
        {
            if (Crossbar != null)
                Marshal.ReleaseComObject(Crossbar);
            Crossbar = null;
            RelatedInputSource = null;
            base.Dispose();
        }
    }
}