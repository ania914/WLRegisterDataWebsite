using System.Collections.Generic;
using System.Linq;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;

namespace WLRegisterDataWebsite.Module.Extensions
{
    public static class EntityMapper
    {
        public static EntityModel Map(ApiEntity entity)
        {
            if (entity == null)
                return null;

            var accounts = entity.AccountNumbers?.Select(x => x.Number)?.ToList() ?? new List<string>();
            var model = new EntityModel
            {
                Name = entity.Name,
                Nip = entity.Nip,
                StatusVat = entity.StatusVat,
                Regon = entity.Regon,
                Pesel = entity.Pesel,
                Krs = entity.Krs,
                ResidenceAddress = entity.ResidenceAddress,
                WorkingAddress = entity.WorkingAddress,
                AuthorizedClerks = MapCollection(entity.AuthorizedClerks),
                Partners = MapCollection(entity.Partners),
                Representatives = MapCollection(entity.Representatives),
                RegistrationLegalDate = entity.RegistrationLegalDate,
                RegistrationDenialDate = entity.RegistrationDenialDate,
                RestorationDate = entity.RestorationDate,
                RestorationBasis = entity.RestorationBasis,
                RemovalDate = entity.RemovalDate,
                RemovalBasis = entity.RemovalBasis,
                RegistrationDenialBasis= entity.RegistrationDenialBasis,
                AccountNumbers = accounts,
                HasVirtualAccounts = entity.HasVirtualAccounts
            };

            return model;
        }

        private static List<EntityPersonModel> MapCollection(IEnumerable<EntityPerson> collection)
        {
            var result = new List<EntityPersonModel>();

            if(collection != null && collection.Any())
            {
                foreach (var item in collection)
                {
                    result.Add(Map(item));
                }
            }

            return result;
        }

        private static EntityPersonModel Map(EntityPerson entity)
        {
            var model = new EntityPersonModel
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Nip = entity.Nip,
                Pesel = entity.Pesel,
                CompanyName = entity.CompanyName
            };

            return model;
        }
    }
}
