using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace WLRegisterDataWebsite.Module.BusinessObjects.Models
{
    [DomainComponent]
    public class AccountNumberModel : NonPersistentBaseObject
    {
        private string number;

        public string Number
        {
            get => number;
            set => SetPropertyValue(ref number, value);
        }
    }
}
