#region using
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
#endregion

namespace Sepehr.Forms.Reports.Designables.Design
{

    #region internal class NegarSyntaxHighlighter : System.Windows.Forms.RichTextBox
    /// <summary>
    /// كلاسي براي كامپايل و تغيير رنگ كلمات كليدي
    /// </summary>
    internal class NegarSyntaxHighlighter : System.Windows.Forms.RichTextBox
    {

        #region Fields
        private readonly SyntaxSettings _SyntaxSettings;
        private static bool _CanPaint;
        private string _LineString;
        private int _LineLength;
        private int _LineStart;
        private int _LineEnd;
        private string _KeywordsString;
        #endregion

        #region Ctor
        /// <summary>
        /// كلاسي براي كامپايل و تغيير رنگ كلمات كليدي يك جعبه متن
        /// </summary>
        public NegarSyntaxHighlighter()
        {
            _SyntaxSettings = new SyntaxSettings();
            _CanPaint = true;
            _LineString = String.Empty;
            _LineLength = 0;
            _LineStart = 0;
            _LineEnd = 0;
            _KeywordsString = String.Empty;
        }
        #endregion

        #region Properties

        #region public SyntaxSettings CompilerSettings
        /// <summary>
        /// تنظيمات مربوط به كامپايلر
        /// </summary>
        [Browsable(false)]
        public SyntaxSettings CompilerSettings
        {
            get { return _SyntaxSettings; }
        }
        #endregion

        #endregion

        #region Events

        #region protected void OnTextChanged Event

        /// <summary>
        /// رخداد باز نویسی شده ی زمان تغییر متن
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            // Calculate shit here:
            int CurrentSelectionStart = SelectionStart;

            _CanPaint = false;

            // Find the start of the current line:
            _LineStart = CurrentSelectionStart;
            while ((_LineStart > 0) && (Text[_LineStart - 1] != '\n'))
                _LineStart--;

            // Find the end of the current line:
            _LineEnd = CurrentSelectionStart;
            while ((_LineEnd < Text.Length) && (Text[_LineEnd] != '\n'))
                _LineEnd++;

            // Calculate the length of the line:
            _LineLength = _LineEnd - _LineStart;

            // Get the current line.
            _LineString = Text.Substring(_LineStart, _LineLength);

            // Process this line:
            ProcessLine();

            _CanPaint = true;
        }

        #endregion

        #region protected override void WndProc

        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="TheMessage"></param>
        protected override void WndProc(ref System.Windows.Forms.Message TheMessage)
        {
            if (TheMessage.Msg == 0x00f)
            {
                if (_CanPaint)
                    base.WndProc(ref TheMessage);
                else
                    TheMessage.Result = IntPtr.Zero;
            }
            else
                base.WndProc(ref TheMessage);
        }

        #endregion

        #endregion

        #region Methods

        #region Private

        #region private void ProcessLine

        /// <summary>
        /// روال بررسی یك خط
        /// </summary>
        private void ProcessLine()
        {
            // Save the position and make the whole line black
            int nPosition = SelectionStart;
            SelectionStart = _LineStart;
            SelectionLength = _LineLength;
            SelectionColor = Color.Black;

            // Process the keywords
            ProcessRegex(_KeywordsString, CompilerSettings.KeywordColor);
            // Process numbers
            if (CompilerSettings.EnableIntegers)
                ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", CompilerSettings.IntegerColor);
            // Process strings
            if (CompilerSettings.EnableStrings)
                ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", CompilerSettings.StringColor);
            // Process comments
            if (CompilerSettings.EnableComments && !string.IsNullOrEmpty(CompilerSettings.Comment))
                ProcessRegex(CompilerSettings.Comment + ".*$", CompilerSettings.CommentColor);

            SelectionStart = nPosition;
            SelectionLength = 0;
            SelectionColor = Color.Black;

        }

        #endregion

        #region private void ProcessRegex

        /// <summary>
        /// روال بررسی كلمات و حروف
        /// </summary>
        /// <param name="RegexString">The regular Expression.</param>
        /// <param name="color">The color.</param>
        private void ProcessRegex(String RegexString, Color color)
        {
            Regex regKeywords =
                new Regex(RegexString, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match MatchRegex;

            for (MatchRegex = regKeywords.Match(_LineString);
                 MatchRegex.Success;
                 MatchRegex = MatchRegex.NextMatch())
            {
                // Process the words
                int nStart = _LineStart + MatchRegex.Index;
                int nLenght = MatchRegex.Length;
                SelectionStart = nStart;
                SelectionLength = nLenght;
                SelectionColor = color;
            }
        }

        #endregion

        #endregion

        #region Public

        #region public void CompileKeywords

        /// <summary>
        /// كامپايل كلمات كليدي به صورت لغت به لغت
        /// </summary>
        public void CompileKeywords()
        {
            for (int i = 0; i < CompilerSettings.Keywords.Count; i++)
            {
                string strKeyword = CompilerSettings.Keywords[i];

                if (i == CompilerSettings.Keywords.Count - 1)
                    _KeywordsString += "\\b" + strKeyword + "\\b";
                else
                    _KeywordsString += "\\b" + strKeyword + "\\b|";
            }
        }

        #endregion

        #region public void ProcessAllLines

        /// <summary>
        /// بررسي خطوط موجود در جعبه متن
        /// </summary>
        public void ProcessAllLines()
        {
            _CanPaint = false;

            int nStartPos = 0;
            int i = 0;
            while (i < Lines.Length)
            {
                _LineString = Lines[i];
                _LineStart = nStartPos;
                _LineEnd = _LineStart + _LineString.Length;

                ProcessLine();
                i++;

                nStartPos += _LineString.Length + 1;
            }

            _CanPaint = true;
        }

        #endregion

        #endregion

        #endregion

    }
    #endregion

    #region internal class SyntaxList
    /// <summary>
    /// كلاسي براي ذخيره سازي ليست كلمات كليدي
    /// </summary>
    internal class SyntaxList
    {
        private List<String> _RegexList = new List<String>();

        public List<String> RegexList
        {
            get { return _RegexList; }
            set { _RegexList = value; }
        }

        public Color TheColor { get; set; }
    }
    #endregion

    #region internal class SyntaxSettings
    /// <summary>
    /// كلاس تنظيمات كامپايلر
    /// </summary>
    internal class SyntaxSettings
    {
        #region Fields
        private readonly SyntaxList _SyntaxList;
        #endregion

        #region Ctor
        public SyntaxSettings()
        {
            _SyntaxList = new SyntaxList();
            Comment = String.Empty;
            CommentColor = Color.Green;
            StringColor = Color.Green;
            IntegerColor = Color.Red;
            EnableComments = true;
            EnableIntegers = true;
            EnableStrings = true;
        }
        #endregion

        #region Properties

        #region public List<string> Keywords

        /// <summary>
        /// لیست كلمات كلیدی اضافه شده
        /// </summary>
        public List<String> Keywords
        {
            get { return _SyntaxList.RegexList; }
        }

        #endregion

        #region public Color KeywordColor

        /// <summary>
        /// رنگ كلمات كلیدی
        /// </summary>
        public Color KeywordColor
        {
            get { return _SyntaxList.TheColor; }
            set { _SyntaxList.TheColor = value; }
        }

        #endregion

        #region public String Comment

        /// <summary>
        /// تعیین كاراكتر توضیحات برای كامپایلر
        /// </summary>
        public String Comment { get; set; }

        #endregion

        #region public Color CommentColor

        /// <summary>
        /// رنگ كاراكتر های توضیحات
        /// </summary>
        public Color CommentColor { get; set; }

        #endregion

        #region public bool EnableComments

        /// <summary>
        /// تعیین فعال یا غیر فعال بودن توضیحات
        /// </summary>
        public bool EnableComments { get; set; }

        #endregion

        #region public bool EnableIntegers

        /// <summary>
        /// فعال بودن كامپایل اعداد
        /// </summary>
        public bool EnableIntegers { get; set; }

        #endregion

        #region public bool EnableStrings

        /// <summary>
        /// فعال بودن كامپایل رشته ها
        /// </summary>
        public bool EnableStrings { get; set; }

        #endregion

        #region public Color StringColor

        /// <summary>
        /// رنگ رشته ها
        /// </summary>
        public Color StringColor { get; set; }

        #endregion

        #region public Color IntegerColor

        /// <summary>
        /// رنگ اعداد
        /// </summary>
        public Color IntegerColor { get; set; }

        #endregion

        #endregion
    }
    #endregion

}