using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent]
    public class EntityListResponse: NonPersistentBaseObject
    {
        private EntityList result;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntityList Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
