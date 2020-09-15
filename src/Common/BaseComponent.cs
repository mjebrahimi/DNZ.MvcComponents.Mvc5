namespace System.Web.Mvc
{
    public abstract class BaseComponent : IHtmlString
    {
        public virtual string ToHtmlString()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
    }
}
