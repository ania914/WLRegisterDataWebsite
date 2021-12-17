using System.Collections.Generic;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Enums;

namespace WLRegisterDataWebsite.Module.Services.Abstract
{
    public interface IDatabaseService
    {
        Task<ApiEntity> CreateEntity(EntityModel model);
        Task<List<EntityModel>> GetEntityByOption(SearchOption option, string value);
    }
}
