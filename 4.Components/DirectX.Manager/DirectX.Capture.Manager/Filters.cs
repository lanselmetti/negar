using System;
using Negar.DirectShow.Manager;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    ///  Provides collections of devices and compression codecs
    ///  installed on the system. 
    /// </summary>
    /// <example>
    ///  Devices and compression codecs are implemented in DirectShow 
    ///  as filters, see the <see cref="Filter"/> class for more 
    ///  information. To list the available video devices:
    ///  <code><div style="background-color:whitesmoke;">
    ///   Filters filters = new Filters();
    ///   foreach ( Filter f in filters.VideoInputDevices )
    ///   {
    ///		Debug.WriteLine( f.Name );
    ///   }
    ///  </div></code>
    ///  <seealso cref="Filter"/>
    /// </example>
    public class Filters
    {
        #region Fields

        /// <summary> Collection of available audio compressors. </summary>
        public FilterCollection AudioCompressors;

        /// <summary> Collection of available audio capture devices. </summary>
        public FilterCollection AudioInputDevices;

        /// <summary> Collection of available audio compressors. </summary>
        public FilterCollection LegacyFilters;

        /// <summary> Collection of available video compressors. </summary>
        public FilterCollection VideoCompressors;

        /// <summary> Collection of available video capture devices. </summary>
        public FilterCollection VideoInputDevices;

        #endregion

        #region Ctors

        #region Filters()

        public Filters()
        {
            AudioCompressors = new FilterCollection(FilterCategory.AudioCompressorCategory);

            AudioInputDevices = new FilterCollection(FilterCategory.AudioInputDevice);

            LegacyFilters = new FilterCollection(FilterCategory.LegacyAmFilterCategory);

            VideoCompressors = new FilterCollection(FilterCategory.VideoCompressorCategory);

            VideoInputDevices = new FilterCollection(FilterCategory.VideoInputDevice);
        }

        #endregion

        #region Filters(Boolean InitAudio, Boolean InitVideo)

        public Filters(Boolean InitAudio, Boolean InitVideo)
        {
            if (InitAudio)
            {
                AudioCompressors = new FilterCollection(FilterCategory.AudioCompressorCategory);
                AudioInputDevices = new FilterCollection(FilterCategory.AudioInputDevice);
            }
            LegacyFilters = new FilterCollection(FilterCategory.LegacyAmFilterCategory);
            if (InitVideo)
            {
                VideoCompressors = new FilterCollection(FilterCategory.VideoCompressorCategory);
                VideoInputDevices = new FilterCollection(FilterCategory.VideoInputDevice);
            }
        }

        #endregion

        #endregion
    }
}