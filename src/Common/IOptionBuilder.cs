using System.Collections.Generic;

namespace System.Web.Mvc
{
    public interface IOptionBuilder
    {
        Dictionary<string, object> Attributes { get; set; }
    }
}
