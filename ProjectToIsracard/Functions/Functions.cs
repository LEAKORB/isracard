using ProjectToIsracard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ProjectToIsracard.Functions
{
    public class Functions
    {
        public static Repository GetGitHubRepositories(string search)
        {
            if (search != null && search != "")
            {

                string route = "https://api.github.com/search/repositories?q=" + search;



                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(route);
                httpWReq.Method = "GET";
                httpWReq.Proxy = null;
                httpWReq.ContentType = "application/json";
                httpWReq.UserAgent = "repositories_search";
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                string parsedResponse = ParseResponse(response);
                Repository res = new JavaScriptSerializer().Deserialize<Repository>(parsedResponse);
                return res;
            }
            return null;
        }
        public static string ParseResponse(HttpWebResponse response)
        {
            string responseText;
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
            return responseText;
        }


    }
}