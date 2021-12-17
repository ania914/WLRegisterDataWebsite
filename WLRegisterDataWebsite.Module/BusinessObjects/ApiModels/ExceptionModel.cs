using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    public class ExceptionModel : NonPersistentBaseObject
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
