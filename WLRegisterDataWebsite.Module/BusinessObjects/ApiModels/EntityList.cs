using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    public class EntityList : NonPersistentBaseObject
    {
        private List<EntityModel> subject = new List<EntityModel>();
        private string requestDateTime;
        private string requestId;

        public List<EntityModel> Subject
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
