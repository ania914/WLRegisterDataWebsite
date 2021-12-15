using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    [DomainComponent, DefaultListViewOptions]
    public class EntityResponse : NonPersistentBaseObject, IGetResult
    {
        private EntityItem result;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntityItem Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }

        public IEnumerable<EntityModel> GetResult()
        {
            return new List<EntityModel>() { Result?.Subject };
        }
    }
}
