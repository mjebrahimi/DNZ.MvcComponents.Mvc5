using Savosh.Component;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.Fuelux.css.fuelux.css", "text/css")]
[assembly: WebResource("Savosh.Component.Fuelux.css.wizard.rtl.css", "text/css")]
[assembly: WebResource("Savosh.Component.Fuelux.js.fuelux.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class FueluxWizardHelper
    {
        private const string fuelux_css = "Savosh.Component.Fuelux.css.fuelux.css";
        private const string wizard_rtl_css = "Savosh.Component.Fuelux.css.wizard.rtl.css";
        private const string fuelux_js = "Savosh.Component.Fuelux.js.fuelux.js";

        public static FueluxWizardOption FueluxWizard(this HtmlHelper helper)
        {
            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(fuelux_css) + @""" rel=""stylesheet"" />");
            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(wizard_rtl_css) + @""" rel=""stylesheet"" />");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(fuelux_js) + @"""></script>");
            return new FueluxWizardOption(helper);
        }
    }
}