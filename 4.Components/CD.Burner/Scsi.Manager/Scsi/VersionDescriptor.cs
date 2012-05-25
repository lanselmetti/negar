using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi
{
    /// <summary>This structure stores the descriptors in big endian format, so it can be marshaled directly. It holds 8 version descriptors.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VersionDescriptorCollection : IEnumerable<VersionDescriptor>, IMarshalable
    {
#pragma warning disable 0649
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor1;

        public VersionDescriptor VersionDescriptor1
        {
            get { return Bits.BigEndian(_VersionDescriptor1); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor2;

        public VersionDescriptor VersionDescriptor2
        {
            get { return Bits.BigEndian(_VersionDescriptor2); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor3;

        public VersionDescriptor VersionDescriptor3
        {
            get { return Bits.BigEndian(_VersionDescriptor3); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor4;

        public VersionDescriptor VersionDescriptor4
        {
            get { return Bits.BigEndian(_VersionDescriptor4); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor5;

        public VersionDescriptor VersionDescriptor5
        {
            get { return Bits.BigEndian(_VersionDescriptor5); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor6;

        public VersionDescriptor VersionDescriptor6
        {
            get { return Bits.BigEndian(_VersionDescriptor6); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor7;

        public VersionDescriptor VersionDescriptor7
        {
            get { return Bits.BigEndian(_VersionDescriptor7); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VersionDescriptor _VersionDescriptor8;

        public VersionDescriptor VersionDescriptor8
        {
            get { return Bits.BigEndian(_VersionDescriptor8); }
        }
#pragma warning restore 0649

        public VersionDescriptor this[int index]
        {
            get
            {
                if (index < 0 | index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index", index,
                                                          "Index must be be nonnegative and less than the size of the collection.");
                }
                unsafe
                {
                    fixed (VersionDescriptor* pDescriptors = &_VersionDescriptor1)
                    {
                        return Bits.BigEndian(pDescriptors[index]);
                    }
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Count
        {
            get { return 8; }
        }

        public IEnumerator<VersionDescriptor> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public VersionDescriptor[] ToArray()
        {
            var result = new VersionDescriptor[Count];
            for (int i = 0; i < Count; i++)
            {
                result[i] = this[i];
            }
            return result;
        }

        public void CopyTo(VersionDescriptor[] array, int offset)
        {
            for (int i = 0; i < Count; i++)
            {
                array[offset + i] = this[i];
            }
        }

        public void MarshalFrom(BufferWithSize buffer)
        {
            if (buffer.Length32 > 1*sizeof (VersionDescriptor))
            {
                _VersionDescriptor1 = buffer.Read<VersionDescriptor>(0*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 2*sizeof (VersionDescriptor))
            {
                _VersionDescriptor2 = buffer.Read<VersionDescriptor>(1*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 3*sizeof (VersionDescriptor))
            {
                _VersionDescriptor3 = buffer.Read<VersionDescriptor>(2*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 4*sizeof (VersionDescriptor))
            {
                _VersionDescriptor4 = buffer.Read<VersionDescriptor>(3*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 5*sizeof (VersionDescriptor))
            {
                _VersionDescriptor5 = buffer.Read<VersionDescriptor>(4*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 6*sizeof (VersionDescriptor))
            {
                _VersionDescriptor6 = buffer.Read<VersionDescriptor>(5*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 7*sizeof (VersionDescriptor))
            {
                _VersionDescriptor7 = buffer.Read<VersionDescriptor>(6*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 8*sizeof (VersionDescriptor))
            {
                _VersionDescriptor8 = buffer.Read<VersionDescriptor>(7*sizeof (VersionDescriptor));
            }
        }

        public void MarshalTo(BufferWithSize buffer)
        {
            if (buffer.Length32 > 1*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor1, 0*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 2*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor2, 1*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 3*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor3, 2*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 4*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor4, 3*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 5*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor5, 4*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 6*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor6, 5*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 7*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor7, 6*sizeof (VersionDescriptor));
            }
            if (buffer.Length32 > 8*sizeof (VersionDescriptor))
            {
                buffer.Write(_VersionDescriptor8, 7*sizeof (VersionDescriptor));
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int MarshaledSize
        {
            get { return Count*Marshaler.DefaultSizeOf<VersionDescriptor>(); }
        }
    }

    public enum VersionDescriptor : short
    {
        /// <summary>Version Descriptor Not Supported or No Standard Identified</summary>
        None = 0x0000,
        /// <summary>ACS-2 (no version claimed)</summary>
        ACS2 = 0x1761,
        /// <summary>ADC (no version claimed)</summary>
        ADC = 0x03C0,
        /// <summary>ADC ANSI INCITS 403-2005</summary>
        ADC_ANSI_INCITS_403_2005 = 0x03D7,
        /// <summary>ADC T10/1558-D revision 7</summary>
        ADC_T10_1558_D_Revision7 = 0x03D6,
        /// <summary>ADC T10/1558-D revision 6</summary>
        ADC_T10_1558_D_Revision6 = 0x03D5,
        /// <summary>ADC-2 (no version claimed)</summary>
        ADC2 = 0x04A0,
        /// <summary>ADC-2 ANSI INCITS 441-2008</summary>
        ADC2_ANSI_INCITS_441_2008 = 0x04AC,
        /// <summary>ADC-2 T10/1741-D revision 7</summary>
        ADC2_T10_1741_D_Revision7 = 0x04A7,
        /// <summary>ADC-2 T10/1741-D revision 8</summary>
        ADC2_T10_1741_D_Revision8 = 0x04AA,
        /// <summary>ADC-3 (no version claimed)</summary>
        ADC3 = 0x0500,
        /// <summary>ADP (no version claimed)</summary>
        ADP = 0x09C0,
        /// <summary>ADT (no version claimed)</summary>
        ADT = 0x09E0,
        /// <summary>ADT ANSI INCITS 406-2005</summary>
        ADT_ANSI_INCITS_406_2005 = 0x09FD,
        /// <summary>ADT T10/1557-D revision 14</summary>
        ADT_T10_1557_D_Revision14 = 0x09FA,
        /// <summary>ADT T10/1557-D revision 11</summary>
        ADT_T10_1557_D_Revision11 = 0x09F9,
        /// <summary>ADT-2 (no version claimed)</summary>
        ADT2 = 0x0A20,
        /// <summary>ADT-2 T10/1742-D revision 06</summary>
        ADT2_T10_1742_D_Revision06 = 0x0A22,
        /// <summary>ATA/ATAPI-6 (no version claimed)</summary>
        ATA_ATAPI_6 = 0x15E0,
        /// <summary>ATA/ATAPI-6 ANSI INCITS 361-2002</summary>
        ATA_ATAPI_6_ANSI_INCITS_361_2002 = 0x15FD,
        /// <summary>ATA/ATAPI-7 (no version claimed)</summary>
        ATA_ATAPI_7 = 0x1600,
        /// <summary>ATA/ATAPI-7 ANSI INCITS 397-2005</summary>
        ATA_ATAPI_7_ANSI_INCITS_397_2005 = 0x161C,
        /// <summary>ATA/ATAPI-7 T13/1532-D revision 3</summary>
        ATA_ATAPI_7_T13_1532_D_Revision3 = 0x1602,
        /// <summary>ATA/ATAPI-8 ATA8-AAM (no version claimed)</summary>
        ATA_ATAPI_8_ATA8_AAM = 0x1620,
        /// <summary>ATA/ATAPI-8 ATA8-AAM ANSI INCITS 451-2008</summary>
        ATA_ATAPI_8_ATA8_AAM_ANSI_INCITS_451_2008 = 0x1628,
        /// <summary>ATA/ATAPI-8 ATA8-APT Parallel Transport (no version claimed)</summary>
        ATA_ATAPI_8_ATA8_APT_Parallel_Transport = 0x1621,
        /// <summary>ATA/ATAPI-8 ATA8-AST Serial Transport (no version claimed)</summary>
        ATA_ATAPI_8_ATA8_AST_Serial_Transport = 0x1622,
        /// <summary>ATA/ATAPI-8 ATA8-ACS ATA/ATAPI Command Set (no version claimed)</summary>
        ATA_ATAPI_8_ATA8_ACS_ATA_ATAPI_Command_Set = 0x1623,
        /// <summary>BCC (no version claimed)</summary>
        BCC = 0x0380,
        /// <summary>EPI (no version claimed)</summary>
        EPI = 0x0B20,
        /// <summary>EPI ANSI INCITS TR-23 1999</summary>
        EPI_ANSI_INCITS_TR_23_1999 = 0x0B3C,
        /// <summary>EPI T10/1134 revision 16</summary>
        EPI_T10_1134_Revision16 = 0x0B3B,
        /// <summary>Fast-20 (no version claimed)</summary>
        Fast20 = 0x0AC0,
        /// <summary>Fast-20 ANSI INCITS 277-1996</summary>
        Fast20_ANSI_INCITS_277_1996 = 0x0ADC,
        /// <summary>Fast-20 T10/1071 revision 06</summary>
        Fast20_T10_1071_Revision06 = 0x0ADB,
        /// <summary>FC 10GFC (no version claimed)</summary>
        FC10GFC = 0x0EA0,
        /// <summary>FC 10GFC ISO/IEC 14165-116</summary>
        FC10GFC_ISO_IEC_14165_116 = 0x0EA3,
        /// <summary>FC 10GFC ANSI INCITS 364-2003</summary>
        FC10GFC_ANSI_INCITS_364_2003 = 0x0EA2,
        /// <summary>FC 10GFC ANSI INCITS 364-2003 with AM1 ANSI INCITS 364/AM1-2007</summary>
        FC10GFC_ANSI_INCITS_364_2003_with_AM1_ANSI_INCITS_364_AM1_2007 = 0x0EA6,
        /// <summary>FC-AL (no version claimed)</summary>
        FC_AL = 0x0D40,
        /// <summary>FC-AL ANSI INCITS 272-1996</summary>
        FC_AL_ANSI_INCITS_272_1996 = 0x0D5C,
        /// <summary>FC-AL-2 (no version claimed)</summary>
        FC_AL_2 = 0x0D60,
        /// <summary>FC-AL-2 ANSI INCITS 332-1999 with AM1-2003 &amp; AM2-2006</summary>
        FC_AL_2_ANSI_INCITS_332_1999_with_AM1_2003_AND_AM2_2006 = 0x0D63,
        /// <summary>FC-AL-2 ANSI INCITS 332-1999 with Amendment 2 AM2-2006</summary>
        FC_AL_2_ANSI_INCITS_332_1999_with_Amendment_2_AM2_2006 = 0x0D64,
        /// <summary>FC-AL-2 ANSI INCITS 332-1999 with Amendment 1 AM1-2003</summary>
        FC_AL_2_ANSI_INCITS_332_1999_with_Amendment_1_AM1_2003 = 0x0D7D,
        /// <summary>FC-AL-2 ANSI INCITS 332-1999</summary>
        FC_AL_2_ANSI_INCITS_332_1999 = 0x0D7C,
        /// <summary>FC-AL-2 T11/1133-D revision 7.0</summary>
        FC_AL_2_T11_1133_D_Revision7_0 = 0x0D61,
        /// <summary>FC-DA (no version claimed)</summary>
        FC_DA = 0x12E0,
        /// <summary>FC-DA ANSI INCITS TR-36 2004</summary>
        FC_DA_ANSI_INCITS_TR_36_2004 = 0x12E8,
        /// <summary>FC-DA T11/1513-DT revision 3.1</summary>
        FC_DA_T11_1513_DT_Revision3_1 = 0x12E2,
        /// <summary>FC-DA-2 (no version claimed)</summary>
        FC_DA_2 = 0x12C0,
        /// <summary>FC-FLA (no version claimed)</summary>
        FC_FLA = 0x1320,
        /// <summary>FC-FLA ANSI INCITS TR-20 1998</summary>
        FC_FLA_ANSI_INCITS_TR_20_1998 = 0x133C,
        /// <summary>FC-FLA T11/1235 revision 7</summary>
        FC_FLA_T11_1235_Revision7 = 0x133B,
        /// <summary>FC-FS (no version claimed)</summary>
        FC_FS = 0x0DA0,
        /// <summary>FC-FS ANSI INCITS 373-2003</summary>
        FC_FS_ANSI_INCITS_373_2003 = 0x0DBC,
        /// <summary>FC-FS T11/1331-D revision 1.2</summary>
        FC_FS_T11_1331_D_Revision1_2 = 0x0DB7,
        /// <summary>FC-FS T11/1331-D revision 1.7</summary>
        FC_FS_T11_1331_D_Revision1_7 = 0x0DB8,
        /// <summary>FC-FS-2 (no version claimed)</summary>
        FC_FS_2 = 0x0E00,
        /// <summary>FC-FS-2 ANSI INCITS 242-2007 with AM1 ANSI INCITS 242/AM1-2007</summary>
        FC_FS_2_ANSI_INCITS_242_2007_with_AM1_ANSI_INCITS_242_AM1_2007 = 0x0E03,
        /// <summary>FC-FS-2 ANSI INCITS 242-2007</summary>
        FC_FS_2_ANSI_INCITS_242_2007 = 0x0E02,
        /// <summary>FC-FS-3 (no version claimed)</summary>
        FC_FS_3 = 0x0EE0,
        /// <summary>FC-FS-3 T11/1861-D revision 0.9</summary>
        FC_FS_3_T11_1861_D_Revision0_9 = 0x0EE2,
        /// <summary>FC-LS (no version claimed)</summary>
        FC_LS = 0x0E20,
        /// <summary>FC-LS ANSI INCITS 433-2007</summary>
        FC_LS_ANSI_INCITS_433_2007 = 0x0E29,
        /// <summary>FC-LS T11/1620-D revision 1.62</summary>
        FC_LS_T11_1620_D_Revision1_62 = 0x0E21,
        /// <summary>FC-LS-2 (no version claimed)</summary>
        FC_LS_2 = 0x0F00,
        /// <summary>FCP (no version claimed)</summary>
        FCP = 0x08C0,
        /// <summary>FCP ANSI INCITS 269-1996</summary>
        FCP_ANSI_INCITS_269_1996 = 0x08DC,
        /// <summary>FCP T10/0993-D revision 12</summary>
        FCP_T10_0993_D_Revision12 = 0x08DB,
        /// <summary>FC-PH (no version claimed)</summary>
        FC_PH = 0x0D20,
        /// <summary>FC-PH ANSI INCITS 230-1994</summary>
        FC_PH_ANSI_INCITS_230_1994 = 0x0D3B,
        /// <summary>FC-PH ANSI INCITS 230-1994 with Amendment 1 ANSI INCITS 230/AM1-1996</summary>
        FC_PH_ANSI_INCITS_230_1994_with_Amendment_1_ANSI_INCITS_230_AM1_1996 = 0x0D3C,
        /// <summary>FC-PH-3 (no version claimed)</summary>
        FC_PH_3 = 0x0D80,
        /// <summary>FC-PH-3 ANSI INCITS 303-1998</summary>
        FC_PH_3_ANSI_INCITS_303_1998 = 0x0D9C,
        /// <summary>FC-PI (no version claimed)</summary>
        FC_PI = 0x0DC0,
        /// <summary>FC-PI ANSI INCITS 352-2002</summary>
        FC_PI_ANSI_INCITS_352_2002 = 0x0DDC,
        /// <summary>FC-PI-2 (no version claimed)</summary>
        FC_PI_2 = 0x0DE0,
        /// <summary>FC-PI-2 ANSI INCITS 404-2006</summary>
        FC_PI_2_ANSI_INCITS_404_2006 = 0x0DE4,
        /// <summary>FC-PI-2 T11/1506-D revision 5.0</summary>
        FC_PI_2_T11_1506_D_Revision5_0 = 0x0DE2,
        /// <summary>FC-PI-3 (no version claimed)</summary>
        FC_PI_3 = 0x0E60,
        /// <summary>FC-PI-3 T11/1625-D revision 2.0</summary>
        FC_PI_3_T11_1625_D_Revision2_0 = 0x0E62,
        /// <summary>FC-PI-3 T11/1625-D revision 2.1</summary>
        FC_PI_3_T11_1625_D_Revision2_1 = 0x0E68,
        /// <summary>FC-PI-4 (no version claimed)</summary>
        FC_PI_4 = 0x0E80,
        /// <summary>FC-PI-4 ANSI INCITS 450-2009</summary>
        FC_PI_4_ANSI_INCITS_450_2009 = 0x0E88,
        /// <summary>FC-PI-4 T11/1647-D revision 8.0</summary>
        FC_PI_4_T11_1647_D_Revision8_0 = 0x0E82,
        /// <summary>FC-PI-5 (no version claimed)</summary>
        FC_PI_5 = 0x0F20,
        /// <summary>FC-PLDA (no version claimed)</summary>
        FC_PLDA = 0x1340,
        /// <summary>FC-PLDA ANSI INCITS TR-19 1998</summary>
        FC_PLDA_ANSI_INCITS_TR_19_1998 = 0x135C,
        /// <summary>FC-PLDA T11/1162 revision 2.1</summary>
        FC_PLDA_T11_1162_Revision2_1 = 0x135B,
        /// <summary>FCP-2 (no version claimed)</summary>
        FCP2 = 0x0900,
        /// <summary>FCP-2 ANSI INCITS 350-2003</summary>
        FCP2_ANSI_INCITS_350_2003 = 0x0917,
        /// <summary>FCP-2 T10/1144-D revision 8</summary>
        FCP2_T10_1144_D_Revision8 = 0x0918,
        /// <summary>FCP-2 T10/1144-D revision 4</summary>
        FCP2_T10_1144_D_Revision4 = 0x0901,
        /// <summary>FCP-2 T10/1144-D revision 7</summary>
        FCP2_T10_1144_D_Revision7 = 0x0915,
        /// <summary>FCP-2 T10/1144-D revision 7a</summary>
        FCP2_T10_1144_D_Revision7a = 0x0916,
        /// <summary>FCP-3 (no version claimed)</summary>
        FCP3 = 0x0A00,
        /// <summary>FCP-3 ISO/IEC 14776-223</summary>
        FCP3_ISO_IEC_14776_223 = 0x0A1C,
        /// <summary>FCP-3 ANSI INCITS 416-2006</summary>
        FCP3_ANSI_INCITS_416_2006 = 0x0A11,
        /// <summary>FCP-3 T10/1560-D revision 4</summary>
        FCP3_T10_1560_D_Revision4 = 0x0A0F,
        /// <summary>FCP-3 T10/1560-D revision 3f</summary>
        FCP3_T10_1560_D_Revision3f = 0x0A07,
        /// <summary>FCP-4 (no version claimed)</summary>
        FCP4 = 0x0A40,
        /// <summary>FCP-4 T10/1828-D revision 01</summary>
        FCP4_T10_1828_D_Revision01 = 0x0A42,
        /// <summary>FC-SP (no version claimed)</summary>
        FC_SP = 0x0E40,
        /// <summary>FC-SP ANSI INCITS 426-2007</summary>
        FC_SP_ANSI_INCITS_426_2007 = 0x0E45,
        /// <summary>FC-SP T11/1570-D revision 1.6</summary>
        FC_SP_T11_1570_D_Revision1_6 = 0x0E42,
        /// <summary>FC-SP-2 (no version claimed)</summary>
        FC_SP_2 = 0x0EC0,
        /// <summary>FC-Tape (no version claimed)</summary>
        FC_Tape = 0x1300,
        /// <summary>FC-Tape ANSI INCITS TR-24 1999</summary>
        FC_Tape_ANSI_INCITS_TR_24_1999 = 0x131C,
        /// <summary>FC-Tape T11/1315 revision 1.17</summary>
        FC_Tape_T11_1315_Revision1_17 = 0x131B,
        /// <summary>FC-Tape T11/1315 revision 1.16</summary>
        FC_Tape_T11_1315_Revision1_16 = 0x1301,
        /// <summary>IEEE 1394 (no version claimed)</summary>
        IEEE1394 = 0x14A0,
        /// <summary>ANSI IEEE 1394-1995</summary>
        ANSI_IEEE_1394_1995 = 0x14BD,
        /// <summary>IEEE 1394a (no version claimed)</summary>
        IEEE1394a = 0x14C0,
        /// <summary>IEEE 1394b (no version claimed)</summary>
        IEEE1394b = 0x14E0,
        /// <summary>IEEE 1667 (no version claimed)</summary>
        IEEE1667 = unchecked((short) 0xFFC0),
        /// <summary>IEEE 1667-2006</summary>
        IEEE1667_2006 = unchecked((short) 0xFFC1),
        /// <summary>iSCSI (no version claimed)</summary>
        iScsi = 0x0960,
        /// <summary>MMC (no version claimed)</summary>
        MMC = 0x0140,
        /// <summary>MMC ANSI INCITS 304-1997</summary>
        MMC_ANSI_INCITS_304_1997 = 0x015C,
        /// <summary>MMC T10/1048-D revision 10a</summary>
        MMC_T10_1048_D_Revision10a = 0x015B,
        /// <summary>MMC-2 (no version claimed)</summary>
        MMC2 = 0x0240,
        /// <summary>MMC-2 ANSI INCITS 333-2000</summary>
        MMC2_ANSI_INCITS_333_2000 = 0x025C,
        /// <summary>MMC-2 T10/1228-D revision 11a</summary>
        MMC2_T10_1228_D_Revision11a = 0x025B,
        /// <summary>MMC-2 T10/1228-D revision 11</summary>
        MMC2_T10_1228_D_Revision11 = 0x0255,
        /// <summary>MMC-3 (no version claimed)</summary>
        MMC3 = 0x02A0,
        /// <summary>MMC-3 ANSI INCITS 360-2002</summary>
        MMC3_ANSI_INCITS_360_2002 = 0x02B8,
        /// <summary>MMC-3 T10/1363-D revision 10g</summary>
        MMC3_T10_1363_D_Revision10g = 0x02B6,
        /// <summary>MMC-3 T10/1363-D revision 9</summary>
        MMC3_T10_1363_D_Revision9 = 0x02B5,
        /// <summary>MMC-4 (no version claimed)</summary>
        MMC4 = 0x03A0,
        /// <summary>MMC-4 ANSI INCITS 401-2005</summary>
        MMC4_ANSI_INCITS_401_2005 = 0x03BF,
        /// <summary>MMC-4 T10/1545-D revision 3</summary>
        MMC4_T10_1545_D_Revision3 = 0x03BD,
        /// <summary>MMC-4 T10/1545-D revision 3d</summary>
        MMC4_T10_1545_D_Revision3d = 0x03BE,
        /// <summary>MMC-4 T10/1545-D revision 5</summary>
        MMC4_T10_1545_D_Revision5 = 0x03B0,
        /// <summary>MMC-4 T10/1545-D revision 5a</summary>
        MMC4_T10_1545_D_Revision5a = 0x03B1,
        /// <summary>MMC-5 (no version claimed)</summary>
        MMC5 = 0x0420,
        /// <summary>MMC-5 T10/1675-D revision 04</summary>
        MMC5_T10_1675_D_Revision04 = 0x0432,
        /// <summary>MMC-5 ANSI INCITS 430-2007</summary>
        MMC5_ANSI_INCITS_430_2007 = 0x0434,
        /// <summary>MMC-5 T10/1675-D revision 03</summary>
        MMC5_T10_1675_D_Revision03 = 0x042F,
        /// <summary>MMC-5 T10/1675-D revision 03b</summary>
        MMC5_T10_1675_D_Revision03b = 0x0431,
        /// <summary>MMC-6 (no version claimed)</summary>
        MMC6 = 0x04E0,
        /// <summary>MMC-6 T10/1836-D revision 02b</summary>
        MMC6_T10_1836_D_Revision02b = 0x04E3,
        /// <summary>OCRW (no version claimed)</summary>
        OCRW = 0x0280,
        /// <summary>OCRW ISO/IEC 14776-381</summary>
        OCRW_ISO_IEC_14776_381 = 0x029E,
        /// <summary>OSD (no version claimed)</summary>
        OSD = 0x0340,
        /// <summary>OSD ANSI INCITS 400-2004</summary>
        OSD_ANSI_INCITS_400_2004 = 0x0356,
        /// <summary>OSD T10/1355-D revision 10</summary>
        OSD_T10_1355_D_Revision10 = 0x0355,
        /// <summary>OSD T10/1355-D revision 0</summary>
        OSD_T10_1355_D_Revision0 = 0x0341,
        /// <summary>OSD T10/1355-D revision 7a</summary>
        OSD_T10_1355_D_Revision7a = 0x0342,
        /// <summary>OSD T10/1355-D revision 8</summary>
        OSD_T10_1355_D_Revision8 = 0x0343,
        /// <summary>OSD T10/1355-D revision 9</summary>
        OSD_T10_1355_D_Revision9 = 0x0344,
        /// <summary>OSD-2 (no version claimed)</summary>
        OSD2 = 0x0440,
        /// <summary>OSD-2 T10/1729-D revision 4</summary>
        OSD2_T10_1729_D_Revision4 = 0x0444,
        /// <summary>OSD-2 T10/1729-D revision 5</summary>
        OSD2_T10_1729_D_Revision5 = 0x0446,
        /// <summary>OSD-3 (no version claimed)</summary>
        OSD3 = 0x0560,
        /// <summary>RBC (no version claimed)</summary>
        RBC = 0x0220,
        /// <summary>RBC ANSI INCITS 330-2000</summary>
        RBC_ANSI_INCITS_330_2000 = 0x023C,
        /// <summary>RBC T10/1240-D revision 10a</summary>
        RBC_T10_1240_D_Revision10a = 0x0238,
        /// <summary>SAM (no version claimed)</summary>
        SAM = 0x0020,
        /// <summary>SAM ANSI INCITS 270-1996</summary>
        SAM_ANSI_INCITS_270_1996 = 0x003C,
        /// <summary>SAM T10/0994-D revision 18</summary>
        SAM_T10_0994_D_Revision18 = 0x003B,
        /// <summary>SAM-2 (no version claimed)</summary>
        SAM2 = 0x0040,
        /// <summary>SAM-2 ISO/IEC 14776-412</summary>
        SAM2_ISO_IEC_14776_412 = 0x005E,
        /// <summary>SAM-2 ANSI INCITS 366-2003</summary>
        SAM2_ANSI_INCITS_366_2003 = 0x005C,
        /// <summary>SAM-2 T10/1157-D revision 24</summary>
        SAM2_T10_1157_D_Revision24 = 0x0055,
        /// <summary>SAM-2 T10/1157-D revision 23</summary>
        SAM2_T10_1157_D_Revision23 = 0x0054,
        /// <summary>SAM-3 (no version claimed)</summary>
        SAM3 = 0x0060,
        /// <summary>SAM-3 ANSI INCITS 402-2005</summary>
        SAM3_ANSI_INCITS_402_2005 = 0x0077,
        /// <summary>SAM-3 T10/1561-D revision 14</summary>
        SAM3_T10_1561_D_Revision14 = 0x0076,
        /// <summary>SAM-3 T10/1561-D revision 7</summary>
        SAM3_T10_1561_D_Revision7 = 0x0062,
        /// <summary>SAM-3 T10/1561-D revision 13</summary>
        SAM3_T10_1561_D_Revision13 = 0x0075,
        /// <summary>SAM-4 (no version claimed)</summary>
        SAM4 = 0x0080,
        /// <summary>SAM-4 ANSI INCITS 447-2008</summary>
        SAM4_ANSI_INCITS_447_2008 = 0x0090,
        /// <summary>SAM-4 T10/1683-D revision 13</summary>
        SAM4_T10_1683_D_Revision13 = 0x0087,
        /// <summary>SAM-4 T10/1683-D revision 14</summary>
        SAM4_T10_1683_D_Revision14 = 0x008B,
        /// <summary>SAM-5 (no version claimed)</summary>
        SAM5 = 0x00A0,
        /// <summary>SAS (no version claimed)</summary>
        SAS = 0x0BE0,
        /// <summary>SAS ANSI INCITS 376-2003</summary>
        SAS_ANSI_INCITS_376_2003 = 0x0BFD,
        /// <summary>SAS T10/1562-D revision 05</summary>
        SAS_T10_1562_D_Revision05 = 0x0BFC,
        /// <summary>SAS T10/1562-D revision 01</summary>
        SAS_T10_1562_D_Revision01 = 0x0BE1,
        /// <summary>SAS T10/1562-D revision 03</summary>
        SAS_T10_1562_D_Revision03 = 0x0BF5,
        /// <summary>SAS T10/1562-D revision 04</summary>
        SAS_T10_1562_D_Revision04_1 = 0x0BFA,
        /// <summary>SAS T10/1562-D revision 04</summary>
        SAS_T10_1562_D_Revision04_2 = 0x0BFB,
        /// <summary>SAS-1.1 (no version claimed)</summary>
        SAS1_1 = 0x0C00,
        /// <summary>SAS-1.1 ANSI INCITS 417-2006</summary>
        SAS1_1_ANSI_INCITS_417_2006 = 0x0C11,
        /// <summary>SAS-1.1 T10/1601-D revision 10</summary>
        SAS1_1_T10_1601_D_Revision10 = 0x0C0F,
        /// <summary>SAS-1.1 T10/1601-D revision 9</summary>
        SAS1_1_T10_1601_D_Revision9 = 0x0C07,
        /// <summary>SAS-2 (no version claimed)</summary>
        SAS2 = 0x0C20,
        /// <summary>SAS-2 T10/1760-D revision 14</summary>
        SAS2_T10_1760_D_Revision14 = 0x0C23,
        /// <summary>SAS-2 T10/1760-D revision 15</summary>
        SAS2_T10_1760_D_Revision15 = 0x0C27,
        /// <summary>SAS-2 T10/1760-D revision 16</summary>
        SAS2_T10_1760_D_Revision16 = 0x0C28,
        /// <summary>SAS-2.1 (no version claimed)</summary>
        SAS2_1 = 0x0C40,
        /// <summary>SAS-2.1 T10/2125-D revision 04</summary>
        SAS2_1_T10_2125_D_Revision04 = 0x0C48,
        /// <summary>SAT (no version claimed)</summary>
        SAT = 0x1EA0,
        /// <summary>SAT ANSI INCITS 431-2007</summary>
        SAT_ANSI_INCITS_431_2007 = 0x1EAD,
        /// <summary>SAT T10/1711-D revision 9</summary>
        SAT_T10_1711_D_Revision9 = 0x1EAB,
        /// <summary>SAT T10/1711-D revision 8</summary>
        SAT_T10_1711_D_Revision8 = 0x1EA7,
        /// <summary>SAT-2 (no version claimed)</summary>
        SAT2 = 0x1EC0,
        /// <summary>SAT-2 T10/1826-D revision 06</summary>
        SAT2_T10_1826_D_Revision06 = 0x1EC4,
        /// <summary>SAT-2 T10/1826-D revision 09</summary>
        SAT2_T10_1826_D_Revision09 = 0x1EC8,
        /// <summary>SAT-3 (no version claimed)</summary>
        SAT3 = 0x1EE0,
        /// <summary>SBC (no version claimed)</summary>
        SBC = 0x0180,
        /// <summary>SBC ANSI INCITS 306-1998</summary>
        SBC_ANSI_INCITS_306_1998 = 0x019C,
        /// <summary>SBC T10/0996-D revision 08c</summary>
        SBC_T10_0996_D_Revision08c = 0x019B,
        /// <summary>SBC-2 (no version claimed)</summary>
        SBC2 = 0x0320,
        /// <summary>SBC-2 ISO/IEC 14776-322</summary>
        SBC2_ISO_IEC_14776_322 = 0x033E,
        /// <summary>SBC-2 ANSI INCITS 405-2005</summary>
        SBC2_ANSI_INCITS_405_2005 = 0x033D,
        /// <summary>SBC-2 T10/1417-D revision 16</summary>
        SBC2_T10_1417_D_Revision16 = 0x033B,
        /// <summary>SBC-2 T10/1417-D revision 5a</summary>
        SBC2_T10_1417_D_Revision5a = 0x0322,
        /// <summary>SBC-2 T10/1417-D revision 15</summary>
        SBC2_T10_1417_D_Revision15 = 0x0324,
        /// <summary>SBC-3 (no version claimed)</summary>
        SBC3 = 0x04C0,
        /// <summary>SBP-2 (no version claimed)</summary>
        SBP2 = 0x08E0,
        /// <summary>SBP-2 ANSI INCITS 325-1998</summary>
        SBP2_ANSI_INCITS_325_1998 = 0x08FC,
        /// <summary>SBP-2 T10/1155-D revision 04</summary>
        SBP2_T10_1155_D_Revision04 = 0x08FB,
        /// <summary>SBP-3 (no version claimed)</summary>
        SBP3 = 0x0980,
        /// <summary>SBP-3 ANSI INCITS 375-2004</summary>
        SBP3_ANSI_INCITS_375_2004 = 0x099C,
        /// <summary>SBP-3 T10/1467-D revision 5</summary>
        SBP3_T10_1467_D_Revision5 = 0x099B,
        /// <summary>SBP-3 T10/1467-D revision 1f</summary>
        SBP3_T10_1467_D_Revision1f = 0x0982,
        /// <summary>SBP-3 T10/1467-D revision 3</summary>
        SBP3_T10_1467_D_Revision3 = 0x0994,
        /// <summary>SBP-3 T10/1467-D revision 4</summary>
        SBP3_T10_1467_D_Revision4 = 0x099A,
        /// <summary>SCC (no version claimed)</summary>
        SCC = 0x0160,
        /// <summary>SCC ANSI INCITS 276-1997</summary>
        SCC_ANSI_INCITS_276_1997 = 0x017C,
        /// <summary>SCC T10/1047-D revision 06c</summary>
        SCC_T10_1047_D_Revision06c = 0x017B,
        /// <summary>SCC-2 (no version claimed)</summary>
        SCC2 = 0x01E0,
        /// <summary>SCC-2 ANSI INCITS 318-1998</summary>
        SCC2_ANSI_INCITS_318_1998 = 0x01FC,
        /// <summary>SCC-2 T10/1125-D revision 04</summary>
        SCC2_T10_1125_D_Revision04 = 0x01FB,
        /// <summary>SES (no version claimed)</summary>
        SES = 0x01C0,
        /// <summary>SES ANSI INCITS 305-1998</summary>
        SES_ANSI_INCITS_305_1998 = 0x01DC,
        /// <summary>SES T10/1212-D revision 08b</summary>
        SES_T10_1212_D_Revision08b = 0x01DB,
        /// <summary>SES ANSI INCITS 305-1998 w/ Amendment ANSI INCITS.305/AM1-2000</summary>
        SES_ANSI_INCITS_305_1998_w__Amendment_ANSI_INCITS_305_AM1_2000 = 0x01DE,
        /// <summary>SES T10/1212 revision 08b w/ Amendment ANSI INCITS.305/AM1-2000</summary>
        SES_T10_1212_Revision08b_w__Amendment_ANSI_INCITS_305_AM1_2000 = 0x01DD,
        /// <summary>SES-2 (no version claimed)</summary>
        SES2 = 0x03E0,
        /// <summary>SES-2 ANSI INCITS 448-2008</summary>
        SES2_ANSI_INCITS_448_2008 = 0x03F0,
        /// <summary>SES-2 T10/1559-D revision 16</summary>
        SES2_T10_1559_D_Revision16 = 0x03E1,
        /// <summary>SES-2 T10/1559-D revision 19</summary>
        SES2_T10_1559_D_Revision19 = 0x03E7,
        /// <summary>SES-2 T10/1559-D revision 20</summary>
        SES2_T10_1559_D_Revision20 = 0x03EB,
        /// <summary>SES-3 (no version claimed)</summary>
        SES3 = 0x0580,
        /// <summary>SIP (no version claimed)</summary>
        SIP = 0x08A0,
        /// <summary>SIP ANSI INCITS 292-1997</summary>
        SIP_ANSI_INCITS_292_1997 = 0x08BC,
        /// <summary>SIP T10/0856-D revision 10</summary>
        SIP_T10_0856_D_Revision10 = 0x08BB,
        /// <summary>SMC (no version claimed)</summary>
        SMC = 0x01A0,
        /// <summary>SMC ISO/IEC 14776-351</summary>
        SMC_ISO_IEC_14776_351 = 0x01BE,
        /// <summary>SMC ANSI INCITS 314-1998</summary>
        SMC_ANSI_INCITS_314_1998 = 0x01BC,
        /// <summary>SMC T10/0999-D revision 10a</summary>
        SMC_T10_0999_D_Revision10a = 0x01BB,
        /// <summary>SMC-2 (no version claimed)</summary>
        SMC2 = 0x02E0,
        /// <summary>SMC-2 ANSI INCITS 382-2004</summary>
        SMC2_ANSI_INCITS_382_2004 = 0x02FE,
        /// <summary>SMC-2 T10/1383-D revision 7</summary>
        SMC2_T10_1383_D_Revision7 = 0x02FD,
        /// <summary>SMC-2 T10/1383-D revision 5</summary>
        SMC2_T10_1383_D_Revision5 = 0x02F5,
        /// <summary>SMC-2 T10/1383-D revision 6</summary>
        SMC2_T10_1383_D_Revision6 = 0x02FC,
        /// <summary>SMC-3 (no version claimed)</summary>
        SMC3 = 0x0480,
        /// <summary>SPC (no version claimed)</summary>
        SPC = 0x0120,
        /// <summary>SPC ANSI INCITS 301-1997</summary>
        SPC_ANSI_INCITS_301_1997 = 0x013C,
        /// <summary>SPC T10/0995-D revision 11a</summary>
        SPC_T10_0995_D_Revision11a = 0x013B,
        /// <summary>SPC-2 (no version claimed)</summary>
        SPC2 = 0x0260,
        /// <summary>SPC-2 ISO/IEC 14776-452</summary>
        SPC2_ISO_IEC_14776_452 = 0x0278,
        /// <summary>SPC-2 ANSI INCITS 351-2001</summary>
        SPC2_ANSI_INCITS_351_2001 = 0x0277,
        /// <summary>SPC-2 T10/1236-D revision 20</summary>
        SPC2_T10_1236_D_Revision20 = 0x0276,
        /// <summary>SPC-2 T10/1236-D revision 12</summary>
        SPC2_T10_1236_D_Revision12 = 0x0267,
        /// <summary>SPC-2 T10/1236-D revision 18</summary>
        SPC2_T10_1236_D_Revision18 = 0x0269,
        /// <summary>SPC-2 T10/1236-D revision 19</summary>
        SPC2_T10_1236_D_Revision19 = 0x0275,
        /// <summary>SPC-3 (no version claimed)</summary>
        SPC3 = 0x0300,
        /// <summary>SPC-3 ANSI INCITS 408-2005</summary>
        SPC3_ANSI_INCITS_408_2005 = 0x0314,
        /// <summary>SPC-3 T10/1416-D revision 23</summary>
        SPC3_T10_1416_D_Revision23 = 0x0312,
        /// <summary>SPC-3 T10/1416-D revision 7</summary>
        SPC3_T10_1416_D_Revision7 = 0x0301,
        /// <summary>SPC-3 T10/1416-D revision 21</summary>
        SPC3_T10_1416_D_Revision21 = 0x0307,
        /// <summary>SPC-3 T10/1416-D revision 22</summary>
        SPC3_T10_1416_D_Revision22 = 0x030F,
        /// <summary>SPC-4 (no version claimed)</summary>
        SPC4 = 0x0460,
        /// <summary>SPC-4 T10/1731-D revision 16</summary>
        SPC4_T10_1731_D_Revision16 = 0x0461,
        /// <summary>SPC-4 T10/1731-D revision 18</summary>
        SPC4_T10_1731_D_Revision18 = 0x0462,
        /// <summary>SPI (no version claimed)</summary>
        SPI = 0x0AA0,
        /// <summary>SPI ANSI INCITS 253-1995</summary>
        SPI_ANSI_INCITS_253_1995 = 0x0ABA,
        /// <summary>SPI T10/0855-D revision 15a</summary>
        SPI_T10_0855_D_Revision15a = 0x0AB9,
        /// <summary>SPI ANSI INCITS 253-1995 with SPI Amendment ANSI INCITS 253/AM1-1998</summary>
        SPI_ANSI_INCITS_253_1995_with_SPI_Amendment_ANSI_INCITS_253_AM1_1998 = 0x0ABC,
        /// <summary>SPI T10/0855-D revision 15a with SPI Amendment revision 3a</summary>
        SPI_T10_0855_D_Revision15a_with_SPI_Amendment_Revision3a = 0x0ABB,
        /// <summary>SPI-2 (no version claimed)</summary>
        SPI2 = 0x0AE0,
        /// <summary>SPI-2 ANSI INCITS 302-1999</summary>
        SPI2_ANSI_INCITS_302_1999 = 0x0AFC,
        /// <summary>SPI-2 T10/1142-D revision 20b</summary>
        SPI2_T10_1142_D_Revision20b = 0x0AFB,
        /// <summary>SPI-3 (no version claimed)</summary>
        SPI3 = 0x0B00,
        /// <summary>SPI-3 ANSI INCITS 336-2000</summary>
        SPI3_ANSI_INCITS_336_2000 = 0x0B1C,
        /// <summary>SPI-3 T10/1302-D revision 14</summary>
        SPI3_T10_1302_D_Revision14 = 0x0B1A,
        /// <summary>SPI-3 T10/1302-D revision 10</summary>
        SPI3_T10_1302_D_Revision10 = 0x0B18,
        /// <summary>SPI-3 T10/1302-D revision 13a</summary>
        SPI3_T10_1302_D_Revision13a = 0x0B19,
        /// <summary>SPI-4 (no version claimed)</summary>
        SPI4 = 0x0B40,
        /// <summary>SPI-4 ANSI INCITS 362-2002</summary>
        SPI4_ANSI_INCITS_362_2002 = 0x0B56,
        /// <summary>SPI-4 T10/1365-D revision 7</summary>
        SPI4_T10_1365_D_Revision7 = 0x0B54,
        /// <summary>SPI-4 T10/1365-D revision 9</summary>
        SPI4_T10_1365_D_Revision9 = 0x0B55,
        /// <summary>SPI-4 T10/1365-D revision 10</summary>
        SPI4_T10_1365_D_Revision10 = 0x0B59,
        /// <summary>SPI-5 (no version claimed)</summary>
        SPI5 = 0x0B60,
        /// <summary>SPI-5 ANSI INCITS 367-2003</summary>
        SPI5_ANSI_INCITS_367_2003 = 0x0B7C,
        /// <summary>SPI-5 T10/1525-D revision 6</summary>
        SPI5_T10_1525_D_Revision6 = 0x0B7B,
        /// <summary>SPI-5 T10/1525-D revision 3</summary>
        SPI5_T10_1525_D_Revision3 = 0x0B79,
        /// <summary>SPI-5 T10/1525-D revision 5</summary>
        SPI5_T10_1525_D_Revision5 = 0x0B7A,
        /// <summary>SPL (no version claimed)</summary>
        SPL = 0x20A0,
        /// <summary>SRP (no version claimed)</summary>
        SRP = 0x0940,
        /// <summary>SRP ANSI INCITS 365-2002</summary>
        SRP_ANSI_INCITS_365_2002 = 0x095C,
        /// <summary>SRP T10/1415-D revision 16a</summary>
        SRP_T10_1415_D_Revision16a = 0x0955,
        /// <summary>SRP T10/1415-D revision 10</summary>
        SRP_T10_1415_D_Revision10 = 0x0954,
        /// <summary>SSA-PH2 (no version claimed)</summary>
        SSA_PH2 = 0x1360,
        /// <summary>SSA-PH2 ANSI INCITS 293-1996</summary>
        SSA_PH2_ANSI_INCITS_293_1996 = 0x137C,
        /// <summary>SSA-PH2 T10.1/1145-D revision 09c</summary>
        SSA_PH2_T10_1_1145_D_Revision09c = 0x137B,
        /// <summary>SSA-PH3 (no version claimed)</summary>
        SSA_PH3 = 0x1380,
        /// <summary>SSA-PH3 ANSI INCITS 307-1998</summary>
        SSA_PH3_ANSI_INCITS_307_1998 = 0x139C,
        /// <summary>SSA-PH3 T10.1/1146-D revision 05b</summary>
        SSA_PH3_T10_1_1146_D_Revision05b = 0x139B,
        /// <summary>SSA-S2P (no version claimed)</summary>
        SSA_S2P = 0x0880,
        /// <summary>SSA-S2P ANSI INCITS 294-1996</summary>
        SSA_S2P_ANSI_INCITS_294_1996 = 0x089C,
        /// <summary>SSA-S2P T10.1/1121-D revision 07b</summary>
        SSA_S2P_T10_1_1121_D_Revision07b = 0x089B,
        /// <summary>SSA-S3P (no version claimed)</summary>
        SSA_S3P = 0x0860,
        /// <summary>SSA-S3P ANSI INCITS 309-1998</summary>
        SSA_S3P_ANSI_INCITS_309_1998 = 0x087C,
        /// <summary>SSA-S3P T10.1/1051-D revision 05b</summary>
        SSA_S3P_T10_1_1051_D_Revision05b = 0x087B,
        /// <summary>SSA-TL1 (no version claimed)</summary>
        SSA_TL1 = 0x0840,
        /// <summary>SSA-TL1 ANSI INCITS 295-1996</summary>
        SSA_TL1_ANSI_INCITS_295_1996 = 0x085C,
        /// <summary>SSA-TL1 T10.1/0989-D revision 10b</summary>
        SSA_TL1_T10_1_0989_D_Revision10b = 0x085B,
        /// <summary>SSA-TL2 (no version claimed)</summary>
        SSA_TL2 = 0x0820,
        /// <summary>SSA-TL2 ANSI INCITS 308-1998</summary>
        SSA_TL2_ANSI_INCITS_308_1998 = 0x083C,
        /// <summary>SSA-TL2 T10.1/1147-D revision 05b</summary>
        SSA_TL2_T10_1_1147_D_Revision05b = 0x083B,
        /// <summary>SSC (no version claimed)</summary>
        SSC = 0x0200,
        /// <summary>SSC ANSI INCITS 335-2000</summary>
        SSC_ANSI_INCITS_335_2000 = 0x021C,
        /// <summary>SSC T10/0997-D revision 22</summary>
        SSC_T10_0997_D_Revision22 = 0x0207,
        /// <summary>SSC T10/0997-D revision 17</summary>
        SSC_T10_0997_D_Revision17 = 0x0201,
        /// <summary>SSC-2 (no version claimed)</summary>
        SSC2 = 0x0360,
        /// <summary>SSC-2 ANSI INCITS 380-2003</summary>
        SSC2_ANSI_INCITS_380_2003 = 0x037D,
        /// <summary>SSC-2 T10/1434-D revision 9</summary>
        SSC2_T10_1434_D_Revision9 = 0x0375,
        /// <summary>SSC-2 T10/1434-D revision 7</summary>
        SSC2_T10_1434_D_Revision7 = 0x0374,
        /// <summary>SSC-3 (no version claimed)</summary>
        SSC3 = 0x0400,
        /// <summary>SSC-3 T10/1611-D revision 04a</summary>
        SSC3_T10_1611_D_Revision04a = 0x0403,
        /// <summary>SSC-3 T10/1611-D revision 05</summary>
        SSC3_T10_1611_D_Revision05 = 0x0407,
        /// <summary>SSC-4 (no version claimed)</summary>
        SSC4 = 0x0520,
        /// <summary>SST (no version claimed)</summary>
        SST = 0x0920,
        /// <summary>SST T10/1380-D revision 8b</summary>
        SST_T10_1380_D_Revision8b = 0x0935,
        /// <summary>UAS (no version claimed)</summary>
        UAS = 0x1740,
        /// <summary>UAS T10/2095-D revision 02</summary>
        UAS_T10_2095_D_Revision02 = 0x1743,
        /// <summary>Universal Serial Bus Specification, Revision 1.1</summary>
        Universal_Serial_Bus_Specification__Revision1_1 = 0x1728,
        /// <summary>Universal Serial Bus Specification, Revision 2.0</summary>
        Universal_Serial_Bus_Specification__Revision2_0 = 0x1729,
        /// <summary>USB Mass Storage Class Bulk-Only Transport, Revision 1.0</summary>
        USB_Mass_Storage_Class_Bulk_Only_Transport__Revision1_0 = 0x1730,
    }
}