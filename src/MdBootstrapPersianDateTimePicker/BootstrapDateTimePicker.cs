using Savosh.Component;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.UI;

[assembly: WebResource("Savosh.Component.MdBootstrapPersianDateTimePicker.css.jquery.Bootstrap-PersianDateTimePicker.css", "text/css")]
[assembly: WebResource("Savosh.Component.MdBootstrapPersianDateTimePicker.js.jalaali.js", "text/javascript")]
[assembly: WebResource("Savosh.Component.MdBootstrapPersianDateTimePicker.js.jquery.Bootstrap-PersianDateTimePicker.js", "text/javascript")]
namespace System.Web.Mvc
{
    public static class BootstrapDateTimePicker
    {
        private const string PersianDateTimePicker_css = "Savosh.Component.MdBootstrapPersianDateTimePicker.css.jquery.Bootstrap-PersianDateTimePicker.css";
        private const string Jalali_js = "Savosh.Component.MdBootstrapPersianDateTimePicker.js.jalaali.js";
        private const string PersianDateTimePicker_js = "Savosh.Component.MdBootstrapPersianDateTimePicker.js.jquery.Bootstrap-PersianDateTimePicker.js";

        public static MvcHtmlString TarikhFarsiFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null, bool enableTimePicker = false)
        {
            var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            var value = "";
            var castedValue = data.Model as DateTime?;
            if (castedValue?.Equals(default(DateTime)) == false)
                value = helper.DisplayFor(expression).ToString();

            var attributes = new Dictionary<string, object>() {
                { "Value", value },
                { "data-targetselector", "#" + helper.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)) },
                { "data-mdpersiandatetimepickershowing", "false" },
                { "data-mdpersiandatetimepicker", "true" },
                { "style", "cursor: pointer;" },
                { "data-mddatetimepicker", "true" },
                { "data-trigger", "focus" },
                { "data-enabletimepicker", enableTimePicker.ToString().ToLower() },
                { "data-placement", "left" },
                { "data-englishnumber", "true" },
                { "data-mdformat", enableTimePicker ? "yyyy/MM/dd HH:mm" : "yyyy/MM/dd" },
                //{ "data-todate", "true" },
                //{ "data-fromdate", "true" },
                //{ "data-disabled", "false" },
                //{ "data-disablebeforetoday", "false" },
                //{ "data-isgregorian", "false" },
            };

            //Supported format
            //yyyy: سال چهار رقمی
            //yy: سال دو رقمی
            //MMMM: نام فارسی ماه
            //MM: عدد دو رقمی ماه
            //M: عدد یک رقمی ماه
            //dddd: نام فارسی روز هفته
            //dd: عدد دو رقمی روز ماه
            //d: عدد یک رقمی روز ماه
            //HH: ساعت دو رقمی با فرمت 00 تا 24
            //H: ساعت یک رقمی با فرمت 0 تا 24
            //hh: ساعت دو رقمی با فرمت 00 تا 12
            //h: ساعت یک رقمی با فرمت 0 تا 12
            //mm: عدد دو رقمی دقیقه
            //m: عدد یک رقمی دقیقه
            //ss: ثانیه دو رقمی
            //s: ثانیه یک رقمی
            //fff: میلی ثانیه 3 رقمی
            //ff: میلی ثانیه 2 رقمی
            //f: میلی ثانیه یک رقمی
            //tt: ب.ظ یا ق.ظ
            //t: حرف اول از ب.ظ یا ق.ظ

            var mergAttr = ComponentUtility.MergeAttributes(htmlAttributes, attributes);
            var result = helper.TextBoxFor(expression, mergAttr).ToString(); //input.ToString(TagRenderMode.SelfClosing);

            helper.StyleFileSingle(@"<link href=""" + ComponentUtility.GetWebResourceUrl(PersianDateTimePicker_css) + @""" rel=""stylesheet"" />");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(Jalali_js) + @"""></script>");
            helper.ScriptFileSingle(@"<script src=""" + ComponentUtility.GetWebResourceUrl(PersianDateTimePicker_js) + @"""></script>");

            return new MvcHtmlString(result);
        }

        public static MvcHtmlString DatePicker3Part<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, int lowYear = -5, int highYear = +5)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var property = ExpressionHelper.GetExpressionText(expression);
            var value = metadata.Model;
            var id = helper.ViewData.TemplateInfo.GetFullHtmlFieldId(property);
            var name = helper.ViewData.TemplateInfo.GetFullHtmlFieldName(property);
            DateTime? datetime = null;
            var pc = new PersianCalendar();
            if (value != null && value.ToString() != "")
                datetime = Convert.ToDateTime(value);
            var listDay = new List<SelectListItem> { new SelectListItem { Text = "روز", Value = null, Selected = !datetime.HasValue } };
            for (int i = 1; i <= 31; i++)
                listDay.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString("00"), Selected = datetime.HasValue ? i == Convert.ToInt32(datetime.Value.ToString("dd")) : false });
            var listMonth = new List<SelectListItem> { new SelectListItem { Text = "ماه", Value = null, Selected = !datetime.HasValue } };
            for (int i = 1; i <= 12; i++)
                listMonth.Add(new SelectListItem { Text = i + " - " + GetMonthName(i), Value = i.ToString("00"), Selected = datetime.HasValue ? i == Convert.ToInt32(datetime.Value.ToString("MM")) : false });
            var listYear = new List<SelectListItem> { new SelectListItem { Text = "سال", Value = null, Selected = !datetime.HasValue } };
            for (int i = pc.GetYear(DateTime.Now) + lowYear; i <= pc.GetYear(DateTime.Now) + highYear; i++)
                listYear.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = datetime.HasValue ? i == Convert.ToInt32(datetime.Value.ToString("yyyy")) : false });
            var drpDay = helper.DropDownList(id + "_day", listDay, new { @class = "form-control" });
            var drpMonth = helper.DropDownList(id + "_month", listMonth, new { @class = "form-control"/*, style = "padding: 6px 12px 6px 0 !important"*/ });
            var drpYear = helper.DropDownList(id + "_year", listYear, new { @class = "form-control" });
            var hidden = helper.HiddenFor(expression);
            var result = string.Format(@"
<div class='col-sm-3' style='padding:0'>{0}</div>
<div class='col-sm-5' style='padding:0'>{1}</div>
<div class='col-sm-4' style='padding:0'>{2}</div>{3}", drpDay, drpMonth, drpYear, hidden)
     + helper.Script(@"
<script>
    $(function () {
        function IsNumeric (n) {
          return !isNaN(parseFloat(n)) && isFinite(n);
        }
        function DDLValidation () {
            var day = $(""#" + id + @"_day"").val();
            var month = $(""#" + id + @"_month"").val();
            var year = $(""#" + id + @"_year"").val();
            if (IsNumeric(day) && IsNumeric(month) && IsNumeric(year)){
                $(""#" + id + @""").val(year + '/' + month + '/' + day).trigger('change');
            }
            else{
                $(""#" + id + @""").val('').trigger('change');
            }
            $(""#" + id + @""").valid();
        }
        var isFirst = true;
        $(""#" + id + "_day, #" + id + "_month, #" + id + @"_year"").blur(function () {
                var aa = $(""#" + id + @"_day"").is(':active');
                var bb = $(""#" + id + @"_month"").is(':active');
                var cc = $(""#" + id + @"_year"").is(':active');
                if (aa == false && bb == false && cc == false) {
                    if (isFirst) {
                        DDLValidation();
                        isFirst = false;
                    }
                }
        });
        $(""#" + id + "_day, #" + id + "_month, #" + id + @"_year"").change(function () {
            if (isFirst == false) {
                DDLValidation()
            }
        });
    })
</script>
");
            return new MvcHtmlString(result);
        }

        private static string GetMonthName(int value)
        {
            switch (value)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return "";
            }
        }
    }
}