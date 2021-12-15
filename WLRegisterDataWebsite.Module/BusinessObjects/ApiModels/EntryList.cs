using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using System.Linq;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    public class EntryList : NonPersistentBaseObject, IGetResult
    {
        private List<Entry> subject = new List<Entry>();
        private string requestDateTime;
        private string requestId;

        public List<Entry> Entries
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

        public IEnumerable<EntityModel> GetResult()
        {
            return Entries?.SelectMany(x => x.GetResult());
        }
    }
}
