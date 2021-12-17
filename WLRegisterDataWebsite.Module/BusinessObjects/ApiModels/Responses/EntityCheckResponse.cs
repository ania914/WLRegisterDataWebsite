using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent]
    public class EntityCheckResponse : NonPersistentBaseObject
    {
        private EntityCheck result;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntityCheck Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
