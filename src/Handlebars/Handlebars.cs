using System.Web.WebPages;

namespace System.Web.Mvc
{
    public static class Handlebars
    {
        public static HanderBarTemplate AddHandlebarsPlugin(this HtmlHelper helper)
        {
            return new HanderBarTemplate(helper);
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this HtmlHelper helper, Func<object, HelperResult> template)
        {
            var html = template(null).ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = MvcHtmlString.Create(html);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplateInlineHelper(this HtmlHelper helper, HelperResult template)
        {
            var html = template.ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = MvcHtmlString.Create(html);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this HtmlHelper helper, string template)
        {
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Html = MvcHtmlString.Create(template);
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this HtmlHelper helper, string id, Func<object, HelperResult> template)
        {
            var html = template(null).ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = MvcHtmlString.Create(html);
            helper.ScriptSingle(id, @"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + html + @"
</script>
");
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplateInlineHelper(this HtmlHelper helper, string id, HelperResult template)
        {
            var html = template.ToHtmlString();
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = MvcHtmlString.Create(html);
            helper.ScriptSingle(id, @"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + html + @"
</script>
");
            return handlebar;
        }

        public static HanderBarTemplate CreateHandlebarsTemplate(this HtmlHelper helper, string id, string template)
        {
            var handlebar = helper.AddHandlebarsPlugin();
            handlebar.Id = id;
            handlebar.Html = MvcHtmlString.Create(template);
            helper.ScriptSingle(id, @"
<script id=""" + id + @""" type=""text/x-handlebars-template"">
    " + template.Replace("\t", "") + @"
</script>");
            return handlebar;
        }
    }
}