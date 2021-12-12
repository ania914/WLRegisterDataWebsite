using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models.Parameters;

namespace WLRegisterDataWebsite.Module.BusinessObjects
{
    [DomainComponent, DefaultClassOptions, XafDisplayName("Search")]
    public class SearchSubject : NonPersistentBaseObject
    {
        private DateTime date;
        private List<Nip> nip = new List<Nip>();
        private List<Regon> regon = new List<Regon>();
        private List<BankAccount> bankAccounts = new List<BankAccount>();

        public SearchSubject()
        {
           // Fill();
        }

        public DateTime Date
        {
            get => date;
            set => SetPropertyValue(ref date, value);
        }

        [XafDisplayName("NIP")]
        public List<Nip> Nip
        {
            get => nip;
            set => SetPropertyValue(ref nip, value);
        }

        [XafDisplayName("REGON")]
        public List<Regon> Regon
        {
            get => regon;
            set => SetPropertyValue(ref regon, value);
        }

        [XafDisplayName("Bank account")]
        public List<BankAccount> BankAccount
        {
            get => bankAccounts;
            set => SetPropertyValue(ref bankAccounts, value);
        }

        private void Fill()
        {
            for (int i = 0; i < 30; i++)
            {
                Nip.Add(new Nip { Number = "gujfjgk" });
            }
        }
    }
}
