using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent]
    public class EntryListResponse : NonPersistentBaseObject, IGetResult, ICacheResult
    {
        private EntryList result;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntryList Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }

        public void AddCachedData(IEnumerable<EntityModel> entityModels)
        {
            if (Result == null)
                Result = new EntryList();

            Result.AddCachedData(entityModels);
        }

        public IEnumerable<EntityModel> GetResult()
        {
            return Result?.GetResult();
        }
    }
}
