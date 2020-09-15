using Savosh.Component;
using System.Web.UI;
using System.Web.WebPages;

[assembly: WebResource("Savosh.Component.SweetAlert.sweetalert.css", "text/css")]
[assembly: WebResource("Savosh.Component.SweetAlert.sweetalert-dev.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.SweetAlert.sweetalert.min.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class SweetAlert : MessageBoxResult
    {
        private const string sweetalert_css = "Savosh.Component.SweetAlert.sweetalert.css";
        private const string sweetalert_js = "Savosh.Component.SweetAlert.sweetalert-dev.js";
        private const string sweetalert_min_js = "Savosh.Component.SweetAlert.sweetalert.min.js";
        private string function;

        public SweetAlert(HtmlHelper helper = null) : base(helper)
        {
            RenderScriptAndStyle.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(sweetalert_css) + @""" rel=""stylesheet"" />");
            RenderScriptAndStyle.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(sweetalert_js) + @"""></script>");
        }

        public SweetAlert Function(string value)
        {
            function = value;
            SetScript();
            return this;
        }

        public SweetAlert Title(string value)
        {
            Attributes["title"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert Title(Func<object, HelperResult> template)
        {
            var html = ComponentUtility.ToJavaScriptString(template(null).ToHtmlString());
            Attributes["title"] = string.Format("{0}", html);
            return Html(true);
        }

        public SweetAlert Text(string value)
        {
            Attributes["text"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert TextValue(string value)
        {
            Attributes["text"] = value;
            SetScript();
            return this;
        }

        public SweetAlert Text(Func<object, HelperResult> template)
        {
            var html = ComponentUtility.ToJavaScriptString(template(null).ToHtmlString());
            Attributes["text"] = string.Format("{0}", html);
            return Html(true);
        }

        public SweetAlert Type(string value)
        {
            Attributes["type"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert Type(SweetAlertType type)
        {
            if (type != SweetAlertType.Default)
                Attributes["type"] = string.Format("'{0}'", type.ToString().ToLower());
            SetScript();
            return this;
        }

        public SweetAlert ConfirmButtonText(string value)
        {
            Attributes["confirmButtonText"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert ConfirmButtonColor(string value)
        {
            Attributes["confirmButtonColor"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert CancelButtonText(string value)
        {
            Attributes["cancelButtonText"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert ImageUrl(string url)
        {
            Attributes["imageUrl"] = string.Format("'{0}'", url);
            SetScript();
            return this;
        }

        public SweetAlert ImageSize(int width, int height)
        {
            Attributes["imageSize"] = string.Format("'{0}x{1}'", width, height);
            SetScript();
            return this;
        }

        public SweetAlert Timer(int milisecond)
        {
            Attributes["timer"] = milisecond;
            SetScript();
            return this;
        }

        public SweetAlert Animation(SweetAlertAnimation value)
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

        public SweetAlert InputType(string value)
        {
            Attributes["inputType"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert InputPlaceholder(string value)
        {
            Attributes["inputPlaceholder"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert InputValue(string value)
        {
            Attributes["inputValue"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public SweetAlert AllowEscapeKey(bool value)
        {
            Attributes["allowEscapeKey"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert AllowOutsideClick(bool value)
        {
            Attributes["allowOutsideClick"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert ShowCancelButton(bool value)
        {
            Attributes["showCancelButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert ShowConfirmButton(bool value)
        {
            Attributes["showConfirmButton"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert CloseOnConfirm(bool value)
        {
            Attributes["closeOnConfirm"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert CloseOnCancel(bool value)
        {
            Attributes["closeOnCancel"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert Html(bool value)
        {
            Attributes["html"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert Animation(bool value)
        {
            Attributes["animation"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public SweetAlert ShowLoaderOnConfirm(bool value)
        {
            Attributes["showLoaderOnConfirm"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            Script = "swal(" + this.RenderOptions() + (string.IsNullOrEmpty(function) ? "" : ", " + function) + ")";
            if (!HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest() && htmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}