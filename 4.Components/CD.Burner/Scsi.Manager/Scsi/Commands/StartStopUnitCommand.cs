using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class StartStopUnitCommand : FixedLengthScsiCommand
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte FORMAT_LAYER_NUMBER_MASK = 0x03;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte POWER_CONDITIONS_MASK = 0xF0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte POWER_CONDITION_MODIFIER_MASK = 0x0F;

        public StartStopUnitCommand() : base(ScsiCommandCode.StartStopUnit)
        {
        }

        public StartStopUnitCommand(bool loadEject, bool start) : this(loadEject, start, false)
        {
        }

        public StartStopUnitCommand(bool loadEject, bool start, bool immediate)
            : this(loadEject, start, default(PowerCondition), PowerConditionModifier.None, immediate)
        {
        }

        public StartStopUnitCommand(PowerCondition powerCondition) : this(powerCondition, false)
        {
        }

        public StartStopUnitCommand(PowerCondition powerCondition, bool immediate)
            : this(powerCondition, PowerConditionModifier.None, immediate)
        {
        }

        public StartStopUnitCommand(PowerCondition powerCondition, PowerConditionModifier modifier, bool immediate)
            : this(false, false, powerCondition, modifier, immediate)
        {
        }

        public StartStopUnitCommand(PowerCondition powerCondition, byte? formatLayerNumber, bool immediate)
            : this(false, false, powerCondition, formatLayerNumber, immediate)
        {
        }

        private StartStopUnitCommand(bool loadEject, bool start, PowerCondition powerCondition,
                                     PowerConditionModifier modifier, bool immediate)
            : this(loadEject, start, powerCondition, immediate)
        {
            PowerConditionModifier = modifier;
        }

        private StartStopUnitCommand(bool loadEject, bool start, PowerCondition powerCondition, bool immediate)
            : this()
        {
            LoadEject = loadEject;
            Start = start;
            PowerCondition = powerCondition;
            Immediate = immediate;
        }

        public StartStopUnitCommand(bool loadEject, bool start, PowerCondition PowerCondition, byte? formatLayerNumber,
                                    bool immediate)
            : this()
        {
            LoadEject = loadEject;
            Start = start;
            this.PowerCondition = PowerCondition;
            FormatLayerNumber = formatLayerNumber;
            Immediate = immediate;
        }

        private byte byte1;

        /// <summary>If <see cref="Immediate"/> is set to <c>false</c>, status is returned only after the operation is completed. If <see cref="Immediate"/> is set to <c>true</c>, status is returned as soon as the CDB has been validated.</summary>
        public bool Immediate
        {
            get { return Bits.GetBit(byte1, 0); }
            set { byte1 = Bits.SetBit(byte1, 0, value); }
        }

        private byte byte2;
        private byte byte3;

        /// <summary>This field is used only by block devices; do not use it for multimedia devices.</summary>
        public PowerConditionModifier PowerConditionModifier
        {
            get { return (PowerConditionModifier) Bits.GetValueMask(byte3, 0, POWER_CONDITION_MODIFIER_MASK); }
            set { byte3 = Bits.PutValueMask(byte3, (byte) value, 0, POWER_CONDITION_MODIFIER_MASK); }
        }

        /// <summary>This field is used only by multimedia devices; do not use it for block devices.</summary>
        public byte? FormatLayerNumber
        {
            get { return Bits.GetBit(byte4, 2) ? (byte?) Bits.GetValueMask(byte3, 0, FORMAT_LAYER_NUMBER_MASK) : null; }
            set
            {
                if (value != null)
                {
                    byte4 |= 1 << 2;
                }
                else
                {
                    byte4 &= unchecked((byte) (~(1 << 2)));
                }
                ;
                //Either reset to 0, or set to value
                byte3 = Bits.PutValueMask(byte3, value.GetValueOrDefault(), 0, FORMAT_LAYER_NUMBER_MASK);
            }
        }

        private byte byte4;

        public PowerCondition PowerCondition
        {
            get { return (PowerCondition) Bits.GetValueMask(byte4, 4, POWER_CONDITIONS_MASK); }
            set { byte4 = Bits.PutValueMask(byte4, (byte) value, 4, POWER_CONDITIONS_MASK); }
        }

        public bool NoFlush
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        public bool LoadEject
        {
            get { return Bits.GetBit(byte4, 1); }
            set { byte4 = Bits.SetBit(byte4, 1, value); }
        }

        public bool Start
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private CommandControl _Control;

        public override CommandControl Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        public override ScsiTimeoutGroup TimeoutGroup
        {
            get { return ScsiTimeoutGroup.Group1; }
        }
    }

    public enum PowerConditionModifier : byte
    {
        None = 0,
        IncreaseTolerance = 1,
        IncreaseToleranceAndLowerPowerUsage = 2
    }

    public enum PowerCondition : byte
    {
        NoChange = 0x0,
        Active = 0x1,
        Idle = 0x2,
        Standby = 0x3,
        Sleep = 0x5,
        LogicalUnitControl = 0x7,
        ForceZeroIdleConditionTimer = 0xA,
        ForceZeroStandbyConditionTimer = 0xB,
    }
}