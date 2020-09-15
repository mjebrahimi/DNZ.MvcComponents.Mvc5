using Savosh.Component;
using Savosh.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.FileUploader.css.fileinput.css", "text/css")]
[assembly: WebResource("Savosh.Component.FileUploader.css.custom-fileinput.css", "text/css")]
[assembly: WebResource("Savosh.Component.FileUploader.js.fileinput.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.FileUploader.js.fileinput_locale_fa.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class BootstrapUploadHelper
    {
        private const string fileinput_css = "Savosh.Component.FileUploader.css.fileinput.css";
        private const string custom_fileinput_css = "Savosh.Component.FileUploader.css.custom-fileinput.css";
        private const string fileinput_js = "Savosh.Component.FileUploader.js.fileinput.js";
        private const string fileinput_locale_fa_js = "Savosh.Component.FileUploader.js.fileinput_locale_fa.js";

        public static MvcHtmlString BsUploadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string action = null, string controller = null, object routeValues = null, string urlImages = null)
        {
            var setting = new BsUploadSetting();
            return html.BsUploadFor(expression, setting, action, controller, routeValues, urlImages);
        }

        public static MvcHtmlString BsUploadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, BsUploadSetting setting, string action = null, string controller = null, object routeValues = null, string urlImages = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var property = ExpressionHelper.GetExpressionText(expression);
            var displayName = metadata.DisplayName ?? metadata.PropertyName ?? property.Split('.').Last();
            var value = metadata.Model;
            var id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(property);
            var name = html.ViewData.TemplateInfo.GetFullHtmlFieldName(property);
            var label = html.LabelFor(expression, new { @class = "control-label" });
            var input = new TagBuilder("input");
            input.Attributes.Add("type", "file");
            input.Attributes.Add("id", id);
            input.Attributes.Add("name", "file");
            input.Attributes.Add("multiple", "");
            input.Attributes.Add("class", "file-loading");
            var file = MvcHtmlString.Create(input.ToString());
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            if (action != null && controller != null)
            {
                var url = urlHelper.Action(action, controller, routeValues);
                setting.UploadUrl(url);
                if (urlImages.HasValue())
                {
                    //compatible url: "/home/images" or queryString: "/home/images/?image_id="
                    if (!urlImages.Contains("{0}"))
                        urlImages = urlImages.Contains("?") ? urlImages : urlImages.TrimEnd('/') + '/';
                    var initialPreview = new BsUploadInitialPreview();
                    var initialPreviewConfig = new BsUploadInitialPreviewConfig();
                    foreach (var item in (value as IEnumerable<int>))
                    {
                        var imgSrc = urlImages.Contains("{0}") ? string.Format(urlImages, item) : (urlImages + item);
                        initialPreview.Add(imgSrc, new { key = item });
                        initialPreviewConfig.Add("", url, item);
                    }
                    setting.InitialPreview(initialPreview);
                    setting.InitialPreviewConfig(initialPreviewConfig);
                }
            }
            

            var result = @"
<div id=""" + id + @"_fileuploader_container"">
    " + label + @"
    " + file + @"
    <div id=""" + id + @"_hidden""></div>
</div>

" + html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(fileinput_css) + @""" rel=""stylesheet"" />") + @"
" + html.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(custom_fileinput_css) + @""" rel=""stylesheet"" />") + @"

" + html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(fileinput_js) + @"""></script>") + @"
" + html.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(fileinput_locale_fa_js) + @"""></script>") + @"

" + html.Script(@"
<script>
        $(function () {
            $(""#" + id + @""").fileinput(" + setting.RenderOptions() + ")"
            +
            (Convert.ToBoolean(setting.Attributes["uploadAsync"]) ?
            @".on('filebatchselected', function (event, files) {
                $(this).fileinput('upload');
            }).on('filedeleted', function (event, key) {
                $('#" + id + @"_fileuploader_hidden_' + key).remove();
            }).on('fileuploaded', function (event, data, previewId, index) {
                var key = data.response
                $(""#" + id + @"_hidden"").append($('<input/>', { type: 'hidden', id: '" + id + "_fileuploader_hidden_' + key, value: key, name: '" + name + @"' }));
                $(""#" + id + @"_fileuploader_container div.file-preview-thumbnails #"" + previewId + "" button.kv-file-remove"").attr(""data-key"", key);
            }).on('filesuccessremove', function (event, id) {
                var key = $('#' + id + '  button.kv-file-remove').attr(""data-key"")
                $('#" + id + @"_fileuploader_hidden_' + key).remove();
            });
            $(""#" + id + @"_fileuploader_container .file-preview-frame.file-preview-initial img"").each(function () {
                var previewkey = $(this).attr(""key"");
                $(""#" + id + @"_hidden"").append($('<input/>', { type: 'hidden', id: '" + id + "_fileuploader_hidden_' + previewkey, value: previewkey, name: '" + name + @"' }))
            });" : "")
            +
        @"})
    </script>
");
            return MvcHtmlString.Create(result);
        }
    }
}

