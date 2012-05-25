#Region "Imports"

Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Text

#End Region

''' <summary>
''' كلاس نمایش جعبه پیام فارسی 
''' </summary>
''' <remarks>شركت رایان پرتونگار</remarks>
Public Class PMBox

#Region "Class Declaration"

#Region "API Fields & Functions"

#Region "Fields"
    Private Delegate Function CallBack_WinProc(ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Delegate Function CallBack_EnumWinProc(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer
#End Region

#Region "Functions"

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowLong(ByVal hwnd As Integer, _
         ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function GetCurrentThreadId() As Integer
    End Function

    <DllImport("user32.dll")> Private Shared Function SetWindowsHookEx( _
    ByVal idHook As Integer, ByVal lpfn As CallBack_WinProc, ByVal hmod As Integer, _
    ByVal dwThreadId As Integer) As Integer
    End Function

    <DllImport("user32.dll")> Private Shared Function UnhookWindowsHookEx( _
        ByVal hHook As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> Private Shared Function _
    SetWindowText(ByVal hwnd As Integer, ByVal lpString As String) As Integer
    End Function

    <DllImport("user32.dll")> Private Shared Function EnumChildWindows( _
        ByVal hWndParent As Integer, ByVal lpEnumFunc As CallBack_EnumWinProc, _
        ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetClassName(ByVal hwnd As Integer, _
        ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

#End Region

#End Region

#Region "Fields"

    Shared TopCount As Integer
    Shared ButtonCount As Integer

    Private Const GWL_HINSTANCE As Integer = (-6)
    Private Const HCBT_ACTIVATE As Integer = 5
    Private Const WH_CBT As Integer = 5

    Private Shared hHook As Integer

    Shared strCaption1 As String = ""
    Shared strCaption2 As String = ""
    Shared strCaption3 As String = ""

#End Region

#Region "Methods"

#Region "Public Shared Function Show(ByVal Text As String) As DialogResult"
    ''' <summary>
    ''' تابع نمایش جعبه پیام فارسی
    ''' </summary>
    ''' <param name="Text">متن جعبه پیام</param>
    ''' <returns>نتیجه انتخابی كاربر</returns>
    ''' <remarks>بازنویسی شده برای كلاس جعبه متن مایكروسافت</remarks>
    Public Shared Function Show(ByVal Text As String) As DialogResult
        Show(Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Function

#End Region

#Region "Public Shared Function Show(...) As DialogResult"
    ''' <summary>
    ''' تابع نمایش جعبه پیام فارسی
    ''' </summary>
    ''' <param name="Text">متن جعبه پیام</param>
    ''' <param name="Title">تیتر جعبه پیام</param>
    ''' <returns>نتیجه انتخابی كاربر</returns>
    ''' <remarks>بازنویسی شده برای كلاس جعبه متن مایكروسافت</remarks>
    Public Shared Function Show(ByVal Text As String, ByVal Title As String) As DialogResult
        Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information, _
            MessageBoxDefaultButton.Button1)
    End Function
#End Region

#Region "Public Shared Function Show(...) As DialogResult"
    ''' <summary>
    ''' تابع نمایش جعبه پیام فارسی
    ''' </summary>
    ''' <param name="Text">متن جعبه پیام</param>
    ''' <param name="Title">تیتر جعبه پیام</param>
    ''' <param name="ButtonsType">نوع و تعداد دكمه های جعبه پیام</param>
    ''' <returns>نتیجه انتخابی كاربر</returns>
    ''' <remarks>بازنویسی شده برای كلاس جعبه متن مایكروسافت</remarks>
    Public Shared Function Show(ByVal Text As String, ByVal Title As String, _
    ByVal ButtonsType As MessageBoxButtons) As DialogResult
        Show(Text, Title, ButtonsType, MessageBoxIcon.Information, _
            MessageBoxDefaultButton.Button1)
    End Function
#End Region

#Region "Public Shared Function Show(...) As DialogResult"
    ''' <summary>
    ''' تابع نمایش جعبه پیام فارسی
    ''' </summary>
    ''' <param name="Text">متن جعبه پیام</param>
    ''' <param name="Title">تیتر جعبه پیام</param>
    ''' <param name="ButtonsType">نوع و تعداد دكمه های جعبه پیام</param>
    ''' <param name="IconType">نوع آیكون جعبه پیام</param>
    ''' <returns>نتیجه انتخابی كاربر</returns>
    ''' <remarks>بازنویسی شده برای كلاس جعبه متن مایكروسافت</remarks>
    Public Shared Function Show(ByVal Text As String, ByVal Title As String, _
    ByVal ButtonsType As MessageBoxButtons, _
    ByVal IconType As MessageBoxIcon) As DialogResult
        Show(Text, Title, ButtonsType, IconType, MessageBoxDefaultButton.Button1)
    End Function
#End Region

#Region "Public Shared Function Show(Full)"
    ''' <summary>
    ''' تابع نمایش جعبه پیام فارسی
    ''' </summary>
    ''' <param name="Text">متن جعبه پیام</param>
    ''' <param name="Title">تیتر جعبه پیام</param>
    ''' <param name="ButtonsType">نوع و تعداد دكمه های جعبه پیام</param>
    ''' <param name="IconType">نوع آیكون جعبه پیام</param>
    ''' <param name="DefaultButton">دكمه پیش فرض</param>
    ''' <returns>نتیجه انتخابی كاربر</returns>
    ''' <remarks>بازنویسی شده برای كلاس جعبه متن مایكروسافت</remarks>
    Public Shared Function Show( _
    ByVal Text As String, _
    ByVal Title As String, _
    ByVal ButtonsType As MessageBoxButtons, _
    ByVal IconType As MessageBoxIcon, _
    ByVal DefaultButton As MessageBoxDefaultButton) As DialogResult

        Dim ReadingOptions As MessageBoxOptions = MessageBoxOptions.RtlReading
        Dim MsgStyle As MsgBoxStyle = MsgBoxStyle.OkOnly
        Dim hParent As Integer = 0
        Dim IntWindowLenght As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0

        ' ############ "بررسی نوع دكمه ها" #############
        Select Case ButtonsType
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
                MsgStyle = MsgBoxStyle.OkOnly
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
                MsgStyle = MsgBoxStyle.OkCancel
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
                MsgStyle = MsgBoxStyle.RetryCancel
            Case MessageBoxButtons.YesNo
                strCaption1 = "بلی"
                strCaption2 = "خیر"
                MsgStyle = MsgBoxStyle.YesNo
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بلی"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
                MsgStyle = MsgBoxStyle.YesNoCancel
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
                MsgStyle = MsgBoxStyle.AbortRetryIgnore
        End Select
        ' ############ "اتمام بررسی نوع دكمه ها" #############

        If Title = String.Empty Then Title = Application.ProductName

        Dim MsgBoxIconType As MsgBoxStyle = IconType
        Dim MsgDefaultButton As MsgBoxStyle = DefaultButton
        Dim MsgReadingOptions As MsgBoxStyle = ReadingOptions

        Dim MyWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)

        IntWindowLenght = GetWindowLong(hParent, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, MyWndProc, IntWindowLenght, Thread)

        Dim MyMsgBox As MsgBoxStyle = _
            MsgBoxIconType + MsgDefaultButton + _
            MsgBoxStyle.MsgBoxRight + MsgReadingOptions + MsgStyle

        Return MsgBox(Text, MyMsgBox, Title)
    End Function

#End Region

#Region "Private Shared Function WinProc"

    Private Shared Function WinProc(ByVal uMsg As Integer, ByVal wParam As Integer, _
    ByVal lParam As Integer) As Integer
        Dim myEnumProc As CallBack_EnumWinProc = _
        New CallBack_EnumWinProc(AddressOf EnumWinProc)
        If uMsg = HCBT_ACTIVATE Then
            EnumChildWindows(wParam, myEnumProc, 0)
            UnhookWindowsHookEx(hHook)
        End If
        Return 0
    End Function

#End Region

#Region "Private Shared Function EnumWinProc"

    Private Shared Function EnumWinProc(ByVal hWnd As Integer, _
        ByVal lParam As Integer) As Integer

        Dim strBuffer As StringBuilder = New StringBuilder(256)
        TopCount += 1
        GetClassName(hWnd, strBuffer, strBuffer.Capacity)
        Dim ss As String = strBuffer.ToString()
        If (ss.ToUpper().StartsWith("BUTTON")) Then
            ButtonCount += 1
            Select Case ButtonCount
                Case 1
                    SetWindowText(hWnd, strCaption1)
                    Exit Select
                Case 2
                    SetWindowText(hWnd, strCaption2)
                    Exit Select
                Case 3
                    SetWindowText(hWnd, strCaption3)
                    Exit Select
            End Select
        End If
        Return 1

    End Function

#End Region

#End Region

#End Region

End Class