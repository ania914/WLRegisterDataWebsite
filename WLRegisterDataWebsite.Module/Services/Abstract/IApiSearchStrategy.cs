using DevExpress.ExpressApp;
using System.Threading.Tasks;

namespace WLRegisterDataWebsite.Module.Services.Abstract
{
    public interface IApiSearchStrategy
    {
        Task<object> Search();
    }
}
