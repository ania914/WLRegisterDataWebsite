using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent]
    public class EntityListResponse: NonPersistentBaseObject, IGetResult
    {
        private EntityList result;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntityList Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }

        public IEnumerable<EntityModel> GetResult()
        {
            return Result?.GetResult();
        }
    }
}
