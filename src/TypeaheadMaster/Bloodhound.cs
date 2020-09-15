using Savosh.Component;
using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public class Bloodhound : IOptionBuilder, IHtmlString, IScript
    {
        public Dictionary<string, object> Attributes { get; set; }

        public Bloodhound()
        {
            Attributes = new Dictionary<string, object>();
            DatumTokenizer();
            QueryTokenizer();
        }

        public Bloodhound DatumTokenizer(string value = "whitespace")
        {
            Attributes["datumTokenizer"] = "Bloodhound.tokenizers." + value;
            return this;
        }

        public Bloodhound QueryTokenizer(string value = "whitespace")
        {
            Attributes["queryTokenizer"] = "Bloodhound.tokenizers." + value;
            return this;
        }


        public Bloodhound Local(string value)
        {
            Attributes["local"] = value;
            return this;
        }

        public Bloodhound Local(IEnumerable<string> source)
        {
            var value = ComponentUtility.ToJsonString(source);
            Attributes["local"] = value;
            return this;
        }

        public Bloodhound Prefetch(string url)
        {
            Attributes["prefetch"] = "\"" + url + "\"";
            return this;
        }

        public Bloodhound RemoteUrl(string url)
        {
            var urlWithQuery = "";
            if (url.Contains("{0}")) //compatibel with "../%QUERY.json"
                urlWithQuery = string.Format(url, "%QUERY");
            else
                urlWithQuery = url.Contains("?") ? url : (url.TrimEnd('/') + '/') + "%QUERY";
            var result = @"{
                    url: """ + urlWithQuery + @""",
                    wildcard: '%QUERY'
                }";
            Attributes["remote"] = result;
            return this;
        }

        public Bloodhound RemoteUrlAction(string action)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action);
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, string controller)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller);
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, string controller, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            RemoteUrl(url);
            return this;
        }

        public Bloodhound RemoteUrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            RemoteUrl(url);
            return this;
        }

        public string ToHtmlString()
        {
            return "";
        }

        public string Script
        {
            get
            {
                return string.Format("new Bloodhound({0})", this.RenderOptions());
            }
        }
    }
}