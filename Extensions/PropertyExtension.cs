using Microsoft.AspNetCore.Html;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AssetTrackingEFMVC.Extensions
{
    public static class PropertyExtension
    {
        public static string FormatLocalPrice(this decimal price, string currency)
        {
            return $"{price} {currency}";
        }

        public static string FormatDate(this DateTime date) 
        {
            return date == DateTime.MinValue ? string.Empty : date.ToString("yyyy-MM-dd");
        }

        public static string FormatPrice(this decimal price)
        {
            return price > 0 ? price.ToString() : string.Empty;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            string? displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();

            if (string.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }

            return displayName;
        }

        public static HtmlString IsExpiredSoon(this bool isExpiredSoon, string color)
        {
            if (isExpiredSoon)
            {
                return new HtmlString($"<i style=\"color:{color}\" class=\"fa fa-bookmark\"></i>");
            }
            return new HtmlString(string.Empty);
        }
    }
}
