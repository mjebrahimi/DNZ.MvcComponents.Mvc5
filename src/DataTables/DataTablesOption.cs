using Savosh.Component;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using System.Web.WebPages;

[assembly: WebResource("Savosh.Component.DataTables.Persian.json", "text/json")]
namespace System.Web.Mvc
{
    public class DataTablesOption : IOptionBuilder, IHtmlString
    {
        private const string persian_json = "Savosh.Component.DataTables.Persian.json";

        private RouteValueDictionary _htmlAttributes;
        private HtmlHelper htmlHelper;
        private string _thead;
        private string _tbody;
        private bool bordered;
        private bool striped;
        private bool condensed;
        private bool hover;
        //private string id;
        private bool footer;
        public Dictionary<string, object> Attributes { get; set; }

        public DataTablesOption(HtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, RouteValueDictionary htmlAttributes)
        {
            Attributes = new Dictionary<string, object>();
            _htmlAttributes = htmlAttributes;
            _thead = thead(null).ToHtmlString();
            _tbody = tbody(null).ToHtmlString();
            htmlHelper = helper;
            Bordered(true);
            Striped(true);
            Hover(true);
            Searching(false);
            Info(false);
            Paging(false);
            Order(0, DataTabledOrder.Desc);
            Attributes["language"] = "{ 'sUrl': '" + ComponentUtility.GetWebResourceUrl(persian_json) + "' }";
        }

        public DataTablesOption Paging(bool value)
        {
            Attributes["paging"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption LengthChange(bool value)
        {
            Attributes["lengthChange"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption Searching(bool value)
        {
            Attributes["searching"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption Ordering(bool value)
        {
            Attributes["ordering"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption Order(int columnIndex, DataTabledOrder order)
        {
            Attributes["order"] = $"[[ {columnIndex}, '{order.ToString().ToLower()}' ]]";
            return this;
        }

        public DataTablesOption Info(bool value)
        {
            Attributes["info"] = value.ToString().ToLower();
            return this;
        }

        public DataTablesOption AutoWidth(bool value)
        {
            Attributes["autoWidth"] = value;
            return this;
        }

        public DataTablesOption Bordered(bool value)
        {
            bordered = value;
            return this;
        }

        public DataTablesOption Striped(bool value)
        {
            striped = value;
            return this;
        }

        public DataTablesOption Condensed(bool value)
        {
            condensed = value;
            return this;
        }

        public DataTablesOption Hover(bool value)
        {
            hover = value;
            return this;
        }

        public DataTablesOption Footer(bool value)
        {
            footer = value;
            return this;
        }

        public string ToHtmlString()
        {
            var id = Guid.NewGuid().ToString();
            var classes = "";
            id = Guid.NewGuid().ToString();
            classes += bordered ? " table-bordered" : "";
            classes += striped ? " table-striped" : "";
            classes += condensed ? " table-condensed" : "";
            classes += hover ? " table-hover" : "";
            if (_htmlAttributes.ContainsKey("class"))
                classes += " " + _htmlAttributes["class"];
            if (_htmlAttributes.ContainsKey("id"))
                id = _htmlAttributes["id"].ToString();
            var attr = string.Join("", _htmlAttributes.Where(p => p.Key != "class" && p.Key != "id").Select(p => p.Key + "=\"" + p.Value + "\" "));
            var tfoot = "<tfoot" + _thead.Substring(6, _thead.Length - 6) + "tfoot>";
            var html = @"
                    <table id=""" + id + @""" class=""table" + classes + @""" " + attr + @">
                        " + _thead + @"
                        " + _tbody + @"
                        " + (footer ? tfoot : "") + @"
                    </table>
                    ";
            htmlHelper.Script(@"
            <script>
                $(function(){
                    $(""#" + id + @""").DataTable(" + this.RenderOptions() + @");
                });
            </script>");
            return html;
        }
    }
}

