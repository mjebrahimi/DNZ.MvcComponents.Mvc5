using System.Linq;
using System.Web.WebPages;

namespace System.Web.Mvc
{
    public class Dialog : MessageBoxResult, IHtmlString
    {
        private string id;
        private string method;
        private string size;
        private string animation;
        private string type;
        private string title;
        private string body;
        private string buttons;

        public Dialog(string id = null, HtmlHelper helper = null) : base(helper)
        {
            this.id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            Animation("fade");
        }

        public MvcHtmlString ShowOnClick()
        {
            return MvcHtmlString.Create("data-toggle=\"modal\" data-target=\"#" + id + "\"");
        }

        public Dialog Id(string value)
        {
            id = value;
            SetScript();
            return this;
        }

        public Dialog Show()
        {
            method = "show";
            SetScript();
            return this;
        }

        public Dialog Toggle()
        {
            method = "toggle";
            SetScript();
            return this;
        }

        public Dialog Hide()
        {
            method = "hide";
            SetScript();
            return this;
        }

        public Dialog HandleUpdate()
        {
            method = "handleUpdate";
            SetScript();
            return this;
        }

        public Dialog OnShow(string value)
        {
            Attributes["show.bs.modal"] = value;
            SetScript();
            return this;
        }

        public Dialog OnShown(string value)
        {
            Attributes["shown.bs.modal"] = value;
            SetScript();
            return this;
        }

        public Dialog OnHide(string value)
        {
            Attributes["hide.bs.modal"] = value;
            SetScript();
            return this;
        }

        public Dialog OnHidden(string value)
        {
            Attributes["hidden.bs.modal"] = value;
            SetScript();
            return this;
        }

        public Dialog OnLoaded(string value)
        {
            Attributes["loaded.bs.modal"] = value;
            SetScript();
            return this;
        }

        public Dialog Size(DialogSize value)
        {
            switch (value)
            {
                case DialogSize.Small:
                    size = " bs-example-modal-sm";
                    break;
                case DialogSize.Large:
                    size = " bs-example-modal-lg";
                    break;
                case DialogSize.Normal:
                    size = " ";
                    break;
            }
            return this;
        }

        public Dialog Type(DialogType value)
        {
            type = "panel-" + value.ToString().ToLower();
            return this;
        }

        public Dialog Title(string value)
        {
            title = value;
            return this;
        }

        public Dialog Body(Func<object, HelperResult> template)
        {
            return Body<object>(template, null);
            //body = template(null).ToHtmlString();
            //return this;
        }

        public Dialog Body<T>(Func<T, HelperResult> template, T item)
        {
            body = template(item).ToHtmlString();
            return this;
        }

        public Dialog Body(string content)
        {
            body = content;
            return this;
        }

        public Dialog Animation(string value)
        {
            animation = value;
            return this;
        }

        public Dialog Buttons(Func<object, HelperResult> template)
        {
            return Buttons<object>(template, null);
            //buttons = template(null).ToHtmlString();
            //return this;
        }

        public Dialog Buttons<T>(Func<T, HelperResult> template, T item)
        {
            buttons = template(item).ToHtmlString();
            return this;
        }

        public Dialog Buttons(string template)
        {
            buttons = template;
            return this;
        }

        protected void SetScript()
        {
            var script = "";
            if (!string.IsNullOrEmpty(method))
                script += ".modal('" + method + "')";
            script += string.Join("", Attributes.Select(p => ".on('" + p.Key + "', " + p.Value + ")"));
            Script = script == "" ? "" : "$('#" + id + "')" + script;
            if (!HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest() && htmlHelper == null)
            {
                SetScriptTag();
            }
        }

        public new string ToHtmlString()
        {
            base.ToHtmlString();

            var result =
    @"<div id=""" + id + @""" class=""modal " + animation + " " + size + @""" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content " + type + @""">
            <div class=""modal-header panel-heading"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <h4 class=""modal-title"">" + title + @"</h4>
            </div>
            <div class=""modal-body"">
                " + body + @"
            </div>
            <div class=""modal-footer"">
                " + buttons + @"
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div><!-- /.modal -->";

            return result;
        }
    }
}

