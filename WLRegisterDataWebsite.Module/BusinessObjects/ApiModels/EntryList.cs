using DevExpress.ExpressApp;
using System.Collections.Generic;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class EntryList : NonPersistentBaseObject
    {
        private List<EntryList> subject = new List<EntryList>();
        private string requestDateTime;
        private string requestId;

        public List<EntryList> Entries
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
