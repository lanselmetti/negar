using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Helper;

namespace Ata
{
    [StructLayout(LayoutKind.Explicit, Size = 512, Pack = sizeof (ushort))]
    public struct DeviceIdentifier
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(117*sizeof (ushort))] private uint
            _LogicalSectorSize;

        public uint LogicalSectorSize
        {
            get { return LogicalSectorLargerThan256Words ? _LogicalSectorSize : 256*sizeof (ushort); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(49*sizeof (ushort))] private short Capabilities49;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(59*sizeof (ushort))] private short Capabilities50;

        public bool DmaSupported
        {
            get { return Bits.GetBit(Capabilities50, 8); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(94*sizeof (ushort) + 0)] private byte
            _AutomaticAcousticManagementLevelCurrent;

        public byte AutomaticAcousticManagementLevelCurrent
        {
            get { return _AutomaticAcousticManagementLevelCurrent; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(94*sizeof (ushort) + 1)] public byte
            _AutomaticAcousticManagementLevelDefault;

        public byte AutomaticAcousticManagementLevelDefault
        {
            get { return _AutomaticAcousticManagementLevelDefault; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(91*sizeof (ushort) + 0)] private byte
            _AdvancedPowerManagementLevelCurrent;

        public byte AdvancedPowerManagementLevelCurrent
        {
            get { return _AdvancedPowerManagementLevelCurrent; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(91*sizeof (ushort) + 1)] public byte
            _AdvancedPowerManagementLevelDefault;

        public byte AdvancedPowerManagementLevelDefault
        {
            get { return _AdvancedPowerManagementLevelDefault; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(53*sizeof (ushort) + 1)] public byte
            _FreeFallControlSensitivityLevelCurrent;

        public byte FreeFallControlSensitivityLevelCurrent
        {
            get { return _FreeFallControlSensitivityLevelCurrent; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(217*sizeof (ushort))] private ushort
            _NominalMediaRotationSpeed;

        public ushort NominalMediaRotationSpeed
        {
            get { return _NominalMediaRotationSpeed; }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(82*sizeof (ushort))] private short
            CommandsAndFeatures82Supported;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(83*sizeof (ushort))] private short
            CommandsAndFeatures83Supported;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(84*sizeof (ushort))] private short
            CommandsAndFeatures84Supported;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(119*sizeof (ushort))] private short
            CommandsAndFeatures119Supported;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(85*sizeof (ushort))] private short
            CommandsAndFeatures85Enabled;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(86*sizeof (ushort))] private short
            CommandsAndFeatures86Enabled;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(87*sizeof (ushort))] private short
            CommandsAndFeatures87Enabled;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(120*sizeof (ushort))] private short
            CommandsAndFeatures120Enabled;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] [FieldOffset(106*sizeof (ushort))] private short
            PhysicalLogicalSectorSize;

        public bool NopCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 14); }
        }

        public bool ReadBufferCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 13); }
        }

        public bool WriteBufferCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 12); }
        }

        public bool HpaSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 10); }
        }

        public bool DeviceResetCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 9); }
        }

        public bool ReadLookAheadSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 6); }
        }

        public bool VolatileWriteCacheSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 5); }
        }

        public bool PacketFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 4); }
        }

        public bool PowerManagementFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 3); }
        }

        public bool SecurityFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 1); }
        }

        public bool SmartFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures82Supported, 0); }
        }

        public bool FlushCacheExtCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 13); }
        }

        public bool FlushCacheCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 12); }
        }

        public bool DcoFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 11); }
        }

        public bool Command48BitAddressFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 10); }
        }

        public bool AutomaticAcousticManagementFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 9); }
        }

        public bool SetMaxSecurityExtensionSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 8); }
        }

        public bool SetFeaturesSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 6); }
        }

        public bool PowerUpInStandbyFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 5); }
        }

        public bool AdvancedPowerManagementFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 3); }
        }

        public bool DownloadMicrocodeCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures83Supported, 0); }
        }

        public bool MandatorWwnSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures84Supported, 8); }
        }

        public bool GplFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures84Supported, 5); }
        }

        public bool ExtendedPowerConditionsFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures119Supported, 7); }
        }

        public bool ExtendedStatusReportingFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures119Supported, 6); }
        }

        public bool FreeFallControlFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures119Supported, 5); }
        }

        public bool DownloadMicrocodeCommandWithOffsetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures119Supported, 4); }
        }

        public bool ReadWriteLogDmaExtCommandsSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures119Supported, 3); }
        }

        public bool WriteUncorrectableExtCommandSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures119Supported, 2); }
        }

        public bool WriteReadVerifyFeatureSetSupported
        {
            get { return Bits.GetBit(CommandsAndFeatures119Supported, 1); }
        }

        public bool NopCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 14); }
        }

        public bool ReadBufferCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 13); }
        }

        public bool WriteBufferCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 12); }
        }

        public bool HpaSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 10); }
        }

        public bool DeviceResetCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 9); }
        }

        public bool ReadLookAheadEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 6); }
        }

        public bool VolatileWriteCacheEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 5); }
        }

        public bool PacketFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 4); }
        }

        public bool PowerManagementFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 3); }
        }

        public bool SecurityFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 1); }
        }

        public bool SmartFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures85Enabled, 0); }
        }

        public bool FlushCacheExtCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 13); }
        }

        public bool FlushCacheCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 12); }
        }

        public bool DcoFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 11); }
        }

        public bool Command48BitAddressFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 10); }
        }

        public bool AutomaticAcousticManagementFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 9); }
        }

        public bool SetMaxSecurityExtensionEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 8); }
        }

        public bool SetFeaturesEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 6); }
        }

        public bool PowerUpInStandbyFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 5); }
        }

        public bool AdvancedPowerManagementFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 3); }
        }

        public bool DownloadMicrocodeCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures86Enabled, 0); }
        }

        public bool MandatorWwnEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures87Enabled, 8); }
        }

        public bool GplFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures87Enabled, 5); }
        }

        public bool ExtendedPowerConditionsFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures120Enabled, 7); }
        }

        public bool ExtendedStatusReportingFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures120Enabled, 6); }
        }

        public bool FreeFallControlFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures120Enabled, 5); }
        }

        public bool DownloadMicrocodeCommandWithOffsetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures120Enabled, 4); }
        }

        public bool ReadWriteLogDmaExtCommandsEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures120Enabled, 3); }
        }

        public bool WriteUncorrectableExtCommandEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures120Enabled, 2); }
        }

        public bool WriteReadVerifyFeatureSetEnabled
        {
            get { return Bits.GetBit(CommandsAndFeatures120Enabled, 1); }
        }


        [IndexerName("Words")]
        public ushort this[int index]
        {
            get
            {
                if (index < 0 | index >= 256)
                {
                    throw new ArgumentOutOfRangeException("index", index, "Invalid word index.");
                }
                unsafe
                {
                    fixed (DeviceIdentifier* pMe = &this)
                    {
                        return ((ushort*) pMe)[index];
                    }
                }
            }
        }

        public bool PhysicalLogicalSectorSizeInfoValid
        {
            get { return Bits.GetBit(PhysicalLogicalSectorSize, 14); }
        }

        public bool LogicalSectorSmallerThanPhysicalSector
        {
            get { return Bits.GetBit(PhysicalLogicalSectorSize, 13); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool LogicalSectorLargerThan256Words
        {
            get { return Bits.GetBit(PhysicalLogicalSectorSize, 12); }
        }

        public ushort LogicalSectorsPerPhysicalSectorLog2
        {
            get { return (ushort) (unchecked((ushort) PhysicalLogicalSectorSize) & 0x000F); }
        }

#if WORDS
		public ushort Word000;
		public ushort Word001;
		public ushort Word002;
		public ushort Word003;
		public ushort Word004;
		public ushort Word005;
		public ushort Word006;
		public ushort Word007;
		public ushort Word008;
		public ushort Word009;
		public ushort Word010;
		public ushort Word011;
		public ushort Word012;
		public ushort Word013;
		public ushort Word014;
		public ushort Word015;
		public ushort Word016;
		public ushort Word017;
		public ushort Word018;
		public ushort Word019;
		public ushort Word020;
		public ushort Word021;
		public ushort Word022;
		public ushort Word023;
		public ushort Word024;
		public ushort Word025;
		public ushort Word026;
		public ushort Word027;
		public ushort Word028;
		public ushort Word029;
		public ushort Word030;
		public ushort Word031;
		public ushort Word032;
		public ushort Word033;
		public ushort Word034;
		public ushort Word035;
		public ushort Word036;
		public ushort Word037;
		public ushort Word038;
		public ushort Word039;
		public ushort Word040;
		public ushort Word041;
		public ushort Word042;
		public ushort Word043;
		public ushort Word044;
		public ushort Word045;
		public ushort Word046;
		public ushort Word047;
		public ushort Word048;
		public ushort Word049;
		public ushort Word050;
		public ushort Word051;
		public ushort Word052;
		public ushort Word053;
		public ushort Word054;
		public ushort Word055;
		public ushort Word056;
		public ushort Word057;
		public ushort Word058;
		public ushort Word059;
		public ushort Word060;
		public ushort Word061;
		public ushort Word062;
		public ushort Word063;
		public ushort Word064;
		public ushort Word065;
		public ushort Word066;
		public ushort Word067;
		public ushort Word068;
		public ushort Word069;
		public ushort Word070;
		public ushort Word071;
		public ushort Word072;
		public ushort Word073;
		public ushort Word074;
		public ushort Word075;
		public ushort Word076;
		public ushort Word077;
		public ushort Word078;
		public ushort Word079;
		public ushort Word080;
		public ushort Word081;
		public ushort Word082;
		public ushort Word083;
		public ushort Word084;
		public ushort Word085;
		public ushort Word086;
		public ushort Word087;
		public ushort Word088;
		public ushort Word089;
		public ushort Word090;
		public ushort Word091;
		public ushort Word092;
		public ushort Word093;
		public ushort Word094;
		public ushort Word095;
		public ushort Word096;
		public ushort Word097;
		public ushort Word098;
		public ushort Word099;
		public ushort Word100;
		public ushort Word101;
		public ushort Word102;
		public ushort Word103;
		public ushort Word104;
		public ushort Word105;
		public ushort Word106;
		public ushort Word107;
		public ushort Word108;
		public ushort Word109;
		public ushort Word110;
		public ushort Word111;
		public ushort Word112;
		public ushort Word113;
		public ushort Word114;
		public ushort Word115;
		public ushort Word116;
		public ushort Word117;
		public ushort Word118;
		public ushort Word119;
		public ushort Word120;
		public ushort Word121;
		public ushort Word122;
		public ushort Word123;
		public ushort Word124;
		public ushort Word125;
		public ushort Word126;
		public ushort Word127;
		public ushort Word128;
		public ushort Word129;
		public ushort Word130;
		public ushort Word131;
		public ushort Word132;
		public ushort Word133;
		public ushort Word134;
		public ushort Word135;
		public ushort Word136;
		public ushort Word137;
		public ushort Word138;
		public ushort Word139;
		public ushort Word140;
		public ushort Word141;
		public ushort Word142;
		public ushort Word143;
		public ushort Word144;
		public ushort Word145;
		public ushort Word146;
		public ushort Word147;
		public ushort Word148;
		public ushort Word149;
		public ushort Word150;
		public ushort Word151;
		public ushort Word152;
		public ushort Word153;
		public ushort Word154;
		public ushort Word155;
		public ushort Word156;
		public ushort Word157;
		public ushort Word158;
		public ushort Word159;
		public ushort Word160;
		public ushort Word161;
		public ushort Word162;
		public ushort Word163;
		public ushort Word164;
		public ushort Word165;
		public ushort Word166;
		public ushort Word167;
		public ushort Word168;
		public ushort Word169;
		public ushort Word170;
		public ushort Word171;
		public ushort Word172;
		public ushort Word173;
		public ushort Word174;
		public ushort Word175;
		public ushort Word176;
		public ushort Word177;
		public ushort Word178;
		public ushort Word179;
		public ushort Word180;
		public ushort Word181;
		public ushort Word182;
		public ushort Word183;
		public ushort Word184;
		public ushort Word185;
		public ushort Word186;
		public ushort Word187;
		public ushort Word188;
		public ushort Word189;
		public ushort Word190;
		public ushort Word191;
		public ushort Word192;
		public ushort Word193;
		public ushort Word194;
		public ushort Word195;
		public ushort Word196;
		public ushort Word197;
		public ushort Word198;
		public ushort Word199;
		public ushort Word200;
		public ushort Word201;
		public ushort Word202;
		public ushort Word203;
		public ushort Word204;
		public ushort Word205;
		public ushort Word206;
		public ushort Word207;
		public ushort Word208;
		public ushort Word209;
		public ushort Word210;
		public ushort Word211;
		public ushort Word212;
		public ushort Word213;
		public ushort Word214;
		public ushort Word215;
		public ushort Word216;
		public ushort Word217;
		public ushort Word218;
		public ushort Word219;
		public ushort Word220;
		public ushort Word221;
		public ushort Word222;
		public ushort Word223;
		public ushort Word224;
		public ushort Word225;
		public ushort Word226;
		public ushort Word227;
		public ushort Word228;
		public ushort Word229;
		public ushort Word230;
		public ushort Word231;
		public ushort Word232;
		public ushort Word233;
		public ushort Word234;
		public ushort Word235;
		public ushort Word236;
		public ushort Word237;
		public ushort Word238;
		public ushort Word239;
		public ushort Word240;
		public ushort Word241;
		public ushort Word242;
		public ushort Word243;
		public ushort Word244;
		public ushort Word245;
		public ushort Word246;
		public ushort Word247;
		public ushort Word248;
		public ushort Word249;
		public ushort Word250;
		public ushort Word251;
		public ushort Word252;
		public ushort Word253;
		public ushort Word254;
		public ushort Word255;
#endif
    }
}