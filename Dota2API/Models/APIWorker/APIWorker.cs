using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Dota2API.Models.APIWorker
{
    public static class APIWorker
    {
        public static Uri API_URI = new Uri("https://api.steampowered.com/");
        public static string API_KEY = "6A5490A97C16533AF31B903C98783110";

        public static APIResponseModel GetResponseResult(Uri uri)
        {
            var _request = HttpWebRequest.Create(uri);
            
            _request.Method = "GET";
            String _JSON = String.Empty;
            using (HttpWebResponse _response = (HttpWebResponse)_request.GetResponse())
            {
                Stream dataStream = _response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                _JSON = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
             }
            return JsonConvert.DeserializeObject<APIResponseModel>(_JSON);
        }

        public static List<LeaguesModel> GetLeagueListing(Languages language)
        {
            var _sourceURI = new Uri(API_URI.AbsoluteUri + "IDOTA2Match_570/GetLeagueListing/v0001/?key=" + API_KEY + "&language=" + language.ToString());
            var _responseResult = GetResponseResult(_sourceURI);
            var _leagues = JsonConvert.DeserializeObject<APILeaguesResponseMoldel>(_responseResult.Result.ToString());
            return _leagues.Leagues;  
        }

    }

}