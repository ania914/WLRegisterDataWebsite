using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services.Abstract;
using WLRegisterDataWebsite.Module.Services.ApiSearch;

namespace WLRegisterDataWebsite.Module.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ICustomHttpClient _httpClient;
        private const string TestUri = "https://wl-test.mf.gov.pl/";
        private const string ProductionUri = "https://wl-api.mf.gov.pl";

        public SubjectService(ICustomHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> Search(SearchSubject model, SearchOption selectedOption)
        {
            var strategy = SearchApiFactory.GetStrategy(ProductionUri, model, selectedOption);
            var result = await strategy.Search();
            return result;
        }
    }
}
