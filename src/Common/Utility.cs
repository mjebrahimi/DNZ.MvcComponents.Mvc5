using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace Savosh.Component
{
    public static class ComponentUtility
    {
        public static void DefinGlobalJavascriptVariable(this IScript script, HtmlHelper html, string name)
        {
            html.Script(@"
            <script>
                var " + name + @";
                $(function(){
                    " + name + " = " + script.Script + @" 
                });
            </script>");
        }

        public static string GetWebResourceUrl(string resourceId)
        {
            var type = typeof(ComponentUtility);
            return CachedPageInstance.ClientScript.GetWebResourceUrl(type, resourceId);
        }

        public static string GetWebResourceUrl(Type type, string resourceId)
        {
            if (type == null)
                type = typeof(ComponentUtility);
            return CachedPageInstance.ClientScript.GetWebResourceUrl(type, resourceId);
        }

        private static Page CachedPageInstance
        {
            get { return _CachedPage ?? (_CachedPage = new Page()); }
        }

        private static Page _CachedPage;

        public static string ToJsonStringWithoutQuotes(object value)
        {
            var serializer = new JsonSerializer();
            var stringWriter = new StringWriter();
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);
                return stringWriter.ToString();
            }
        }

        public static string ToJsonString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        #region MergeAttributes
        private static object GetValue(IGrouping<string, KeyValuePair<string, object>> source, bool appendCssClass)
        {
            if (appendCssClass)
                return source.Key == "class" ? string.Join(" ", source.Select(p => p.Value)) : source.First().Value;
            return source.First().Value;
        }

        public static Dictionary<string, object> MergeAttributes(object primaryAttributes, Dictionary<string, object> secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            if (primaryAttributes is Dictionary<string, object> primary)
                return MergeAttributes(primary, secondaryAttributes, appendCssClass);

            return new RouteValueDictionary(primaryAttributes).Concat(secondaryAttributes).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => GetValue(d, appendCssClass));
        }

        public static Dictionary<string, object> MergeAttributes(object primaryAttributes, object secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            var primary = primaryAttributes as Dictionary<string, object>;
            var secondary = secondaryAttributes as Dictionary<string, object>;

            if (primary != null && secondary != null)
                return MergeAttributes(primary, secondary, appendCssClass);
            if (primary != null)
                return MergeAttributes(primary, secondaryAttributes, appendCssClass);
            if (secondary != null)
                return MergeAttributes(primaryAttributes, secondary, appendCssClass);

            var attributes = new RouteValueDictionary(primaryAttributes).Concat(new RouteValueDictionary(secondaryAttributes)).GroupBy(d => d.Key)
                .ToDictionary(d => d.Key.Replace('_', '-'), d => GetValue(d, appendCssClass));
            return attributes;
        }

        public static Dictionary<string, object> MergeAttributes(this Dictionary<string, object> primaryAttributes, Dictionary<string, object> secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            return primaryAttributes.Concat(secondaryAttributes).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => GetValue(d, appendCssClass));
        }

        public static Dictionary<string, object> MergeAttributes(this Dictionary<string, object> primaryAttributes, object secondaryAttributes, bool appendCssClass = true) //not replace css class
        {
            if (secondaryAttributes is Dictionary<string, object> secondary)
                return MergeAttributes(primaryAttributes, secondary, appendCssClass);

            return primaryAttributes.Concat(new RouteValueDictionary(secondaryAttributes)).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => GetValue(d, appendCssClass));

            //var input = new TagBuilder("input");
            //var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            //input.MergeAttributes(attributes);
        }
        #endregion

        public static string RenderOptions(this IOptionBuilder options)
        {
            var result = string.Join(", \n", options.Attributes.Select(p => p.Key + ": " + p.Value));
            return "{\n" + result + "\n}";
        }

        public static string RenderOptions(this Dictionary<string, object> attributes)
        {
            var result = string.Join(", \n", attributes.Select(p => p.Key + ": " + p.Value));
            return "{\n" + result + "\n}";
        }

        private static long lastTimeStamp = DateTime.UtcNow.Ticks;
        public static long UtcNowTicks
        {
            get
            {
                long original, newValue;
                do
                {
                    original = lastTimeStamp;
                    long now = DateTime.UtcNow.Ticks;
                    newValue = Math.Max(now, original + 1);
                } while (Interlocked.CompareExchange(ref lastTimeStamp, newValue, original) != original);

                return newValue;
            }
        }

        public static string ToJavaScriptString(this string template)
        {
            var safeText = template.Replace('\'', '"');
            var lines = safeText.Split('\n');
            var linesWithQuotes = lines.Select(p => string.Format("'{0}'", p.Trim('\n', '\r', ' ')));
            var result = string.Join("+\n", linesWithQuotes);
            return result;
        }

        public static string ToLowerFirst(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static T GetPropValue<T>(object src, string propName)
        {
            var value = src.GetType().GetProperty(propName).GetValue(src, null);
            return (T)value;
        }
    }
}
