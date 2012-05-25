using System;
using System.Runtime.InteropServices;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    ///  Represents a physical connector or source on an 
    ///  audio device. This class is used on filters that
    ///  support the IAMAudioInputMixer interface such as 
    ///  source cards.
    /// </summary>
    public class AudioSource : Source
    {
        // --------------------- Private/Internal properties -------------------------

        internal IPin Pin; // audio mixer interface (COM object)


        // -------------------- Constructors/Destructors ----------------------

        /// <summary> Constructor. This class cannot be created directly. </summary>
        internal AudioSource(IPin pin)
        {
            if ((pin as IAMAudioInputMixer) == null)
                throw new NotSupportedException("The input pin does not support the IAMAudioInputMixer interface");
            Pin = pin;
            name = getName(pin);
        }


        // ----------------------- Public properties -------------------------

        /// <summary> Enable or disable this source. For audio sources it is 
        /// usually possible to enable several sources. When setting Enabled=true,
        /// set Enabled=false on all other audio sources. </summary>
        public override bool Enabled
        {
            get
            {
                var mix = (IAMAudioInputMixer) Pin;
                bool e;
                //#if NEWCODE
                try
                {
                    mix.get_Enable(out e);
                    return e;
                }
                catch
                {
                    return false;
                }

                //#else
                //				mix.get_Enable( out e );
                //				return( e );
                //#endif
            }

            set
            {
                var mix = (IAMAudioInputMixer) Pin;
                //#if NEWCODE
                try
                {
                    mix.put_Enable(value);
                }
                catch
                {
                    // Do nothing?
                }
                //#else
                //				mix.put_Enable( value );
                //#endif
            }
        }


        // --------------------------- Private methods ----------------------------

        /// <summary> Retrieve the friendly name of a connectorType. </summary>
        private string getName(IPin pin)
        {
            string s = "Unknown pin";
            var pinInfo = new PinInfo();

            // Direction matches, so add pin name to listbox
            Int32 hr = pin.QueryPinInfo(out pinInfo);
            if (hr == 0)
            {
                s = pinInfo.name + "";
            }
            else
                Marshal.ThrowExceptionForHR(hr);

            // The pininfo structure contains a reference to an IBaseFilter,
            // so you must release its reference to prevent resource a leak.
            if (pinInfo.filter != null)
                Marshal.ReleaseComObject(pinInfo.filter);
            pinInfo.filter = null;

            return (s);
        }

        // -------------------- IDisposable -----------------------

        /// <summary> Release unmanaged resources. </summary>
        public override void Dispose()
        {
            if (Pin != null)
                Marshal.ReleaseComObject(Pin);
            Pin = null;
            base.Dispose();
        }
    }
}