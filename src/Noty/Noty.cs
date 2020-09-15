using Savosh.Component;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.Noty.jquery.noty.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.jquery.noty.packaged.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.Noty.jquery.noty.packaged.min.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class Noty : MessageBoxResult
    {
        private const string noty_js = "Savosh.Component.Noty.jquery.noty.js";
        private const string noty_packaged_js = "Savosh.Component.jquery.noty.packaged.js";
        private const string noty_packaged_min_js = "Savosh.Component.Noty.jquery.noty.packaged.min.js";
        public Dictionary<string, object> ButtonAttributes { get; set; }

        public Noty(HtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(noty_packaged_min_js) + @"""></script>");
            ButtonAttributes = new Dictionary<string, object>();
        }

        public Noty Text(string value)
        {
            Attributes["text"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Noty Type(MessageType value)
        {
            Attributes["type"] = string.Format("'{0}'", value.ToString().ToLower());
            SetScript();
            return this;
        }

        public Noty Layout(MessageAlignment value)
        {
            Attributes["layout"] = string.Format("'{0}'", value.ToString().ToLowerFirst());
            SetScript();
            return this;
        }

        public Noty DismissQueue(bool value)
        {
            Attributes["dismissQueue"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Noty Modal(bool value)
        {
            Attributes["modal"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Noty Timeout(int value)
        {
            Attributes["timeout"] = value;
            SetScript();
            return this;
        }

        public Noty MaxVisible(int value)
        {
            Attributes["maxVisible"] = value;
            SetScript();
            return this;
        }

        public Noty Killer(bool value)
        {
            Attributes["killer"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Noty AddButton(string text, string onClick, string addClass = null)
        {
            var str = @"{
            text: '" + text + @"',
            " + (string.IsNullOrEmpty(addClass) ? "" : "addClass: '" + addClass + "',") + @"
            onClick: " + onClick + @"
        }";
            ButtonAttributes.Add("", str);
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            if (ButtonAttributes.Count > 0)
                Attributes["buttons"] = "[\n" + string.Join(", \n", ButtonAttributes.Select(p => p.Value)) + "\n]";
            var script = "$.noty.closeAll(); noty(" + this.RenderOptions() + ")";
            Script = script;
            if (!HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest() && htmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}