using DevExpress.ExpressApp;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
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
