using DevExpress.ExpressApp;
using System.Collections.Generic;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
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
