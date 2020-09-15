using Savosh.Component;
using System.Web.Routing;
using System.Web.UI;
using System.Web.WebPages;

[assembly: WebResource("Savosh.Component.DataTables.dataTables.bootstrap.css", "text/css")]
[assembly: WebResource("Savosh.Component.DataTables.jquery.dataTables.css", "text/css")]
[assembly: WebResource("Savosh.Component.DataTables.jquery.dataTables.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.DataTables.jquery.dataTables.min.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.DataTables.dataTables.bootstrap.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.DataTables.dataTables.bootstrap.min.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class DataTablesHelper
    {
        private const string dataTables_bootstrap_css = "Savosh.Component.DataTables.dataTables.bootstrap.css";
        private const string jquery_dataTables_css = "Savosh.Component.DataTables.jquery.dataTables.css";
        private const string jquery_dataTables_js = "Savosh.Component.DataTables.jquery.dataTables.js";
        private const string jquery_dataTables_min_js = "Savosh.Component.DataTables.jquery.dataTables.min.js";
        private const string dataTables_bootstrap_js = "Savosh.Component.DataTables.dataTables.bootstrap.js";
        private const string dataTables_bootstrap_min_js = "Savosh.Component.DataTables.dataTables.bootstrap.min.js";

        //public static DataTablesOption DataTables(this HtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, Dictionary<string, object> htmlAttributes = null)
        //{
        //    helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_css) + @""" rel=""stylesheet"" />");
        //    helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(jquery_dataTables_min_js) + @"""></script>");
        //    helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_min_js) + @"""></script>");
        //    return new DataTablesOption(helper, thead, tbody, new RouteValueDictionary(htmlAttributes));
        //}
        public static DataTablesOption DataTables(this HtmlHelper helper, Func<object, HelperResult> thead, Func<object, HelperResult> tbody, object htmlAttributes = null)
        {
            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_css) + @""" rel=""stylesheet"" />");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(jquery_dataTables_min_js) + @"""></script>");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(dataTables_bootstrap_min_js) + @"""></script>");
            return new DataTablesOption(helper, thead, tbody, new RouteValueDictionary(htmlAttributes));
        }
    }
}
