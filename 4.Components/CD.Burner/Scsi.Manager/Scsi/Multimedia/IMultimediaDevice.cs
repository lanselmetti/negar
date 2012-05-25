using System.IO;

namespace Scsi.Multimedia
{
    public interface IMultimediaDevice : IScsiDevice
    {
        int FirstTrackNumber { get; }
        int TrackCount { get; }
        int SessionCount { get; }

        /// <summary>Creates a new track or opens an existing track.</summary>
        /// <param name="trackNumber">The track to create. Note that this does not start from zero, but from the <see cref="FirstTrackNumber"/> member.</param>
        /// <returns>A <see cref="Stream"/> representing the opened track.</returns>
        Stream OpenTrack(int trackNumber);
    }
}