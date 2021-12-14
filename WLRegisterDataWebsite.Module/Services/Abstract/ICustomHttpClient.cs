using System.Collections.Generic;
using System.Threading.Tasks;

namespace WLRegisterDataWebsite.Module.Services.Abstract
{
    public interface ICustomHttpClient
    {
        Task<string> GetAsync(string url, IDictionary<string, string> queryParams);
    }
}
