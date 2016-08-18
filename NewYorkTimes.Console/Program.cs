using NewYorkTimes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace NewYorkTimes.ConsoleApp
{
    class Program
    {
        //http://msdn.microsoft.com/en-us/library/hh674188.aspx
        //NYT API Key: Article Search:
        //937d456077314d678bbcefa73c4439a2;       

        static string NewYorkTimesAPI = "937d456077314d678bbcefa73c4439a2";

        static void Main(string[] args)
        {

            try
            {
                string articleRequest = CreateRequest("q=olympics&begin_date=20160101&end_date=20160815");
               
                var client = new HttpClient();
                var result = client.GetAsync(articleRequest).Result;

                var content = result.Content.ReadAsStringAsync().Result;
                var contentObject = (JObject) JsonConvert.DeserializeObject(content);


                var jsonResult = (JObject)contentObject["response"];
                var jsonArticles = jsonResult["docs"];
                var docs = JsonConvert.DeserializeObject<List<docs>>(JsonConvert.SerializeObject(jsonArticles));

                var articles = docs.Select(d => new Article
                {
                    ArticleURL = d.web_url,
                    Headline = d.headline.main,
                    Source = d.source,
                    PublishDate = d.pub_date
                }).ToArray();

                Console.WriteLine(JsonConvert.SerializeObject(articles, Formatting.Indented));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }

            Console.ReadLine();
        }
   
        private static string CreateRequest(string queryString)
        {

            string UrlRequest = "http://api.nytimes.com/svc/search/v2/articlesearch.json?" +
                          queryString +
                         "&api-key=" + NewYorkTimesAPI;
            return (UrlRequest);
        }       

    }
}
