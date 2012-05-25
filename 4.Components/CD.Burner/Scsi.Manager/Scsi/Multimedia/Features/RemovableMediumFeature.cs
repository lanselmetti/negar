using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Helper;

namespace Scsi.Multimedia
{
    /// <summary>This feature identifies a drive that has a medium that is removable. Media is be considered removable if it is possible to remove it from the loaded position, i.e., a single mechanism changer, even if the media is captive to the changer.</summary>
    [Description(
        "This feature identifies a drive that has a medium that is removable.\r\nMedia is be considered removable if it is possible to remove it from the loaded position, i.e., a single mechanism changer, even if the media is captive to the changer."
        )]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class RemovableMediumFeature : MultimediaFeature
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private static readonly ScsiCommandCode[]
            __SupportedOperations =
                Sort(new[]
                         {
                             ScsiCommandCode.GetEventStatusNotification, ScsiCommandCode.MechanismStatus,
                             ScsiCommandCode.PreventAllowMediumRemoval, ScsiCommandCode.StartStopUnit
                         });

        public override FeatureSupportKind GetSupport(ScsiCommand command)
        {
            return Array.BinarySearch(__SupportedOperations, command.OpCode) >= 0
                   &&
                   (command.OpCode != ScsiCommandCode.PreventAllowMediumRemoval ||
                    ((PreventAllowMediumRemovalCommand) command).Persistent == false)
                   &&
                   (command.OpCode != ScsiCommandCode.GetEventStatusNotification ||
                    (((GetEventStatusNotificationCommand) command).NotificationClassRequest &
                     NotificationClassFlags.Media) != 0)
                       ? FeatureSupportKind.Mandatory
                       : FeatureSupportKind.None;
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const byte LOADING_MECHANISM_TYPE_MASK = 0xE0;

        public RemovableMediumFeature() : base(FeatureCode.RemovableMedium)
        {
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte4;

        [DisplayName("Lockable")]
        public bool Lock
        {
            get { return Bits.GetBit(byte4, 0); }
            set { byte4 = Bits.SetBit(byte4, 0, value); }
        }

        [DisplayName("Prevent Jumper Absent")]
        public bool PreventJumper
        {
            get { return Bits.GetBit(byte4, 2); }
            set { byte4 = Bits.SetBit(byte4, 2, value); }
        }

        [DisplayName("No Soft Eject")]
        public bool Eject
        {
            get { return Bits.GetBit(byte4, 3); }
            set { byte4 = Bits.SetBit(byte4, 3, value); }
        }

        [DisplayName("No Soft Load")]
        public bool Load
        {
            get { return Bits.GetBit(byte4, 4); }
            set { byte4 = Bits.SetBit(byte4, 4, value); }
        }

        [DisplayName("Loading Mechanism Type")]
        public LoadingMechanism LoadingMechanismType
        {
            get { return (LoadingMechanism) Bits.GetValueMask(byte4, 5, LOADING_MECHANISM_TYPE_MASK); }
            set { byte4 = Bits.PutValueMask(byte4, (byte) value, 5, LOADING_MECHANISM_TYPE_MASK); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte5;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte6;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private byte byte7;
    }
}