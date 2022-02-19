using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Classes
{
    public class Api
    {
        HttpClient Client;

        public Api()
        {
            Client = new HttpClient();
        }
        public Api(HttpClient client)
        {
            Client = client;
        }
        public string CreateUrlToken()
        {
            string username = "florent.oddo@epsi.fr";
            string password = "57f3e57f3e";
            string grant_type = "password";
            string client_id = "3MVG9t0sl2P.pByqwJ4AJohc4YcjnNlJyt1jZxqdIXYuSu0VsEoWHfDH4WKT0klIEFrHLa8GY0eIB3vgauXT.";
            string client_secret = "7653F2CE83587AD8EC61752B2FC28C6507948B2DC1BC43B8489E144D3E3595BD";
            string baseUrlToken = "https://login.salesforce.com/services/oauth2/token";

            return baseUrlToken +
                "?username=" + username
                + "&grant_type=" + grant_type
                + "&password=" + password
                + "&client_id=" + client_id
                + "&client_secret=" + client_secret;
        }


        public async Task<string> GetToken()
        {
            string token = "";
            string urlToken = CreateUrlToken();
            using (var request = new HttpRequestMessage(HttpMethod.Post, urlToken))
            {
                using var stringContent = new StringContent("", Encoding.UTF8, "application/json");
                request.Content = stringContent;

                using var send = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);

                if (!send.IsSuccessStatusCode)
                {
                    return null;
                }

                var res = await send.Content.ReadAsStringAsync();

                Response reponse = JsonConvert.DeserializeObject<Response>(res);
                token = reponse.access_token;

            }

            return token;
        }


        public async Task<string> InsertOpportunity(string token, Opportunity opportunity)
        {
            string jsonOpportunity = JsonConvert.SerializeObject(opportunity);
            string urlOpportunity = "https://epsi-4a-dev-ed.my.salesforce.com/services/data/v53.0/sobjects/Opportunity";

            using (var req = new HttpRequestMessage(HttpMethod.Post, urlOpportunity))
            {
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                using var stringCont = new StringContent(jsonOpportunity, Encoding.UTF8, "application/json");
                req.Content = stringCont;

                using var send = await Client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);

                return send.StatusCode.ToString();
            }
        }
    }
}
