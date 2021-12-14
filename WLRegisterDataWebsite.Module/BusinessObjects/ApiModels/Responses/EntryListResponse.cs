using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    public class EntryListResponse : NonPersistentBaseObject
    {
        private EntryList result;

    public EntityList Result
    {
        get => result;
        set => SetPropertyValue(ref result, value);
    }
}
}
