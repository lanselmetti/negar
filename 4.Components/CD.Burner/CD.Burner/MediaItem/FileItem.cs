#region using
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using IMAPI2.Interop;
#endregion

namespace IMAPI2.MediaItem
{
    /// <summary>
    /// 
    /// </summary>
    public class FileItem : IMediaItem
    {
        private const Int64 SECTOR_SIZE = 2048;

        private readonly Int64 m_fileLength;

        public FileItem(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The file added to FileItem was not found!", path);
            }

            filePath = path;

            FileInfo fileInfo = new FileInfo(filePath);
            displayName = fileInfo.Name;
            m_fileLength = fileInfo.Length;

            // Get the File icon
            SHFILEINFO shinfo = new SHFILEINFO();
            Win32.SHGetFileInfo(filePath, 0, ref shinfo,
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
        public Int64 SizeOnDisc
        {
            get
            {
                if (m_fileLength > 0)
                {
                    return ((m_fileLength / SECTOR_SIZE) + 1) * SECTOR_SIZE;
                }

                return 0;
            }
        }

        public string Path
        {
            get
            {
                return filePath;
            }
        }
        private readonly string filePath;

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
        public override string ToString()
        {
            return displayName;
        }
        private readonly string displayName;

        public bool AddToFileSystem(IFsiDirectoryItem rootItem)
        {
            IStream stream = null;

            try
            {
                Win32.SHCreateStreamOnFile(filePath, Win32.STGM_READ | Win32.STGM_SHARE_DENY_WRITE, ref stream);

                if (stream != null)
                {
                    rootItem.AddFile(displayName, stream);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (stream != null)
                {
                    Marshal.FinalReleaseComObject(stream);
                }
            }

            return false;
        }
    }
}
