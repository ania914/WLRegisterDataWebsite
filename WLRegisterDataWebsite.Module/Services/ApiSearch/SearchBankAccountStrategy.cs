using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public class SearchBankAccountStrategy : SearchStrategyBase
    {
        public SearchBankAccountStrategy(ICustomHttpClient client, string baseUrl, IEnumerable<ParameterBase> parameters, DateTime date) : base(client, baseUrl, parameters, date)
        {
        }

        protected override object DeserializeApiResult(string result)
        {
            object deserializedObject;
            if (ParametersCount == 1)
            {
                deserializedObject = JsonConvert.DeserializeObject<EntityListResponse>(result, new JsonSerializerSettings
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
    }
}
