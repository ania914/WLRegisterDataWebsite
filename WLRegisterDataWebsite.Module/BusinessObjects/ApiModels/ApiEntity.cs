using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WLRegisterDataWebsite.Module.Enums;


namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DefaultClassOptions]
    public class ApiEntity : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        private string name;
        private string nip;
        private StatusVat statusVat;
        private string regon;
        private string pesel;
        private string krs;
        private string residenceAddress;
        private string workingAddress;
        private DateTime? registrationLegalDate;
        private DateTime? registrationDenialDate;
        private string registrationDenialBasis;
        private DateTime? restorationDate;
        private string restorationBasis;
        private DateTime? removalDate;
        private string removalBasis;
        private bool hasVirtualAccounts;
        public ApiEntity(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        public string Nip
        {
            get => nip;
            set => SetPropertyValue(nameof(Nip), ref nip, value);
        }

        public StatusVat StatusVat
        {
            get => statusVat;
            set => SetPropertyValue(nameof(StatusVat), ref statusVat, value);
        }

        public string Regon
        {
            get => regon;
            set => SetPropertyValue(nameof(Regon), ref regon, value);
        }

        public string Pesel
        {
            get => pesel;
            set => SetPropertyValue(nameof(Pesel), ref pesel, value);
        }

        public string Krs
        {
            get => krs;
            set => SetPropertyValue(nameof(Krs), ref krs, value);
        }

        public string ResidenceAddress
        {
            get => residenceAddress;
            set => SetPropertyValue(nameof(ResidenceAddress), ref residenceAddress, value);
        }

        public string WorkingAddress
        {
            get => workingAddress;
            set => SetPropertyValue(nameof(WorkingAddress), ref workingAddress, value);
        }

        [Association("Entity-Representatives")]
        public XPCollection<EntityPerson> Representatives
        {
            get => GetCollection<EntityPerson>(nameof(Representatives));
        }

        [Association("Entity-AuthorizedClerks")]
        public XPCollection<EntityPerson> AuthorizedClerks
        {
            get => GetCollection<EntityPerson>(nameof(AuthorizedClerks));
        }

        [Association("Entity-Partners")]
        public XPCollection<EntityPerson> Partners
        {
            get => GetCollection<EntityPerson>(nameof(Partners));
        }

        public DateTime? RegistrationLegalDate
        {
            get => registrationLegalDate;
            set => SetPropertyValue(nameof(RegistrationLegalDate), ref registrationLegalDate, value);
        }

        public DateTime? RegistrationDenialDate
        {
            get => registrationDenialDate;
            set => SetPropertyValue(nameof(RegistrationDenialDate), ref registrationDenialDate, value);
        }

        public string RegistrationDenialBasis
        {
            get => registrationDenialBasis;
            set => SetPropertyValue(nameof(RegistrationDenialBasis), ref registrationDenialBasis, value);
        }

        public DateTime? RestorationDate
        {
            get => restorationDate;
            set => SetPropertyValue(nameof(RestorationDate), ref restorationDate, value);
        }

        public string RestorationBasis
        {
            get => restorationBasis;
            set => SetPropertyValue(nameof(RestorationBasis), ref restorationBasis, value);
        }

        public DateTime? RemovalDate
        {
            get => removalDate;
            set => SetPropertyValue(nameof(RemovalDate), ref removalDate, value);
        }

        public string RemovalBasis
        {
            get => removalBasis;
            set => SetPropertyValue(nameof(RemovalBasis), ref removalBasis, value);
        }

        [Association("Entity-AccountNumbers")]
        public XPCollection<AccountNumber> AccountNumbers
        {
            get => GetCollection<AccountNumber>(nameof(AccountNumbers));
        }

        public bool HasVirtualAccounts
        {
            get => hasVirtualAccounts;
            set => SetPropertyValue(nameof(HasVirtualAccounts), ref hasVirtualAccounts, value);
        }
    }
}