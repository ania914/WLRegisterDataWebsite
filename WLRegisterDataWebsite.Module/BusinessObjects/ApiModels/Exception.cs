using DevExpress.ExpressApp;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class Exception : NonPersistentBaseObject
    {
        private string code;
        private string message;

        public string Message
        {
            get => message;
            set => SetPropertyValue(ref message, value);
        }

        public string Code
        {
            get => code;
            set => SetPropertyValue(ref code, value);
        }
    }
}
