using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SuperProjet
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string baseUrlToken = "https://login.salesforce.com/services/oauth2/token";

            string username = "florent.oddo@epsi.fr";
            string password = "57f3e57f3e";
            string gran_type = "password";
            string client_id = "3MVG9t0sl2P.pByqwJ4AJohc4YcjnNlJyt1jZxqdIXYuSu0VsEoWHfDH4WKT0klIEFrHLa8GY0eIB3vgauXT.";
            string client_secret = "7653F2CE83587AD8EC61752B2FC28C6507948B2DC1BC43B8489E144D3E3595BD";

            string urlToken = baseUrlToken + 
                "?username="+username
                +"&grant_type="+gran_type
                +"&password="+password
                +"&client_id="+client_id
                +"&client_secret="+client_secret;


            var client = new HttpClient();
            using (var request = new HttpRequestMessage(HttpMethod.Post,urlToken))
            {
                using var stringContent = new StringContent("", Encoding.UTF8, "application/json");
                request.Content = stringContent;

                using var send = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false);

                if (!send.IsSuccessStatusCode)
                    throw new Exception();

                var response = send.EnsureSuccessStatusCode();
                var res = await send.Content.ReadAsStringAsync();

                Response reponse = JsonSerializer.Deserialize<Response>(res);
                string token = reponse.access_token;
                Console.WriteLine(token);

                var op = new Opportunity
                {
                    Name = "NameTest",
                    CloseDate = "2023-08-01",
                    StageName = "New"
                };

                string jsonOpportunity = JsonSerializer.Serialize(op);

                Console.WriteLine(jsonOpportunity);


                string urlOpportunity = "https://epsi-4a-dev-ed.my.salesforce.com/services/data/v53.0/sobjects/Opportunity";

                using (var req = new HttpRequestMessage(HttpMethod.Post, urlOpportunity))
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    using var stringCont = new StringContent(jsonOpportunity, Encoding.UTF8, "application/json");
                    req.Content = stringCont;

                    using var sen = await client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false);
                }

            }
        }
    }
}
