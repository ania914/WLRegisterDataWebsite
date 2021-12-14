using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services
{
    public class CustomHttpClient : ICustomHttpClient
    {
        public async Task<string> GetAsync(string uri, IDictionary<string, string> queryParams)
        {
            using (var client = new HttpClient())
            {
                if(queryParams != null)
                {
                    uri = FillQueryParams(uri, queryParams);
                }

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await client.SendAsync(requestMessage);
                return await response.Content.ReadAsStringAsync();
            }
        }

        private string FillQueryParams(string uri, IDictionary<string, string> queryParams)
        {
            var builder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach(var keyValue in queryParams)
            {
                query[keyValue.Key] = keyValue.Value;
            }

            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
