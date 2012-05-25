#region using
using System;
using System.Windows.Forms;
#endregion

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // ReSharper disable PossibleNullReferenceException

        #region Fields

        #region Int32 _InsertDataProgress
        /// <summary>
        /// مرحله ی جاری برای ثبت اطلاعات در فرم وب
        /// </summary>
        private Int32 _InsertDataProgress;
        #endregion

        #endregion

        #region Ctor
        public Form1()
        {
            InitializeComponent();
            WB.StatusTextChanged += WB_StatusTextChanged;
        }
        #endregion

        #region WB_StatusTextChanged
        void WB_StatusTextChanged(object sender, EventArgs e)
        {
            textBox1.Text = WB.StatusText;
        }
        #endregion

        #region btnRegStart_Click
        /// <summary>
        /// مرحلع اول: ورود به صفحه تامین اجتماعی
        /// </summary>
        private void btnRegStart_Click(object sender, EventArgs e)
        {
            WB.DocumentCompleted += Progress_1;
            WB.Navigate("http://www2.darman.sso.ir");
        }
        #endregion

        #region Progress_1
        /// <summary>
        /// مرحلع دوم: وارد كردن نام كاربری و كلمه عبور و فشردن دكمه ورود
        /// </summary>
        void Progress_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WB.DocumentCompleted -= Progress_1;
            Text = WB.Document.Url.AbsoluteUri;
            #region Set Login Data
            WB.Document.GetElementById("ctl00_txtUID").InnerText = "0000005016";
            WB.Document.GetElementById("ctl00_txtPASS").InnerText = "abcdefgh";
            #endregion
            WB.DocumentCompleted += Progress_2;
            WB.Document.GetElementById("ctl00_BtnLogin").RaiseEvent("onclick");
        }
        #endregion

        #region Progress_2
        /// <summary>
        /// مرحلع سوم: فشردن دكمه تایید نسخه جدید
        /// </summary>
        void Progress_2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Text = WB.Document.Url.AbsoluteUri;
            WB.DocumentCompleted -= Progress_2;
            WB.DocumentCompleted += Progress_3;
            WB.Document.GetElementById("BtnlistID").RaiseEvent("onclick");
        }
        #endregion

        #region Progress_3
        /// <summary>
        /// مرحلع چهارم: ورود اطلاعات نسخه جدید
        /// </summary>
        void Progress_3(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Text = WB.Document.Url.AbsoluteUri;
            WB.DocumentCompleted -= Progress_3;
            HtmlElement Items;
            #region Serial *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtBletSerial"); // شماره سریال دفترچه
            Items.InnerText = "000123456789";
            Items.RaiseEvent("onblur");
            #endregion

            #region Validation Date *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtDateEtebar"); // تاریخ اعتبار دفترچه
            Items.InnerText = "1389/08/05";
            Items.RaiseEvent("onblur");
            #endregion

            #region Book Vol
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtBletNo"); // ‌چندمین جلد دفترچه
            Items.InnerText = "1";
            #endregion

            #region Page Number *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtBletPage"); // شماره صفحه دفترچه
            Items.InnerText = "1";
            #endregion

            #region Prescription Date *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtPrescDate"); // تاریخ نسخه
            Items.InnerText = "1389/08/05";
            Items.RaiseEvent("onblur");
            #endregion

            #region Request Physican Mecical ID *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_docid"); // شماره نظام پزشكی پزشك درخواست كننده
            Items.InnerText = "65229";
            Items.RaiseEvent("onblur");
            #endregion

            #region Ins Number
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtBimNo"); // شماره بیمه
            Items.Focus();
            Items.InnerText = "0000123456789";
            Items.RaiseEvent("onblur");
            #endregion

            #region First Name *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtFirstName"); // نام بیمار
            Items.InnerText = "نام كوچك بیمار";
            Items.RaiseEvent("onblur");
            #endregion

            #region Last Name *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtLastName"); // نام خانوادگی
            Items.InnerText = "نام خانوادگی";
            Items.RaiseEvent("onblur");
            #endregion

            #region BirthDate *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtBirthDate"); // تاریخ تولد بیمار
            Items.InnerText = "1389/08/05";
            Items.RaiseEvent("onblur");
            #endregion

            #region Gender *
            Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_cmbSexType"); // جنسیت
            Items.InnerHtml = "<OPTION value=1>مذکر</OPTION> <OPTION selected value=2>مونث</OPTION>"; // برای مونث ها
            Items.OuterHtml = "<SELECT style=\"WIDTH: 105px\" id=ctl00_ContentPlaceHolder1_cmbSexType class=operator_button " +
                "tabIndex=15 name=ctl00$ContentPlaceHolder1$cmbSexType> <OPTION value=1>مذکر</OPTION>" +
                " <OPTION selected value=2>مونث</OPTION></SELECT>"; // برای مونث ها
            WB.Document.GetElementById("ctl00_ContentPlaceHolder1_cbx").Focus();
            #endregion

            _InsertDataProgress = 1;
            TimerInsertData.Start();
        }
        #endregion

        #region TimerInsertData_Tick
        private void TimerInsertData_Tick(object sender, EventArgs e)
        {
            switch (_InsertDataProgress)
            {
                #region case 1: Paraclinic Type
                case 1: // نوع پاراكلینیك
                    {
                        HtmlElement Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_cmbParType");
                        Items.InnerHtml = "<OPTION selected value=05>سی تی اسکن</OPTION> " +
                            "<OPTION value=06>ام آر آی</OPTION>";
                        Items.OuterHtml = "<SELECT style=\"WIDTH: 130px\" " +
                            "id=ctl00_ContentPlaceHolder1_cmbParType class=operator_button " +
                            "tabIndex=20 name=ctl00$ContentPlaceHolder1$cmbParType> " +
                            "<OPTION selected value=05>سی تی اسکن</OPTION> <OPTION value=06>ام آر آی</OPTION></SELECT>";
                        WB.Document.GetElementById("ctl00_ContentPlaceHolder1_cbx").Focus();
                        break;
                    }
                #endregion

                #region case 2: Service 1 International Code
                case 2: // خدمات اول
                    {
                        HtmlElement Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtParTarefCode1");
                        Items.Focus();
                        Items.InnerText = "0570481";
                        WB.Document.GetElementById("ctl00_ContentPlaceHolder1_cbx").Focus();
                        break;
                    }
                #endregion

                #region case 3: Service 1 Spiral
                case 3: // خدمت اول - اسپیرال بودن
                    {
                        HtmlElement Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_isSpiral1");
                        Items.Focus();
                        Items.OuterHtml = "<INPUT id=ctl00_ContentPlaceHolder1_isSpiral1 tabIndex=24 " + 
                            "onclick=\"Calculate_Sum('1')\" name=ctl00$ContentPlaceHolder1$isSpiral1 CHECKED type=checkbox>";
                        WB.Document.GetElementById("ctl00_ContentPlaceHolder1_cbx").Focus();
                        break;
                    }
                #endregion

                #region case 4: Service 1 Quantity
                case 4: // خدمت اول - تعداد
                    {
                        HtmlElement Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_txtParTarefNo1");
                        Items.Focus();
                        Items.InnerText = "2";
                        WB.Document.GetElementById("ctl00_ContentPlaceHolder1_cbx").Focus();
                        break;
                    }
                #endregion

                default: TimerInsertData.Stop(); break;
            }
            _InsertDataProgress++;
        }
        #endregion

        #region btnRetry_Click
        private void btnRetry_Click(object sender, EventArgs e)
        {
            if (TimerInsertData.Enabled) return;
            TimerInsertData.Stop();
            WB.DocumentCompleted += Progress_3;
            WB.Navigate("http://www2.darman.sso.ir/Forms/Paraclinic/ApplyParNote.aspx");
        }
        #endregion

        #region btnTest_Click
        private void btnTest_Click(object sender, EventArgs e)
        {
            // ReSharper disable PossibleNullReferenceException
            HtmlElement Items = WB.Document.GetElementById("ctl00_ContentPlaceHolder1_isSpiral1");
            Items.OuterHtml = Items.OuterHtml;
            Items.OuterHtml = "<INPUT id=ctl00_ContentPlaceHolder1_isSpiral1 disabled tabIndex=24 " +
                "onclick=\"Calculate_Sum('1')\" name=ctl00$ContentPlaceHolder1$isSpiral1 type=checkbox>";
            // ReSharper restore PossibleNullReferenceException
        }
        #endregion

    }
    // ReSharper restore PossibleNullReferenceException
}