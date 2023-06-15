using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        private HttpClient _client;
        public RonVSKanyeAPI(HttpClient client)
        {
            _client = client;
        }
        public string YeQuote()
        {
            string kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;
        }
        public string SwansonQuote()
        {
            string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = _client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse);
            return ronQuote[0].ToString();
        }



    }

   
    

    
    

}   
