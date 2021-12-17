using System.Collections.Generic;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;

namespace WLRegisterDataWebsite.Module.Services.Abstract
{
    public interface IApiSearchStrategy
    {
        IList<ParameterBase> GetParameters();
        Task<object> Search();
        void RemoveParameter(ParameterBase parameter);
    }
}
