namespace System.Web.Mvc
{
    public static partial class MessageBox
    {
        public static Toastr Toastr(string text, string title = "پیغام", ToastrType type = ToastrType.Info)
        {
            return new Toastr().Text(text).Title(title).Type(type);
        }

        public static Toastr Toastr(this HtmlHelper helper, string text, string title = "پیغام", ToastrType type = ToastrType.Info)
        {
            return new Toastr(helper).Text(text).Title(title).Type(type);
        }
    }
}
