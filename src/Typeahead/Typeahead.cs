using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public class TypeaheadAjax : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }
        public TypeaheadAjax()
        {
            Attributes = new Dictionary<string, object>();
        }


        public TypeaheadAjax Url(string value)
        {
            Attributes["url"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadAjax UrlAction(string action)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action);
            return Url(url);
        }

        public TypeaheadAjax UrlAction(string action, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            return Url(url);
        }

        public TypeaheadAjax UrlAction(string action, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            return Url(url);
        }

        public TypeaheadAjax UrlAction(string action, string controller)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller);
            return Url(url);
        }

        public TypeaheadAjax UrlAction(string action, string controller, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            Url(url);
            return this;
        }

        public TypeaheadAjax UrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            return Url(url);
        }

        public TypeaheadAjax Timeout(int value)
        {
            Attributes["timeout"] = value;
            return this;
        }

        public TypeaheadAjax Method(FormMethod value)
        {
            Attributes["method"] = string.Format("'{0}'", value.ToString());
            return this;
        }

        public TypeaheadAjax TriggerLength(int value)
        {
            Attributes["triggerLength"] = value;
            return this;
        }

        public TypeaheadAjax LoadingClass(string value)
        {
            Attributes["loadingClass"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadAjax DisplayField(string value)
        {
            Attributes["displayField"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadAjax ValueField(string value)
        {
            Attributes["valueField"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadAjax PreDispatch(string value)
        {
            Attributes["preDispatch"] = value;
            return this;
        }

        public TypeaheadAjax PreProcess(string value)
        {
            Attributes["preProcess"] = value;
            return this;
        }

        public TypeaheadAjax Parameter(string value)
        {
            Attributes["preDispatch"] = @"function (query) {
	                                    return {
		                                    " + value + @":query
	                                    }
                                    }";
            return this;
        }
    }
}