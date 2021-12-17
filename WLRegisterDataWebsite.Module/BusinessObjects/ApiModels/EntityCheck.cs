using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
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
