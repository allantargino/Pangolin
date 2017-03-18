using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Cognitive.LUIS;
using Newtonsoft.Json;
using System.Net.Http;

namespace LuisUtils.Model
{
    public class LUISClient : LuisClient
    {
        string _appKey = string.Empty;
        string _appId = string.Empty;

        public LUISClient(string appId, string appKey, bool preview = false) : base(appId, appKey, preview)
        {
            _appKey = appKey;
            _appId = appId;
            base.BASE_API_URL = "https://westus.api.cognitive.microsoft.com/luis/v1.0/prog/apps/";
        }

        public async Task<bool> CreateIntent(Intent intent)
        {
            var content = JsonConvert.SerializeObject(intent);
            return await LuisHttpCall(HttpMethod.Post, "intents", content);
        }

        public async Task<bool> LuisHttpCall(HttpMethod method, string relativeUrl, string content)
        {
            var baseUrl = base.BASE_API_URL;
            var url = baseUrl + $"/{_appId}/" + relativeUrl;

            try
            {

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _appKey);

                    HttpRequestMessage request = new HttpRequestMessage(method, url);
                    request.Content = new StringContent(content, Encoding.UTF8, "application/json");

                    var httpResponse = await client.SendAsync(request);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var responseStr = await httpResponse.Content.ReadAsStringAsync();
                        //dynamic response = JsonConvert.DeserializeObject(responseStr);
                        //var intent = response.intents[0].intent;
                        //var score = response.intents[0].confidence;
                        //intention = new WatsonIntention()
                        //{
                        //    Name = (string)intent,
                        //    Score = (decimal)score
                        //};
                        return true;
                    }
                    else
                    {
                        var responseStr = await httpResponse.Content.ReadAsStringAsync();

                        return false;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
