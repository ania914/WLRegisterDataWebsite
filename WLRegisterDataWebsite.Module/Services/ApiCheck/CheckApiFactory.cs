using System;
using System.Linq;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services.ApiCheck
{
    public static class CheckApiFactory
    {
        public static ICheckStrategy GetStrategy(ICustomHttpClient customHttp, string url, CheckSubject checkSubject, CheckOption checkOption)
        {
            string baseUrl = $@"{url}/api/check";
            switch (checkOption)
            {
                case CheckOption.Nip:
                    return new CheckStrategy(customHttp, $"{baseUrl}/nip", checkSubject.Nip.FirstOrDefault(), checkSubject.BankAccounts.FirstOrDefault(), checkSubject.Date);

                case CheckOption.Regon:
                    return new CheckStrategy(customHttp, $"{baseUrl}/regon", checkSubject.Regon.FirstOrDefault(), checkSubject.BankAccounts.FirstOrDefault(), checkSubject.Date);

                default:
                    throw new ArgumentOutOfRangeException(nameof(checkOption));
            }
        }
    }
}
