using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Services
{
    class Service
    {
        public async Task<string> LoginAsync(string username, string password)
        {
            string URL = "http://192.168.1.208:45455/token";
            var accesToken = string.Empty;
            await Task.Run(() =>
            {
                try
                {
                    var keyvalues = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("grant_type", "password")
                    };
                    var request = new HttpRequestMessage(HttpMethod.Post, URL);

                    request.Content = new FormUrlEncodedContent(keyvalues);

                    var client = new HttpClient();
                    var response = client.SendAsync(request).Result;
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync();
                        JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(json.Result);
                        var accessTokenExpiration = jwtDynamic.Value<DateTime>("expires");
                        accesToken = jwtDynamic.Value<string>("access_token");

                        var username = jwtDynamic.Value<string>("userName");
                        var accessTokenExpirationDate = accessTokenExpiration;
                    }
                }
                catch (Exception ex)
                {

                }
            });
            return accesToken;
        }
        

        public async Task<bool> RegisterUserAsync(string email,string password,string phonenumber,string username)
        {
            bool Response = false;
            await Task.Run(() =>
            {

                var client = new HttpClient();

                var model = new Models.RegisterBindingModel
                {
                    Email = email,
                    Username = username,
                    Password = password,
                    ConfirmPassword = password,
                    Phonenumber = phonenumber,
                };

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync("http://192.168.1.208:45455/" + "api/Account/Register", httpContent);
                var mystring = response.GetAwaiter().GetResult();

                if (response.Result.IsSuccessStatusCode)
                {
                    Response = true;
                }
            });
            return Response;
        }
    }
}
