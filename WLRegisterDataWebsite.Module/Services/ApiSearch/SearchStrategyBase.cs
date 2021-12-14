using DevExpress.ExpressApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public abstract class SearchStrategyBase : IApiSearchStrategy
    {
        private readonly string baseUrl;
        private readonly string date;

        protected ImmutableList<ParameterBase> Parameters { get; }
        protected abstract string Option { get; }

        public SearchStrategyBase(string baseUrl, IEnumerable<ParameterBase> parameters, DateTime date)
        {
            this.baseUrl = baseUrl;
            this.date = date.ToString("yyyy-MM-dd");
            Parameters = parameters.ToImmutableList();
        }

        public async Task<object> Search()
        {
            return await SearchWithApiClient();
        }

        protected virtual object DeserializeApiResult(string result)
        {
            object deserializedObject;
            if (Parameters.Count == 1)
            {
                deserializedObject = JsonConvert.DeserializeObject<EntityResponse>(result);
            }
            else
            {
                deserializedObject = JsonConvert.DeserializeObject<EntryListResponse>(result);
            }
            return deserializedObject;
        }

        private async Task<object> SearchWithApiClient()
        {
            var client = new CustomHttpClient();
            var numbers = string.Join(",", Parameters.Select(x => x.Number));
            var queryParams = new Dictionary<string, string>() { { "date", date } };
            var uri = $@"{baseUrl}/api/search/{Option}{(Parameters.Count > 1 ? "s" : "")}/{numbers}";
            var result = await client.GetAsync(uri, queryParams);

            return DeserializeObject(result);
        }

        private object DeserializeObject(string result)
        {
            object deserializedObject = DeserializeApiResult(result);
            if(deserializedObject.GetType().GetProperty("Result").GetValue(deserializedObject) == null)
            {
                return JsonConvert.DeserializeObject<ExceptionModel>(result);
            }
            return deserializedObject;
        }
    }
}
