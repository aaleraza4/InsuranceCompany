using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public static class Helper
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : string.Empty;
        }
        public static string GetHTMLTags(List<string> ListData)
        {
            string html_vals = "";

            foreach (var item in ListData)
            {
                html_vals += "<label class='badge badge-primary p-1'>" + item + "</label> ";
            }
            return html_vals;
        }

        public static string GetSingleHTMLTags(string SingleItem)
        {
            string html_vals = "";
            return html_vals += "<label class='badge badge-primary p-1'>" + SingleItem + "</label> ";
        }
        public static string GetAlternateImage(string fileurl)
        {
            if (string.IsNullOrEmpty(fileurl))
            {
                return "/img/avatar-1.jpg";
            }
            else
            {
                return fileurl;
            }
        }

        public static string StripeConfigurationStatus(string stripeAccountId)
        {
            if (string.IsNullOrEmpty(stripeAccountId))
            {
                return "<span class='badge badge-warning'>Stripe Pending</span>";
            }
            else
            {
                return "<span class='badge badge-info'>Stripe Configured</span>";
            }

        }
        public static string AllVerificationStatus(bool AllIntructionCheck)
        {
            if (!AllIntructionCheck)
            {
                return "<span class='badge badge-warning'>Pending</span>";
            }
            else
            {
                return "<span class='badge badge-info'>Active</span>";
            }

        }
        public static string CertifiedTutor(bool CertifiedTutor)
        {
            if (!CertifiedTutor)
            {
                return "<span class='badge badge-warning'>Not Certified</span>";
            }
            else
            {
                return "<span class='badge badge-info'>Certified</span>";
            }
        }
        public static bool EmailsValid(List<string> Emails)
        {
            var is_valid = true;
            var email_validation = new EmailAddressAttribute();
            foreach (var item in Emails)
            {

                if (email_validation.IsValid(item) == false)
                {
                    is_valid = false;
                    break;
                }
            }

            return is_valid;
        }
        public static string GetStatusTags(bool status)
        {
            string html_vals = "";
            if (status)
            {
                html_vals = "<label class='badge badge-primary p-1'>Active</label> ";
            }
            else
            {
                html_vals = "<label class='badge badge-danger p-1'>Inactive</label> ";
            }
            return html_vals;
        }
        public static string GetEnrollmentStatusTags(bool status)
        {
            string html_vals = "";
            if (status)
            {
                html_vals = "<label class='badge badge-danger p-1'>Rejected</label> ";
            }
            else
            {
                html_vals = "<label class='badge badge-primary p-1'>Active</label> ";
            }
            return html_vals;
        }
        public static string GetRewardStatusTags(bool status)
        {
            string html_vals = "";
            if (status)
            {
                html_vals = "<label class='badge badge-success p-1'>Availed</label> ";
            }
            else
            {
                html_vals = "<label class='badge badge-primary p-1'>Pending</label> ";
            }
            return html_vals;
        }
        public static string ProfileStatusTags(bool status)
        {
            string html_vals = "";
            if (status)
            {
                html_vals = "<label class='badge badge-primary p-1'>Profile Updated</label> ";
            }
            else
            {
                html_vals = "<label class='badge badge-danger p-1'>Pending</label> ";
            }
            return html_vals;
        }
        /// <summary>
        /// Enum Value to get the Description dynamically just to pass id.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescriptionText(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();

        }
        public static IEnumerable<SelectListItem> GetEnumList<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .ToDictionary(t => ((Enum)((object)t)).GetEnumDescription(), t => (int)(object)t).ToList()
                .Select(t => new SelectListItem { Text = t.Key, Value = t.Value.ToString() });
        }
        /// <summary>
        /// Base 64 String back to file ...............
        /// </summary>
        /// <param name="filestring"></param>
        public static void ConvertTofile(string filestring, string path)
        {
            Byte[] bytes = Convert.FromBase64String(filestring);
            File.WriteAllBytes(path, bytes);
        }
        public static List<TimeZoneInfo> GetTimeList()
        {
            var zones = new List<TimeZoneInfo> {
                            TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"),
                            TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"),
                            TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"),
                            TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
                            TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"),
                            TimeZoneInfo.FindSystemTimeZoneById("US Mountain Standard Time"),
                            TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time"),
                            TimeZoneInfo.FindSystemTimeZoneById("Alaskan Standard Time"),
                    };
            return zones;
        }
        public static List<string> GetLanguages()
        {
            var languages = new List<string>().ToList();
            languages.Add("English");
            return languages;
        }

        public static string GetStatus(long status)
        {
            string html_vals = "";
            if (status == 1)
            {
                html_vals = "<label class='badge badge-primary p-1'>Yes</label> ";
            }
            else
            {
                html_vals = "<label class='badge badge-danger p-1'>No</label> ";
            }
            return html_vals;
        }
    }
}
