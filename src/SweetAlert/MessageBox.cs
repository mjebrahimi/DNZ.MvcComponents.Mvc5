namespace System.Web.Mvc
{
    public static partial class MessageBox
    {
        public static SweetAlert SweetAlert(this HtmlHelper helper, string message, string title = "پیغام", SweetAlertType type = SweetAlertType.Default)
        {
            return new SweetAlert(helper).Text(message).Title(title).Type(type);
        }

        public static SweetAlert SweetAlert(string message, string title = "پیغام", SweetAlertType type = SweetAlertType.Default)
        {
            return new SweetAlert().Text(message).Title(title).Type(type);
        }
    }
}