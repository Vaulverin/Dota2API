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

        public static List<LeaguesModel> GetLeaguesListing(Languages language)
        {
            var _sourceURI = new Uri(API_URI.AbsoluteUri + "IDOTA2Match_570/GetLeagueListing/v0001/?key=" + API_KEY + "&language=" + language.ToString());
            var _responseResult = GetResponseResult(_sourceURI);
            var _leagues = JsonConvert.DeserializeObject<APILeaguesResponseModel>(_responseResult.Result.ToString());
            return _leagues.Leagues;  
        }

        public static List<Matches.MatchesModel> GetMatchesForLeague(int leagueId)
        {
            List<Matches.MatchesModel> _result = null;
            double _lastId = 0;
            bool _isThatAll = false;
            do
            {
                var _sourceURI = new Uri(API_URI.AbsoluteUri + "IDOTA2Match_570/GetMatchHistory/v1/?key=" + API_KEY + "&league_id=" + leagueId + "&start_at_match_id=" + _lastId);
                var _responseResult = GetResponseResult(_sourceURI);
                var _matchesHistory = JsonConvert.DeserializeObject<APIMatchesHistoryResponseModel>(_responseResult.Result.ToString());
                _lastId = _matchesHistory.Matches.Last().MatchId;
                _result.Concat(_matchesHistory.Matches);
                if (_matchesHistory.ResultsRemaining == 0)
                {
                    _isThatAll = true;
                }
            }
            while (_isThatAll == false);
            List<Matches.MatchesModel> _temp = _result;
            _result = null;
            foreach (Matches.MatchesModel _item in _result)
            {
                Matches.MatchesModel _match = GetMatcheDetails(_item.MatchId);
                _match.SeriesId = _item.SeriesId;
                _match.SeriesType = _item.SeriesType;
                _result.Add(_match); 
            }

            return _result;
        }

        public static Matches.MatchesModel GetMatcheDetails(double matchId)
        {
            var _sourceURI = new Uri(API_URI.AbsoluteUri + "IDOTA2Match_570/GetMatchDetails/v0001/?key=" + API_KEY + "&match_id=" + matchId);
            var _responseResult = GetResponseResult(_sourceURI);
            return JsonConvert.DeserializeObject<Matches.MatchesModel>(_responseResult.Result.ToString());
        }

    }

}