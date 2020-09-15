using Savosh.Component;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.TagAutocomplete.bootstrap-typeahead.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.TagAutocomplete.rangy-core.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.TagAutocomplete.caret-position.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.TagAutocomplete.bootstrap-tagautocomplete.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class TagAutocompleteHelper
    {
        private const string Bootstrap_Typeahead_js = "Savosh.Component.TagAutocomplete.bootstrap-typeahead.js";
        private const string Rangy_Core_js = "Savosh.Component.TagAutocomplete.rangy-core.js";
        private const string Caret_Position_js = "Savosh.Component.TagAutocomplete.caret-position.js";
        private const string Bootstrap_Tagautocomplete_js = "Savosh.Component.TagAutocomplete.bootstrap-tagautocomplete.js";

        public static MvcHtmlString TagAutocompleteFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            var option = new TagAutocompleteOption();
            if (source != null)
                option.Source(source);
            return html.TagAutocompleteFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TagAutocompleteFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, TagAutocompleteOption option, object htmlAttributes = null)
        {
            if (source != null)
                option.Source(source);
            return html.TagAutocompleteFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TagAutocompleteFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, TagAutocompleteOption option, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            var divId = id + "_autotag";
            var value = metadata.Model ?? "";
            var tag = new TagBuilder("div");
            tag.AddCssClass("form-control");
            tag.Attributes.Add("contenteditable", "true");
            tag.Attributes.Add("id", id + "_autotag");
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.SetInnerText(value.ToString());
            var editor = html.HiddenFor(expression);

            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Bootstrap_Typeahead_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Rangy_Core_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Caret_Position_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Bootstrap_Tagautocomplete_js) + @"""></script>");
            html.Script(@"
            <script>
                $(function(){
                    $(""#" + divId + @""").tagautocomplete(" + option.RenderOptions() + @");
                });
            </script>");
            return MvcHtmlString.Create(tag + "\n" + editor);
        }
    }
}