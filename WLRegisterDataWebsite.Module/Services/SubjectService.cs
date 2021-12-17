using DevExpress.ExpressApp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects;
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
        private bool useTestUrl = true;
        public bool UseTestUrl => useTestUrl;

        public SubjectService(ICustomHttpClient httpClient, IDatabaseService databaseService)
        {
            _httpClient = httpClient;
            this.databaseService = databaseService;
        }

        public void ChangeBaseUrl()
        {
            useTestUrl = !useTestUrl;
        }

        public async Task<object> Search(SearchSubject model, SearchOption selectedOption)
        {
            var strategy = SearchApiFactory.GetStrategy(_httpClient, useTestUrl ? TestUri : ProductionUri, model, selectedOption);
            var cachedData = await GetEntitiesFromDatabase(selectedOption, strategy);
            var result = await strategy.Search();
            if(cachedData != null && cachedData.Any() && result is ICacheResult cacheResult)
            {
                cacheResult.AddCachedData(cachedData);
            }
            return result;
        }

        public async Task SaveResults(IObjectSpace objectSpace, object result)
        {
            if (result is not IGetResult getResultData)
                return;

            var data = getResultData.GetResult().ToList();
            if (data != null && data.Any())
            {
                foreach (var model in data)
                {
                    if (model == null)
                        continue;

                    await databaseService.CreateEntity(model);
                }
            }
        }

        private async Task<IEnumerable<EntityModel>> GetEntitiesFromDatabase(SearchOption option, IApiSearchStrategy searchStrategy)
        {
            var result = new List<EntityModel>();
            var parameters = searchStrategy.GetParameters();
            foreach (var parameter in parameters)
            {
                var entityModel = await databaseService.GetEntityByOption(option, parameter.Number);
                if (entityModel == null || !entityModel.Any())
                    continue;

                result.AddRange(entityModel);
                searchStrategy.RemoveParameter(parameter);
            }

            return result.Distinct();
        }
    }
}
