using DevExpress.ExpressApp;
using System.Collections.Generic;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class Entry : NonPersistentBaseObject
    {
        private string identifier;
        private List<Entity> subjects = new List<Entity>();

        public string Identifier
        {
            get => identifier;
            set => SetPropertyValue(ref identifier, value);
        }

        public List<Entity> Subjects
        {
            get => subjects;
            set => SetPropertyValue(ref subjects, value);
        }
    }
}
