using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    public class Entry : NonPersistentBaseObject, IGetResult
    {
        private string identifier;
        private List<EntityModel> subjects = new List<EntityModel>();
        private ExceptionModel exception;

        public string Identifier
        {
            get => identifier;
            set => SetPropertyValue(ref identifier, value);
        }

        public List<EntityModel> Subjects
        {
            get => subjects;
            set => SetPropertyValue(ref subjects, value);
        }

        public ExceptionModel Exception
        {
            get => exception;
            set => SetPropertyValue(ref exception, value);
        }

        public void AddCachedData(IEnumerable<EntityModel> entityModels)
        {
            Subjects.AddRange(entityModels);
        }

        public IEnumerable<EntityModel> GetResult()
        {
            return Subjects;
        }
    }
}
