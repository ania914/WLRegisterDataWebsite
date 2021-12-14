using DevExpress.ExpressApp;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class EntryError: NonPersistentBaseObject
    {
        private Exception error;
        private string identifier;

        public string Identifier
        {
            get => identifier;
            set => SetPropertyValue(ref identifier, value);
        }

        public Exception Error
        {
            get => error;
            set => SetPropertyValue(ref error, value);
        }
    }
}
