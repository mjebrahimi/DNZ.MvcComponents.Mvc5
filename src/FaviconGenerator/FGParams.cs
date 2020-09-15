namespace System.Web.Mvc
{
    public class FGParams
    {
        public favicon_generationClass favicon_generation { get; set; }

        public class favicon_generationClass
        {
            public string api_key { get; set; }
            public master_pictureClass master_picture { get; set; }
            public files_locationClass files_location { get; set; }
            public callbackClass callback { get; set; }
        }

        public class master_pictureClass
        {
            public string type { get; set; }
            public string url { get; set; }
            public string demo { get; set; }
            public string path_only { get; set; }
        }

        public class files_locationClass
        {
            public string type { get; set; }
            //  public string path { get; set; }
        }

        public class callbackClass
        {
            public string type { get; set; }
            public string url { get; set; }
            public string short_url { get; set; }
            public string path_only { get; set; }
            public string custom_parameter { get; set; }
        }
    }
}
