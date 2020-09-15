using Savosh.Component;
using System.Collections.Generic;
using System.Web.WebPages;

namespace System.Web.Mvc
{
    public class TypeaheadMasterTemplate : IOptionBuilder
    {
        public Dictionary<string, object> Attributes { get; set; }
        public TypeaheadMasterTemplate()
        {
            Attributes = new Dictionary<string, object>();
        }

        public TypeaheadMasterTemplate NotFound(string value)
        {
            Attributes["notFound"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Empty(string value)
        {
            Attributes["empty"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Pending(string value)
        {
            Attributes["pending"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Header(string value)
        {
            Attributes["header"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate Footer(string value)
        {
            Attributes["footer"] = string.Format("'{0}'", value);
            return this;
        }

        public TypeaheadMasterTemplate NotFound(Func<object, HelperResult> template)
        {
            Attributes["notFound"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Empty(Func<object, HelperResult> template)
        {
            Attributes["empty"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Pending(Func<object, HelperResult> template)
        {
            Attributes["pending"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Header(Func<object, HelperResult> template)
        {
            Attributes["header"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Footer(Func<object, HelperResult> template)
        {
            Attributes["footer"] = template(null).ToHtmlString().ToJavaScriptString();
            return this;
        }


        public TypeaheadMasterTemplate NotFound(HelperResult template)
        {
            Attributes["notFound"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Empty(HelperResult template)
        {
            Attributes["empty"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Pending(HelperResult template)
        {
            Attributes["pending"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Header(HelperResult template)
        {
            Attributes["header"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Footer(HelperResult template)
        {
            Attributes["footer"] = template.ToHtmlString().ToJavaScriptString();
            return this;
        }

        public TypeaheadMasterTemplate Suggestion(string value)
        {
            Attributes["suggestion"] = value;
            return this;
        }

        public TypeaheadMasterTemplate Suggestion(HanderBarTemplate template)
        {
            var value = template.Script;
            return Suggestion(value);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(HtmlHelper helper, string template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(HtmlHelper helper, Func<object, HelperResult> template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplateInlineHelper(HtmlHelper helper, HelperResult template)
        {
            var handlebars = helper.CreateHandlebarsTemplateInlineHelper(template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(HtmlHelper helper, string id, string template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(id, template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplate(HtmlHelper helper, string id, Func<object, HelperResult> template)
        {
            var handlebars = helper.CreateHandlebarsTemplate(id, template);
            return Suggestion(handlebars);
        }

        public TypeaheadMasterTemplate SuggestionHanderBarTemplateInlineHelper(HtmlHelper helper, string id, HelperResult template)
        {
            var handlebars = helper.CreateHandlebarsTemplateInlineHelper(id, template);
            return Suggestion(handlebars);
        }
    }
}