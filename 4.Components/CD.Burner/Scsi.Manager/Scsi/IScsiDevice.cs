using System;

namespace Scsi
{
    public interface IScsiDevice : IDisposable
    {
        /// <summary>The block size, in bytes, of the current medium.</summary>
        uint BlockSize { get; }

        bool CanRead { get; }
        bool CanSeek { get; }
        bool CanWrite { get; }

        /// <summary>The current status of the drive.</summary>
        ScsiStatus Status { get; }

        /// <summary>The capacity of the entire medium, in bytes.</summary>
        long Capacity { get; }

        /// <summary>Reads the specified number of bytes from the medium.</summary>
        /// <param name="position">The position to read from, in bytes.</param>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="bufferOffset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current medium.</param>
        /// <param name="length">The maximum number of bytes to be read from the current medium.</param>
        /// <param name="forceUnitAccess">Whether to force the data to be read from the unit, regardless of any cache present.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="position"/> or <paramref name="length"/> is not aligned to the sector size.</exception>
        void Read(long position, byte[] buffer, int bufferOffset, int length, bool forceUnitAccess);

        /// <summary>Writes the specified data to the medium.</summary>
        /// <param name="position">The position to write to, in bytes.</param>
        /// <param name="buffer">The buffer to write the data from.</param>
        /// <param name="bufferOffset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data into the current medium.</param>
        /// <param name="length">The maximum number of bytes to be written to the current medium.</param>
        /// <param name="forceUnitAccess">Whether to force the data to be written to the unit, regardless of any cache present. This is equivalent to flushing the data to the medium.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="position"/> or <paramref name="length"/> is not aligned to the sector size.</exception>
        void Write(long position, byte[] buffer, int bufferOffset, int length, bool forceUnitAccess);

        /// <summary>Synchronizes data in the cache with the medium.</summary>
        void Flush();
    }
}