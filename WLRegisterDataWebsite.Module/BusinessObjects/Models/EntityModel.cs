using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WLRegisterDataWebsite.Module.Enums;

namespace WLRegisterDataWebsite.Module.BusinessObjects.Models
{
    [DomainComponent]
    [DefaultClassOptions]
    public class EntityModel : NonPersistentBaseObject
    {
        private string name;
        private string nip;
        private StatusVat statusVat;
        private string regon;
        private string pesel;
        private string krs;
        private string residenceAddress;
        private string workingAddress;
        private List<EntityPersonModel> representatives = new List<EntityPersonModel>();
        private List<EntityPersonModel> authorizedClerks = new List<EntityPersonModel>();
        private List<EntityPersonModel> partners = new List<EntityPersonModel>();
        private DateTime? registrationLegalDate;
        private DateTime? registrationDenialDate;
        private string registrationDenialBasis;
        private DateTime? restorationDate;
        private string restorationBasis;
        private DateTime? removalDate;
        private string removalBasis;
        private List<AccountNumberModel> bankAccounts = new List<AccountNumberModel>();
        private bool hasVirtualAccounts;
        private List<string> accountNumbers;

        public string Name
        {
            get => name;
            set => SetPropertyValue(ref name, value);
        }
        public string Nip
        {
            get => nip;
            set => SetPropertyValue(ref nip, value);
        }
        public StatusVat StatusVat
        {
            get => statusVat; set => SetPropertyValue(ref statusVat, value);
        }
        public string Regon
        {
            get => regon;
            set => SetPropertyValue(ref regon, value);
        }
        public string Pesel
        {
            get => pesel;
            set => SetPropertyValue(ref pesel, value);
        }
        public string Krs
        {
            get => krs;
            set => SetPropertyValue(ref krs, value);
        }
        public string ResidenceAddress
        {
            get => residenceAddress;
            set => SetPropertyValue(ref residenceAddress, value);
        }
        public string WorkingAddress
        {
            get => workingAddress;
            set => SetPropertyValue(ref workingAddress, value);
        }
        public List<EntityPersonModel> Representatives
        {
            get => representatives;
            set => SetPropertyValue(ref representatives, value);
        }
        public List<EntityPersonModel> AuthorizedClerks
        {
            get => authorizedClerks;
            set => SetPropertyValue(ref authorizedClerks, value);
        }
        public List<EntityPersonModel> Partners
        {
            get => partners;
            set => SetPropertyValue(ref partners, value);
        }
        public DateTime? RegistrationLegalDate
        {
            get => registrationLegalDate;
            set => SetPropertyValue(ref registrationLegalDate, value);
        }
        public DateTime? RegistrationDenialDate
        {
            get => registrationDenialDate;
            set => SetPropertyValue(ref registrationDenialDate, value);
        }
        public string RegistrationDenialBasis
        {
            get => registrationDenialBasis;
            set => SetPropertyValue(ref registrationDenialBasis, value);
        }
        public DateTime? RestorationDate
        {
            get => restorationDate;
            set => SetPropertyValue(ref restorationDate, value);
        }
        public string RestorationBasis
        {
            get => restorationBasis;
            set => SetPropertyValue(ref restorationBasis, value);
        }
        public DateTime? RemovalDate
        {
            get => removalDate;
            set => SetPropertyValue(ref removalDate, value);
        }
        public string RemovalBasis
        {
            get => removalBasis;
            set => SetPropertyValue(ref removalBasis, value);
        }

        public List<string> AccountNumbers
        {
            get => accountNumbers; 
            set
            {
                accountNumbers = value;
                if (accountNumbers == null)
                    return;

                BankAccounts.Clear();
                foreach(var account in accountNumbers)
                {
                    BankAccounts.Add(new AccountNumberModel { Number = account });
                }
            }
        }

        public List<AccountNumberModel> BankAccounts
        {
            get => bankAccounts;
            set => SetPropertyValue(ref bankAccounts, value);
        }

        public bool HasVirtualAccounts
        {
            get => hasVirtualAccounts;
            set => SetPropertyValue(ref hasVirtualAccounts, value);
        }

        public override bool Equals(object obj)
        {
            if (obj is not EntityModel model)
                return false;

            return Nip == model.Nip && Pesel == model.Pesel && Regon == model.Regon;
        }

        public override int GetHashCode()
        {
            return (Nip ?? "").GetHashCode() + (Pesel ?? "").GetHashCode() + (Regon ?? "").GetHashCode();
        }
    }
}
