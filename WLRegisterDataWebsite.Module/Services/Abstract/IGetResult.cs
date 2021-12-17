using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;

namespace WLRegisterDataWebsite.Module.Services.Abstract
{
    public interface IGetResult
    {
        IEnumerable<EntityModel> GetResult();
    }

    public interface ICacheResult
    {
        void AddCachedData(IEnumerable<EntityModel> entityModels);
    }
}
