using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public class SearchBankAccountStrategy : SearchStrategyBase
    {
        public SearchBankAccountStrategy(string baseUrl, IEnumerable<ParameterBase> parameters, DateTime date) : base(baseUrl, parameters, date)
        {
        }

        protected override string Option => "bank-account";
        protected override object DeserializeApiResult(string result)
        {
            object deserializedObject;
            if (Parameters.Count == 1)
            {
                deserializedObject = JsonConvert.DeserializeObject<EntityListResponse>(result);
            }
            else
            {
                deserializedObject = JsonConvert.DeserializeObject<EntryListResponse>(result);
            }
            return deserializedObject;
        }
    }
}
