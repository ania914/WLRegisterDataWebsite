using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent]
    public class EntityResponse : NonPersistentBaseObject
    {
        private EntityItem result;

        public EntityItem Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
