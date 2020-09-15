using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public class BsUploadInitialPreview : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }
        public BsUploadInitialPreview()
        {
            Attributes = new Dictionary<string, object>();
        }

        public BsUploadInitialPreview Add(string src, object htmlAttributes)
        {
            var input = new TagBuilder("img");
            input.Attributes.Add("src", src);
            input.Attributes.Add("style", "width:auto;height:160px;");
            if (htmlAttributes != null)
                input.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            Attributes.Add(Guid.NewGuid().ToString(), string.Format("'{0}'", input.ToString(TagRenderMode.SelfClosing)));
            return this;
        }
    }
}
