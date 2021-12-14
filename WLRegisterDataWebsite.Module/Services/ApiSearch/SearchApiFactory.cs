using System;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public static class SearchApiFactory
    {
         public static IApiSearchStrategy GetStrategy(string url, SearchSubject model, SearchOption selectedOption)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            switch (selectedOption)
            {
                case SearchOption.BankAccount:
                    return new SearchBankAccountStrategy(url, model.BankAccount, model.Date);
                case SearchOption.Nip:
                    return new SearchNipStrategy(url, model.Nip, model.Date);
                case SearchOption.Regon:
                    return new SearchRegonStrategy(url, model.Regon, model.Date);
                default:
                    throw new ArgumentOutOfRangeException(nameof(selectedOption));
            }
        }
    }
}
