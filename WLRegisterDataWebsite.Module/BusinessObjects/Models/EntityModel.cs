using System;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Enums;

namespace WLRegisterDataWebsite.Module.BusinessObjects
{
    public class EntityModel
    {
        public string Name { get; set; }
        public string Nip { get; set; }
        public StatusVat StatusVat { get; set; }
        public string Regon { get; set; }
        public string Pesel { get; set; }
        public string Krs { get; set; }
        public string ResidenceAddress { get; set; }
        public string WorkingAddress { get; set; }
        public List<EntityPersonModel> Representatives { get; set; }
        public List<EntityPersonModel> AuthorizedClerks { get; set; }
        public List<EntityPersonModel> Partners { get; set; }
        public DateTime? RegistrationLegalDate { get; set; }
        public DateTime? RegistrationDenialDate { get; set; }
        public string RegistrationDenialBasis { get; set; }
        public DateTime? RestorationDate { get; set; }
        public string RestorationBasis { get; set; }
        public DateTime? RemovalDate { get; set; }
        public string RemovalBasis { get; set; }
        public List<AccountNumberModel> AccountNumbers { get; set; }
        public bool HasVirtualAccounts { get; set; }
    }
}
