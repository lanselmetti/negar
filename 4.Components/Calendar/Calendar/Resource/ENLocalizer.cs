using System;

namespace Negar.PersianCalendar.Resource
{
    public class ENLocalizer : BaseLocalizer
    {
        public override String GetLocalizedString(StringIDEnum ID)
        {
            switch (ID)
            {
                case StringIDEnum.Empty:
                    return String.Empty;
                case StringIDEnum.Numbers_0:
                    return "0";
                case StringIDEnum.Numbers_1:
                    return "1";
                case StringIDEnum.Numbers_2:
                    return "2";
                case StringIDEnum.Numbers_3:
                    return "3";
                case StringIDEnum.Numbers_4:
                    return "4";
                case StringIDEnum.Numbers_5:
                    return "5";
                case StringIDEnum.Numbers_6:
                    return "6";
                case StringIDEnum.Numbers_7:
                    return "7";
                case StringIDEnum.Numbers_8:
                    return "8";
                case StringIDEnum.Numbers_9:
                    return "9";

                case StringIDEnum.FADateTextBox_Required:
                    return "Mandatory field";
                case StringIDEnum.FAMonthView_None:
                    return "Empty";
                case StringIDEnum.FAMonthView_Today:
                    return "Today";

                case StringIDEnum.PersianDate_InvalidDateFormat:
                    return "Invalid date format";
                case StringIDEnum.PersianDate_InvalidDateTime:
                    return "Invalid date/time value";
                case StringIDEnum.PersianDate_InvalidDateTimeLength:
                    return "Invalid date time format";
                case StringIDEnum.PersianDate_InvalidDay:
                    return "Invalid Day value";
                case StringIDEnum.PersianDate_InvalidEra:
                    return "Invalid Era value";
                case StringIDEnum.PersianDate_InvalidFourDigitYear:
                    return "Invalid four digit Year value";
                case StringIDEnum.PersianDate_InvalidHour:
                    return "Invalid Hour value";
                case StringIDEnum.PersianDate_InvalidLeapYear:
                    return "Not a leap year. Correct the day value.";
                case StringIDEnum.PersianDate_InvalidMinute:
                    return "Invalid Minute value";
                case StringIDEnum.PersianDate_InvalidMonth:
                    return "Invalid Month value";
                case StringIDEnum.PersianDate_InvalidMonthDay:
                    return "Invalid Month/Day value";
                case StringIDEnum.PersianDate_InvalidSecond:
                    return "Invalid Second value";
                case StringIDEnum.PersianDate_InvalidTimeFormat:
                    return "Invalid Time format";
                case StringIDEnum.PersianDate_InvalidYear:
                    return "Invalid Year value.";

                case StringIDEnum.Validation_Cancel:
                    return "Cancel";
                case StringIDEnum.Validation_NotValid:
                    return "Entered value is not in valid range.";
                case StringIDEnum.Validation_Required:
                    return "This is a mandatory field. Please fill it in.";
                case StringIDEnum.Validation_NullText:
                    return "  /  /    ";

                case StringIDEnum.MessageBox_Ok:
                    return "Ok";
                case StringIDEnum.MessageBox_Abort:
                    return "Abort";
                case StringIDEnum.MessageBox_Cancel:
                    return "Cancel";
                case StringIDEnum.MessageBox_Ignore:
                    return "Ignore";
                case StringIDEnum.MessageBox_No:
                    return "No";
                case StringIDEnum.MessageBox_Retry:
                    return "Retry";
                case StringIDEnum.MessageBox_Yes:
                    return "Yes";
            }

            return "";
        }
    }
}