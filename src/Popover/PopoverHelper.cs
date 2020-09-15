using Savosh.Utility;
using System.Collections.Generic;

namespace System.Web.Mvc
{
    public static class PopoverHelper
    {
        public static MvcHtmlString BsPopover(this HtmlHelper html, string content, string title = "", Placement placement = Placement.Bottom)
        {
            return MvcHtmlString.Create("data-toggle=\"popover\" data-content=\"" + content + "\" " + (string.IsNullOrEmpty(title) ? "" : " title =\"" + title + "\"") + (placement == Placement.Top ? "" : " data-placement=\"" + placement.ToString().ToLower() + "\""));
        }

        public static Dictionary<string, string> BsPopoverAttibutes(this HtmlHelper html, string content, string title = "", Placement placement = Placement.Bottom)
        {
            var dict = new Dictionary<string, string>
            {
                { "data-toggle", "popover" },
                { "data-content", content }
            };
            if (title.HasValue())
                dict.Add("title", title);
            if (placement != Placement.Top)
                dict.Add("data-placement", placement.ToString().ToLower());
            return dict;
        }

        public static Popover Popover(string id)
        {
            return new Popover(id);
        }

        public static Popover Popover(this HtmlHelper html, string id)
        {
            return new Popover(id, html);
        }
    }
}