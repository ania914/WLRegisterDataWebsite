using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;

namespace WLRegisterDataWebsite.Module.BusinessObjects
{
    [DomainComponent, DefaultClassOptions, XafDisplayName("Check")]
    public class CheckSubject : NonPersistentBaseObject
    {
        private DateTime date;
        private List<Nip> nip = new List<Nip>();
        private List<Regon> regon = new List<Regon>();

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
    }
}
