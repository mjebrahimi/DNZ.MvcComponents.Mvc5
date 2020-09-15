using System.Collections.Generic;

namespace System.Web.Mvc
{
    public static class TooltipHelper
    {
        public static MvcHtmlString BsTooltip(this HtmlHelper html, string title, Placement placement = Placement.Top)
        {
            return MvcHtmlString.Create("data-toggle=\"tooltip\" title=\"" + title + "\"" + (placement == Placement.Top ? "" : " data-placement=\"" + placement.ToString().ToLower() + "\""));
        }

        public static Dictionary<string, string> BsTooltipAttibutes(this HtmlHelper html, string title, Placement placement = Placement.Top)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("data-toggle", "tooltip");
            dict.Add("title", title);
            if (placement != Placement.Top)
                dict.Add("data-placement", placement.ToString().ToLower());
            return dict;
        }

        public static Tooltip Tooltip(string id)
        {
            return new Tooltip(id);
        }

        public static Tooltip Tooltip(this HtmlHelper html, string id)
        {
            return new Tooltip(id, html);
        }
    }
}
