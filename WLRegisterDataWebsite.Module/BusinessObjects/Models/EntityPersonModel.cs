using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;

namespace WLRegisterDataWebsite.Module.BusinessObjects.Models
{
    [DomainComponent]
    public class EntityPersonModel : NonPersistentBaseObject
    {
        private string companyName;
        private string firstName;
        private string lastName;
        private string pesel;
        private string nip;

        public string CompanyName
        {
            get => companyName;
            set => SetPropertyValue(ref companyName, value);
        }
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(ref firstName, value);
        }
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(ref lastName, value);
        }
        public string Pesel
        {
            get => pesel;
            set => SetPropertyValue(ref pesel, value);
        }
        public string Nip
        {
            get => nip;
            set => SetPropertyValue(ref nip, value);
        }
    }
}
