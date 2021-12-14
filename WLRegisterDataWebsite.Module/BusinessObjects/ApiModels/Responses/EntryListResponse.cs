using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent]
    public class EntryListResponse : NonPersistentBaseObject
    {
        private EntryList result;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntryList Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
