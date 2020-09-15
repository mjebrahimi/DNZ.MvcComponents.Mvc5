using Savosh.Component;
using System.Collections.Generic;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.BootBox.bootbox.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class BootBox : MessageBoxResult, IOptionBuilder
    {
        private const string bootbox_js = "Savosh.Component.BootBox.bootbox.js";
        private int indexButton;
        private BootBoxType type;
        public Dictionary<string, object> ButtonAttributes { get; set; }
        public BootBox(HtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(bootbox_js) + @"""></script>");
            ButtonAttributes = new Dictionary<string, object>();
        }

        public BootBox Message(string value)
        {
            Attributes["message"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BootBox Title(string value)
        {
            Attributes["title"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BootBox Value(string value)
        {
            Attributes["value"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public BootBox AddButton(string label, string callback, string className = null)
        {
            indexButton++;
            var str = @"{
                    label: '" + label + @"',
                    " + (string.IsNullOrEmpty(className) ? "" : "className: '" + className + "',") + @"
                    callback: " + callback + @"
                }";
            ButtonAttributes.Add("button" + indexButton, str);
            SetScript();
            return this;
        }

        public BootBox Callback(string value)
        {
            Attributes["callback"] = value;
            SetScript();
            return this;
        }

        public BootBox Type(BootBoxType type)
        {
            if (!Attributes.ContainsKey("message"))
                Message("Message");
            if (!Attributes.ContainsKey("callback"))
                Callback("function(result) { }");
            this.type = type;
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            if (ButtonAttributes.Count > 0)
                Attributes["buttons"] = ButtonAttributes.RenderOptions();
            var script = @"bootbox." + type.ToString().ToLower() + "(" + this.RenderOptions() + ");";
            Script = script;
            if (!HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest() && htmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}

