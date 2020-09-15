using Savosh.Component;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.Typeahead.bootstrap-typeahead.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.Typeahead.bootstrap-typeahead.min.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class TypeaheadHelper
    {
        private const string typeahead_js = "Savosh.Component.Typeahead.bootstrap-typeahead.js";
        private const string typeahead_min_js = "Savosh.Component.Typeahead.bootstrap-typeahead.min.js";

        public static MvcHtmlString TypeaheadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            var option = new TypeaheadOption();
            if (source != null)
                option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TypeaheadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, object htmlAttributes = null)
        {
            var option = new TypeaheadOption();
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TypeaheadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, object htmlAttributes = null)
        {
            var option = new TypeaheadOption();
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TypeaheadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, TypeaheadOption option, object htmlAttributes = null)
        {
            if (source != null)
                option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TypeaheadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, TypeaheadOption option, object htmlAttributes = null)
        {
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TypeaheadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, TypeaheadOption option, object htmlAttributes = null)
        {
            option.Source(source);
            return html.TypeaheadFor(expression, option, htmlAttributes);
        }

        public static MvcHtmlString TypeaheadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, TypeaheadOption option, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            var name = html.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            var value = (metadata.Model ?? "").ToString();
            var txtValue = "";
            option.Dictionary.TryGetValue(value, out txtValue);
            var displayName = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, new { id = id + "_typeahead", @class = "form-control", placeholder = displayName, autocomplete = "off" });
            var textbox = html.TextBox(name + "_typeahead", txtValue, mergAttr);
            var hidden = html.HiddenFor(expression);
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(typeahead_js) + @"""></script>");
            option.OnSelect(@"function(item) {
                            if ( item.value != ""-21"") {
                                $(""#" + id + @""").val(item.value).trigger('change').valid();
                            }
                        }");
            html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @"_typeahead"").typeahead(" + option.RenderOptions() + @")
                    .keypress(function(){
                        $(""#" + id + @""").val('').trigger('change').valid();
                    });
                });
            </script>");
            return MvcHtmlString.Create(textbox.ToHtmlString() + hidden.ToHtmlString());
        }
    }
}