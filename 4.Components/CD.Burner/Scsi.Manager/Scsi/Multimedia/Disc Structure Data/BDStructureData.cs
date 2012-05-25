using System.Runtime.InteropServices;

namespace Scsi.Multimedia
{
    /// <summary>Represents BD structure data.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public abstract class BDStructureData : DiscStructureData
    {
    }
}