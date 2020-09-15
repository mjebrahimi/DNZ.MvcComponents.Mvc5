using Savosh.Component;
using System.Collections.Generic;

namespace System.Web.Mvc
{
    public class BsUploadInitialPreviewConfig : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }
        public BsUploadInitialPreviewConfig()
        {
            Attributes = new Dictionary<string, object>();
        }

        public BsUploadInitialPreviewConfig Add(string caption, string url, int key)
        {
            var jsonClass = new { caption = caption, url = url, key = key };
            Attributes.Add(Guid.NewGuid().ToString(), ComponentUtility.ToJsonStringWithoutQuotes(jsonClass));
            return this;
        }
    }
}
