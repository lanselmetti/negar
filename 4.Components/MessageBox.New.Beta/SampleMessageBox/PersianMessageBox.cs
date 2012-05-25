#region using
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

/// <summary>
/// كلاس مدیریت جعبه پیام فارسی
/// </summary>
public class PMBox : Form
{

    #region Enums

    #region PMBoxButton enum
    public enum PMBoxButton
    {
        AbortRetryIgnore,
        OK,
        OKCancel,
        RetryCancel,
        YesNo,
        YesNoCancel
    }
    #endregion

    #region MessageIcon enum
    public enum MessageIcon
    {
        Error,
        Explorer,
        Find,
        Information,
        Mail,
        Media,
        Print,
        Question,
        RecycleBinEmpty,
        RecycleBinFull,
        Stop,
        User,
        Warning
    }
    #endregion

    #endregion

    #region Fields

    #region PMBox _MBoxInstance
    private static PMBox _MBoxInstance;
    #endregion

    #region API Fields
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern Boolean MessageBeep(UInt32 type);

    [DllImport("Shell32.dll")]
    public static extern Int32 ExtractIconEx(String libName, Int32 iconIndex,
        IntPtr[] largeIcon, IntPtr[] smallIcon, Int32 nIcons);
    #endregion

    #region Buttons
    private static Button _btnAbort;
    private static Button _btnCancel;
    private static Button _btnIgnore;
    private static Button _btnNo;
    private static Button _btnOK;
    private static Button _btnRetry;
    private static Button _btnYes;
    #endregion

    #region MBox Objects
    private static Label _MBoxMessage;
    private static Label _MBoxTitle;
    private static Icon _MBoxIcon;
    private static PictureBox _MBoxPicture;
    private static DialogResult _MessageBoxResult;
    #endregion
    
    private static FlowLayoutPanel _flpButtons;
    private static IntPtr[] _SmallIcon;
    private static IntPtr[] _LargeIcon;
    
    #endregion

    #region Methods

    #region DialogResult Show(String Message)
    /// <summary>
    /// تابع نمای جعبه متن فارسی یا دكمه تایید و نمایش پیغام خطا
    /// </summary>
    /// <param name="Message">متن پیام</param>
    /// <returns>نتیجه انتخاب شده توسط كاربر</returns>
    public static DialogResult Show(String Message)
    {
        BuildMessageBox();
        _MBoxMessage.Text = Message;
        ShowOKButton();
        SetIconStatement(MessageIcon.Error);
        _MBoxInstance.ShowDialog();
        return _MessageBoxResult;
    }
    #endregion

    #region DialogResult Show(String Message, String Title)
    /// <summary>
    /// Title: Text to display in the title bar of the messagebox.
    /// </summary>
    public static DialogResult Show(String Message, String Title)
    {
        BuildMessageBox();
        _MBoxTitle.Text = Title;
        _MBoxMessage.Text = Message;
        ShowOKButton();

        _MBoxInstance.ShowDialog();
        return _MessageBoxResult;
    }
    #endregion

    #region DialogResult Show(String Message, String Title, PMBoxButton MButtons)
    /// <summary>
    /// Buttons: Display PMBoxButton on the message box.
    /// </summary>
    public static DialogResult Show(String Message, String Title, PMBoxButton Buttons)
    {
        BuildMessageBox(); // BuildMessageBox method, responsible for creating the MessageBox
        _MBoxTitle.Text = Title; // Set the title of the MessageBox
        _MBoxMessage.Text = Message; //Set the text of the MessageBox
        ButtonStatements(Buttons); // ButtonStatements method is responsible for showing the appropreiate buttons
        _MBoxInstance.ShowDialog(); // Show the MessageBox as a Dialog.
        return _MessageBoxResult; // Return the button click as an Enumerator
    }
    #endregion

    #region DialogResult Show(String Message, String Title, PMBoxButton Buttons, MessageIcon MIcon)
    /// <summary>
    /// MIcon: Display MessageIcon on the message box.
    /// </summary>
    public static DialogResult Show(String Message, String Title, PMBoxButton Buttons, MessageIcon MIcon)
    {
        BuildMessageBox();
        _MBoxTitle.Text = Title;
        _MBoxMessage.Text = Message;
        ButtonStatements(Buttons);
        SetIconStatement(MIcon);
        Image imageIcon = new Bitmap(_MBoxIcon.ToBitmap(), 38, 38);
        _MBoxPicture.Image = imageIcon;
        _MBoxInstance.RightToLeft = RightToLeft.Yes;
        _MBoxInstance.ShowDialog();
        return _MessageBoxResult;
    }

    #endregion

    #region MyRegion

    #endregion

    #region private static void BuildMessageBox()
    private static void BuildMessageBox()
    {
        _MBoxInstance = new PMBox();
        _MBoxInstance.Text = String.Empty;
        _MBoxInstance.Size = new Size(400, 200);
        _MBoxInstance.StartPosition = FormStartPosition.CenterScreen;
        _MBoxInstance.FormBorderStyle = FormBorderStyle.None;
        _MBoxInstance.Paint += newMessageBox_Paint;
        _MBoxInstance.BackColor = Color.White;

        var tlp = new TableLayoutPanel();
        tlp.RowCount = 3;
        tlp.ColumnCount = 0;
        tlp.Dock = DockStyle.Fill;
        tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
        tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
        tlp.BackColor = Color.Transparent;
        tlp.Padding = new Padding(2, 5, 2, 2);

        _MBoxTitle = new Label();
        _MBoxTitle.Dock = DockStyle.Fill;
        _MBoxTitle.BackColor = Color.Transparent;
        _MBoxTitle.ForeColor = Color.White;
        _MBoxTitle.Font = new Font("Tahoma", 9, FontStyle.Bold);

        _MBoxMessage = new Label();
        _MBoxMessage.Dock = DockStyle.Fill;
        _MBoxMessage.BackColor = Color.White;
        _MBoxMessage.Font = new Font("Tahoma", 9, FontStyle.Regular);

        _LargeIcon = new IntPtr[250];
        _SmallIcon = new IntPtr[250];
        _MBoxPicture = new PictureBox();
        ExtractIconEx("shell32.dll", 0, _LargeIcon, _SmallIcon, 250);

        _flpButtons = new FlowLayoutPanel();
        _flpButtons.FlowDirection = FlowDirection.RightToLeft;
        _flpButtons.Padding = new Padding(0, 5, 5, 0);
        _flpButtons.Dock = DockStyle.Fill;
        _flpButtons.BackColor = Color.FromArgb(240, 240, 240);

        var tlpMessagePanel = new TableLayoutPanel();
        tlpMessagePanel.BackColor = Color.White;
        tlpMessagePanel.Dock = DockStyle.Fill;
        tlpMessagePanel.ColumnCount = 2;
        tlpMessagePanel.RowCount = 0;
        tlpMessagePanel.Padding = new Padding(4, 5, 4, 4);
        tlpMessagePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
        tlpMessagePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpMessagePanel.Controls.Add(_MBoxPicture);
        tlpMessagePanel.Controls.Add(_MBoxMessage);

        tlp.Controls.Add(_MBoxTitle);
        tlp.Controls.Add(tlpMessagePanel);
        tlp.Controls.Add(_flpButtons);
        _MBoxInstance.Controls.Add(tlp);
    }
    #endregion

    #endregion


    



    private static void btnOK_Click(object sender, EventArgs e)
    {
        _MessageBoxResult = DialogResult.OK;
        _MBoxInstance.Dispose();
    }

    private static void btnAbort_Click(object sender, EventArgs e)
    {
        _MessageBoxResult = DialogResult.Abort;
        _MBoxInstance.Dispose();
    }

    private static void btnRetry_Click(object sender, EventArgs e)
    {
        _MessageBoxResult = DialogResult.Retry;
        _MBoxInstance.Dispose();
    }

    private static void btnIgnore_Click(object sender, EventArgs e)
    {
        _MessageBoxResult = DialogResult.Ignore;
        _MBoxInstance.Dispose();
    }

    private static void btnCancel_Click(object sender, EventArgs e)
    {
        _MessageBoxResult = DialogResult.Cancel;
        _MBoxInstance.Dispose();
    }

    private static void btnYes_Click(object sender, EventArgs e)
    {
        _MessageBoxResult = DialogResult.Yes;
        _MBoxInstance.Dispose();
    }

    private static void btnNo_Click(object sender, EventArgs e)
    {
        _MessageBoxResult = DialogResult.No;
        _MBoxInstance.Dispose();
    }

    private static void ShowOKButton()
    {
        _btnOK = new Button();
        _btnOK.Text = "OK";
        _btnOK.Size = new Size(80, 25);
        _btnOK.BackColor = Color.FromArgb(255, 255, 255);
        _btnOK.Font = new Font("Tahoma", 8, FontStyle.Regular);
        _btnOK.Click += btnOK_Click;
        _flpButtons.Controls.Add(_btnOK);
    }

    private static void ShowAbortButton()
    {
        _btnAbort = new Button();
        _btnAbort.Text = "Abort";
        _btnAbort.Size = new Size(80, 25);
        _btnAbort.BackColor = Color.FromArgb(255, 255, 255);
        _btnAbort.Font = new Font("Tahoma", 8, FontStyle.Regular);
        _btnAbort.Click += btnAbort_Click;
        _flpButtons.Controls.Add(_btnAbort);
    }

    private static void ShowRetryButton()
    {
        _btnRetry = new Button();
        _btnRetry.Text = "Retry";
        _btnRetry.Size = new Size(80, 25);
        _btnRetry.BackColor = Color.FromArgb(255, 255, 255);
        _btnRetry.Font = new Font("Tahoma", 8, FontStyle.Regular);
        _btnRetry.Click += btnRetry_Click;
        _flpButtons.Controls.Add(_btnRetry);
    }

    private static void ShowIgnoreButton()
    {
        _btnIgnore = new Button();
        _btnIgnore.Text = "Ignore";
        _btnIgnore.Size = new Size(80, 25);
        _btnIgnore.BackColor = Color.FromArgb(255, 255, 255);
        _btnIgnore.Font = new Font("Tahoma", 8, FontStyle.Regular);
        _btnIgnore.Click += btnIgnore_Click;
        _flpButtons.Controls.Add(_btnIgnore);
    }

    private static void ShowCancelButton()
    {
        _btnCancel = new Button();
        _btnCancel.Text = "Cancel";
        _btnCancel.Size = new Size(80, 25);
        _btnCancel.BackColor = Color.FromArgb(255, 255, 255);
        _btnCancel.Font = new Font("Tahoma", 8, FontStyle.Regular);
        _btnCancel.Click += btnCancel_Click;
        _flpButtons.Controls.Add(_btnCancel);
    }

    private static void ShowYesButton()
    {
        _btnYes = new Button();
        _btnYes.Text = "Yes";
        _btnYes.Size = new Size(80, 25);
        _btnYes.BackColor = Color.FromArgb(255, 255, 255);
        _btnYes.Font = new Font("Tahoma", 8, FontStyle.Regular);
        _btnYes.Click += btnYes_Click;
        _flpButtons.Controls.Add(_btnYes);
    }

    private static void ShowNoButton()
    {
        _btnNo = new Button();
        _btnNo.Text = "No";
        _btnNo.Size = new Size(80, 25);
        _btnNo.BackColor = Color.FromArgb(255, 255, 255);
        _btnNo.Font = new Font("Tahoma", 8, FontStyle.Regular);
        _btnNo.Click += btnNo_Click;
        _flpButtons.Controls.Add(_btnNo);
    }

    private static void ButtonStatements(PMBoxButton MButtons)
    {
        if (MButtons == PMBoxButton.AbortRetryIgnore)
        {
            ShowIgnoreButton();
            ShowRetryButton();
            ShowAbortButton();
        }

        if (MButtons == PMBoxButton.OK)
        {
            ShowOKButton();
        }

        if (MButtons == PMBoxButton.OKCancel)
        {
            ShowCancelButton();
            ShowOKButton();
        }

        if (MButtons == PMBoxButton.RetryCancel)
        {
            ShowCancelButton();
            ShowRetryButton();
        }

        if (MButtons == PMBoxButton.YesNo)
        {
            ShowNoButton();
            ShowYesButton();
        }

        if (MButtons == PMBoxButton.YesNoCancel)
        {
            ShowCancelButton();
            ShowNoButton();
            ShowYesButton();
        }
    }

    private static void SetIconStatement(MessageIcon MIcon)
    {
        if (MIcon == MessageIcon.Error)
        {
            MessageBeep(30);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[109]);
        }

        if (MIcon == MessageIcon.Explorer)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[220]);
        }

        if (MIcon == MessageIcon.Find)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[22]);
        }

        if (MIcon == MessageIcon.Information)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[221]);
        }

        if (MIcon == MessageIcon.Mail)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[156]);
        }

        if (MIcon == MessageIcon.Media)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[116]);
        }

        if (MIcon == MessageIcon.Print)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[136]);
        }

        if (MIcon == MessageIcon.Question)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[23]);
        }

        if (MIcon == MessageIcon.RecycleBinEmpty)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[31]);
        }

        if (MIcon == MessageIcon.RecycleBinFull)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[32]);
        }

        if (MIcon == MessageIcon.Stop)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[27]);
        }

        if (MIcon == MessageIcon.User)
        {
            MessageBeep(0);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[170]);
        }

        if (MIcon == MessageIcon.Warning)
        {
            MessageBeep(30);
            _MBoxIcon = Icon.FromHandle(_LargeIcon[217]);
        }
    }

    private static void newMessageBox_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        var frmTitleL = new Rectangle(0, 0, (_MBoxInstance.Width/2), 22);
        var frmTitleR = new Rectangle((_MBoxInstance.Width/2), 0, (_MBoxInstance.Width/2), 22);
        var frmMessageBox = new Rectangle(0, 0, (_MBoxInstance.Width - 1), (_MBoxInstance.Height - 1));
        var frmLGBL = new LinearGradientBrush(frmTitleL, Color.FromArgb(87, 148, 160), Color.FromArgb(209, 230, 243),
                                              LinearGradientMode.Horizontal);
        var frmLGBR = new LinearGradientBrush(frmTitleR, Color.FromArgb(209, 230, 243), Color.FromArgb(87, 148, 160),
                                              LinearGradientMode.Horizontal);
        var frmPen = new Pen(Color.FromArgb(63, 119, 143), 1);
        g.FillRectangle(frmLGBL, frmTitleL);
        g.FillRectangle(frmLGBR, frmTitleR);
        g.DrawRectangle(frmPen, frmMessageBox);
    }
}