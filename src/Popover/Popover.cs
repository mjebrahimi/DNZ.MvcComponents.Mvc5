﻿using Savosh.Component;
using Savosh.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace System.Web.Mvc
{
    public class Popover : MessageBoxResult, IHtmlString
    {
        private string id;
        private string method;
        public Dictionary<string, object> Options { get; set; }

        public Popover(string id = null, HtmlHelper helper = null) : base(helper)
        {
            this.id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
            Options = new Dictionary<string, object>();
        }

        public Popover Id(string value)
        {
            id = value;
            SetScript();
            return this;
        }

        public Popover Show()
        {
            method = "show";
            SetScript();
            return this;
        }

        public Popover Toggle()
        {
            method = "toggle";
            SetScript();
            return this;
        }

        public Popover Hide()
        {
            method = "hide";
            SetScript();
            return this;
        }

        public Popover Destroy()
        {
            method = "destroy";
            SetScript();
            return this;
        }

        public Popover OnShow(string value)
        {
            Attributes["show.bs.popover"] = value;
            SetScript();
            return this;
        }

        public Popover OnShown(string value)
        {
            Attributes["shown.bs.popover"] = value;
            SetScript();
            return this;
        }

        public Popover OnHide(string value)
        {
            Attributes["hide.bs.popover"] = value;
            SetScript();
            return this;
        }

        public Popover OnHidden(string value)
        {
            Attributes["hidden.bs.popover"] = value;
            SetScript();
            return this;
        }

        public Popover OnLoaded(string value)
        {
            Attributes["inserted.bs.popover"] = value;
            SetScript();
            return this;
        }

        public Popover Animation(bool value)
        {
            Options["animation"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Popover Container(string value)
        {
            Options["container"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Popover Delay(int value)
        {
            Options["delay"] = value;
            SetScript();
            return this;
        }

        public Popover Html(bool value)
        {
            Options["html"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Popover Placement(Placement value)
        {
            Options["placement"] = string.Format("'{0}'", value.ToString().ToLower());
            SetScript();
            return this;
        }

        public Popover Selector(bool value)
        {
            Options["selector"] = value.ToString().ToLower();
            SetScript();
            return this;
        }

        public Popover Template(string value)
        {
            Options["template"] = string.Format("'{0}'", value);
            SetScript();
            return this;
        }

        public Popover Template(Func<object, HelperResult> template)
        {
            Options["template"] = template(null).ToHtmlString().ToJavaScriptString();
            SetScript();
            return this;
        }

        public Popover Trigger(Trigger value)
        {
            var list = new List<string>();
            if (value.HasFlag(Mvc.Trigger.Click))
                list.Add("click");
            if (value.HasFlag(Mvc.Trigger.Focus))
                list.Add("focus");
            if (value.HasFlag(Mvc.Trigger.Hover))
                list.Add("hover");
            if (value.HasFlag(Mvc.Trigger.MouseOver))
                list.Add("mouseover");

            Options["trigger"] = string.Format("'{0}'", string.Join(" ", list));
            SetScript();
            return this;
        }

        public Popover Viewport(string value)
        {
            Options["viewport"] = value;
            SetScript();
            return this;
        }

        protected void SetScript()
        {
            var script = "";
            if (Options.Count > 0)
                script += ".popover(" + Options.RenderOptions() + ")";
            if (method.HasValue())
                script += ".popover('" + method + "')";
            script += string.Join("", Attributes.Select(p => ".on('" + p.Key + "', " + p.Value + ")"));
            Script = script == "" ? "" : "$('#" + id + "')" + script;
            if (!HttpContext.Current.Request.RequestContext.HttpContext.Request.IsAjaxRequest() && htmlHelper == null)
            {
                SetScriptTag();
            }
        }
    }
}