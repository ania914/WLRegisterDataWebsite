using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent, DefaultListViewOptions]
    public class EntityResponse : NonPersistentBaseObject
    {
        private EntityItem result;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntityItem Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
