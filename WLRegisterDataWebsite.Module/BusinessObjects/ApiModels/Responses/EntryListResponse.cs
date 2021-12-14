using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
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

        public EntryList Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
