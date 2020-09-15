using Savosh.Component;
using System.Web.UI;
using System.Web.WebPages;

[assembly: WebResource("Savosh.Component.SweetAlertBs.sweet-alert.css", "text/css")]
[assembly: WebResource("Savosh.Component.SweetAlertBs.sweet-alert.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.SweetAlertBs.sweet-alert.min.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class SweetAlertBs : MessageBoxResult
    {
        private const string sweetalert_bs_css = "Savosh.Component.SweetAlertBs.sweet-alert.css";
        private const string sweetalert_bs_js = "Savosh.Component.SweetAlertBs.sweet-alert.js";
        private const string sweetalert_bs_min_js = "Savosh.Component.SweetAlertBs.sweet-alert.min.js";
        private string function;

        public SweetAlertBs(HtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(sweetalert_bs_css) + @""" rel=""stylesheet"" />");
            RenderScriptAndStyle.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(sweetalert_bs_min_js) + @"""></script>");

            ConfirmButtonClass("btn btn-primary");
        }

        public SweetAlertBs Function(string value)
        {
            function = value;
            SetScript();
            return this;
        }

        public SweetAlertBs Title(string value)
        {
            Attributes["title"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs Title(Func<object, HelperResult> template)
        {
            var html = ComponentUtility.ToJavaScriptString(template(null).ToHtmlString());
            Attributes["title"] = string.Format("{0}", html);
            return Html(true);
        }

        public SweetAlertBs Text(string value)
        {
            Attributes["text"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs TextValue(string value)
        {
            Attributes["text"] = value;
            SetScript();
            return this;
        }

        public SweetAlertBs Text(Func<object, HelperResult> template)
        {
            var html = ComponentUtility.ToJavaScriptString(template(null).ToHtmlString());
            Attributes["text"] = string.Format("{0}", html);
            return Html(true);
        }

        public SweetAlertBs Type(string value)
        {
            Attributes["type"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs Type(SweetAlertType type)
        {
            if (type != SweetAlertType.Default)
                Attributes["type"] = string.Format("'{0}'", type.ToString().ToLower());
            SetScript();
            return this;
        }

        public SweetAlertBs ConfirmButtonText(string value)
        {
            Attributes["confirmButtonText"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs ConfirmButtonColor(string value)
        {
            Attributes["confirmButtonColor"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs CancelButtonText(string value)
        {
            Attributes["cancelButtonText"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs ImageUrl(string url)
        {
            Attributes["imageUrl"] = string.Format("'{0}'", url);
            SetScript();
            return this;
        }

        public SweetAlertBs ImageSize(int width, int height)
        {
            Attributes["imageSize"] = string.Format("'{0}x{1}'", width, height);
            SetScript();
            return this;
        }

        public SweetAlertBs Timer(int milisecond)
        {
            Attributes["timer"] = milisecond;
            SetScript();
            return this;
        }

        public SweetAlertBs Animation(SweetAlertAnimation value)
        {
            switch (value)
            {
                case SweetAlertAnimation.SlideFromTop:
                    Attributes["animation"] = string.Format("'{0}'", "slide-from-top");
                    break;
                case SweetAlertAnimation.SlideFromBootom:
                    Attributes["animation"] = string.Format("'{0}'", "slide-from-bottom");
                    break;
                case SweetAlertAnimation.PopDefault:
                    Animation(true);
                    break;
            }
            SetScript();
            return this;
        }

        public SweetAlertBs InputType(string value)
        {
            Attributes["inputType"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs InputPlaceholder(string value)
        {
            Attributes["inputPlaceholder"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs InputValue(string value)
        {
            Attributes["inputValue"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlertBs AllowEscapeKey(bool value)
        {
            Attributes["allowEscapeKey"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs AllowOutsideClick(bool value)
        {
            Attributes["allowOutsideClick"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs ShowCancelButton(bool value)
        {
            Attributes["showCancelButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs ShowConfirmButton(bool value)
        {
            Attributes["showConfirmButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs CloseOnConfirm(bool value)
        {
            Attributes["closeOnConfirm"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs CloseOnCancel(bool value)
        {
            Attributes["closeOnCancel"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs Html(bool value)
        {
            Attributes["html"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs Animation(bool value)
        {
            Attributes["animation"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs ShowLoaderOnConfirm(bool value)
        {
            Attributes["showLoaderOnConfirm"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlertBs ConfirmButtonClass(string value)
        {
            Attributes["confirmButtonClass"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            var script = "swal(" + this.RenderOptions() + (string.IsNullOrEmpty(function) ? "" : ", " + function) + ")";
            Script = script;
            if (!HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest() && htmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}