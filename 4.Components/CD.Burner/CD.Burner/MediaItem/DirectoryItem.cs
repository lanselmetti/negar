#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IMAPI2.Interop;
#endregion

namespace IMAPI2.MediaItem
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectoryItem : IMediaItem
    {
        private readonly List<IMediaItem> mediaItems = new List<IMediaItem>();

        public DirectoryItem(String directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                throw new FileNotFoundException("The directory added to DirectoryItem was not found!", directoryPath);

            m_directoryPath = directoryPath;
            FileInfo fileInfo = new FileInfo(m_directoryPath);
            displayName = fileInfo.Name;
            // Get all the files in the directory
            string[] files = Directory.GetFiles(m_directoryPath);
            foreach (String file in files) mediaItems.Add(new FileItem(file));
            
            // Get all the subdirectories
            string[] directories = Directory.GetDirectories(m_directoryPath);
            foreach (string directory in directories)
                mediaItems.Add(new DirectoryItem(directory));

            // Get the Directory icon
            SHFILEINFO shinfo = new SHFILEINFO();
            Win32.SHGetFileInfo(m_directoryPath, 0, ref shinfo,
                (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);

            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            if (shinfo.hIcon != null)
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
            {
                //The icon is returned in the hIcon member of the shinfo struct
                System.Drawing.IconConverter imageConverter = new System.Drawing.IconConverter();
                System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                try
                {
                    fileIconImage = (System.Drawing.Image)
                        imageConverter.ConvertTo(icon, typeof(System.Drawing.Image));
                }
                catch (NotSupportedException)
                {
                }

                Win32.DestroyIcon(shinfo.hIcon);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get
            {
                return m_directoryPath;
            }
        }
        private readonly string m_directoryPath;

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return displayName;
        }
        private readonly string displayName;

        /// <summary>
        /// 
        /// </summary>
        public Int64 SizeOnDisc
        {
            get
            {
                Int64 totalSize = 0;
                foreach (IMediaItem mediaItem in mediaItems)
                {
                    totalSize += mediaItem.SizeOnDisc;
                }
                return totalSize;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Drawing.Image FileIconImage
        {
            get
            {
                return fileIconImage;
            }
        }
        private readonly System.Drawing.Image fileIconImage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootItem"></param>
        /// <returns></returns>
        public bool AddToFileSystem(IFsiDirectoryItem rootItem)
        {
            try
            {
                rootItem.AddTree(m_directoryPath, true);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding folder",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
