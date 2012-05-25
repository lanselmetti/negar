#region using
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using Negar;
using Microsoft.Win32;
#endregion

namespace Negar.Medical.VideoCapture
{

    #region SerialPortManager : IDisposable
    /// <summary>
    /// Manager for serial port data
    /// </summary>
    public class SerialPortManager : IDisposable
    {

        #region Fields

        #region SerialPort _SerialPort
        private SerialPort _SerialPort;
        #endregion

        #region Timer _CheckingTimer
        private Timer _CheckingTimer;
        #endregion

        #region DateTime _RecTime
        private DateTime _RecTime = new DateTime(2010, 01, 01, 0, 0, 0, 0);
        #endregion

        #region event EventHandler<SerialDataEventArgs> NewSerialDataRecieved
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;
        #endregion

        #region String _NegarCaptureCOMPortSetting
        /// <summary>
        /// كلید ذخیره سازی اطلاعات كام پورت برای كاربر جاری در رجیستری
        /// </summary>
        private const String _NegarCaptureCOMPortSetting = "Software\\Negar\\NegarCaptureCOMPortSetting";
        #endregion

        #region String _LastCOMPortName
        /// <summary>
        /// نام ذخیره سازی آخرین نام كام پورت متصل شده در رجیستری
        /// </summary>
        private const String _LastCOMPortName = "COMPortName";
        #endregion

        #endregion

        #region Ctor & Dtor
        public SerialPortManager()
        {
            _CheckingTimer = new Timer(_TimerCallback, null, 0, 100);
            if (!StartListening()) return;
        }
        ~SerialPortManager()
        {
            _CheckingTimer.Dispose();
            _CheckingTimer = null;
            Dispose(false);
        }
        #endregion

        #region Event handlers

        #region SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = _SerialPort.BytesToRead;
            Byte[] data = new Byte[dataLength];
            _SerialPort.ReadTimeout = 50;
            int nbrDataRead = 0;
            try { nbrDataRead = _SerialPort.Read(data, 0, dataLength); }
            #region catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "Serial Port Manager - Reading From COM Port", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
            if (nbrDataRead == 0) return;
            TimeSpan x = DateTime.Now - _RecTime;
            if (x.TotalMilliseconds >= 1000)
            {
                // Send data to whom ever interested
                if (NewSerialDataRecieved != null)
                    NewSerialDataRecieved(this, new SerialDataEventArgs(data));
                _RecTime = DateTime.Now;
            }
            else return;
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean StartListening()
        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public Boolean StartListening()
        {
            // Closing serial port if it is open
            if (_SerialPort != null && _SerialPort.IsOpen) _SerialPort.Close();

            // Setting serial port settings
            _SerialPort = new SerialPort(LoadSavedCOMPort(), 4800, Parity.None, 8, StopBits.One);

            // Subscribe to event and open serial port for data
            _SerialPort.DataReceived += (SerialPortDataReceived);
            try
            {
                _SerialPort.Open();
            }
            #region catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "Serial Port Manager - Opening COM Port", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region _TimerCallback(object state)
        /// <summary>
        /// This Methods Call in Timer Tick
        /// </summary>
        private void _TimerCallback(object state)
        {
            SendData();
        }
        #endregion

        #region String LoadSavedCOMPort()
        /// <summary>
        /// خواندن نام كامپورت ذخیره شده از رجیستری
        /// </summary>
        /// <returns>COM Prot Name</returns>
        /// <remarks>Return COM1 By Default</remarks>
        public String LoadSavedCOMPort()
        {
            String ReturnValue = String.Empty;
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_NegarCaptureCOMPortSetting, true);
                if (MyKey == null) return "COM1";
                ReturnValue = MyKey.GetValue(_LastCOMPortName, String.Empty).ToString();
            }
            catch (Exception) { return ReturnValue; }
            return ReturnValue;
        }
        #endregion

        #region Boolean SaveLastSettingsToReg()
        /// <summary>
        /// ذخیره سازی نام كامپورت مورد نظر در رجیستری
        /// </summary>
        /// <returns>صحت انجام</returns>
        public Boolean SaveLastSettingsToReg(String COMPortName)
        {
            try
            {
                RegistryKey MyKey = Registry.CurrentUser.OpenSubKey(_NegarCaptureCOMPortSetting, true);
                if (MyKey == null)
                {
                    Registry.CurrentUser.CreateSubKey(_NegarCaptureCOMPortSetting);
                    MyKey = Registry.CurrentUser.OpenSubKey(_NegarCaptureCOMPortSetting, true);
                }
                // ReSharper restore PossibleNullReferenceException
                if (MyKey != null) MyKey.SetValue(_LastCOMPortName, COMPortName, RegistryValueKind.String);
            }
            catch (Exception) { return false; }
            return true;
        }
        #endregion

        #region void SendData()
        /// <summary>
        /// Sending Data In Binary Mode
        /// </summary>
        public void SendData()
        {
            try
            {
                if (_SerialPort != null && _SerialPort.IsOpen)
                    _SerialPort.Write("1");
            }
            #region catch
            catch (Exception Ex)
            {
                LogManager.SaveLogEntry("Negar", "Serial Port Manager - Writing To COM Port", Ex.Message + "\n" +
                    Ex.StackTrace, EventLogEntryType.Error);
            }
            #endregion
        }
        #endregion

        #region void Dispose()
        /// <summary>
        /// Call to release serial port
        /// </summary>
        public void Dispose() { Dispose(true); }
        #endregion

        #region virtual void Dispose(bool disposing)
        /// <summary>
        /// Part of basic design pattern for implementing Dispose
        /// </summary>
        /// <param name="disposing">Disposing Mode</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _SerialPort.DataReceived -= (SerialPortDataReceived);
            // Releasing serial port (and other unmanaged objects)
            if (_SerialPort != null)
            {
                if (_SerialPort.IsOpen) _SerialPort.Close();
                _SerialPort.Dispose();
            }
        }
        #endregion

        #endregion

    }
    #endregion

    #region SerialDataEventArgs : EventArgs
    /// <summary>
    /// EventArgs used to send bytes recieved on serial port
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        public Byte[] Data;

        public SerialDataEventArgs(Byte[] DataInByteArray)
        {
            Data = DataInByteArray;
        }
    }
    #endregion

}