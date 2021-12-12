using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace WLRegisterDataWebsite.Module.BusinessObjects.Models.Entities
{
    [DomainComponent]
    public class EntityCheck : NonPersistentBaseObject
    {
        private string accountAssigned, requestDateTime, requestId;
        public string AccountAssigned
        {
            get => accountAssigned;
            set => SetPropertyValue(ref accountAssigned, value);
        }
        public string RequestDateTime
        {
            get => requestDateTime;
            set => SetPropertyValue(ref requestDateTime, value);
        }
        public string RequestId
        {
            get => requestId;
            set => SetPropertyValue(ref requestId, value);
        }
    }
}
