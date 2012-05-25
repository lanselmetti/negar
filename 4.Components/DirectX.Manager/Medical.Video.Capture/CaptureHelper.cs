#region using
using System;
using System.IO;

#endregion

namespace Negar.Medical.VideoCapture
{
    /// <summary>
    /// ابزاری برای كار با كلاس كپچر
    /// </summary>
    public static class CaptureHelper
    {

        #region Fields

        #region String TempFilesPath
        public const String TempFilesPath = "C:\\NegarCaptureFiles";
        #endregion

        #region frmPanelGraber _PanelGraber
        private static frmPanelGraber _PanelGraber;
        #endregion

        #region frmPanelClip _PanelClip
        private static frmPanelClip _PanelClip;
        #endregion

        #region frmPanelClipGraber _PanelGraberClip
        private static frmPanelClipGraber _PanelGraberClip;
        #endregion

        #endregion

        #region Methods

        #region Boolean ShowCaptureForm(Int32 RefID)
        public static Boolean ShowCaptureForm(Int32 RefID)
        {
            _PanelGraber = new frmPanelGraber(RefID);
            if (_PanelGraber.IsDisposed) { _PanelGraber = null; return false; }
            _PanelGraber.ShowDialog();
            _PanelGraber = null;
            return true;
        }
        #endregion

        #region Boolean ShowClipForm(Int32 RefID)
        public static Boolean ShowClipForm(Int32 RefID)
        {
            _PanelClip = new frmPanelClip(RefID);
            if (_PanelClip.IsDisposed) { _PanelClip = null; return false; }
            _PanelClip.ShowDialog();
            _PanelClip = null;
            return true;
        }
        #endregion

        #region Boolean ShowCaptureClipForm(Int32 RefID)
        public static Boolean ShowCaptureClipForm(Int32 RefID)
        {
            _PanelGraberClip = new frmPanelClipGraber(RefID);
            if (_PanelGraberClip.IsDisposed) { _PanelGraberClip = null; return false; }
            _PanelGraberClip.ShowDialog();
            _PanelGraberClip = null;
            return true;
        }
        #endregion

        #region void ReleaseCachedData()
        public static void ReleaseCachedData()
        {
            _PanelGraber = null;
            _PanelClip = null;
            _PanelGraberClip = null;
        }
        #endregion

        #region Boolean CheckCaptureDataFilesFolder()
        /// <summary>
        /// تابعی برای بررسی وجود پوشه ریشه برای ذخیره سازی اطلاعات
        /// </summary>
        /// <returns>وجود و ساخته شدن پوشه</returns>
        public static Boolean CheckCaptureDataFilesFolder()
        {
            try { if (!Directory.Exists(TempFilesPath)) Directory.CreateDirectory(TempFilesPath); }
            catch { return false; }
            return true;
        }
        #endregion

        #region Boolean CheckCaptureRefDataFilesFolder(Int32 RefID)
        /// <summary>
        /// تابعی برای بررسی وجود پوشه ریشه برای ذخیره سازی اطلاعات
        /// </summary>
        /// <returns>وجود و ساخته شدن پوشه</returns>
        public static Boolean CheckCaptureRefDataFilesFolder(Int32 RefID)
        {
            if (!CheckCaptureDataFilesFolder()) return false;
            try
            {
                if (!Directory.Exists(TempFilesPath + "\\" + RefID))
                    Directory.CreateDirectory(TempFilesPath + "\\" + RefID);
            }
            catch { return false; }
            return true;
        }
        #endregion

        #region String GetRefDataFilesFolder(Int32 RefID)
        /// <summary>
        /// تابعی برای خواندن آدرس پوشه ی فایل های یك مراجعه
        /// </summary>
        public static String GetRefDataFilesFolder(Int32 RefID)
        {
            if (!CheckCaptureRefDataFilesFolder(RefID)) return String.Empty;
            return TempFilesPath + "\\" + RefID;
        }
        #endregion

        #region String GetVideoRefDataFilesFolderAndFile(Int32 RefID)
        /// <summary>
        /// تابعی برای تولید پوشه و فایل ثبت Capture
        /// </summary>
        public static String GetVideoRefDataFilesFolderAndFile(Int32 RefID)
        {
            if (!CheckCaptureRefDataFilesFolder(RefID)) return String.Empty;
            return TempFilesPath + "\\" + RefID + "\\" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".Wmv";
        }
        #endregion

        #region String[] GetRefDataFilesList(Int32 RefID, String Pattern)
        /// <summary>
        /// تابعی برای خواندن لیست فایل های پوشه ی فایل های یك مراجعه
        /// </summary>
        public static String[] GetRefDataFilesList(Int32 RefID, String Pattern)
        {
            if (!CheckCaptureRefDataFilesFolder(RefID)) return null;
            return Directory.GetFiles(GetRefDataFilesFolder(RefID), Pattern, SearchOption.TopDirectoryOnly);
        }
        #endregion

        #endregion

    }
}