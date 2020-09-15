using System.Web.WebPages;

namespace System.Web.Mvc
{
    public static partial class MessageBox
    {
        public static Dialog Dialog(string id)
        {
            return new Dialog(id);
        }

        public static MvcHtmlString DeleteModal(this HtmlHelper html, long id)
        {
            var controllerName = html.ViewContext.RouteData.Values["controller"].ToString();
            var actionName = html.ViewContext.RouteData.Values["action"].ToString();
            var modalId = string.Format("DeleteModal_{0}_{1}", controllerName, actionName);
            var func = modalId + "(" + id + ");";
            var script = html.Dialog(modalId).Show().Script + "; " + func;
            return MvcHtmlString.Create(script);
        }

        public static MvcHtmlString DeleteModal(this HtmlHelper html, int id, string modalId)
        {
            var func = modalId.Replace('.', '_') + "(" + id + ");";
            var script = html.Dialog(modalId).Show().Script + "; " + func;
            return MvcHtmlString.Create(script);
        }

        public static Dialog Dialog(this HtmlHelper html, string id)
        {
            return new Dialog(id, html);
        }

        public static MvcHtmlString OpenDialog(this HtmlHelper html, string id)
        {
            var script = new Dialog(id, html).Show().Script;
            return MvcHtmlString.Create(script);
        }

        public static Dialog Dialog(string id, string title, Func<object, HelperResult> body, Func<object, HelperResult> buttons)
        {
            return new Dialog(id).Title(title).Body(body).Buttons(buttons);
        }

        public static Dialog Dialog(this HtmlHelper html, string id, string title, Func<object, HelperResult> body, Func<object, HelperResult> buttons)
        {
            return new Dialog(id, html).Title(title).Body(body).Buttons(buttons);
        }

        public static Dialog Dialog<T>(this HtmlHelper html, string id, string title, Func<T, HelperResult> body, Func<T, HelperResult> buttons, T item)
        {
            return new Dialog(id, html).Title(title).Body<T>(body, item).Buttons<T>(buttons, item);
        }

        public static Dialog Dialog(string id, string title, string body, string buttons)
        {
            return new Dialog(id).Title(title).Body(body).Buttons(buttons);
        }
    }
}
