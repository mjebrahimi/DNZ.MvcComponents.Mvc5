using Newtonsoft.Json;
using RestSharp;

namespace System.Web.Mvc
{
    public static class FaviconGenerator
    {
        public static void FaviconGenerate(this HttpPostedFileBase img)
        {
            var obj = new FGParams();
            obj.favicon_generation = new FGParams.favicon_generationClass
            {
                api_key = "be39969545219bfaa31823bc8f7f04ceb917aef3",
                master_picture = new FGParams.master_pictureClass
                {
                    type = "url",
                    url = "https://www.savosh.com/Content/img/apple-touch-icon-57x57-precomposed.png",
                    demo = "true"
                },
                files_location = new FGParams.files_locationClass
                {
                    type = "root",
                    // path = "/path/to/icons"
                },
                callback = new FGParams.callbackClass
                {
                    type = "none",
                    url = "http://savosh.com/callback",
                    short_url = "true",
                    path_only = "true",
                }
            };

            string input = JsonConvert.SerializeObject(obj);
            SendPost(input);
        }

        private static string SendPost(object input)
        {
            var _url = "https://realfavicongenerator.net/api";
            var restClient = new RestClientRequest(_url, "favicon");
            restClient.AddJsonParameter(input);
            var searchOutputs = restClient.SendPostRequest();
            return searchOutputs.Content;
        }
    }
}
