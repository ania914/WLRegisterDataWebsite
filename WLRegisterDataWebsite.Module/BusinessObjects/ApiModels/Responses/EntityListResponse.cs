using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent]
    public class EntityListResponse: NonPersistentBaseObject
    {
        private EntityList result;

        public EntityList Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
