#region using

using System;
using System.Globalization;

#endregion

namespace Negar.PersianCalendar.Resource
{
    /// <summary>
    /// كلاس مدیریت فرهنگ های انتخابی
    /// </summary>
    public class PersianLocalizeManager
    {
        #region Ctor

        /// <summary>
        /// سازنده پیش فرض مخفی
        /// </summary>
        private PersianLocalizeManager()
        {
        }

        #endregion

        #region Fields

        #region Private Fields

        #region CultureInfo _FarsiCulture

        /// <summary>
        /// فرهنگ فارسی
        /// </summary>
        private static readonly CultureInfo _FarsiCulture = new CultureInfo("fa-IR");

        #endregion

        #region CultureInfo _ArabicCulture

        /// <summary>
        /// فرهنگ عربی
        /// </summary>
        private static readonly CultureInfo _ArabicCulture = new CultureInfo("ar-SA");

        #endregion

        #region CultureInfo _EnglishCulture

        /// <summary>
        /// فرهنگ انگلیسی
        /// </summary>
        private static readonly CultureInfo _EnglishCulture = CultureInfo.InvariantCulture;

        #endregion

        #region CultureInfo _CustomCulture

        /// <summary>
        /// فرهنگ انتخابی
        /// </summary>
        private static CultureInfo _CustomCulture;

        #endregion

        private static readonly ARLocalizer _ARLocalizer = new ARLocalizer();
        private static readonly ENLocalizer _ENLocalizer = new ENLocalizer();
        private static readonly FALocalizer _FALocalizer = new FALocalizer();
        private static BaseLocalizer _CustomLocalizer;

        #endregion

        #region Public Fields

        /// <summary>
        /// مدیریت كننده رخداد تغییر فرهنگ
        /// </summary>
        public static event EventHandler LocalizerChanged;

        #endregion

        #endregion

        #region Methods

        #region public static BaseLocalizer GetLocalizerByCulture(CultureInfo ci)

        /// <summary>
        /// نمونه ای از فرهنگ پایه ارسال شده بر مبنای فرهنگ درخواستی باز می گرداند
        /// </summary>
        /// <param name="ci">نوع فرهنگ</param>
        /// <returns>فرهنگ پایه تغییر یافته</returns>
        public static BaseLocalizer GetLocalizerByCulture(CultureInfo ci)
        {
            if (_CustomLocalizer != null) return _CustomLocalizer;
            if (ci.Equals(_FarsiCulture)) return _FALocalizer;
            if (ci.Equals(_ArabicCulture)) return _ARLocalizer;
            return _ENLocalizer;
        }

        #endregion

        #region protected static void OnLocalizerChanged(EventArgs e)

        /// <summary>
        /// مدیریت كننده رخداد تغییر فرهنگ
        /// </summary>
        /// <param name="e">شی ء رخداد</param>
        protected static void OnLocalizerChanged(EventArgs e)
        {
            if (LocalizerChanged != null) LocalizerChanged(null, e);
        }

        #endregion

        #endregion

        #region Properties

        #region static CultureInfo CustomCulture

        /// <summary>
        /// تنظیم خصوصیت فرهنگ انتخابی
        /// </summary>
        public static CultureInfo CustomCulture
        {
            get { return _CustomCulture; }
            set { _CustomCulture = value; }
        }

        #endregion

        #region static CultureInfo FarsiCulture

        /// <summary>
        /// فرهنگ فارسی
        /// </summary>
        public static CultureInfo FarsiCulture
        {
            get { return _FarsiCulture; }
        }

        #endregion

        #region static CultureInfo ArabicCulture

        /// <summary>
        /// فرهنگ عربی
        /// </summary>
        public static CultureInfo ArabicCulture
        {
            get { return _ArabicCulture; }
        }

        #endregion

        #region static CultureInfo InvariantCulture

        /// <summary>
        /// فرهنگ انگلیسی
        /// </summary>
        public static CultureInfo InvariantCulture
        {
            get { return _EnglishCulture; }
        }

        #endregion

        #region static BaseLocalizer CustomLocalizer

        /// <summary>
        /// تنظیم یا بازگرداندن نمونه جدید از كلاس فرهنگ محلی. 
        ///  اگر این خصوصیت مقداردهی نشود مقدار پیش فرض ندارد. 
        /// اما اگر مقدار دهی گردد مقدار فرهنگ انتخابی را باز می گرداند
        /// </summary>
        public static BaseLocalizer CustomLocalizer
        {
            get { return _CustomLocalizer; }
            set
            {
                if (_CustomLocalizer == value)
                    return;
                _CustomLocalizer = value;
                OnLocalizerChanged(EventArgs.Empty);
            }
        }

        #endregion

        #endregion
    }
}