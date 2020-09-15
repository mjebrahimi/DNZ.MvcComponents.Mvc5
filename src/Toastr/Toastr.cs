using Savosh.Component;
using Savosh.Utility;
using System.Web.UI;
using System.Web.WebPages;

[assembly: WebResource("Savosh.Component.Toastr.toastr.min.css", "text/css")]
[assembly: WebResource("Savosh.Component.Toastr.toastr.min.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class Toastr : MessageBoxResult, IOptionBuilder
    {
        private const string toastr_css = "Savosh.Component.Toastr.toastr.min.css";
        private const string toastr_js = "Savosh.Component.Toastr.toastr.min.js";
        private string type = string.Format("'{0}'", ToastrType.Info.ToString().ToLower());
        private string title = "''";
        private string text = "''";
        public Toastr(HtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(toastr_css) + @""" rel=""stylesheet"" />");
            RenderScriptAndStyle.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(toastr_js) + @"""></script>");
        }

        public Toastr Title(string value)
        {
            title = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr Title(Func<object, HelperResult> template)
        {
            title = ComponentUtility.ToJavaScriptString(template(null).ToHtmlString());
            SetScript();
            return this;
        }

        public Toastr Text(string value)
        {
            text = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr Text(Func<object, HelperResult> template)
        {
            text = ComponentUtility.ToJavaScriptString(template(null).ToHtmlString());
            SetScript();
            return this;
        }

        public Toastr Type(ToastrType type)
        {
            this.type = string.Format("'{0}'", type.ToString().ToLower());
            SetScript();
            return this;
        }

        public Toastr CloseButton(bool value)
        {
            Attributes["closeButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr Debug(bool value)
        {
            Attributes["debug"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr NewestOnTop(bool value)
        {
            Attributes["newestOnTop"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr ProgressBar(bool value)
        {
            Attributes["progressBar"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr PreventDuplicates(bool value)
        {
            Attributes["preventDuplicates"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr TapToDismiss(bool value)
        {
            Attributes["tapToDismiss"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Toastr PositionClass(ToastrAlignment value)
        {
            Attributes["positionClass"] = string.Format("'{0}'", value.ToDescription());
            SetScript();
            return this;
        }

        public Toastr OnClick(string value)
        {
            Attributes["onclick"] = value;
            SetScript();
            return this;
        }

        public Toastr OnShown(string value)
        {
            Attributes["onShown"] = value;
            SetScript();
            return this;
        }

        public Toastr OnHidden(string value)
        {
            Attributes["onHidden"] = value;
            SetScript();
            return this;
        }

        public Toastr ShowDuration(int value)
        {
            Attributes["showDuration"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr HideDuration(int value)
        {
            Attributes["hideDuration"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr TimeOut(int value)
        {
            Attributes["timeOut"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr ExtendedTimeOut(int value)
        {
            Attributes["extendedTimeOut"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr ShowEasing(string value)
        {
            Attributes["showEasing"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr HideEasing(string value)
        {
            Attributes["hideEasing"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr ShowMethod(string value)
        {
            Attributes["showMethod"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr HideMethod(string value)
        {
            Attributes["hideMethod"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr CloseMethod(string value)
        {
            Attributes["closeMethod"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Toastr CloseEasing(string value)
        {
            Attributes["closeEasing"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            var script = "toastr[" + type + "](" + text + ", " + title + ", " + this.RenderOptions() + ")";
            Script = script;
            if (!HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest() && htmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}