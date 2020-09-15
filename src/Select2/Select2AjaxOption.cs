using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public class Select2AjaxOption : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }
        public Select2AjaxOption()
        {
            Attributes = new Dictionary<string, object>();
        }

        public Select2AjaxOption Delay(int value)
        {
            Attributes["delay"] = value;
            return this;
        }

        public Select2AjaxOption Data(string value = "function (params) { return { term: params.term, page: params.page }; }")
        {
            Attributes["data"] = value;
            return this;
        }

        public Select2AjaxOption Cache(bool value)
        {
            Attributes["cache"] = value.ToString().ToLower();
            return this;
        }

        public Select2AjaxOption DataType(AjaxDataType value)
        {
            Attributes["dataType"] = string.Format("'{0}'", value.ToString().ToLower());
            return this;
        }

        public Select2AjaxOption ProcessResults(string value)
        {
            Attributes["processResults"] = value;
            return this;
        }

        public Select2AjaxOption Url(string value)
        {
            Attributes["url"] = string.Format("'{0}'", value);
            return this;
        }

        public Select2AjaxOption UrlAction(string action)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action);
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, string controller)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller);
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, string controller, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            Url(url);
            return this;
        }

        public Select2AjaxOption UrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            Url(url);
            return this;
        }
    }
}