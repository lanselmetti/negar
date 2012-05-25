using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Negar.PersianCalendar.UI.Drawing
{
    internal class ColorInfo
    {
        public Int32 BtnFaceColorPart, HighlightColorPart, WindowColorPart;
    }

    /// <summary>
    /// كلاس مدیریت رنگ های كنترل ها
    /// </summary>
    internal class Office2007Colors
    {
        #region Fields

        private static ColorInfo colorInfo;
        private static readonly Office2007Colors defaultColors;

        private static readonly Int32[][] Office11Colors =
            new[] { new[] { 0xddecfe, 0x81a9e2, 0x9ebef5, 0xc3daf9, 0x3b619c, 0x274176, 0xFFFFFF, 0x6a8ccb,
            0xf1f9ff, 0x000080, 0xFFF6CF, 0xffd091, 0xfe8e4b, 0xffd28e, 0x000000, 0x8D8D8D, 0x75a6f1,
            0x053995,0xF6F6F6, 0x002d96, 0x2a66c9, 0xc4dbf9,0xbedafb, 0x7ba2e7, 0x6375d6, 0xd6dff7,
            0x215dc6,0x428eff, 0xffffff, 0xc6d3f7, 0xb1b9d8,0xd3d3d3 }, 
            new[] {0xf4f7de, 0xb7c691, 0xd9d9a7, 0xf2f0e4, 0x608058, 0x515e33, 0xFFFFFF, 0x608058,
                0xf4f7de, 0x3f5d38, 0xFFF6CF, 0xffd091, 0xfe8e4b, 0xffd28e, 0x000000, 0x8D8D8D, 0xb0c28c,
                0x60776b, 0xF4F4F4, 0x758d5e, 0x74865e, 0xe1dead, 0xafba91, 0xccd9ad, 0xa5bd84, 0xf6f6ec,
                0x56662d, 0x72921d, 0xfffcec, 0xe0e7b8, 0xcad5be, 0xd3d3d3 },
                new[] { 0xf3f4fa, 0x9997b5, 0xd7d7e5, 0xf3f3f7, 0x7c7c94, 0x545475, 0xFFFFFF, 0x6e6d8f,
                    0xFFFFFF, 0x000080, 0xFFF6CF, 0xffd091, 0xfe8e4b, 0xffd28e, 0x000000, 0x8D8D8D, 0xb3b2c8,
                    0x767492, 0xfdfaff, 0x7c7c94, 0x7a7999, 0xdbdae4, 0xe5e5eb, 0xc4c8d4, 0xb1b3c8, 0xf0f1f5,
                     0x3f3d3d, 0x7e7c7c, 0xffffff, 0xd6d7e0, 0xc4c6d0, 0xd3d3d3 }, };

        private readonly Hashtable colors;
        #endregion

        #region Static & Normal Ctor

        static Office2007Colors()
        {
            defaultColors = new Office2007Colors();
            colorInfo = new ColorInfo();
        }

        public Office2007Colors()
        {
            colors = new Hashtable();
            Init();
        }

        #endregion

        #region Props

        public static Office2007Colors Default
        {
            get { return defaultColors; }
        }

        public Hashtable Colors
        {
            get { return colors; }
        }

        public Color this[Office2007Color color]
        {
            get
            {
                Object val = Colors[color];
                if (val == null) return SystemColors.Control;
                return (Color)val;
            }
        }

        public static Color FlatBarBorderColor
        {
            get
            {
                Color res = SystemColors.ControlDark;
                res = Color.FromArgb(GetDarkValue(res.R), GetDarkValue(res.G), GetDarkValue(res.B));
                return GetRealColor(res);
            }
        }

        public static Color FlatBarBackColor
        {
            get
            {
                Color res = SystemColors.Control;
                res = Color.FromArgb(GetLightValue(res.R), GetLightValue(res.G), GetLightValue(res.B));
                return GetRealColor(res);
            }
        }

        public static Color FlatBarItemPressedBackColor
        {
            get { return GetRealColor(GetLightColor(14, 44, 40)); }
        }

        public static Color FlatBarItemHighLightBackColor
        {
            get { return GetRealColor(GetLightColor(-2, 30, 72)); }
        }

        public static Color FlatBarItemDownedColor
        {
            get { return GetRealColor(GetLightColor(11, 9, 73)); }
        }

        #endregion

        #region Methods

        public static Color FlatTabBackColor
        {
            get
            {
                Color clr = SystemColors.Control;
                Int32 r = clr.R, g = clr.G, b = clr.B;
                Int32 max = Math.Max(Math.Max(r, g), b);
                const Int32 delta = 0x23;

                Int32 maxDelta = (255 - (max + delta));

                if (maxDelta > 0) maxDelta = 0;
                r += (delta + maxDelta);
                g += (delta + maxDelta);
                b += (delta + maxDelta);
                return Color.FromArgb(r, g, b);
            }
        }

        public void Init()
        {
            XPThemeType themeType = GetThemeType();
            if (themeType != XPThemeType.Unknown)
            {
                Int32 id = ((Int32)themeType) - 1;
                InitOfficeColors(id);
            }
            else InitStandardColors();

            colors[Office2007Color.TabPageForeColor] = colors[Office2007Color.Text];
            colors[Office2007Color.TabBackColor1] = colors[Office2007Color.Button1];
            colors[Office2007Color.TabBackColor2] = colors[Office2007Color.Button2];
            colors[Office2007Color.TabPageBackColor1] = colors[Office2007Color.Button1Pressed];
            colors[Office2007Color.TabPageBackColor2] = colors[Office2007Color.Button2Pressed];
            colors[Office2007Color.TabPageBorderColor] = colors[Office2007Color.Border];
        }

        #region public void InitOfficeColors(Int32 id)
        public void InitOfficeColors(Int32 id)
        {
            colors[Office2007Color.Button1] = FromRgb(Office11Colors[id][0]);
            colors[Office2007Color.Button2] = FromRgb(Office11Colors[id][1]);
            colors[Office2007Color.Border] = FromRgb(Office11Colors[id][9]);
            colors[Office2007Color.Button1Hot] = FromRgb(Office11Colors[id][10]);
            colors[Office2007Color.Button2Hot] = FromRgb(Office11Colors[id][11]);
            colors[Office2007Color.Button1Pressed] = FromRgb(Office11Colors[id][12]);
            colors[Office2007Color.Button2Pressed] = FromRgb(Office11Colors[id][13]);
            colors[Office2007Color.Text] = FromRgb(Office11Colors[id][14]);
            colors[Office2007Color.TextDisabled] = FromRgb(Office11Colors[id][15]);
            colors[Office2007Color.GroupRow] = FromRgb(Office11Colors[id][22]);
            colors[Office2007Color.Header] = GetMiddleRGB(this[Office2007Color.Button1], this[Office2007Color.Button2],
                                                          50);
            colors[Office2007Color.Header2] = this[Office2007Color.Button2];
            colors[Office2007Color.Header2] = ControlPaint.Dark(this[Office2007Color.Button2], 0.05f);
            colors[Office2007Color.LinkBorder] = FromRgb(Office11Colors[id][31]);
            colors[Office2007Color.NavBarBackColor1] = FromRgb(Office11Colors[id][23]);
            colors[Office2007Color.NavBarBackColor2] = FromRgb(Office11Colors[id][24]);
            colors[Office2007Color.NavBarGroupClientBackColor] = FromRgb(Office11Colors[id][25]);
            colors[Office2007Color.NavBarLinkTextColor] = FromRgb(Office11Colors[id][26]);
            colors[Office2007Color.NavBarLinkHightlightedTextColor] = FromRgb(Office11Colors[id][27]);
            colors[Office2007Color.NavBarLinkDisabledTextColor] =
                ControlPaint.Light(this[Office2007Color.NavBarLinkHightlightedTextColor], 0.5f);
            colors[Office2007Color.NavBarGroupCaptionBackColor1] = FromRgb(Office11Colors[id][28]);
            colors[Office2007Color.NavBarGroupCaptionBackColor2] = FromRgb(Office11Colors[id][29]);
            colors[Office2007Color.NavBarExpandButtonRoundColor] = FromRgb(Office11Colors[id][30]);
            colors[Office2007Color.NavPaneBorderColor] = ControlPaint.Dark(SystemColors.Highlight, 0.05f);
            colors[Office2007Color.NavBarNavPaneHeaderBackColor] = SystemColors.Highlight;
        }
        #endregion

        #region public virtual void InitStandardColors()
        public virtual void InitStandardColors()
        {
            // رنگ پس زمینه ی دكمه ها
            colors[Office2007Color.Button2] = Color.LightSteelBlue;
            // رنگ پس زمینه دكمه ها در حالت قرار گرفتن موس بر روی آن
            //colors[Office2007Color.Button1Hot] = Color.Yellow;
            colors[Office2007Color.Button2Hot] = Color.Yellow;
            // رنگ حاشیه ها
            colors[Office2007Color.Border] = Color.Navy;
            // پس زمینه تاریخ انتخاب شده
            colors[Office2007Color.Button1Pressed] = colors[Office2007Color.Button2Pressed] = Color.Salmon;
            colors[Office2007Color.Button2Pressed] = colors[Office2007Color.Button2Pressed] = Color.Yellow;
            // رنگ متن دكمه ها
            colors[Office2007Color.Text] = Color.Blue;
            colors[Office2007Color.TextDisabled] = Color.LightGray;
            colors[Office2007Color.Header] = Color.Black;
            colors[Office2007Color.Header2] = Color.Black;
            
            colors[Office2007Color.GroupRow] = Color.Blue;
            colors[Office2007Color.LinkBorder] = Color.Black;
            // نوار حاشیه كنترل انتخاب تاریخ
            colors[Office2007Color.NavBarBackColor1] = Color.LightBlue;
            colors[Office2007Color.NavBarBackColor2] = Color.Blue;

            colors[Office2007Color.NavBarGroupClientBackColor] = Color.Black;
            colors[Office2007Color.NavBarLinkTextColor] = Color.Black;
            colors[Office2007Color.NavBarLinkHightlightedTextColor] = Color.Black;
            colors[Office2007Color.NavBarGroupCaptionBackColor1] = Color.Black;
            colors[Office2007Color.NavBarGroupCaptionBackColor2] = Color.Black;
            colors[Office2007Color.NavBarExpandButtonRoundColor] = Color.Black;
            colors[Office2007Color.NavPaneBorderColor] = Color.Black;
            colors[Office2007Color.NavBarNavPaneHeaderBackColor] = Color.Black;

            if (this[Office2007Color.NavBarLinkTextColor] == Color.FromArgb(0, 0x15, 0x5b))
                colors[Office2007Color.NavBarLinkDisabledTextColor] = Color.Gray;
            else colors[Office2007Color.NavBarLinkDisabledTextColor] = ControlPaint.LightLight(CalcNavColor(-50));
        }
        #endregion

        #region public static XPThemeType GetThemeType()
        public static XPThemeType GetThemeType()
        {
            String themeName = VisualStyleInformation.ColorScheme.ToUpper();
            switch (themeName)
            {
                case "NORMALCOLOR": return XPThemeType.NormalColor;
                case "HOMESTEAD": return XPThemeType.Homestead;
                case "METALLIC": return XPThemeType.Metallic;
                default: return XPThemeType.Unknown;
            }
        }
        #endregion

        public static Color GetLightColor(Int32 btnFaceColorPart, Int32 highlightColorPart, Int32 windowColorPart)
        {
            if (colorInfo == null) colorInfo = new ColorInfo();
            colorInfo.BtnFaceColorPart = btnFaceColorPart;
            colorInfo.HighlightColorPart = highlightColorPart;
            colorInfo.WindowColorPart = windowColorPart;
            Color btnFace = SystemColors.Control, highlight = SystemColors.Highlight, window = SystemColors.Window;
            Color res;
            if (btnFace == Color.White || btnFace == Color.Black) res = highlight;
            else
            {
                res = Color.FromArgb(
                    GetLightIndex(colorInfo, btnFace.R, highlight.R, window.R),
                    GetLightIndex(colorInfo, btnFace.G, highlight.G, window.G),
                    GetLightIndex(colorInfo, btnFace.B, highlight.B, window.B));
            }
            return res;
        }

        public static Int32 GetLightIndex(ColorInfo info, byte btnFaceValue, byte highlightValue, byte windowValue)
        {
            Int32 res = (btnFaceValue * info.BtnFaceColorPart) / 100 +
                (highlightValue * info.HighlightColorPart) / 100 + (windowValue * info.WindowColorPart) / 100;
            if (res < 0) res = 0;
            if (res > 255) res = 255;
            return res;
        }

        public static Int32 GetDarkValue(Int32 val)
        {
            return (val * 8) / 10;
        }

        public static Int32 GetLightValue(byte val)
        {
            return val + ((255 - val) * 16) / 100;
        }

        public static Color GetRealColor(Color clr)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            Color res = g.GetNearestColor(clr);
            g.Dispose();
            return res;
        }

        public static Color OffsetColor(Color clr, Int32 dR, Int32 dG, Int32 dB)
        {
            dR = Math.Min(255, clr.R + dR);
            dG = Math.Min(255, clr.G + dG);
            dB = Math.Min(255, clr.B + dB);
            return Color.FromArgb(dR, dG, dB);
        }

        public static Color FromRgb(Int32 rgb)
        {
            return Color.FromArgb((Int32)(rgb + 0xff000000));
        }

        public static Color CalcNavColor(Int32 d)
        {
            Color clr = SystemColors.Highlight;
            Int32 r = clr.R, g = clr.G, b = clr.B;
            Int32 max = Math.Max(Math.Max(r, g), b);
            Int32 delta = 0x23 + d;

            Int32 maxDelta = (255 - (max + delta));

            if (maxDelta > 0) maxDelta = 0;
            r += (delta + maxDelta + 5);
            g += (delta + maxDelta);
            b += (delta + maxDelta);
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;
            return Color.FromArgb(Math.Abs(r), Math.Abs(g), Math.Abs(b));
        }

        public static Color CalcColor(Color color1, float percent1, Color color2, float percent2)
        {
            return CalcColor(color1, percent1, color2, percent2, Color.Empty, 0f);
        }

        private static Color GetMiddleRGB(Color clr1, Color clr2, Int32 percent)
        {
            Color r = Color.FromArgb(CalcValue(clr1.R, clr2.R, percent), CalcValue(clr1.G, clr2.G, percent),
                CalcValue(clr1.B, clr2.B, percent));
            return r;
        }

        private static Int32 CalcValue(Int32 v1, Int32 v2, Int32 percent)
        {
            Int32 i = (v1 * percent) / 100 + (v2 * (100 - percent)) / 100;
            if (i > 255) i = 255;
            return i;
        }

        public static Color CalcColor(Color color1, float percent1, Color color2, float percent2, Color color3, float percent3)
        {
            percent1 = Math.Max(0, Math.Min(1, percent1));
            percent2 = Math.Max(0, Math.Min(1, percent2));
            percent3 = Math.Max(0, Math.Min(1, percent3));
            Int32 r = (Int32)(color1.R * percent1 + color2.R * percent2 + color3.R * percent3);
            Int32 g = (Int32)(color1.G * percent1 + color2.G * percent2 + color3.G * percent3);
            Int32 b = (Int32)(color1.B * percent1 + color2.B * percent2 + color3.B * percent3);
            r = Math.Min(r, 255);
            g = Math.Min(g, 255);
            b = Math.Min(b, 255);

            return Color.FromArgb(r, g, b);
        }

        #endregion
    }
}