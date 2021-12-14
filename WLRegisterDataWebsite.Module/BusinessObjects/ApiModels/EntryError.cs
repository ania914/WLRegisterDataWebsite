using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    public class EntryError: NonPersistentBaseObject
    {
        private ExceptionModel error;
        private string identifier;

        public string Identifier
        {
            get => identifier;
            set => SetPropertyValue(ref identifier, value);
        }

        public ExceptionModel Error
        {
            get => error;
            set => SetPropertyValue(ref error, value);
        }
    }
}
