using System;
using System.ComponentModel;

namespace Scsi
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class ScsiComplianceAttribute : Attribute
    {
        /// <param name="complyingStandard">The Scsi standard to which the target complies.</param>
        /// <param name="startingVersion">The version of the standard at which compliance begins (inclusive).</param>
        /// <param name="endingVersion">The version of the standard at which compliance ends (inclusive), or <c>-1</c> if not known.</param>
        public ScsiComplianceAttribute(ScsiStandard complyingStandard, int startingVersion, int endingVersion)
        {
            ComplyingStandard = complyingStandard;
            StartingVersion = startingVersion;
            EndingVersion = endingVersion;
        }

        public ScsiStandard ComplyingStandard { get; private set; }
        public int StartingVersion { get; private set; }

        /// <summary>The ending version, or <c>-1</c> if not known.</summary>
        [Description("The ending version, or -1 if not known.")]
        public int EndingVersion { get; private set; }
    }

    public enum ScsiStandard
    {
        PrimaryCommands,
        ArchitecturalModel,
        BlockCommands,
        MultimediaCommands,
        StreamCommands,
        ParallelInterfaceCommands
    }
}