using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.NetworkInformation;
using Sepehr.DBLayerIMS.DataLayer;
using Timer = System.Windows.Forms.Timer;


namespace Negar.SMSWebService
{
    public static class Manager
    {
        #region Fields

        #region String _UserName
        /// <summary>
        /// شناسه كاربری استفاده از وب سرویس شركت آتیه داده پرداز
        /// این شناسه برای هر یك از مشتریان ما منحصر به فرد می باشد
        /// </summary>
        private static String _UserName;
        #endregion

        #region String _Password
        /// <summary>
        /// كلمه عبور استفاده از وب سرویس شركت آتیه داده پرداز
        /// این كلمه عبور برای هر یك از مشتریان ما منحصر به فرد می باشد
        /// </summary>
        private static String _Password;
        #endregion

        #region String _ConstURL
        /// <summary>
        /// قسمت ثابت آدرس وب سرویس
        /// </summary>
        private const String _ConstURL = @"http://ws2.adpdigital.com/url/";
        #endregion

        #region Boolean _ClassIsBusy
        ///// <summary>
        ///// 
        ///// </summary>
        //private static Boolean _ClassIsBusy;
        #endregion

        #region Timer _Timer
        /// <summary>
        /// شیء تایمر جهت برانگیختن تابع اصلی اجرای دستورات
        /// </summary>
        private static Timer _Timer;
        #endregion

        #region SystemState _SystemState
        /// <summary>
        /// شیء نگهدارنده وضعیت فعلی سیستم
        /// </summary>
        private static SystemState _SystemState;
        #endregion

        #endregion

        #region Props & Enums

        #region  String Username
        /// <summary>
        /// شناسه كاربری استفاده از وب سرویس
        /// </summary>
        public static String Username
        {
            set { _UserName = value; }
        }
        #endregion

        #region String Password
        /// <summary>
        /// كلمه عبور استفاده از وب سرویس
        /// </summary>
        public static String Password { set { _Password = value; } }
        #endregion

        public static SystemState SysState { get; set; }

        #region enum SystemState
        /// <summary>
        /// نگهدارنده وضعیت های مختلف سیستم
        /// </summary>
        public enum SystemState
        {
            Send,
            CheckDelivery,
            Recieve,
            CheckBalance,
        }
        #endregion

        #endregion

        #region Ctors
        ///// <summary>
        ///// 
        ///// </summary>
        //static Manager()
        //{

        //}
        #endregion

        #region Methods

        #region Timer_Tick
        /// <summary>
        /// تابع مدیریت رخداد اجرای تیك تایمر
        /// </summary>
        private static void Timer_Tick(object state, EventArgs eventArgs)
        {
            #region Sending Mode
            // هنگامی كه سیستم در وضعیت ارسال قرار دارد
            if (_SystemState == SystemState.Send)
            {
                if (InvokeRequests.BGWorker.IsBusy) return;
                String SendMsg = SendMessage();
                // xsdsd
                if (!String.IsNullOrEmpty(SendMsg)){InvokeRequests.SendRequest(SendMsg);}
                _SystemState = SystemState.CheckDelivery;
                return;
            }
            #endregion

            #region Cheking Delivery Reports
            // هنگامی كه سیستم در وضعیت چك كردن دلیوری می باشد
            if (_SystemState == SystemState.CheckDelivery)
            {
                if (InvokeRequests.BGWorker.IsBusy) return;
                String ChkDelivery = CheckDelivery();
                if (!String.IsNullOrEmpty(ChkDelivery)){InvokeRequests.SendRequest(ChkDelivery);}
                _SystemState = SystemState.Send;
                return;
            }
            #endregion

            #region Revieving Mode
            // دریافت پیام های خوانده نشده
            //if (_SystemState == SystemState.Recieve)
            //{
            //    if (InvokeRequests.BGWorkerIsBusy) return;
            //    InvokeRequests.SendRequest(SendMessage(CreateMsgList()));
            //    _SystemState = SystemState.Send;
            //    return;
            //}
            #endregion

            #region Check Balance
            // چك كردن میزان اعتبار باقی مانده
            //if (_SystemState == SystemState.CheckBalance)
            //{
            //    if (InvokeRequests.BGWorkerIsBusy) return;
            //    InvokeRequests.SendRequest(SendMessage(CreateMsgList()));
            //    _SystemState = SystemState.Send;
            //    return;
            //}
            #endregion
        }
        #endregion

        #region String SendMessage()
        /// <summary>
        /// تابع ارسال چندین پیام به چندین شماره مختلف
        /// </summary>
        /// <returns>آدرس مورد نیاز جهت ارسال پیام - در صورت بروز خطا رشته خالی باز گردانده می شود</returns>
        public static String SendMessage()
        {
           List<MsgList> MessageList =  Sepehr.DBLayerIMS.Messages.PreparingMsgListForSend();
           if (MessageList == null || MessageList.Count == 0) return String.Empty;
            StringBuilder URL = new StringBuilder();
            //تعیین كننده نوع درخواست از وب سرویس
            URL.Append(_ConstURL + "multisend?");
            // تأیید هویت ارتباط با وب سرویس
            URL.Append("username=" + _UserName);
            URL.Append("&password=" + _Password);
            for (int i = 0; i < MessageList.Count; i++)
            {
                // افزودن آدرس های مقصد
                URL.Append("&dstaddress" + i + "=" + MessageList[i].DestinationNumber);
                // افزودن متن پیام كوتاه
                URL.Append("&body" + i + "=" + MessageList[i].Text);
                // افزودن شناسه پیام كوتاه
                URL.Append("&clientid" + i + "=" + MessageList[i].ID);
                // تعیین فارسی بودن پیام
                URL.Append("&unicode" + i + "=1");
            }
            return URL.ToString();
        }
        #endregion

        #region String CheckDelivery
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String CheckDelivery()
        {
            List<MsgList> MessageList = Sepehr.DBLayerIMS.Messages.PreparingMsgListForCheckDelivery();
            if (MessageList == null || MessageList.Count == 0) return String.Empty;
            StringBuilder URL = new StringBuilder();
            //تعیین كننده نوع درخواست از وب سرویس
            URL.Append(_ConstURL + "multisend?");
            // تأیید هویت ارتباط با وب سرویس
            URL.Append("username=" + _UserName);
            URL.Append("&password=" + _Password);
            for (int i = 0; i < MessageList.Count; i++)
            {
                // افزودن آدرس های مقصد
                URL.Append("&dstaddress" + i + "=" + MessageList[i].DestinationNumber);
                // افزودن متن پیام كوتاه
                URL.Append("&body" + i + "=" + MessageList[i].Text);
                // افزودن شناسه پیام كوتاه
                URL.Append("&clientid" + i + "=" + MessageList[i].ID);
                // تعیین فارسی بودن پیام
                URL.Append("&unicode" + i + "=1");
            }
            return URL.ToString();
        }
        #endregion

        #region Boolean TestInternetConnection()
        /// <summary>
        /// تابع چك كردن امكان برقراری ارتباط با اینترنت
        /// </summary>
        /// <returns>در صورت اتصال به اینترنت مقدار صحیح باز می گرداند</returns>
        public static Boolean TestInternetConnection()
        {
            Ping ping = new Ping();
            PingReply PingStatus = ping.Send(IPAddress.Parse("4.2.2.4"), 1000);
            if (PingStatus.Status == IPStatus.Success) return true;
            return false;
        }
        #endregion

        #region  Boolean TimerStart()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean TimerStart()
        {
            _SystemState = SystemState.Send;
            _Timer = new Timer();
            _Timer.Interval = 1000;
            _Timer.Tick += (Timer_Tick);
            _Timer.Start();
            return true;
        }
        #endregion

        #endregion

        #region  Boolean TimerStop()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean TimerStop()
        {
            if(_Timer != null)
            {
                _Timer.Tick -= (Timer_Tick);
                _Timer.Stop();
            }
            return true;
        }
        #endregion

        #region NOT USED

        //http://ws2.adpdigital.com/url/statusReport?username=parto&password=parto49164&shortNumber=200049164&type=clientId&id=10003

        #region String SendOneMsgToOneNum(Message Message)
        ///// <summary>
        ///// تابع ارسال یك پیام به یك شماره خاص
        ///// </summary>
        ///// <param name="Message"></param>
        ///// <returns>آدرس مورد نیاز جهت ارسال درخواست</returns>
        //public static String SendOneMsgToOneNum(Message Message)
        //{
        //    StringBuilder URL = new StringBuilder();
        //    //تعیین كننده نوع درخواست از وب سرویس
        //    URL.Append(_ConstURL + "send?");
        //    // تأیید هویت ارتباط با وب سرویس
        //    URL.Append("username=" + _UserName);
        //    URL.Append("&password=" + _Password);
        //    // افزودن آدرس های مقصد
        //    URL.Append("&dstaddress=" + Message.DestinationNumber);
        //    // افزودن متن پیام كوتاه
        //    URL.Append("&body=" + Message.TextBody);
        //    // افزودن شناسه پیام كوتاه
        //    URL.Append("&clientid=" + Message.MessageID);
        //    // تعیین فارسی بودن پیام
        //    URL.Append("&unicode=1");
        //    return URL.ToString();
        //}
        #endregion

        #region SendOneMsgToManyNum(String[] DestinationNumber,String BodyText, Int32[] MessageID)
        ///// <summary>
        ///// تابع ارسال یك پیام به چندین شماره مختلف
        ///// </summary>
        ///// <param name="DestinationNumber">مجموعه شماره های مقصد</param>
        ///// <param name="BodyText">متن پیام كوتاه ارسالی</param>
        ///// <param name="MessageID">شناسه پیام كوتاه ارسالی</param>
        ///// <returns>آدرس مورد نیاز جهت ارسال درخواست</returns>
        //public static String SendOneMsgToManyNum(String[] DestinationNumber,
        //    String BodyText, Int32[] MessageID)
        //{
        //    StringBuilder URL = new StringBuilder();
        //    //تعیین كننده نوع درخواست از وب سرویس
        //    URL.Append(_ConstURL + "send?");
        //    // تأیید هویت ارتباط با وب سرویس
        //    URL.Append("username=" + _UserName);
        //    URL.Append("&password=" + _Password);
        //    // افزودن آدرس های مقصد
        //    URL.Append("&dstaddress=");
        //    foreach (String Number in DestinationNumber)
        //        URL.Append(Number + ",");
        //    URL.Remove(URL.Length - 1, 1);
        //    // افزودن متن پیام كوتاه
        //    URL.Append("&body=" + BodyText);
        //    // افزودن شناسه پیام كوتاه
        //    URL.Append("&clientid=");
        //    foreach (Int32 Number in MessageID)
        //        URL.Append(Number + ",");
        //    URL.Remove(URL.Length - 1, 1);
        //    // تعیین فارسی بودن پیام
        //    URL.Append("&unicode=1");
        //    return URL.ToString();
        //}
        #endregion

        #region class Message
        ///// <summary>
        ///// كلاس پیام كوتاه
        ///// </summary>
        //public class Message
        //{
        //    /// <summary>
        //    /// شماره مقصد
        //    /// </summary>
        //    public Int32 MessageID { get; set; }
        //    /// <summary>
        //    /// متن پیام كوتاه ارسالی
        //    /// </summary>
        //    public String DestinationNumber { get; set; }
        //    /// <summary>
        //    /// شناسه پیام كوتاه ارسالی
        //    /// </summary>
        //    public String TextBody { get; set; }
        //}
        #endregion

        #endregion

    }
}
