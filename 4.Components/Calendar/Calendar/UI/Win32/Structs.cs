using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Negar.PersianCalendar.UI.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct LOGFONT
    {
        public Int32 lfHeight;
        public Int32 lfWidth;
        public Int32 lfEscapement;
        public Int32 lfOrientation;
        public Int32 lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public String lfFaceSize;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct NONCLIENTMETRICS
    {
        public Int32 cbSize;
        public Int32 iBorderWidth;
        public Int32 iScrollWidth;
        public Int32 iScrollHeight;
        public Int32 iCaptionWidth;
        public Int32 iCaptionHeight;
        public LOGFONT lfCaptionFont;
        public Int32 iSmCaptionWidth;
        public Int32 iSmCaptionHeight;
        public LOGFONT lfSmCaptionFont;
        public Int32 iMenuWidth;
        public Int32 iMenuHeight;
        public LOGFONT lfMenuFont;
        public LOGFONT lfStatusFont;
        public LOGFONT lfMessageFont;
    }

    /// <summary>
    /// Carries information used to load common control classes from the 
    /// dynamic-link library (DLL). This structure is used with the 
    /// InitCommonControlsEx function. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class INITCOMMONCONTROLSEX
    {
        public Int32 dwSize;
        public Int32 dwICC;

        public INITCOMMONCONTROLSEX()
        {
            dwSize = 8;
        }

        public INITCOMMONCONTROLSEX(Int32 icc) : this()
        {
            dwICC = icc;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MSG
    {
        public IntPtr hwnd;
        public Int32 message;
        public IntPtr wParam;
        public IntPtr lParam;
        public Int32 time;
        public Int32 pt_x;
        public Int32 pt_y;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public Int32 fErase;
        public Rectangle rcPaint;
        public Int32 fRestore;
        public Int32 fIncUpdate;
        public Int32 Reserved1;
        public Int32 Reserved2;
        public Int32 Reserved3;
        public Int32 Reserved4;
        public Int32 Reserved5;
        public Int32 Reserved6;
        public Int32 Reserved7;
        public Int32 Reserved8;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public Int32 left;
        public Int32 top;
        public Int32 right;
        public Int32 bottom;

        public override String ToString()
        {
            return "{left=" + left + ", " + "top=" + top + ", " +
                   "right=" + right + ", " + "bottom=" + bottom + "}";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public Int32 x;
        public Int32 y;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SIZE
    {
        public Int32 cx;
        public Int32 cy;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TRACKMOUSEEVENTS
    {
        public const uint TME_HOVER = 0x00000001;
        public const uint TME_LEAVE = 0x00000002;
        public const uint TME_NONCLIENT = 0x00000010;
        public const uint TME_QUERY = 0x40000000;
        public const uint TME_CANCEL = 0x80000000;
        public const uint HOVER_DEFAULT = 0xFFFFFFFF;

        public uint dwFlags;
        public IntPtr hWnd;
        public uint dwHoverTime;
        public uint cbSize;

        public TRACKMOUSEEVENTS(uint dwFlags, IntPtr hWnd, uint dwHoverTime)
        {
            cbSize = 16;
            this.dwFlags = dwFlags;
            this.hWnd = hWnd;
            this.dwHoverTime = dwHoverTime;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct LOGBRUSH
    {
        public uint lbStyle;
        public uint lbColor;
        public long lbHatch;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NCCALCSIZE_PARAMS
    {
        public RECT rgrc1;
        public RECT rgrc2;
        public RECT rgrc3;
        public IntPtr lppos;
    }
}