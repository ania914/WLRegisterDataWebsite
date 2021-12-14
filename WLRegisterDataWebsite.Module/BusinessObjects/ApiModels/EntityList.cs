using DevExpress.ExpressApp;
using System.Collections.Generic;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class EntityList : NonPersistentBaseObject
    {
        private List<Entity> subject = new List<Entity>();
        private string requestDateTime;
        private string requestId;

        public List<Entity> Subject
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
