using System;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public static class SearchApiFactory
    {
         public static IApiSearchStrategy GetStrategy(ICustomHttpClient customHttpClient, string url, SearchSubject model, SearchOption selectedOption)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var baseUri = $@"{url}/api/search";
            switch (selectedOption)
            {
                case SearchOption.BankAccount:
                    return new SearchBankAccountStrategy(customHttpClient, $@"{baseUri}/bank-account", model.BankAccount, model.Date);
                case SearchOption.Nip:
                    return new SearchStrategyBase(customHttpClient, $@"{baseUri}/nip", model.Nip, model.Date);
                case SearchOption.Regon:
                    return new SearchStrategyBase(customHttpClient, $@"{baseUri}/regon", model.Regon, model.Date);
                default:
                    throw new ArgumentOutOfRangeException(nameof(selectedOption));
            }
        }
    }
}
