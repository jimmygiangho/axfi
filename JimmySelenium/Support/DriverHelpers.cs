using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace JimmySelenium.Support
{
    public static class JimmyHelpers
    {
        public static void SelectItem(this IWebElement element, string text)
        {
                new SelectElement(element).SelectByText(text);
        }

        public static bool IsSelected(this IWebElement element)
        {
            bool reVal = false;

            try
            {
                reVal = element.Selected;
            }
            catch
            {
                // just continue
            }

            return reVal;
        }

        


        public static void SetText(this IWebElement element, string text, bool clearFirst = true, bool continueOnFailure = false, bool isPassword = false)
        {
            if (text == null) // if nothing pass in, just skip it
                return;

            try
            {
                    if (clearFirst) element.Clear();
                    element.SendKeys(text);
                
            }
            catch (Exception)
            {
                    throw;
            }
        }

      

        public static void SelectItemByIndex(this IWebElement element, int? _index, bool reverse = false)
        {
            if (!_index.HasValue || _index < 0) // if nothing pass in, just skip it
                return;

            SelectElement selectElement = new SelectElement(element);

            int index = (int)_index;
            if (reverse)
                index = selectElement.Options.Count - index;

           
          
                selectElement.SelectByIndex(index);
               
            
        }

        public static void ScrollIntoView(this IWebElement element)
        {

            Actions actions = new Actions(JimmyDriver.Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void SelectItemBySendingKeys(this IWebElement element, string text)
        {
            if (text == null) // if nothing pass in, just skip it
                return;

           
            
                element.Click();
                element.SendKeys(text);
            
        }

       

        public static List<string> GetAllSelectedItems(this IWebElement element)
        {


            List<string> AllSelectedItems = new List<string>();
            var selectElement = new SelectElement(element);
            if (selectElement.AllSelectedOptions.Count > 0)
                for (int i = 0; i <= selectElement.AllSelectedOptions.Count - 1; i++)
                {
                    AllSelectedItems.Add(selectElement.AllSelectedOptions[i].Text.ToString());

                }
            return AllSelectedItems;
        }
        public static string GetSelectedItem(this IWebElement element)
        {
           
           
                var selectElement = new SelectElement(element);
                if (selectElement.AllSelectedOptions.Count == 0)
                    return "";
                else
                    return selectElement.SelectedOption.Text;

                // TODO: return all selected options - if needed
                // else if (selectElement.AllSelectedOptions.Count > 1)

           
        }

        public static string GetAllTextFromSelect(this IWebElement element, string separator = "|")
        {
            return element.GetDropdownOptions().ToStringPlus(separator);
        }

        public static string ToStringPlus(this IEnumerable<IWebElement> elementList, string separator = "|")
        {
            var elementTexts = elementList.ToStringArray();
            return string.Join(separator, elementTexts);
        }

        public static string[] ToStringArray(this IEnumerable<IWebElement> elementList)
        {
            var stringArray = new string[elementList.Count()];
            var list = elementList.ToList();

            for (int i = 0; i < list.Count; i++)
                stringArray[i] = list[i].Text;

            return stringArray;
        }
        public static IList<IWebElement> GetDropdownOptions(this IWebElement element)
        {
            if (element.TagName.ToLowerInvariant() != "select")
                throw new Exception("Element must be of type HtmlSelect");

           
            
                SelectElement selectElement = new SelectElement(element);
                return selectElement.Options;
            
        }

        public static string GetRandomText(int maxSize = 8)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider Jimmyypto = new RNGCryptoServiceProvider())
            {
                Jimmyypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                Jimmyypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string GetRandomNumber(int maxSize = 10)
        {
            char[] chars = new char[62];
            chars =
            "1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider Jimmyypto = new RNGCryptoServiceProvider())
            {
                Jimmyypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                Jimmyypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }



    //
    

     

       
    }

   

    public static class DateTimeExtensions
    {
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while (current.DayOfWeek == DayOfWeek.Saturday ||
                    current.DayOfWeek == DayOfWeek.Sunday);
            }
            return current;
        }

        public static DateTime SubtractBusinessDays(this DateTime current, int days)
        {
            return AddBusinessDays(current, -days);
        }

        public static DateTime ToPST(this DateTime nonPstTime)
        {
            //Link: https://msdn.miJimmyosoft.com/en-us/library/gg154758.aspx
            return nonPstTime.ToUniversalTime().AddHours(TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time").IsDaylightSavingTime(nonPstTime) ? -7 : -8);
        }

        public static string ToDateString(this DateTime dateTime, bool slash = false, bool trim = false)
        {
            string format = trim ? "M-d-yyyy" : "mm-dd-yyyy";
            if (slash) format = format.Replace('-', '/');

            return dateTime.ToString(format);
        }

        public static string ToTimeString(this DateTime dateTime, char separator = ':', bool trim = false, bool timeZone = false)
        {
            string format = trim ? "h:mm:ss tt" : "hh:mm:ss tt";
            if (separator != ':') format = format.Replace(':', separator);
            if (timeZone) format = format + " \"GMT\"zzz";

            return dateTime.ToString(format);
        }

        public static string ToString(this DateTime? d, string format)
        {
            return d == null ? "" : ((DateTime)d).ToString(format);
        }

        public static int DaysPassed(this DateTime? d1, DateTime? d2)
        {
            TimeSpan span = (d2 ?? DateTime.UtcNow).Subtract(d1 ?? DateTime.UtcNow);

            return (int)span.TotalDays;
        }

        public static bool isWeekend(this DateTime d)
        {
            var dayOfWeek = d.DayOfWeek;

            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWeekDays(this DateTime d, int days)
        {
            return d.AddDays(d.GetWeekDaysCountingWeekends(days));
        }

        public static int GetWeekDaysCountingWeekends(this DateTime d, int days)
        {
            var dateAfter = d.AddDays(days);
            if (dateAfter.DayOfWeek == DayOfWeek.Saturday)
                return days + 2;
            else if (dateAfter.DayOfWeek == DayOfWeek.Sunday)
                return days + 1;

            return days;
        }

        public static string Jimmyddyyyy(this DateTime d, char sep = '-')
        {
            var format = string.Format("mm{0}dd{1}yyyy", sep, sep);

            return d.ToString(format);
        }

        public static string hhJimmysstt(this DateTime d, char sep = ':')
        {
            var format = string.Format("hh{0}mm{1}ss tt", sep, sep);

            return d.ToString(format);
        }

    }

    public static class DecimalExtension
    {
        public static string ToString(this decimal? num, string format = "N")
        {
            return num == null ? "" : ((Decimal)num).ToString(format);
        }
    }

    public static class DoubleExtensions
    {
        public static string ToString(this double? num, string format = "N")
        {
            return num == null ? "" : ((Decimal)num).ToString(format);
        }
    }

   

    public class ExpectedConditions
    {
        public static Func<IWebDriver, IAlert> AlertIsPresent()
        {
            return (driver) =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsNotVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch (Exception e)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsEnabled(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Enabled;
                }
                catch
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsDisabled(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return !element.Enabled;
                }
                catch
                {
                    return false;
                }
            };
        }
    }

