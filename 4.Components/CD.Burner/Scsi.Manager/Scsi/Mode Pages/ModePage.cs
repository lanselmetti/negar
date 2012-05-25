using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;
using Scsi.Multimedia;

namespace Scsi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class ModePage : IMarshalable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte PAGE_CODE_MASK = 0x3F;

        protected ModePage(ModePageCode pageCode)
        {
            PageCode = pageCode;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte0;

        /// <summary>For a Mode Sense command, indicates whether the mode page may be saved by the target in a nonvolatile, vendor specific location. Reserved for the Mode Select command.</summary>
        [ReadOnly(true), DisplayName("Parameters Savable"),
         Description("Whether the mode page may be saved by the target in a nonvolatile, vendor specific location.")]
        public bool ParametersSavable
        {
            get { return Bits.GetBit(byte0, 7); }
            set { byte0 = Bits.SetBit(byte0, 7, value); }
        }

        [Browsable(false)]
        public ModePageCode PageCode
        {
            get { return (ModePageCode) Bits.GetValueMask(byte0, 0, PAGE_CODE_MASK); }
            private set { byte0 = Bits.PutValueMask(byte0, (byte) value, 0, PAGE_CODE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _PageLength;

        [Browsable(false)]
        public byte PageLength
        {
            get { return _PageLength; }
            protected set { _PageLength = value; }
        }

        protected virtual void MarshalFrom(BufferWithSize buffer)
        {
            Marshaler.DefaultPtrToStructure(buffer, this);
        }

        protected virtual void MarshalTo(BufferWithSize buffer)
        {
            PageLength = (byte) (Marshaler.SizeOf(this) - Marshaler.DefaultSizeOf<ModePage>());
            Marshaler.DefaultStructureToPtr((object) this, buffer);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual int MarshaledSize
        {
            get { return Marshal.SizeOf(this); }
        }

        void IMarshalable.MarshalFrom(BufferWithSize buffer)
        {
            MarshalFrom(buffer);
        }

        void IMarshalable.MarshalTo(BufferWithSize buffer)
        {
            MarshalTo(buffer);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IMarshalable.MarshaledSize
        {
            get
            {
                int size = MarshaledSize;
                PageLength = (byte) (size - Marshaler.DefaultSizeOf<ModePage>());
                return size;
            }
        }

        //public override string ToString() { return Internal.GenericToString(this, true); }

        public static ModePage TryCreateInstance(ModePageCode pageCode)
        {
            switch (pageCode)
            {
                case ModePageCode.ReadWriteErrorRecoveryParameters:
                    return new ReadWriteErrorRecoveryParametersPage();
                case ModePageCode.WriteParameters:
                    return new WriteParametersPage();
                case ModePageCode.Caching:
                    return new CachingModePage();
                case ModePageCode.CDDeviceParameters:
                    return new CDParametersPage();
                case ModePageCode.CapabilitiesAndMechanicalStatus:
                    return new CapabilitiesMechanicalStatusPage();
                default:
                    return null;
            }
        }

        public static ModePage CreateInstance(ModePageCode pageCode)
        {
            ModePage result = TryCreateInstance(pageCode);
            if (result == null)
            {
                throw new ArgumentOutOfRangeException("pageCode", pageCode, "Invalid mode page.");
            }
            return result;
        }

        internal static ModePageCode ReadPageCode(IntPtr pBuffer)
        {
            unsafe
            {
                return (ModePageCode) Bits.GetValueMask(*(byte*) pBuffer, 0, PAGE_CODE_MASK);
            }
        }

        public static ModePage FromBuffer(IntPtr pBuffer, int bufferLength)
        {
            ModePage mp = CreateInstance(ReadPageCode(pBuffer));
            Marshaler.PtrToStructure(new BufferWithSize(pBuffer, bufferLength), ref mp);
            return mp;
        }
    }

    public enum PageControl : byte
    {
        CurrentValues = 0x00,
        ChangeableValues = 0x01,
        DefaultValues = 0x02,
        SavedValues = 0x03,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct Mode10ParametersHeader
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _ModeDataLength;

        public ushort ModeDataLength
        {
            get { return Bits.BigEndian(_ModeDataLength); }
            set { _ModeDataLength = Bits.BigEndian(value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte _MediumTypeCode;

        [Obsolete]
        public byte MediumTypeCode
        {
            get { return _MediumTypeCode; }
            set { _MediumTypeCode = value; }
        }

        public byte DeviceSpecificParameter;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        public bool LongLogicalBlockAddress
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ushort _BlockDescriptorLength;

        /// <summary>Should be zero for multimedia devices.</summary>
        public ushort BlockDescriptorLength
        {
            get { return Bits.BigEndian(_BlockDescriptorLength); }
            set { _BlockDescriptorLength = Bits.BigEndian(value); }
        }

        public static ModePage TryGetModePageFromBuffer(IntPtr pBuffer, int bufferSize)
        {
            var buf = new BufferWithSize(pBuffer, bufferSize);
            BufferWithSize mpBuf =
                buf.ExtractSegment(Marshaler.SizeOf(Marshaler.PtrToStructure<Mode10ParametersHeader>(buf)));
            return ModePage.FromBuffer(mpBuf.Address, mpBuf.Length32);
        }
    }

    public enum ModePageCode : byte
    {
        None = 0x00,
        ReadWriteErrorRecoveryParameters = 0x01,
        WriteParameters = 0x05,
        VerifyErrorRecovery = 0x07,
        Caching = 0x08,
        MediumTypesSupported = 0x0B,
        CDDeviceParameters = 0x0D,
        CDAudioControl = 0x0E,
        XorControl = 0x10,
        PowerConditions = 0x1A,
        FaultFailureReporting = 0x1C,
        BackgroundControl = 0x1C,
        TimeoutAndProtect = 0x1D,
        CapabilitiesAndMechanicalStatus = 0x2A,
        MountRainierRewritable = 0x2C,
        All = 0x3F,
    }
}