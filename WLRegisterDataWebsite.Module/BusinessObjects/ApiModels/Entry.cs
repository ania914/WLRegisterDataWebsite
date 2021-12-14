using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    public class Entry : NonPersistentBaseObject
    {
        private string identifier;
        private List<EntityModel> subjects = new List<EntityModel>();

        public string Identifier
        {
            get => identifier;
            set => SetPropertyValue(ref identifier, value);
        }

        public List<EntityModel> Subjects
        {
            get => subjects;
            set => SetPropertyValue(ref subjects, value);
        }
    }
}
