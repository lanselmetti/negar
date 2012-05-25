using System;
using System.Diagnostics;

namespace Negar.DirectX.Capture.Manager
{
    /// <summary>
    /// Summary description for WMProfileData
    /// </summary>
    public class WMProfileData
    {
        /// <summary>
        /// Indicates whether this profile supports an audio stream
        /// </summary>
        protected bool audio;

        /// <summary>
        /// Audio bit rate
        /// Might be interesting to know when selecting a format
        /// </summary>
        protected Int32 audioBitrate;

        /// <summary>
        /// Description of the profile
        /// Might be interesting to know when selecting a format
        /// </summary>
        protected string description;

        /// <summary>
        /// Indicates whether this profile is the one currently in use
        /// </summary>
        protected bool enabled;

        /// <summary>
        /// Profile filename, a profile must have a guid or a filename
        /// </summary>
        protected string filename;

        /// <summary>
        /// Guid of the profile
        /// Must be valid and an unique guid
        /// </summary>
        protected Guid guid;

        /// <summary>
        /// Name of the profile
        /// Must be valid and an unique name
        /// </summary>
        protected string name;

        /// <summary>
        /// Indicates whether this profile supports an video stream
        /// </summary>
        protected bool video;

        /// <summary>
        /// Video bit rate
        /// Might be interesting to know when selecting a format
        /// </summary>
        protected Int32 videoBitrate;

        /// <summary>
        /// Constructor
        /// </summary>
        internal WMProfileData()
        {
            //
            // TODO: Add constructor logic here
            //
            enabled = false;
        }

        /// <summary>
        /// Initialize profile data
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="audioBitrate"></param>
        /// <param name="videoBitrate"></param>
        /// <param name="audio"></param>
        /// <param name="video"></param>
        internal WMProfileData(Guid guid, string name, string description, Int32 audioBitrate, Int32 videoBitrate,
                               bool audio, bool video)
        {
            this.guid = guid;
            this.name = name;
            this.description = description;
            this.audioBitrate = audioBitrate;
            this.videoBitrate = videoBitrate;
            this.audio = audio;
            this.video = video;
            enabled = false;
#if DEBUG
            Debug.WriteLine(
                "\"" + guid + "\", \"" + name + "\", \"" + description + "\", " +
                audioBitrate + ", " + videoBitrate + ", " +
                audio + ", " + video + ", enabled=" + enabled);
#endif
        }

        /// <summary>
        /// Name of profile
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if ((value != null) && (value.Length > 0))
                {
                    // In future check whether the name is unique
                    name = value;
                }
            }
        }

        /// <summary>
        /// Guid of profile (might be a null value)
        /// </summary>
        public Guid Guid
        {
            get { return guid; }
        }

        /// <summary>
        /// Description of profile
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        /// Video bit rate value
        /// </summary>
        public Int32 VideoBitrate
        {
            get { return videoBitrate; }
        }

        /// <summary>
        /// Audio bit rate value
        /// </summary>
        public Int32 AudioBitrate
        {
            get { return audioBitrate; }
        }

        /// <summary>
        /// Indicates whether profile supports audio
        /// </summary>
        public bool Audio
        {
            get { return audio; }
        }

        /// <summary>
        /// Indicates whether profile supports video
        /// </summary>
        public bool Video
        {
            get { return video; }
        }

        /// <summary>
        /// Enabled flag
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        /// Filename profile
        /// </summary>
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        /// <summary> Release resources. </summary>
        ~WMProfileData()
        {
            Dispose();
        }

        /// <summary> Release resources. </summary>
        public virtual void Dispose()
        {
            name = null;
            description = null;
            filename = null;
        }
    }
}