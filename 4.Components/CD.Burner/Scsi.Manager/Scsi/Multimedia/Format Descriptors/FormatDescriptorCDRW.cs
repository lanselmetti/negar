using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class FormatDescriptorCDRW : FormatDescriptor
    {
        public FormatDescriptorCDRW()
        {
        }

        public FormatDescriptorCDRW(bool session, bool grow, uint formatSize)
            : this()
        {
            Session = session;
            Grow = grow;
            FormatSize = formatSize;
            FormatOptionsValid = true;
        }

        public FormatDescriptorCDRW(bool session, bool grow, uint formatSize, bool immediate, bool tryOut,
                                    bool disablePrimary, bool disableCertification)
            : this(session, grow, formatSize)
        {
            Immediate = immediate;
            TryOut = tryOut;
            DisablePrimary = disablePrimary;
            DisableCertification = disableCertification;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        public bool Session
        {
            get { return Bits.GetBit(byte0, 7); }
            set { byte0 = Bits.SetBit(byte0, 7, value); }
        }

        public bool Grow
        {
            get { return Bits.GetBit(byte0, 6); }
            set { byte0 = Bits.SetBit(byte0, 6, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _FormatSize;

        /// <summary>The number of user data blocks. Must be divisible by the <see cref="WriteParametersPage.PacketSize"/> field.</summary>
        [Description("The number of user data blocks. Must be divisible by the PacketSize field.")]
        public uint FormatSize
        {
            get { return Bits.BigEndian(_FormatSize); }
            set { _FormatSize = Bits.BigEndian(value); }
        }


        public override FormatCode FormatCode
        {
            get { return FormatCode.CDRW; }
        }
    }
}