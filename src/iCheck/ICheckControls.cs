using Savosh.Component;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.iCheck.all.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Savosh.Component.iCheck.minimal._all.css", "text/css")]
[assembly: WebResource("Savosh.Component.iCheck.square._all.css", "text/css")]
[assembly: WebResource("Savosh.Component.iCheck.flat._all.css", "text/css")]
[assembly: WebResource("Savosh.Component.iCheck.line._all.css", "text/css")]
[assembly: WebResource("Savosh.Component.iCheck.polaris.polaris.css", "text/css")]
[assembly: WebResource("Savosh.Component.iCheck.futurico.futurico.css", "text/css")]
[assembly: WebResource("Savosh.Component.iCheck.icheck.min.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.iCheck.icheck.custom.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class ICheckControls
    {
        private const string iCheck_all_css = "Savosh.Component.iCheck.all.css";
        private const string iCheck_js = "Savosh.Component.iCheck.icheck.min.js";
        private const string iCheck_custom_js = "Savosh.Component.iCheck.icheck.custom.js";

        public static MvcHtmlString ICheckRadioButtonFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, string label = null, object value = null, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            //var displayName = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //var name = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            var id = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            var cssClass = " " + style.ToString().ToLower().Replace('_', '-');
            if (value == null)
                value = "";
            var result =
    html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(iCheck_all_css) + @""" rel=""stylesheet"" />")
    + @"
<label for=""" + id + "_" + Guid.NewGuid() + @""">
    " + html.RadioButtonFor(expression, value, new { @class = "icheck" + cssClass, id = id + "_" + Guid.NewGuid() }) + @"
    " + (string.IsNullOrEmpty(icon) ? "" : @"<i class=""fa " + icon + @""" style=""font-size: large;""></i>") + " " + label + @"
</label>"
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_js) + @"""></script>")
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_custom_js) + @"""></script>");
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString ICheckRadioButtonsFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, List<Tuple<string, string, string>> values, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null)
        {
            var col = Math.Floor(12 / (decimal)values.Count);
            var result = "";
            foreach (var item in values)
            {
                result += @"
<div class=""col-sm-" + col + @""" style=""padding: 0"">
" + html.ICheckRadioButtonFor(expression, item.Item1, item.Item2, style, item.Item3) + @"
</div>" + Environment.NewLine;
            }
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString ICheckCheckBoxFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, string label = null, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null, object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            //var displayName = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //var name = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            var id = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            var cssClass = " " + style.ToString().ToLower().Replace('_', '-');
            var attributes = ComponentUtility.MergeAttributes(htmlAttributes, new { @class = "icheck" + cssClass, id = id + "_" + Guid.NewGuid() });

            var result =
    html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(iCheck_all_css) + @""" rel=""stylesheet"" />")
    + @"
<label for=""" + id + "_" + Guid.NewGuid() + @""">
    " + html.CheckBoxFor(expression, attributes) + @"
    " + (string.IsNullOrEmpty(icon) ? "" : @"<i class=""fa " + icon + @""" style=""font-size: large;""></i>") + " " + label + @"
</label>"
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_js) + @"""></script> ")
     + html.ScriptFileSingle(@" <script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_custom_js) + @"""></script> ");
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString ICheckCheckBox<TModel>(this HtmlHelper<TModel> html, string name, string label = null, bool value = false, ICheckStyle style = ICheckStyle.Flat_Blue, string icon = null, object htmlAttributes = null)
        {
            var id = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(name);
            var cssClass = style.ToString().ToLower().Replace('_', '-');

            html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(iCheck_all_css) + @""" rel=""stylesheet"" />");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_js) + @"""></script>");
            html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(iCheck_custom_js) + @"""></script>");

            var attributes = ComponentUtility.MergeAttributes(new { @class = $"icheck {cssClass}", id }, htmlAttributes);
            var radioButton = html.CheckBox(name, value, attributes);
            var iconTag = string.IsNullOrEmpty(icon) ? "" : $@"<i class=""fa {icon}"" style=""font-size: large;""></i>";
            var result = $@"
            <label for=""{id}"">
                {radioButton}
                {iconTag}
                {label}
            </label>";
            return new MvcHtmlString(result);
        }

    }
}
