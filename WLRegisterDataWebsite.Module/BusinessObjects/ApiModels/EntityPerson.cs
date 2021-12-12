using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class EntityPerson : BaseObject
    {
        private string companyName;
        private string firstName;
        private string lastName;
        private string pesel;
        private string nip;

        public EntityPerson(Session session) : base(session)
        {
        }

        public string CompanyName
        {
            get => companyName;
            set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
        }

        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        public string LastName
        {
            get => lastName; 
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        [XafDisplayName("PESEL")]
        public string Pesel
        {
            get => pesel;
            set => SetPropertyValue(nameof(Pesel), ref pesel, value);
        }

        [XafDisplayName("NIP")]
        public string Nip
        {
            get => nip;
            set => SetPropertyValue(nameof(Nip), ref nip, value);
        }

        [Association("Entity-Representatives")]
        public XPCollection<Entity> RepresentativesEntities
        {
            get => GetCollection<Entity>(nameof(RepresentativesEntities));
        }

        [Association("Entity-AuthorizedClerks")]
        public XPCollection<Entity> AuthorizedClerksEntities
        {
            get => GetCollection<Entity>(nameof(AuthorizedClerksEntities));
        }

        [Association("Entity-Partners")]
        public XPCollection<Entity> PartnersEntities
        {
            get => GetCollection<Entity>(nameof(PartnersEntities));
        }
    }
}
