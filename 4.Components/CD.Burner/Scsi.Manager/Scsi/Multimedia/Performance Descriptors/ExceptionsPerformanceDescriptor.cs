using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ExceptionsPerformanceDescriptor : PerformanceDescriptor
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _LogicalBlockAddress;

        /// <summary>Indicate that there is a seek delay between (<see cref="LogicalBlockAddress"/> – 1) and <see cref="LogicalBlockAddress"/>.</summary>
        public uint LogicalBlockAddress
        {
            get { return Bits.BigEndian(_LogicalBlockAddress); }
            set { _LogicalBlockAddress = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _Time;

        /// <summary>The expected additional delay between (<see cref="LogicalBlockAddress"/> – 1) and <see cref="LogicalBlockAddress"/> from nominal, in units of tenths of milliseconds (100 microseconds). This seek delay may be due to linear replacement, zone boundaries, or other media dependent Features. The expected additional delay should represent the typical time expected for the type of exception described.</summary>
        public ushort Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        public TimeSpan TimeSpan
        {
            get { return TimeSpan.FromMilliseconds(Bits.BigEndian(_Time)/10D); }
            set { _Time = Bits.BigEndian((ushort) (value.TotalMilliseconds*10D)); }
        }
    }
}