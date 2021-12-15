using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services.Abstract;
using WLRegisterDataWebsite.Module.Services.ApiSearch;

namespace WLRegisterDataWebsite.Module.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ICustomHttpClient _httpClient;
        private readonly IDatabaseService databaseService;
        private const string TestUri = "https://wl-test.mf.gov.pl/";
        private const string ProductionUri = "https://wl-api.mf.gov.pl";

        public SubjectService(ICustomHttpClient httpClient, IDatabaseService databaseService)
        {
            _httpClient = httpClient;
            this.databaseService = databaseService;
        }

        public async Task<object> Search(SearchSubject model, SearchOption selectedOption)
        {
            var strategy = SearchApiFactory.GetStrategy(_httpClient, TestUri, model, selectedOption);
            var result = await strategy.Search();
            return result;
        }

        public async Task SaveResults(IObjectSpace objectSpace, object result)
        {
            if (result is not IGetResult getResultData)
                return;

            var data = getResultData.GetResult();
            if (data != null && data.Any())
            {
                foreach (var model in data)
                {
                    var entity = await databaseService.CreateEntity(model);

                }
            }
        }
    }
}
