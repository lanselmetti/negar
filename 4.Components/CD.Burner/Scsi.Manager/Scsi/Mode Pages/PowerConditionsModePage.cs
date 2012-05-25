using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PowerConditionsModePage : ModePage
    {
        public PowerConditionsModePage() : base(ModePageCode.PowerConditions)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte3;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool IdleTimerActive
        {
            get { return Bits.GetBit(byte3, 1); }
            set { byte3 = Bits.SetBit(byte3, 1, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool StandbyTimerActive
        {
            get { return Bits.GetBit(byte3, 0); }
            set { byte3 = Bits.SetBit(byte3, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _IdleConditionTimer;

        /// <summary>The inactivity time in 100 millisecond increments that the logical unit waits before transitioning to the idle power condition.</summary>
        public uint? IdleConditionTimer
        {
            get { return IdleTimerActive ? Bits.BigEndian(_IdleConditionTimer) : (uint?) null; }
            set
            {
                IdleTimerActive = value != null;
                _IdleConditionTimer = Bits.BigEndian(value.GetValueOrDefault());
            }
        }

        public TimeSpan? IdleCondition
        {
            get
            {
                uint? timer = IdleConditionTimer;
                return TimeSpan.FromMilliseconds(timer.GetValueOrDefault()*100);
            }
            set { IdleConditionTimer = value != null ? (uint) (value.Value.TotalMilliseconds/100) : 0; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private uint _StandbyConditionTimer;

        /// <summary>The inactivity time in 100 millisecond increments that the logical unit waits before transitioning to the standby power condition.</summary>
        public uint? StandbyConditionTimer
        {
            get { return StandbyTimerActive ? Bits.BigEndian(_StandbyConditionTimer) : (uint?) null; }
            set
            {
                StandbyTimerActive = value != null;
                _StandbyConditionTimer = Bits.BigEndian(value.GetValueOrDefault());
            }
        }

        public TimeSpan? StandbyCondition
        {
            get
            {
                uint? timer = StandbyConditionTimer;
                return TimeSpan.FromMilliseconds(timer.GetValueOrDefault()*100);
            }
            set { StandbyConditionTimer = value != null ? (uint) (value.Value.TotalMilliseconds/100) : 0; }
        }
    }
}