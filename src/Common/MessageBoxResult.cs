using System.Collections.Generic;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.Noty.jquery.noty.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.jquery.noty.packaged.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.Noty.jquery.noty.packaged.min.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class MessageBoxResult : JavaScriptResult, IHtmlString, IOptionBuilder
    {
        protected string guid;
        protected HtmlHelper htmlHelper;
        public Dictionary<string, object> Attributes { get; set; }
        public MvcHtmlString Js => MvcHtmlString.Create(Script);

        public MessageBoxResult(HtmlHelper helper)
        {
            Attributes = new Dictionary<string, object>();
            guid = Guid.NewGuid().ToString();
            htmlHelper = helper;
        }

        protected void SetScriptTag()
        {
            var script = @"<script>
                        $(function(){
                            " + Script + @"
                        });
                    </script>";
            RenderScriptAndStyle.ScriptSingle(guid, script, true);
        }

        public string ToHtmlString()
        {
            SetScriptTag();
            return "";
        }
    }
}
