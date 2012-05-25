using System;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace Negar.SMSWebService
{
    static class InvokeRequests
    {

        #region Fields

        #region BackgroundWorker BGWorker
        /// <summary>
        /// جهت ارسال درخواست ها و دانلود نتیجه در ریسمان مجزا
        /// </summary>
        public static BackgroundWorker BGWorker;
        #endregion

        #region String _URL
        /// <summary>
        /// قسمت ثابت آدرس وب سرویس
        /// </summary>
        private static String _URL;
        #endregion

        #endregion

        #region Ctor
        /// <summary>
        /// سازنده پیش فرض كلاس 
        /// </summary>
        static InvokeRequests()
        {
            BGWorker = new BackgroundWorker();
            BGWorker.DoWork += (BGWorker_DoWork);
            BGWorker.RunWorkerCompleted += (BGWorker_RunWorkerCompleted);
        }
        #endregion

        #region Boolean SendRequest(String URL)
        /// <summary>
        /// تابع ارسال درخواست به وب سرویس
        /// </summary>
        /// <param name="URL">متن آدرس برقراری ارتباط با وب سرویس</param>
        /// <returns>صحت انجام كار</returns>
        public static Boolean SendRequest(String URL)
        {
            _URL = URL;
            if (!BGWorker.IsBusy) BGWorker.RunWorkerAsync();
            return true;
        }
        #endregion

        #region BGWorker_RunWorkerCompleted
        private static void BGWorker_RunWorkerCompleted
           (Object URL, RunWorkerCompletedEventArgs e)
        {
            //if(e.Cancelled) 
            //_BGWorkerIsBusy = false;
        }
        #endregion

        #region BGWorker_DoWork
        private static void BGWorker_DoWork(Object Sender, DoWorkEventArgs e)
        {
            String ReportString = String.Empty;
            Byte[] ResultData = new Byte[] {};
            WebClient client = new WebClient();

            try{ResultData = client.DownloadData(_URL);}
            #region Catch
            catch (Exception Ex){e.Cancel = true;}
            #endregion

            ReportString = Encoding.ASCII.GetString(ResultData);
            if (!String.IsNullOrEmpty(ReportString))
            {
                #region In Error Cases
                if (ReportString.Contains("ERR:"))
                {
                    String ErrorString = ReportString.Substring(4);
                    switch (ErrorString)
                    {
                        case "User Authentication Failure":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(100, String.Empty);
                            break;
                        case "Invalid Facility":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(101, String.Empty);
                            break;
                        case "Not Enough Credit":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(102, String.Empty);
                            break;
                        case "Null Parameter":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(103, String.Empty);
                            break;
                        case "Body Decoding Error":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(104, String.Empty);
                            break;
                        case "Parameter value is not valid":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(105, String.Empty);
                            break;
                        case "Unexpected Error":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(106, String.Empty);
                            break;
                        case "Too many requests":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(107, String.Empty);
                            break;
                        case "TOO MANY MESSAGES":
                            Sepehr.DBLayerIMS.Messages.InsertMsgLogEvent(100, String.Empty);
                            break;
                    }
                }
                #endregion

                #region Success

                if (ReportString.Contains("--BEGIN") && ReportString.Contains("--END"))
                {
                    if(ReportString.Contains(""))
                }
                #endregion
            }

        }
        #endregion
    }
}
