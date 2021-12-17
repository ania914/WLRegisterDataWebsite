using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string connectionString;

        public DatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<ApiEntity> GetEntitiesAsync()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (var unitOfWork = new UnitOfWork(inMemoryDAL))
            {
                return unitOfWork.Query<ApiEntity>().AsEnumerable();
            }
        }

        public async Task<ApiEntity> CreateEntity(EntityModel model)
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (var unitOfWork = new UnitOfWork(inMemoryDAL))
            {
                var pesel = ParseCriteriaParam(model.Pesel);
                var nip = ParseCriteriaParam(model.Nip);
                var regon = ParseCriteriaParam(model.Regon);

                var criteria = CriteriaOperator.Parse($"[Pesel] {pesel} && [Nip] {nip} && [Regon] {regon}");
                var dbEntity = await unitOfWork.FindObjectAsync<ApiEntity>(criteria);
                if (dbEntity != null)
                    return dbEntity;

                var entity = await Map(unitOfWork, model);
                await unitOfWork.CommitChangesAsync();
                return entity;
            }
        }

        private string ParseCriteriaParam(string value)
        {
            return string.IsNullOrEmpty(value) ? "IS NULL" : $"== '{value}'";
        }

        private async Task<ApiEntity> Map(UnitOfWork uow, EntityModel model)
        {
            var entity = new ApiEntity(uow);
            entity.Name = model.Name;
            entity.Nip = model.Nip;
            entity.StatusVat = model.StatusVat;
            entity.Regon = model.Regon;
            entity.Pesel = model.Pesel;
            entity.Krs = model.Krs;
            entity.ResidenceAddress = model.ResidenceAddress;
            entity.WorkingAddress = model.WorkingAddress;
            if (model.Representatives != null && model.Representatives.Any())
            {
                foreach (var representative in model.Representatives)
                {
                    var dbPerson = await Map(uow, representative);
                    entity.Representatives.Add(dbPerson);
                }
            }

            if (model.AuthorizedClerks != null && model.AuthorizedClerks.Any())
            {
                foreach (var authorizedClerk in model.AuthorizedClerks)
                {
                    var dbPerson = await Map(uow, authorizedClerk);
                    entity.AuthorizedClerks.Add(dbPerson);
                }
            }

            if (model.Partners != null && model.Partners.Any())
            {
                foreach (var partner in model.Partners)
                {
                    var dbPerson = await Map(uow, partner);
                    entity.Partners.Add(dbPerson);
                }
            }

            entity.RegistrationLegalDate = model.RegistrationLegalDate;
            entity.RegistrationDenialDate = model.RegistrationDenialDate;
            entity.RegistrationDenialBasis = model.RegistrationDenialBasis;
            entity.RestorationDate = model.RestorationDate;
            entity.RestorationBasis = model.RestorationBasis;
            entity.RemovalDate = model.RemovalDate;
            entity.RemovalBasis = model.RemovalBasis;

            if (model.BankAccounts != null && model.BankAccounts.Any())
            {
                foreach (var account in model.BankAccounts)
                {
                    var dbAccount = await Map(uow, account);
                    entity.AccountNumbers.Add(dbAccount);
                }
            }

            entity.HasVirtualAccounts = model.HasVirtualAccounts;
            return entity;
        }

        private async Task<EntityPerson> Map(UnitOfWork uow, EntityPersonModel model)
        {
            var criteria = CriteriaOperator.Parse($"[Pesel] {ParseCriteriaParam(model.Pesel)} && [Nip] {ParseCriteriaParam(model.Nip)}");
            var savedPerson = await uow.FindObjectAsync<EntityPerson>(criteria);
            if (savedPerson != null)
                return savedPerson;

            var newPerson = new EntityPerson(uow);
            newPerson.CompanyName = model.CompanyName;
            newPerson.FirstName = model.FirstName;
            newPerson.LastName = model.LastName;
            newPerson.Pesel = model.Pesel;
            newPerson.Nip = model.Nip;
            return newPerson;
        }

        private async Task<AccountNumber> Map(UnitOfWork uow, AccountNumberModel model)
        {
            var criteria = CriteriaOperator.Parse($"[Number] {ParseCriteriaParam(model.Number)}");
            var savedAccount = await uow.FindObjectAsync<AccountNumber>(criteria);
            if (savedAccount != null)
                return savedAccount;

            var newAccount = new AccountNumber(uow);
            newAccount.Number = model.Number;
            return newAccount;
        }
    }
}
