using DevExpress.ExpressApp;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;

namespace WLRegisterDataWebsite.Module.Services
{
    public interface ISubjectService
    {
        Task<object> Search(SearchSubject model, SearchOption selectedOption);
        Task SaveResults(IObjectSpace objectSpace, object result);
    }
}
