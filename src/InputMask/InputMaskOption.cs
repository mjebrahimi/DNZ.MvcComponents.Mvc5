﻿using Savosh.Component;
using Savosh.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.InputMask.jquery.inputmask.bundle.js", "text/javascript")]
namespace System.Web.Mvc
{
    public class InputMaskOption<TModel, TValue> : BaseComponent, IOptionBuilder
    {
        private const string inputmask_js = "Savosh.Component.InputMask.jquery.inputmask.bundle.js";

        private HtmlHelper<TModel> _htmlHelper;
        private Expression<Func<TModel, TValue>> _expression;
        private IDictionary<string, object> _htmlAttributes;
        private string _name;
        private string _value;
        public Dictionary<string, object> Attributes { get; set; }

        public InputMaskOption(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            Attributes = new Dictionary<string, object>();
            _htmlHelper = htmlHelper;
            _expression = expression;
            _htmlAttributes = htmlAttributes;

            //Inputmask.extendDefaults({
            //    'autoUnmask': true
            //});
            //Inputmask.extendDefinitions({
            //    'A': {
            //        validator: "[A-Z]",
            //        cardinality: 1,
            //        casing: "upper", //auto uppercasing
            //        definitionSymbol: "*"
            //    }
            //});
            //Inputmask.extendAliases({
            //    'myNum': {
            //        alias: "numeric",
            //        placeholder: '',
            //        allowPlus: false,
            //        allowMinus: false
            //    }
            //});
        }

        public InputMaskOption(HtmlHelper<TModel> htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            Attributes = new Dictionary<string, object>();
            _htmlHelper = htmlHelper;
            _expression = null;
            _htmlAttributes = htmlAttributes;
            _name = name;
            _value = value;
        }

        public InputMaskOption<TModel, TValue> ClearIncomplete(bool value)
        {
            Attributes["clearIncomplete"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> ClearMaskOnLostFocus(bool value)
        {
            Attributes["clearMaskOnLostFocus"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> ShowMaskOnHover(bool value)
        {
            Attributes["showMaskOnHover"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> ShowMaskOnFocus(bool value)
        {
            Attributes["showMaskOnFocus"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> Greedy(bool value)
        {
            Attributes["greedy"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> TabThrough(bool value)
        {
            Attributes["tabThrough"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> ShowTooltip(bool value)
        {
            Attributes["showTooltip"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> AutoGroup(bool value)
        {
            Attributes["autoGroup"] = value.ToString().ToLower();
            return this;
        }

        public InputMaskOption<TModel, TValue> Placeholder(string value)
        {
            Attributes["placeholder"] = string.Format("'{0}'", value);
            return this;
        }

        public InputMaskOption<TModel, TValue> Mask(string value)
        {
            Attributes["mask"] = string.Format("'{0}'", value);
            return this;
        }

        public InputMaskOption<TModel, TValue> Regex(string value)
        {
            Attributes["regex"] = string.Format("'{0}'", value);
            return this;
        }

        public InputMaskOption<TModel, TValue> Alias(string value)
        {
            Attributes["alias"] = string.Format("'{0}'", value);
            return this;
        }

        public InputMaskOption<TModel, TValue> StaticDefinitionSymbol(string value)
        {
            Attributes["staticDefinitionSymbol"] = string.Format("'{0}'", value);
            return this;
        }

        public InputMaskOption<TModel, TValue> GroupSeparator(string value)
        {
            Attributes["groupSeparator"] = string.Format("'{0}'", value);
            return this;
        }

        public InputMaskOption<TModel, TValue> RadixPoint(string value)
        {
            Attributes["radixPoint"] = string.Format("'{0}'", value);
            return this;
        }

        public InputMaskOption<TModel, TValue> GroupSize(int value)
        {
            Attributes["groupSize"] = value;
            return this;
        }

        public InputMaskOption<TModel, TValue> Repeat(int value)
        {
            Attributes["repeat"] = value;
            return this;
        }

        public InputMaskOption<TModel, TValue> OnCleared(int value)
        {
            Attributes["oncleared"] = value;
            return this;
        }

        public InputMaskOption<TModel, TValue> OnInComplete(int value)
        {
            Attributes["onincomplete"] = value;
            return this;
        }

        public InputMaskOption<TModel, TValue> OnComplete(int value)
        {
            Attributes["oncomplete"] = value;
            return this;
        }

        public InputMaskOption<TModel, TValue> AddDefinitions(char character, string validator = null, int? cardinality = null, InputMaskCasing? casing = null, char? definitionSymbol = null)
        {
            var defin = new Dictionary<string, object>();
            if (validator != null)
                defin["validator"] = string.Format("'{0}'", validator);
            if (cardinality != null)
                defin["cardinality"] = cardinality;
            if (casing != null)
                defin["casing"] = string.Format("'{0}'", casing.Value.ToString().ToLower());
            if (definitionSymbol != null)
                defin["definitionSymbol"] = string.Format("'{0}'", definitionSymbol);

            Attributes["defin_" + Guid.NewGuid()] = string.Format("'{0}': ", character) + defin.RenderOptions();
            return this;
        }

        public override string ToHtmlString()
        {
            var id = "";
            MvcHtmlString editor = null;
            if (_expression == null)
            {
                //var dic = new RouteValueDictionary(_htmlAttributes);
                //if (dic.ContainsKey("id"))
                //    id = dic["id"].ToString();
                //else
                //    id = Guid.NewGuid().ToString();
                id = _htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldId(_name);
                editor = _htmlHelper.TextBox(_name, _value, _htmlAttributes);
            }
            else
            {
                var metadata = ModelMetadata.FromLambdaExpression(_expression, _htmlHelper.ViewData);
                var htmlFieldName = ExpressionHelper.GetExpressionText(_expression);
                id = _htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
                editor = _htmlHelper.TextBoxFor(_expression, _htmlAttributes);
            }
            _htmlHelper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(inputmask_js) + @"""></script>");
            _htmlHelper.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").inputmask(" + RenderOptions() + @");
                });
            </script>");
            return editor.ToHtmlString();
        }

        public string RenderOptions()
        {
            var hasRegex = Attributes.ContainsKey("regex");
            var definitions = string.Join(", \n", Attributes.Where(p => p.Key.StartsWith("defin_")).Select(p => p.Value));
            if (definitions.Trim().HasValue())
                Attributes["definitions"] = definitions;
            var result = string.Join(", \n", Attributes.Where(p => !p.Key.StartsWith("defin_")).Select(p => p.Key + ": " + p.Value));
            return (hasRegex ? "\"Regex\", " : "") + "{\n" + result + "\n}";
        }
    }
}

