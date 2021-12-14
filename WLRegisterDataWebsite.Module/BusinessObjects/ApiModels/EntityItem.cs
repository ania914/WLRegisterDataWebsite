using DevExpress.ExpressApp;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class EntityItem : NonPersistentBaseObject
    {
        private Entity subject;
        private string requestDateTime;
        private string requestId;

        public Entity Subject
        {
            get => subject;
            set => SetPropertyValue(ref subject, value);
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
