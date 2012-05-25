using System.Runtime.InteropServices;

namespace Scsi
{
    /// <summary>According to the Scsi standard, all fixed-size commands have a <see cref="CommandControl"/> structure at the end of the command descriptor block.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class FixedLengthScsiCommand : ScsiCommand
    {
        protected FixedLengthScsiCommand(ScsiCommandCode operationCode) : base(operationCode)
        {
        }
    }
}