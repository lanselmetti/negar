#region using

using System;
using System.Globalization;
using Negar.PersianCalendar.Resource;

#endregion

namespace Negar.PersianCalendar.Utilities
{
    /// <summary>
    /// Helper class to convert numbers to it's farsi equivalent. 
    /// Use this class' methods to overcome a problem in displaying farsi numeric values.
    /// </summary>
    public sealed class toFarsi
    {
        #region Methods

        #region public static String Convert(String EnglishNumber, CultureInfo culture)

        /// <summary>
        /// Converts a number in String format e.g. 14500 to its localized version, if <c>Localized</c> value is set to <c>true</c>.
        /// </summary>
        /// <param name="EnglishNumber"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static String Convert(String EnglishNumber, CultureInfo culture)
        {
            String numEnglish = String.Empty;
            for (Int32 i = 0; i < EnglishNumber.Length; i++)
            {
                String numTemp = EnglishNumber.Substring(i, 1);
                switch (numTemp)
                {
                    case "0":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_0);
                        break;
                    case "1":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_1);
                        break;
                    case "2":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_2);
                        break;
                    case "3":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_3);
                        break;
                    case "4":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_4);
                        break;
                    case "5":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_5);
                        break;
                    case "6":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_6);
                        break;
                    case "7":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_7);
                        break;
                    case "8":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_8);
                        break;
                    case "9":
                        numEnglish = numEnglish +
                                     PersianLocalizeManager.GetLocalizerByCulture(culture).GetLocalizedString(
                                         StringIDEnum.Numbers_9);
                        break;
                    default:
                        numEnglish = numEnglish + numTemp;
                        break;
                }
            }
            return (numEnglish);
        }

        #endregion

        #region public static String Convert(String EnglishNumber)

        /// <summary>
        /// Converts an English number to it's Farsi value.
        /// </summary>
        /// <remarks>This method only converts the numbers in a String, 
        /// and does not convert any non-numeric characters.</remarks>
        /// <param name="EnglishNumber"></param>
        /// <returns></returns>
        public static String Convert(String EnglishNumber)
        {
            String numEnglish = String.Empty;
            for (Int32 i = 0; i < EnglishNumber.Length; i++)
            {
                String numTemp = EnglishNumber.Substring(i, 1);
                switch (numTemp)
                {
                    case "0":
                        numEnglish = numEnglish + "۰";
                        break;
                    case "1":
                        numEnglish = numEnglish + "۱";
                        break;
                    case "2":
                        numEnglish = numEnglish + "۲";
                        break;
                    case "3":
                        numEnglish = numEnglish + "۳";
                        break;
                    case "4":
                        numEnglish = numEnglish + "۴";
                        break;
                    case "5":
                        numEnglish = numEnglish + "۵";
                        break;
                    case "6":
                        numEnglish = numEnglish + "۶";
                        break;
                    case "7":
                        numEnglish = numEnglish + "۷";
                        break;
                    case "8":
                        numEnglish = numEnglish + "۸";
                        break;
                    case "9":
                        numEnglish = numEnglish + "۹";
                        break;
                    default:
                        numEnglish = numEnglish + numTemp;
                        break;
                }
            }
            return (numEnglish);
        }

        #endregion

        #endregion
    }
}