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
        protected ImmutableList<ParameterBase> Parameters { get; }

        public SearchStrategyBase(ICustomHttpClient client, string baseUrl, IEnumerable<ParameterBase> parameters, DateTime date)
        {
            this.client = client;
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
            //var numbers = string.Join(",", Parameters.Select(x => x.Number));
            //var queryParams = new Dictionary<string, string>() { { "date", date } };
            //var uri = $@"{baseUrl}{(Parameters.Count > 1 ? "s" : "")}/{numbers}";
            //var result = await client.GetAsync(uri, queryParams);
            var result = "{\"result\":{\"subject\":{\"name\":\"Nazwa Firmy 3\",\"nip\":\"7250018312\",\"statusVat\":\"Czynny\",\"regon\":\"08951113622787\",\"pesel\":null,\"krs\":\"123456789098765\",\"residenceAddress\":\"TAKA a Taka 80/588, 17-717 Miejscowość 127\",\"workingAddress\":\"TAKA a Taka 708/410, 17-728 Miejscowość 166\",\"representatives\":[],\"authorizedClerks\":[],\"partners\":[{\"companyName\":\"nazwaUpr1110\",\"firstName\":\"imię Upr1110\",\"lastName\":\"NazwiskoUpr1110\",\"nip\":\"1100291928\",\"pesel\":null},{\"companyName\":\"nazwaUpr806\",\"firstName\":\"imię Upr806\",\"lastName\":\"NazwiskoUpr806\",\"nip\":\"1100291624\",\"pesel\":null},{\"companyName\":\"nazwaUpr770\",\"firstName\":\"imię Upr770\",\"lastName\":\"NazwiskoUpr770\",\"nip\":\"1100291588\",\"pesel\":null},{\"companyName\":\"nazwaUpr604\",\"firstName\":\"imię Upr604\",\"lastName\":\"NazwiskoUpr604\",\"nip\":\"1100291422\",\"pesel\":null},{\"companyName\":\"nazwaUpr444\",\"firstName\":\"imię Upr444\",\"lastName\":\"NazwiskoUpr444\",\"nip\":\"1100291262\",\"pesel\":null},{\"companyName\":\"nazwaUpr442\",\"firstName\":\"imię Upr442\",\"lastName\":\"NazwiskoUpr442\",\"nip\":\"1100291260\",\"pesel\":null},{\"companyName\":\"nazwaUpr150\",\"firstName\":\"imię Upr150\",\"lastName\":\"NazwiskoUpr150\",\"nip\":\"1100290968\",\"pesel\":null}],\"registrationLegalDate\":\"2017-09-09\",\"registrationDenialBasis\":\"\",\"registrationDenialDate\":null,\"restorationBasis\":\"Ustawa o podatku od towarów i usług Art. 1234\",\"restorationDate\":\"2017-11-26\",\"removalBasis\":\"Ustawa o podatku od towarów i usług Art. 196\",\"removalDate\":\"2017-10-11\",\"accountNumbers\":[\"27153662316795476436468441\",\"11304188053278601564573060\",\"68373145083176679157718095\",\"72212004558825763981578471\",\"68550166887180126325489533\",\"73567961489759831450004531\",\"55875642927286331329005564\",\"80506772201385324099490597\",\"28599120974992533170736731\",\"56107562593331955877197867\"],\"hasVirtualAccounts\":false},\"requestId\":\"1k4dd-8dll0k0\",\"requestDateTime\":\"15-12-2021 20:20:00\"}}";
            
            return DeserializeObject(result);
        }

        private object DeserializeObject(string result)
        {
            object deserializedObject = DeserializeApiResult(result);
            if(deserializedObject is IGetResult getResult && getResult == null)
            {
                return JsonConvert.DeserializeObject<ExceptionModel>(result);
            }
            //if(deserializedObject.GetType().GetProperty("Result").GetValue(deserializedObject) == null)
            //{
            //    return JsonConvert.DeserializeObject<ExceptionModel>(result);
            //}
            return deserializedObject;
        }
    }
}
