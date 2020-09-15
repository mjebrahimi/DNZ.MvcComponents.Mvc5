using Savosh.Component;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.JasnyUploader.css.jasny-bootstrap.css", "text/css")]
[assembly: WebResource("Savosh.Component.JasnyUploader.css.jasny-bootstrap.min.css", "text/css")]
[assembly: WebResource("Savosh.Component.JasnyUploader.js.jasny-bootstrap.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.JasnyUploader.js.jasny-bootstrap.min.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar1.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar2.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar3.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar4.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar5.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar6.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar7.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar8.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar9.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar10.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar11.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar12.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar13.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar14.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar15.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar16.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar17.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar18.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar19.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar20.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar21.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar22.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar23.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar24.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar25.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar26.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar27.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoAvatar28.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoImage1.gif", "image/gif")]
[assembly: WebResource("Savosh.Component.JasnyUploader.img.NoImage2.gif", "image/gif")]
namespace System.Web.Mvc
{
    public class JasnyUploaderOption<TModel, TValue> : IOptionBuilder, IHtmlString
    {
        private const string jasny_bootstrap_css = "Savosh.Component.JasnyUploader.css.jasny-bootstrap.css";
        private const string jasny_bootstrap_css_min = "Savosh.Component.JasnyUploader.css.jasny-bootstrap.min.css";
        private const string jasny_bootstrap_js = "Savosh.Component.JasnyUploader.js.jasny-bootstrap.js";
        private const string jasny_bootstrap_min_js = "Savosh.Component.JasnyUploader.js.jasny-bootstrap.min.js";

        public HtmlHelper<TModel> HtmlHelper { get; set; }
        public Expression<Func<TModel, TValue>> Expression { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
        public bool JustPartial { get; set; }
        private string accept;

        public JasnyUploaderOption(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            HtmlHelper = htmlHelper;
            Expression = expression;
            Attributes = new Dictionary<string, object>();
            SelectText("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-check'></i> انتخاب تصویر&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            ChangeText("تغییر");
            RemoveText("حذف");
            SelectIcon(""); //fa fa-check
            ChangeIcon("fa fa-repeat"); //fa fa-repeat
            RemoveIcon("fa fa-times"); //fa fa-times
            SelectChangeClass("btn btn-primary");
            RemoveClass("btn btn-danger");
            FixSize(true);
            AutoUpload(true);
            DefaultPreview(true);
            DefaultImage(JasnyDefaultImage.NoImage2);
            Width(200);
            Height(150);
            UploadUrl("");
            LoadingImage(JasnyLoading.Default1);
        }

        public JasnyUploaderOption<TModel, TValue> SetJustPartial()
        {
            JustPartial = true;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> Accept(string value)
        {
            accept = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> SelectText(string value)
        {
            Attributes["selectText"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> SelectIcon(string value)
        {
            Attributes["selectIcon"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> ChangeText(string value)
        {
            Attributes["changeText"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> ChangeIcon(string value)
        {
            Attributes["changeIcon"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> RemoveText(string value)
        {
            Attributes["removeText"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> RemoveIcon(string value)
        {
            Attributes["removeIcon"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> SelectChangeClass(string value)
        {
            Attributes["selectChangeClass"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> RemoveClass(string value)
        {
            Attributes["removeClass"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> FixSize(bool value)
        {
            Attributes["fixSize"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> AutoUpload(bool value)
        {
            Attributes["autoUpload"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> DefaultPreview(bool value)
        {
            Attributes["defaultPreview"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> DefaultImage(string value)
        {
            Attributes["defaultImage"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> DefaultImage(JasnyDefaultImage value)
        {
            var resource = string.Format("Savosh.Component.JasnyUploader.img.{0}.gif", value.ToString());
            Attributes["defaultImage"] = ComponentUtility.GetWebResourceUrl(resource);
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> LoadingImage(JasnyLoading value)
        {
            Attributes["loadingImage"] = value.ToString().ToLower();
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> Width(int value)
        {
            Attributes["width"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> Height(int value)
        {
            Attributes["height"] = value;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> UrlImage(string url)
        {
            Attributes["urlImage"] = url;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrl(string url)
        {
            Attributes["uploadUrl"] = url;
            return this;
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action);
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, routeValues);
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, string controller)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller);
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, string controller, object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            return UploadUrl(url);
        }

        public JasnyUploaderOption<TModel, TValue> UploadUrlAction(string action, string controller, RouteValueDictionary routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            return UploadUrl(url);
        }

        public string ToHtmlString()
        {
            var metadata = ModelMetadata.FromLambdaExpression(Expression, HtmlHelper.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(Expression);
            var label = HtmlHelper.LabelFor(Expression, new { @class = "control-label", style = "padding: 0 0 10px 0;" });
            var id = Savosh.Utility.WebHelper.FieldIdFor(HtmlHelper, Expression); //.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
            var name = HtmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            var value = (metadata.Model ?? "").ToString();

            var script = "";
            if (JustPartial)
            {
                script += "<link href=\"" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_css) + "\" rel=\"stylesheet\" />\n\n";
                script += "<script src=\"" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_js) + "\"></script>\n";
            }
            else
            {
                HtmlHelper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_css) + @""" rel=""stylesheet"" />");
                HtmlHelper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(jasny_bootstrap_js) + @"""></script>");
            }
            var url = Attributes["uploadUrl"].ToString();
            var selectIcon = Attributes["selectIcon"].ToString() == "" ? "" : string.Format(@"<i class=""{0}""></i> ", Attributes["selectIcon"]);
            var changeIcon = Attributes["changeIcon"].ToString() == "" ? "" : string.Format(@"<i class=""{0}""></i> ", Attributes["changeIcon"]);
            var removeIcon = Attributes["removeIcon"].ToString() == "" ? "" : string.Format(@"<i class=""{0}""></i> ", Attributes["removeIcon"]);
            var urlImage = Attributes["urlImage"].ToString();
            var defaultImageValue = Attributes["defaultImage"].ToString();
            if (/*urlImage != "" && */value != "")
            {
                defaultImageValue = urlImage.Contains("{0}") ? string.Format(urlImage, value) : (urlImage + value);
            }
            var defaultImage = Attributes["defaultImage"].ToString() == "" ? "" : $@"<img src=""{defaultImageValue}"" />";
            var autoUpload = Convert.ToBoolean(Attributes["autoUpload"]);
            var width = Attributes["width"] + "px";
            var height = Attributes["height"] + "px";
            var max = Convert.ToBoolean(Attributes["fixSize"]) ? "" : "max-";
            var styles = $"{max}width: {width}; {max}height: {height};";

            script += @"
            <script>
                $(function(){
                    var changedCount = 0;
                    var clearedCount = 0;
                    $(""#" + id + @"_jasnyUpload"").jasnyfileinput()" + ((autoUpload && url != "") ? @"
                    .on(""change.bs.fileinput"", function () {
                        $('<div class=""jasny-loading " + Attributes["loadingImage"] + @""" ></div>').insertAfter($(this).find("".fileinput-preview img""));
                        var hidden = $(""#" + id + @""");
                        hidden.val('');
                        var data = new FormData();
                        data.append('file', $(""#" + id + @"_jasnyFile"")[0].files[0]);
                        $.ajax({
                            url: '" + url + @"',
                            type: 'POST',
                            data: data,
                            cache: false,
                            contentType: false,
                            processData: false,
                            success: function (response) {
                                $(""#" + id + @"_jasnyUpload "").find("".jasny-loading." + Attributes["loadingImage"] + @""").remove();
                                hidden.val(response).valid();
                            }
                        });
                    }).on(""clear.bs.fileinput"", function () {
                        $(""#" + id + @""").val('" + (value != "" ? value : "") + @"').valid();
                    });" : "") + @"
                });
            </script>";

            var defaultPreview = Convert.ToBoolean(Attributes["defaultPreview"]) ?
                    $@"<div class=""fileinput-new thumbnail"" style=""width:{width}; height: {height}"">
                        {defaultImage}
                    </div>" : "";
            var result = $@"
            <div id=""{id}_jasnyUpload"" class=""fileinput fileinput-new text-center"" data-provides=""fileinput"">
                <div>{label }</div>
                    {defaultPreview}
                    <div class=""fileinput-preview fileinput-exists thumbnail"" style=""{styles}""></div>
                <div>
                    <span class=""{Attributes["selectChangeClass"]} btn-file"">
                        <span class=""fileinput-new"">{selectIcon}{Attributes["selectText"]}</span>
                        <span class=""fileinput-exists"">{changeIcon}{Attributes["changeText"]}</span>
                        <input type=""file"" id=""{id}_jasnyFile"" name=""{(autoUpload ? "file" : name)}"" accept=""{accept}"">
                    </span>
                    <a href=""#"" class=""{Attributes["removeClass"]} fileinput-exists"" data-dismiss=""fileinput"">{removeIcon}{Attributes["removeText"]}</a>
                </div>
                {(autoUpload ? HtmlHelper.HiddenFor(Expression, new { id }).ToHtmlString() : "")}
            </div>";

            if (JustPartial)
                result += Environment.NewLine + Environment.NewLine + script;
            else
                HtmlHelper.Script(script);

            return result;
        }
    }
}
