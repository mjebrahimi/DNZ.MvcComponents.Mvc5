using Savosh.Component;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.TypeaheadMaster.typeahead.css", "text/css")]
[assembly: WebResource("Savosh.Component.TypeaheadMaster.typeahead.jquery.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.TypeaheadMaster.bloodhound.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.TypeaheadMaster.typeahead.bundle.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class TypeaheadMaster
    {
        private const string typeahead_css = "Savosh.Component.TypeaheadMaster.typeahead.css";
        private const string typeahead_jquery_js = "Savosh.Component.TypeaheadMaster.typeahead.jquery.js";
        private const string bloodhound_js = "Savosh.Component.TypeaheadMaster.bloodhound.js";
        private const string typeahead_bundle_js = "Savosh.Component.TypeaheadMaster.typeahead.bundle.js";
        public static MvcHtmlString TypeaheadMasterFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, object htmlAttributes = null)
        {
            var option = new TypeaheadMasterOption();
            if (source != null)
                option.DataSetSource(source);
            return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        }
        //public static MvcHtmlString TypeaheadMasterFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, object htmlAttributes = null)
        //{
        //    var option = new TypeaheadMasterOption();
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}
        //public static MvcHtmlString TypeaheadMasterFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, object htmlAttributes = null)
        //{
        //    var option = new TypeaheadMasterOption();
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}

        public static MvcHtmlString TypeaheadMasterFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<string> source, TypeaheadMasterOption option, object htmlAttributes = null)
        {
            if (source != null)
                option.DataSetSource(source);
            return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        }
        //public static MvcHtmlString TypeaheadMasterFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Dictionary<int, string> source, TypeaheadMasterOption option, object htmlAttributes = null)
        //{
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}
        //public static MvcHtmlString TypeaheadMasterFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable source, TypeaheadMasterOption option, object htmlAttributes = null)
        //{
        //    option.DataSetSource(source);
        //    return html.TypeaheadMasterFor(expression, option, htmlAttributes);
        //}

        public static MvcHtmlString TypeaheadMasterFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, TypeaheadMasterOption option, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            var displayName = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            var mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, new { @class = "form-control", placeholder = displayName, autocomplete = "off" });
            var editor = html.TextBoxFor(expression, mergAttr);
            html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(typeahead_css) + @""" rel=""stylesheet"" />");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(typeahead_bundle_js) + @"""></script>");
            html.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").typeahead(" + option.RenderOptions() + @",
                    " + option.RenderDataSetOptions() + @");
                });
            </script>");
            return editor;
        }

        public static Bloodhound DefinGlobalBloodhound(this HtmlHelper html, string name, Bloodhound bloodhound)
        {
            bloodhound.DefinGlobalJavascriptVariable(html, name);
            return bloodhound;
        }
    }
}