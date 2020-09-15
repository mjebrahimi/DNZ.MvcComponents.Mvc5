using System.Collections.Generic;

namespace System.Web.Mvc
{
    public class BsUploadAllowedFileType : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }
        public BsUploadAllowedFileType()
        {
            Attributes = new Dictionary<string, object>();
        }

        public BsUploadAllowedFileType xImage()
        {
            Attributes["'image'"] = "";
            return this;
        }

        public BsUploadAllowedFileType xHtml()
        {
            Attributes["'html'"] = "";
            return this;
        }

        public BsUploadAllowedFileType xText()
        {
            Attributes["'text'"] = "";
            return this;
        }

        public BsUploadAllowedFileType xVideo()
        {
            Attributes["'video'"] = "";
            return this;
        }

        public BsUploadAllowedFileType xAudio()
        {
            Attributes["'audio'"] = "";
            return this;
        }

        public BsUploadAllowedFileType xFlash()
        {
            Attributes["'flash'"] = "";
            return this;
        }

        public BsUploadAllowedFileType xObject()
        {
            Attributes["'object'"] = "";
            return this;
        }
    }
}