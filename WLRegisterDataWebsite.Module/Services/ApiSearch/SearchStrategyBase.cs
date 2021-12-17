using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public class SearchStrategyBase : IApiSearchStrategy
    {
        private readonly ICustomHttpClient client;
        private readonly string baseUrl;
        private readonly string date;
        protected readonly int ParametersCount;
        protected List<ParameterBase> parameters;

        public ImmutableList<ParameterBase> Parameters => parameters.ToImmutableList();

        public SearchStrategyBase(ICustomHttpClient client, string baseUrl, IEnumerable<ParameterBase> parameters, DateTime date)
        {
            this.client = client;
            this.baseUrl = baseUrl;
            this.date = date.ToString("yyyy-MM-dd");
            this.parameters = parameters.ToList();
            ParametersCount = this.parameters.Count;
        }

        public async Task<object> Search()
        {
            if (parameters == null || !parameters.Any())
                return new EntryListResponse();

            return await SearchWithApiClient();
        }

        public IList<ParameterBase> GetParameters()
        {
            return Parameters;
        }

        public void RemoveParameter(ParameterBase parameter)
        {
            if (!parameters.Contains(parameter))
                return;

            parameters.Remove(parameter);
        }

        protected virtual object DeserializeApiResult(string result)
        {
            object deserializedObject;
            if (ParametersCount == 1)
            {
                deserializedObject = JsonConvert.DeserializeObject<EntityResponse>(result, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
            }
            else
            {
                deserializedObject = JsonConvert.DeserializeObject<EntryListResponse>(result, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
            }
            return deserializedObject;
        }

        private async Task<object> SearchWithApiClient()
        {
            var numbers = string.Join(",", Parameters.Select(x => x.Number));
            var queryParams = new Dictionary<string, string>() { { "date", date } };
            var uri = $@"{baseUrl}{(Parameters.Count > 1 ? "s" : "")}/{numbers}";
            var result = await client.GetAsync(uri, queryParams);
            
            return DeserializeObject(result);
        }

        private object DeserializeObject(string result)
        {
            object deserializedObject = DeserializeApiResult(result);

            if (deserializedObject.GetType().GetProperty("Result").GetValue(deserializedObject) == null)
            {
                return JsonConvert.DeserializeObject<ExceptionModel>(result);
            }
            return deserializedObject;
        }
    }
}
