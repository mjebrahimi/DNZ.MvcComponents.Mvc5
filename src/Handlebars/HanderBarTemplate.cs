using Savosh.Component;
using System.Collections.Generic;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.Handlebars.handlebars.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.Handlebars.handlebars-v4.0.5.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class HanderBarTemplate : System.Web.IHtmlString
    {
        private const string handlebars_js = "Savosh.Component.Handlebars.handlebars.js";
        private const string handlebars_4_js = "Savosh.Component.Handlebars.handlebars-v4.0.5.js";

        public HanderBarTemplate(HtmlHelper helper)
        {
            helper.ScriptFileSingle(@"<script hand src=""" + ComponentUtility.GetWebResourceUrl(handlebars_js) + @"""></script>");
        }

        public MvcHtmlString Html { get; set; }

        public string Id { get; set; }

        public string Script
        {
            get
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return string.Format("Handlebars.compile({0})", Html.ToString().ToJavaScriptString());
                }
                else
                {
                    return @"Handlebars.compile($(""#" + Id + @""").html())";
                }
            }
        }

        //public MvcHtmlString Render(string context)
        //{
        //    var html = string.Format("{0}({1})", Script, context);
        //    return MvcHtmlString.Create(html);
        //}
        //public MvcHtmlString Render(object value)
        //{
        //    var html = string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value));
        //    return MvcHtmlString.Create(html);
        //}
        //public MvcHtmlString Render(Dictionary<string, object> value)
        //{
        //    var html = string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value));
        //    return MvcHtmlString.Create(html);
        //}

        public string Render(string context)
        {
            var html = string.Format("{0}({1})", Script, context);
            return html;
        }

        public string Render(object value)
        {
            var html = string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value));
            return html;
        }

        public string Render(Dictionary<string, object> value)
        {
            var html = string.Format("{0}({1})", Script, ComponentUtility.ToJsonStringWithoutQuotes(value));
            return html;
        }

        public string ToHtmlString()
        {
            return "";
        }
    }
}