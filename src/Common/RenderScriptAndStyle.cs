using Savosh.Component;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.WebPages;

namespace System.Web.Mvc
{
    public static partial class RenderScriptAndStyle
    {
        public static MvcHtmlString Script(this HtmlHelper htmlHelper, MvcHtmlString template)
        {
            return Script(htmlHelper, template.ToHtmlString());
        }

        public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            return Script(htmlHelper, template(null).ToHtmlString());
        }

        public static MvcHtmlString Script(this HtmlHelper htmlHelper, string template)
        {
            return ScriptSingle(htmlHelper, ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static MvcHtmlString ScriptFileSingle(this HtmlHelper htmlHelper, Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptFileSingle(htmlHelper, template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString ScriptFileSingle(this HtmlHelper htmlHelper, string template, bool overWrite = false)
        {
            var fileName = Regex.Match(template, "<script.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return ScriptSingle(htmlHelper, fileName, template, overWrite);
        }

        public static MvcHtmlString ScriptSingle(this HtmlHelper htmlHelper, string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptSingle(htmlHelper, keyName, template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString ScriptSingle(this HtmlHelper htmlHelper, string keyName, string template, bool overWrite = false)
        {
            htmlHelper.ViewContext.HttpContext.SetItem(GetKeyValue(keyName, template), true, overWrite);
            return MvcHtmlString.Empty;
        }



        public static MvcHtmlString Style(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            return Style(htmlHelper, template(null).ToHtmlString());
        }

        public static MvcHtmlString Style(this HtmlHelper htmlHelper, string template)
        {
            return StyleSingle(htmlHelper, ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static MvcHtmlString StyleFileSingle(this HtmlHelper htmlHelper, Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleFileSingle(htmlHelper, template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString StyleFileSingle(this HtmlHelper htmlHelper, string template, bool overWrite = false)
        {
            var fileName = Regex.Match(template, "<link.+?href=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return StyleSingle(htmlHelper, fileName, template, overWrite);
        }

        public static MvcHtmlString StyleSingle(this HtmlHelper htmlHelper, string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleSingle(htmlHelper, keyName, template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString StyleSingle(this HtmlHelper htmlHelper, string keyName, string template, bool overWrite = false)
        {
            htmlHelper.ViewContext.HttpContext.SetItem(GetKeyValue(keyName, template), false, overWrite);
            return MvcHtmlString.Empty;
        }


        // ===============================================================================
        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys.Cast<object>().Select(p => p.ToString()).Where(p => p.StartsWith("_script_")).OrderBy(p => p))
            {
                var template = (KeyValuePair<string, string>)htmlHelper.ViewContext.HttpContext.Items[key];// as Func<object, HelperResult>;
                if (template.Value != null)
                {
                    htmlHelper.ViewContext.Writer.Write(template.Value + Environment.NewLine);
                }
            }
            return MvcHtmlString.Empty;
        }

        public static IHtmlString RenderStyles(this HtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys.Cast<object>().Select(p => p.ToString()).Where(p => p.StartsWith("_style_")).OrderBy(p => p))
            {
                var template = (KeyValuePair<string, string>)htmlHelper.ViewContext.HttpContext.Items[key];// as Func<object, HelperResult>;
                if (template.Value != null)
                {
                    htmlHelper.ViewContext.Writer.Write(template.Value + Environment.NewLine);
                }
            }
            return MvcHtmlString.Empty;
        }

        private static KeyValuePair<string, string> GetKeyValue(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }

        private static void SetItem(this HttpContextBase context, KeyValuePair<string, string> item, bool isScript, bool overWrite)
        {
            var isUnique = true;
            foreach (object key in context.Items.Keys.Cast<object>().Select(p => p.ToString()).Where(p => isScript ? p.StartsWith("_script_") : p.StartsWith("_style_")))
            {
                var value = (KeyValuePair<string, string>)context.Items[key];
                if (value.Key != "" && value.Key == item.Key)
                {
                    isUnique = false;
                    if (overWrite)
                        context.Items[key] = item;
                    break;
                }
            }
            if (isUnique)
            {
                if (isScript)
                    context.Items["_script_" + ComponentUtility.UtcNowTicks] = item;
                else
                    context.Items["_style_" + ComponentUtility.UtcNowTicks] = item;
            }
        }
    }

    public static partial class RenderScriptAndStyle
    {
        public static MvcHtmlString Script(Func<object, HelperResult> template)
        {
            return Script(template(null).ToHtmlString());
        }

        public static MvcHtmlString Script(string template)
        {
            return ScriptSingle(ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static MvcHtmlString ScriptFileSingle(Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptFileSingle(template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString ScriptFileSingle(string template, bool overWrite = false)
        {
            var fileName = Regex.Match(template, "<script.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return ScriptSingle(fileName, template, overWrite);
        }

        public static MvcHtmlString ScriptSingle(string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return ScriptSingle(keyName, template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString ScriptSingle(string keyName, string template, bool overWrite = false)
        {
            HttpContext.Current.Request.RequestContext.HttpContext.SetItem(GetKeyValue(keyName, template), true, overWrite);
            return MvcHtmlString.Empty;
        }



        public static MvcHtmlString Style(Func<object, HelperResult> template)
        {
            return Style(template(null).ToHtmlString());
        }

        public static MvcHtmlString Style(string template)
        {
            return StyleSingle(ComponentUtility.UtcNowTicks.ToString(), template);
        }

        public static MvcHtmlString StyleFileSingle(Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleFileSingle(template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString StyleFileSingle(string template, bool overWrite = false)
        {
            var fileName = Regex.Match(template, "<link.+?href=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
            return StyleSingle(fileName, template, overWrite);
        }

        public static MvcHtmlString StyleSingle(string keyName, Func<object, HelperResult> template, bool overWrite = false)
        {
            return StyleSingle(keyName, template(null).ToHtmlString(), overWrite);
        }

        public static MvcHtmlString StyleSingle(string keyName, string template, bool overWrite = false)
        {
            HttpContext.Current.Request.RequestContext.HttpContext.SetItem(GetKeyValue(keyName, template), false, overWrite);
            return MvcHtmlString.Empty;
        }
    }
}