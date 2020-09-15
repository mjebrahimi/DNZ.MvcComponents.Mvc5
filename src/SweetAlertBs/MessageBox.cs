namespace System.Web.Mvc
{
    public static partial class MessageBox
    {
        public static SweetAlertBs SweetAlertBs(this HtmlHelper helper, string message, string title = "پیغام", SweetAlertType type = SweetAlertType.Default)
        {
            return new SweetAlertBs(helper).Text(message).Title(title).Type(type);
        }

        public static SweetAlertBs SweetAlertBs(string message, string title = "پیغام", SweetAlertType type = SweetAlertType.Default)
        {
            return new SweetAlertBs().Text(message).Title(title).Type(type);
        }
    }
}