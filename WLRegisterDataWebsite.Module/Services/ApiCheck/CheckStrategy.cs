using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services.ApiCheck
{
    public class CheckStrategy : ICheckStrategy
    {
        private readonly ICustomHttpClient client;
        private readonly string baseUrl;
        private readonly ParameterBase parameter;
        private readonly BankAccount bankAccount;
        private readonly string date;

        public CheckStrategy(ICustomHttpClient client, string baseUrl, ParameterBase parameter, BankAccount bankAccount, DateTime date)
        {
            this.client = client;
            this.baseUrl = baseUrl;
            this.parameter = parameter ?? throw new ArgumentNullException("Parameter can not be empty", nameof(parameter));
            this.bankAccount = bankAccount ?? throw new ArgumentNullException("Account number can not be empty", nameof(bankAccount));
            this.date = date.ToString("yyyy-MM-dd");
        }
        public async Task<object> Check()
        {
            return await CheckWithApiClient();
        }

        private async Task<object> CheckWithApiClient()
        {
            var queryParams = new Dictionary<string, string>() { { "date", date } };
            var uri = $@"{baseUrl}/{parameter.Number}/bank-account/{bankAccount.Number}";
            var result = await client.GetAsync(uri, queryParams);

            return DeserializeObject(result);
        }

        private object DeserializeObject(string result)
        {
            var deserializedObject = JsonConvert.DeserializeObject<EntityCheckResponse>(result);

            if (deserializedObject.GetType().GetProperty("Result").GetValue(deserializedObject) == null)
            {
                return JsonConvert.DeserializeObject<ExceptionModel>(result);
            }
            return deserializedObject;
        }
    }
}
