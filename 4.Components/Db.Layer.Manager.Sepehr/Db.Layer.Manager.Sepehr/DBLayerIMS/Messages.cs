using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negar;
using Sepehr.DBLayerIMS.DataLayer;

namespace Sepehr.DBLayerIMS
{
    ///<summary>
    ///</summary>
    public static class Messages
    {
        #region Fields

        #region List<MsgCategories> _MassageCategories
        /// <summary>
        /// لیست طبقه بندی پیام های كوتاه
        /// </summary>
        private static List<MsgCategories> _MassageCategories;
        #endregion

        #region List<MsgStates> _MassageStates
        /// <summary>
        /// لیست وضعیت سیستم ارسال پیام
        /// </summary>
        private static List<MsgStates> _MassageStates;
        #endregion

        #region List<MsgLogCategories> _MassageLogCategories
        /// <summary>
        /// لیست طبقه بندی رخداد های پیام های كوتاه
        /// </summary>
        private static List<MsgLogCategories> _MassageLogCategories;
        #endregion

        #region List<MsgPriorities> _MassagePriorities
        /// <summary>
        /// لیست اولویت های ارسال پیام
        /// </summary>
        private static List<MsgPriorities> _MassagePriorities;
        #endregion

        #endregion

        #region Prop

        #region List<MsgCategories> MassageCategories
        ///<summary>
        /// لیست طبقه بندی پیام های كوتاه
        ///</summary>
        public static List<MsgCategories> MassageCategories
        {
            get
            {
                if (_MassageCategories == null)
                    try { _MassageCategories = Manager.DBML.MsgCategories.ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست طبقه بندی های پیام های كوتاه ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Massages",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _MassageCategories;
            }
            set { _MassageCategories = value; }
        }
        #endregion

        #region List<MsgStates> MassageStates
        ///<summary>
        /// لیست طبقه بندی پیام های كوتاه
        ///</summary>
        public static List<MsgStates> MassageStates
        {
            get
            {
                if (_MassageStates == null)
                    try { _MassageStates = Manager.DBML.MsgStates.ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست وضعیت سیستم ارسال پیام ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Massages",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _MassageStates;
            }
            set { _MassageStates = value; }
        }
        #endregion

        #region List<MsgLogCategories> MassageLogCategories
        ///<summary>
        /// لیست طبقه بندی پیام های كوتاه
        ///</summary>
        public static List<MsgLogCategories> MassageLogCategories
        {
            get
            {
                if (_MassageLogCategories == null)
                    try { _MassageLogCategories = Manager.DBML.MsgLogCategories.ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست طبقه بندی رخداد های پیام های كوتاه ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Massages",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _MassageLogCategories;
            }
            set { _MassageLogCategories = value; }
        }
        #endregion

        #region List<MsgStates> MassageStates
        ///<summary>
        /// لیست طبقه بندی پیام های كوتاه
        ///</summary>
        public static List<MsgPriorities> MassagePriorities
        {
            get
            {
                if (_MassagePriorities == null)
                    try { _MassagePriorities = Manager.DBML.MsgPriorities.ToList(); }
                    #region Catch
                    catch (Exception Ex)
                    {
                        const String ErrorMessage = "خواندن لیست اولویت های ارسال پیام ممكن نیست.\n" +
                            "موارد زیر را بررسی نمایید:\n" +
                            "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                        PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogManager.SaveLogEntry("Sepehr", "DBLayer - Massages",
                            Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                        return null;
                    }
                    #endregion
                return _MassagePriorities;
            }
            set { _MassagePriorities = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region Boolean InsertMessageToMsgList( . . . )
        ///<summary>
        /// تابع افزودن یك پیام كوتاه در سیستم
        ///</summary>
        /// <returns>صحت انجام كار</returns>
        public static Boolean InsertMessageToMsgList(Byte CategoryID, Byte? PriorityID,
            Int32? ReferraID, String Text, Byte? LongMessageCount, String DestinationNumber)
        {
            MsgList Message = new MsgList();
            Message.CategoryIX = CategoryID;
            Message.PriorityIX = PriorityID;
            Message.StateIX = 100;
            Message.RefIX = ReferraID;
            Message.Text = Text;
            Message.DateTime = DateTime.Now;
            Message.LongMessageCount = LongMessageCount;
            Message.DestinationNumber = DestinationNumber;
            Message.StateChangedDateTime = DateTime.Now;
            Message.MessageID = null;
            Manager.DBML.MsgLists.InsertOnSubmit(Message);
            try { Manager.DBML.SubmitChanges(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = " ثبت پیام كوتاه در بانك اطلاعاتی ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Messages",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region Boolean InsertMsgLogEvent(Byte CategoryID, String Description)
        ///<summary>
        /// تابع ثبت رخداد های سیستم پیام كوتاه
        ///</summary>
        ///<returns>صحت انجام كار</returns>
        public static Boolean InsertMsgLogEvent(Byte CategoryID, String Description)
        {
            MsgLogEvents MassageLogEvent = new MsgLogEvents();
            MassageLogEvent.CategoryIX = CategoryID;
            MassageLogEvent.DateTime = DateTime.Now;
            MassageLogEvent.Description = Description;
            Manager.DBML.MsgLogEvents.InsertOnSubmit(MassageLogEvent);
            try { Manager.DBML.SubmitChanges(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = " ثبت رخداد های پیام كوتاه ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Messages",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region List<MsgList> PreparingMsgListForSend()
        ///<summary>
        /// تابع آماده سازی لیست پیام ها جهت ارسال
        ///</summary>
        ///<returns>لیست پیام ها - در صورت بروز خطا مقدار تهی</returns>
        public static List<MsgList> PreparingMsgListForSend()
        {
            List<MsgList> ResultList = new List<MsgList>();
            List<MsgList> MessagesList = new List<MsgList>();
            Byte MessageCount = 0;
            try
            {
                MessagesList =
                    Manager.DBML.MsgLists.Where(Data => Data.StateIX == 100).
                    OrderByDescending(Data => Data.PriorityIX).OrderBy(Data => Data.ID).ToList();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, MessagesList);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = " خواندن لیست پیام های كوتاه ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Messages",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error);
                return null;
            }
            #endregion
            foreach (MsgList Message in MessagesList)
            {
                if (Message.LongMessageCount == null) MessageCount++;
                else MessageCount += (Byte)Message.LongMessageCount;
                if (MessageCount > 50) break;
                ResultList.Add(Message);
            }
            return ResultList;
        }
        #endregion

        #region List<Int32> PreparingMsgListForCheckDelivery()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<MsgList> PreparingMsgListForCheckDelivery()
        {
            List<MsgList> ResultList = new List<MsgList>();
            List<MsgList> MessagesList = new List<MsgList>();
            Byte MessageCount = 0;
            try
            {
                MessagesList = Manager.DBML.MsgLists.Where(Data =>
                      (Data.StateIX == 103 && Data.StateChangedDateTime < DateTime.Now.AddMinutes(-5))
                   || (Data.StateIX == 104 && Data.StateChangedDateTime < DateTime.Now.AddMinutes(-10))
                   || (Data.StateIX == 105 && Data.StateChangedDateTime < DateTime.Now.AddMinutes(-45))
                   || (Data.StateIX == 106 && Data.StateChangedDateTime < DateTime.Now.AddHours(-4))
                   || (Data.StateIX == 107 && Data.StateChangedDateTime < DateTime.Now.AddHours(-5))).
                   OrderBy(Data => Data.StateChangedDateTime).Take(50).ToList();
                Manager.DBML.Refresh(RefreshMode.OverwriteCurrentValues, MessagesList);
            }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = " خواندن لیست پیام های كوتاه ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Messages",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return null;
            }
            #endregion
            foreach (MsgList Message in MessagesList)
            {
                if (Message.LongMessageCount == null) MessageCount++;
                else MessageCount += (Byte)Message.LongMessageCount;
                if (MessageCount > 50) break;
                ResultList.Add(Message);
            }
            return ResultList;
        }
        #endregion

        #region Boolean UpdateMassagesStates(List<Int32> MessageIDList,Byte StateID)
        ///<summary>
        /// تابع بروز رسانی وضعیت پیام ها
        ///</summary>
        ///<returns>صحت انجام كار</returns>
        public static Boolean UpdateMassagesStates(List<Int32> MessageIDList, Byte StateID)
        {
            StringBuilder Command = new StringBuilder();
            Command.Append("UPDATE [ImagingSystem].[Messages].[List]");
            Command.Append(" SET [StateIX] = " + StateID);
            Command.Append(" , [StateChangedDateTime] = " + DateTime.Now);
            Command.Append(" WHERE [ID] IN (");
            foreach (Int32 ID in MessageIDList) Command.Append(ID + ",");
            Command.Remove(Command.Length - 1, 1);
            Command.Append(")");
            return Manager.ExecuteCommand(Command.ToString(), 5);
        }
        #endregion

        #region Boolean DeleteMessageByID(Int64 ID)
        ///<summary>
        /// تابع حذف پیام كوتاه با شناسه پیام كوتاه
        ///</summary>
        ///<returns>صحت انجام كار</returns>
        public static Boolean DeleteMessageByID(Int64 ID)
        {
            MsgList MsgToDelete = Manager.DBML.MsgLists.Where(Data => Data.ID == ID).First();
            Manager.DBML.MsgLists.DeleteOnSubmit(MsgToDelete);
            try { Manager.DBML.SubmitChanges(); }
            #region Catch
            catch (Exception Ex)
            {
                const String ErrorMessage = " حذف پیام كوتاه از بانك اطلاعاتی ممكن نیست.\n" +
                    "موارد زیر را بررسی نمایید:\n" +
                    "1. آیا ارتباط شما با بانك اطلاعات برقرار است و شبكه متصل می باشد؟";
                PMBox.Show(ErrorMessage, "خطا!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.SaveLogEntry("Sepehr", "DBLayer - Messages",
                    Ex.Message + "\n" + Ex.StackTrace, EventLogEntryType.Error); return false;
            }
            #endregion
            return true;
        }
        #endregion

        #endregion

    }
}
