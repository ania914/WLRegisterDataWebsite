using System.Collections.Generic;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;

namespace WLRegisterDataWebsite.Module.Services.Abstract
{
    public interface IDatabaseService
    {
        Task<ApiEntity> CreateEntity(EntityModel model);
        IEnumerable<ApiEntity> GetEntitiesAsync();
    }
}
