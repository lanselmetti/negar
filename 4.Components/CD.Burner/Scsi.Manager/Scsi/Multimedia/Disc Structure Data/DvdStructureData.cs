using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>Represents DVD and HD DVD structure data.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class DvdStructureData : DiscStructureData
    {
    }
}