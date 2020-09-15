namespace System.Web.Mvc
{
    public static partial class MessageBox
    {
        public static BsDialog BsDialog(string message, string title = "پیغام", DialogType type = DialogType.Default)
        {
            return new BsDialog().Message(message).Title(title).Type(type);
        }

        public static BsDialog BsDialog(this HtmlHelper helper, string message, string title = "پیغام", DialogType type = DialogType.Default)
        {
            return new BsDialog(helper).Message(message).Title(title).Type(type);
        }
    }
}