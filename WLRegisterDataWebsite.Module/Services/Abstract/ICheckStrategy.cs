using System.Threading.Tasks;

namespace WLRegisterDataWebsite.Module.Services.Abstract
{
    public interface ICheckStrategy
    {
        Task<object> Check();
    }
}
